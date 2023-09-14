//DI
using ConsoleConsumer.Configurations;
using ConsoleProducer.Data.Repository;
using Core.Kafka.Comunications;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

var serviceProvider = DependencieInjectionConfig.ConfigureService() as ServiceProvider;
var kafkaSettings = serviceProvider.GetService<IOptions<KafkaSettings>>().Value;
var processoRepository = serviceProvider.GetService<IProcessoRepository>();

var processo = await processoRepository.GetByProcessNumber("13362870");

Console.WriteLine(kafkaSettings.BootstrapServers);