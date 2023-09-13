using Core.Datas.Enumerators;
using Microsoft.EntityFrameworkCore;
using System;

namespace Core.Datas.Extensions;

public static class OptionsBuilderExtenstion
{
    public static DbContextOptions ConfigureConnection(this DbContextOptionsBuilder optionsBuilder,
        TypeDatabaseEnum typeSGDB,
        string connectionString,
        string migratioName = "__TableMigrationsHistory",
        Version version = null
    )
    {
        switch (typeSGDB)
        {
            case TypeDatabaseEnum.SQLServer:
                return optionsBuilder.UseSqlServer(connectionString, x => x.MigrationsHistoryTable(migratioName)).Options;

            case TypeDatabaseEnum.Postgres:
                return optionsBuilder.UseNpgsql(connectionString, x => x.MigrationsHistoryTable(migratioName)
                    .SetPostgresVersion(version ?? new Version(9, 5))).Options;

            default:
                break;
        }
        return optionsBuilder.Options;
    }
}