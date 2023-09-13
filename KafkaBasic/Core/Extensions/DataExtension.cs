using Core.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;

namespace Core.Extensions;

public static class DataExtension
{

    /// <summary>
    /// Método responsável por converter uma lista para um DataTable.
    /// </summary>
    /// <typeparam name="T">Informe o tipo da lista.</typeparam>
    /// <param name="data">Informe a lista.</param>
    /// <returns>Retorna um DataTable com os dados da lista.</returns>
    public static DataTable ConvertToDataTable<T>(this IList<T> data)
    {
        var properties = TypeDescriptor.GetProperties(typeof(T));

        var table = new DataTable();
        foreach (PropertyDescriptor prop in properties)
            table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

        foreach (T item in data)
        {
            var row = table.NewRow();
            foreach (PropertyDescriptor prop in properties)
                row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;

            table.Rows.Add(row);
        }
        return table;

    }


    /// <summary>
    /// Método responsável por transformar um DataTable em uma lista.
    /// </summary>
    /// <typeparam name="T">Informe o tipo da Lista de retorno (tem que ser uma classe)</typeparam>
    /// <param name="dataTable">Infomre o DataTable.</param>
    /// <returns>Retorna uma lista de acordo com os dados do DataTable.</returns>
    public static List<T> ToList<T>(this DataTable dataTable) where T : new()
    {
        var dataList = new List<T>();

        const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic;
        var objFieldNames = (from PropertyInfo aProp in typeof(T).GetProperties(flags)
            select new
            {
                aProp.Name,
                Type = Nullable.GetUnderlyingType(aProp.PropertyType) ?? aProp.PropertyType
            }).ToList();

        var dataTblFieldNames = (from DataColumn aHeader in dataTable.Columns
            select new
            {
                Name = aHeader.ColumnName,
                Type = aHeader.DataType
            }).ToList();
        var commonFields = objFieldNames.Intersect(dataTblFieldNames).ToList();

        foreach (var dataRow in dataTable.AsEnumerable().ToList())
        {
            var aTSource = new T();
            foreach (var aField in commonFields)
            {
                var propertyInfos = aTSource.GetType().GetProperty(aField.Name);
                var value = dataRow[aField.Name] == DBNull.Value ? null : dataRow[aField.Name];

                propertyInfos.SetValue(aTSource, value, null);
            }
            dataList.Add(aTSource);
        }
        return dataList;
    }

    /// <summary>
    /// Método responsável por converter uma lista em DataTable
    /// </summary>
    /// <typeparam name="T">[T] é o tipo que representa o componente para o qual obter propriedades.</typeparam>
    /// <param name="data">Informe a lista.</param>
    /// <returns>Retorna um Datatable com base na lista.</returns>
    public static DataTable ListToDataTable<T>(this IList<T> data)
    {
        var properties = TypeDescriptor.GetProperties(typeof(T));
        var table = new DataTable();
        foreach (PropertyDescriptor prop in properties)
            table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

        foreach (T item in data)
        {
            var row = table.NewRow();
            foreach (PropertyDescriptor prop in properties)
                row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;

            table.Rows.Add(row);
        }
        return table;
    }

    /// <summary>
    /// Converte uma lista em uma string no formato CSV, separado por virgulas
    /// </summary>
    /// <typeparam name="T">[T] é o tipo que representa o componente para o qual obter propriedades.</typeparam>
    /// <param name="data">Informe a Lista.</param>
    /// <returns>Retorna uma string em formato .csv</returns>
    public static string ListToCSV<T>(this IEnumerable<T> data)
    {
        var campo = new StringBuilder();
        var properties = TypeDescriptor.GetProperties(typeof(T));

        foreach (PropertyDescriptor prop in properties)
            campo.Append(prop.Name + ";");

        foreach (T item in data)
        {
            campo.AppendLine();
            foreach (PropertyDescriptor prop in properties)
                campo.Append(prop.GetValue(item)?.ToString().Trim() + ";");
        }

        return campo.ToString();
    }

    /// <summary>
    /// Converte uma lista em um arquivo CSV e retorna um Attachment
    /// </summary>
    /// <typeparam name="T">[T] é o tipo que representa o componente para o qual obter propriedades.</typeparam>
    /// <param name="data"></param>
    /// <param name="fileName">Sua lista</param>
    /// <returns>Retorna um Attachment</returns>
    public static Attachment ListToCSV<T>(this IEnumerable<T> data, string fileName, string fileType = ".csv")
    {
        fileName += fileType;

        var campo = new StringBuilder();
        var properties = TypeDescriptor.GetProperties(typeof(T));

        foreach (PropertyDescriptor prop in properties)
            campo.Append(prop.Name + ";");

        foreach (T item in data)
        {
            campo.AppendLine();
            foreach (PropertyDescriptor prop in properties)
                campo.Append(prop.GetValue(item)?.ToString().Trim() + ";");
        }

        byte[] bytes = Encoding.UTF8.GetBytes(campo.ToString());

        return new Attachment(new MemoryStream(bytes), fileName);

    }

    /// <summary>
    /// Converte um Stream com CSV para um Datatable.
    /// </summary>
    /// <param name="csvFile"></param>
    /// <param name="separator"></param>
    /// <returns></returns>
    public static DataTable CSVToDataTable(this Stream csvFile, char separator)
    {
        var dataTable = new DataTable();
        using (var streamReader = new StreamReader(csvFile, Encoding.GetEncoding("iso-8859-1")))
        {
            string[] headers = streamReader.ReadLine().Split(separator);
            foreach (string header in headers)
                dataTable.Columns.Add(header);

            while (!streamReader.EndOfStream)
            {
                var rows = streamReader.ReadLine().Split(separator);
                var dataRow = dataTable.NewRow();

                for (int i = 0; i < headers.Length; i++)
                    dataRow[i] = rows[i];

                dataTable.Rows.Add(dataRow);
            }
        }
        return dataTable;
    }

    /// <summary>
    /// Converte uma Datatable para um strin  CSV.
    /// </summary>
    /// <param name="dataTable">Infomre o Datatable.</param>
    /// <returns>Retorna a string no formato CSV.</returns>
    public static string DataTableToCSV(this DataTable dataTable)
    {
        var campo = new StringBuilder();
        var count = 1;
        var totalColumns = dataTable.Columns.Count;
        foreach (DataColumn column in dataTable.Columns)
        {
            campo.Append(column.ColumnName);

            if (count != totalColumns)
                campo.Append(";");

            count++;
        }
        campo.AppendLine();

        string value;
        foreach (DataRow dataRow in dataTable.Rows)
        {
            for (int x = 0; x < totalColumns; x++)
            {
                value = dataRow[x].ToString();

                if (value.Contains(";") || value.Contains("\""))
                    value = '"' + value.Replace("\"", "\"\"") + '"';

                campo.Append(value);

                if (x != totalColumns - 1)
                    campo.Append(";");

            }
            campo.AppendLine();
        }
        return campo.ToString();
    }

    public static List<TEntity> ToListClass<TEntity>(this DataTable dt)
    {
        var list = new List<TEntity>();
        PropertyInfo[] properties = typeof(TEntity).GetProperties();

        foreach (DataRow row in dt.Rows)
        {
            TEntity generic = Activator.CreateInstance<TEntity>();
            foreach (PropertyInfo property in properties)
            {
                if (!dt.Columns.Contains(property.Name))
                    continue;

                Type propertyType = Nullable.GetUnderlyingType(property.PropertyType) != null ? Nullable.GetUnderlyingType(property.PropertyType) : property.PropertyType;

                if (row[property.Name] != DBNull.Value)
                    property.SetValue(generic, Convert.ChangeType(row[property.Name], propertyType));
            }

            list.Add(generic);
        }

        return list;
    }

}