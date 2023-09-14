using ConsoleProducer.Data.Context;
using ConsoleProducer.Data.Repository;
using Core.Extensions;
using Core.Kafka.Comunications;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ConsoleConsumer.Configurations;

public static class DependencieInjectionConfig
{
    public static ServiceProvider ConfigureService()
    {
        var configuration = AppSettingsExtensions.GetConfigurationAppSettings();
        var conn = configuration.GetProjectConnectionString("DefaultConnection");
        var appSettings = configuration.GetAppSettings<KafkaSettings>(nameof(KafkaSettings));

        var serviceProvider = new ServiceCollection()

                .AddLogging(options =>
                {
                    options.AddConsole();
                    options.AddDebug();
                })
                .Configure<KafkaSettings>(configuration.GetSection(nameof(KafkaSettings)))
                .AddScoped<IProcessoRepository, ProcessoRepository>()
                .AddDbContext<ApplicationDbContext>(options=>
                {
                    options.UseSqlServer(conn,x=> x.MigrationsHistoryTable("table_migration"));
                })
            ;

        ServiceProvider provider = serviceProvider.BuildServiceProvider();
        return provider;
    }
}

 