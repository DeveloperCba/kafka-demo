
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.Design;
using ConsoleConsumer.Configurations;
using Core.Kafka.Comunications;
using Microsoft.Extensions.Options;


//DI
var serviceProvider = DependencieInjectionConfig.ConfigureService() as ServiceProvider;
var kafkaSettings = serviceProvider.GetService<IOptions<KafkaSettings>>().Value;

Console.WriteLine(kafkaSettings.BootstrapServers);