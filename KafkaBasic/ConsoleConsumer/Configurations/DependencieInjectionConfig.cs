using Core.Extensions;
using Core.Kafka.Comunications;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ConsoleConsumer.Configurations;

public static class DependencieInjectionConfig
{
    public static ServiceProvider ConfigureService()
    {
        var configuration = AppSettingsExtensions.GetConfigurationAppSettings();

        var appSettings = configuration.GetAppSettings<KafkaSettings>(nameof(KafkaSettings));

        var serviceProvider = new ServiceCollection()

                .AddLogging(options =>
                {
                    options.AddConsole();
                    options.AddDebug();
                })
                .Configure<KafkaSettings>(configuration.GetSection(nameof(KafkaSettings)))
                //.AddScoped<ICepService,CepService>()
            ;

        ServiceProvider provider = serviceProvider.BuildServiceProvider();
        return provider;
    }
}

 