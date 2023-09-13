
namespace Core.Extensions;

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class StringExtension
{

    /// <summary>
    /// Método responsável por remover as letras do texto.
    /// </summary>
    /// <param name="texto">Infomre o texto.</param>
    /// <returns>Retorna somente número.</returns>
    public static string RetornarSomenteNumero(this string texto)
    {
        return Regex.Replace(texto, "[^0-9,]", "");
    }


    /// <summary>
    /// Método responsável por remover caracter especial e acento do texto.
    /// </summary>
    /// <param name="texto">Infome o texto.</param>
    /// <returns>Retorno o texto sem caracter especial e acento.</returns>
    public static string RetornarSemCaracterEspecial(this string texto)
    {
        return texto
            .RemoverAcento()
            .RemoverCaracterEspecial();
    }


    /// <summary>
    /// Método responsável por remover caracter especial do texto.
    /// </summary>
    /// <param name="texto">Informe o texto</param>
    /// <returns>Retorna o texto sem caracter especial.</returns>
    public static string RemoverCaracterEspecial(this string texto)
    {
        string letra;
        var resultado = string.Empty;

        if (!string.IsNullOrEmpty(texto))
        {
            for (int i = 0; i < texto.ToString().Length; i++)
            {
                letra = texto[i].ToString();
                switch (letra)
                {
                    case "&": letra = string.Empty; break;
                    case "º": letra = string.Empty; break;
                    case ":": letra = string.Empty; break;
                    case "@": letra = string.Empty; break;
                    case "#": letra = string.Empty; break;
                    case "$": letra = string.Empty; break;
                    case "%": letra = string.Empty; break;
                    case "¨": letra = string.Empty; break;
                    case "*": letra = string.Empty; break;
                    case "(": letra = string.Empty; break;
                    case ")": letra = string.Empty; break;
                    case "ª": letra = string.Empty; break;
                    case "°": letra = string.Empty; break;
                    case ";": letra = string.Empty; break;
                    case "/": letra = string.Empty; break;
                    case "´": letra = string.Empty; break;
                    case "`": letra = string.Empty; break;
                    case "'": letra = string.Empty; break;
                    case "-": letra = string.Empty; break;
                    case " ": letra = string.Empty; break;
                }
                resultado += letra;
            }
        }

        return resultado;
    }


    /// <summary>
    /// Método responsável por remover acento do texto
    /// </summary>
    /// <param name="texto">Informe o texto.</param>
    /// <returns>Retorna o texto sem acento.</returns>
    public static string RemoverAcento(this string texto)
    {
        string letra  ;
        string resultado = string.Empty  ;

        for (int i = 0; i < texto.ToString().Length; i++)
        {
            letra = texto[i].ToString();
            switch (letra)
            {
                case "á": letra = "a"; break;
                case "é": letra = "e"; break;
                case "í": letra = "i"; break;
                case "ó": letra = "o"; break;
                case "ú": letra = "u"; break;
                case "à": letra = "a"; break;
                case "è": letra = "e"; break;
                case "ì": letra = "i"; break;
                case "ò": letra = "o"; break;
                case "ù": letra = "u"; break;
                case "â": letra = "a"; break;
                case "ê": letra = "e"; break;
                case "î": letra = "i"; break;
                case "ô": letra = "o"; break;
                case "û": letra = "u"; break;
                case "ä": letra = "a"; break;
                case "ë": letra = "e"; break;
                case "ï": letra = "i"; break;
                case "ö": letra = "o"; break;
                case "ü": letra = "u"; break;
                case "ã": letra = "a"; break;
                case "õ": letra = "o"; break;
                case "ñ": letra = "n"; break;
                case "ç": letra = "c"; break;
                case "Á": letra = "A"; break;
                case "É": letra = "E"; break;
                case "Í": letra = "I"; break;
                case "Ó": letra = "O"; break;
                case "Ú": letra = "U"; break;
                case "À": letra = "A"; break;
                case "È": letra = "E"; break;
                case "Ì": letra = "I"; break;
                case "Ò": letra = "O"; break;
                case "Ù": letra = "U"; break;
                case "Â": letra = "A"; break;
                case "Ê": letra = "E"; break;
                case "Î": letra = "I"; break;
                case "Ô": letra = "O"; break;
                case "Û": letra = "U"; break;
                case "Ä": letra = "A"; break;
                case "Ë": letra = "E"; break;
                case "Ï": letra = "I"; break;
                case "Ö": letra = "O"; break;
                case "Ü": letra = "U"; break;
                case "Ã": letra = "A"; break;
                case "Õ": letra = "O"; break;
                case "Ñ": letra = "N"; break;
                case "Ç": letra = "C"; break;
                case "£": letra = ""; break;
                case "©": letra = ""; break;
                case "¢": letra = ""; break;
            }
            resultado += letra;
        }
        return resultado;
    }


    /// <summary>
    /// Corrige o número sequencial.
    /// </summary>
    /// <param name="valor">Infomre o valor</param>
    /// <returns></returns>
    public static string CorrigirSequencial(this string valor)
    {
        string resultado = null;
        try
        {
            var anterior = '0';
            var novo = '0';
            var caracteres = new char[valor.Length];
            caracteres = valor.ToCharArray();

            foreach (char caracter in caracteres)
            {
                if (caracter == anterior)
                    novo = Convert.ToChar(Convert.ToString(Convert.ToInt16(caracter) + 2 > 9 ? 1 : Convert.ToInt16(caracter) + 2));
                else
                    novo = caracter;

                anterior = novo;
                resultado += novo;
            }
        }
        catch { resultado = null; }

        return resultado;
    }

    public static string RemoverCharacters(this string input)
    {
        string resultString ;
        try
        {
            var regexObj = new Regex(@"[^\d]");
            resultString = regexObj.Replace(input, "");
        }
        catch { resultString = null; }

        return resultString;
    }

    public static long RemoverCharactersToInt(this string input)
    {
        string resultString ;
        try
        {
            var regexObj = new Regex(@"[^\d]");
            resultString = regexObj.Replace(input, "");
        }
        catch { resultString = null; }

        return string.IsNullOrEmpty(resultString) ? 0 : Convert.ToInt64(resultString);
    }

    public static string FormatarString(this string mascara, string valor)
    {
        var novoValor = string.Empty;
        var posicao = 0;
        for (int i = 0; mascara.Length > i; i++)
        {
            if (mascara[i] == '#')
            {
                if (valor.Length > posicao)
                {
                    novoValor = novoValor + valor[posicao];
                    posicao++;
                }
                else
                    break;
            }
            else
            {
                if (valor.Length > posicao)
                    novoValor = novoValor + mascara[i];
                else
                    break;
            }
        }
        return novoValor;
    }

    public static string ToReplaceWebProtocol(this string input)
    {
        if (string.IsNullOrEmpty(input)) return input;

        var webProtocol = new List<string>() { "https://", "http://" };

        webProtocol.ForEach(protocol =>
        {
            if (input.Contains(protocol))
            {
                input = input.Replace(protocol, "");
            }
        });

        return input;
    }

    public static bool ToRemoveLogRequest(this string input)
    {
        var notRemove = true;

        if (string.IsNullOrEmpty(input)) return notRemove;

        var extenssions = new List<string>() { ".json", ".css", ".js", ".gif", ".woff", ".ico", ".svg", ".png", ".map", "hangfire" };

        foreach (var extenssion in extenssions)
        {
            if (input.ToLower().Contains(extenssion))
            {
                notRemove = false;
                break;
            }
        }

        return notRemove;
    }

    public static string OnlyNumber(this string valor)
    {
        var onlyNumber = "";
        foreach (var s in valor)
        {
            if (char.IsDigit(s))
            {
                onlyNumber += s;
            }
        }
        return onlyNumber.Trim();
    }
    public static string ToSnakeCase(this string name)
        => Regex.Replace(
            name,
            @"([a-z0-9])([A-Z])",
            "$1_$2").ToLower();

}