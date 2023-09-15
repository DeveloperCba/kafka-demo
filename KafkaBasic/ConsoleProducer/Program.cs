//DI
using Confluent.Kafka;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;
using ConsoleConsumer.Configurations;
using ConsoleProducer.Data.Repository;
using ConsoleProducer.Models;
using Core.Kafka.Comunications;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Text.Json;

var serviceProvider = DependencieInjectionConfig.ConfigureService() as ServiceProvider;
var kafkaSettings = serviceProvider.GetService<IOptions<KafkaSettings>>().Value;
var processoRepository = serviceProvider.GetService<IProcessoRepository>();

var processos = await processoRepository.GetById(13362870);


var processoKafka = processos.Select(x=> new
{
    SistemaId = x.IdSistema,
    ProcessoId = x.SkProcesso,
    NumeroProcesso = x.NumeroUnico
}).FirstOrDefault();


var schemaConfig = new SchemaRegistryConfig
{
    Url = "localhost:8081"
};

var schemaRegistry = new CachedSchemaRegistryClient(schemaConfig);

var config = new ProducerConfig { BootstrapServers = "localhost:9092" };

var messages = new OmniProcessDto
{

    IdSistema = processoKafka.SistemaId,
    SkProcesso = processoKafka.ProcessoId,
    NumeroUnico = processoKafka.NumeroProcesso
};

var json = JsonSerializer.Serialize(messages);
using var producer = new ProducerBuilder<string, string>(config)
    //.SetValueSerializer(new AvroSerializer<OmniProcessDto>(schemaRegistry))
    //.SetValueSerializer(json)
    .Build()
;




var message = new Message<string, string>
{
    Key = Guid.NewGuid().ToString(),
    Value = json
};



var result = await producer.ProduceAsync("cursos", message);

System.Console.WriteLine($"Offset: {result.Offset}");

Console.WriteLine(kafkaSettings.BootstrapServers);