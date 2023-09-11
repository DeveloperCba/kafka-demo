
using Confluent.Kafka;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;


var schemaConfig = new SchemaRegistryConfig
{
    Url = "localhost:8081"
};

var schemaRegistry = new CachedSchemaRegistryClient(schemaConfig);

var config = new ProducerConfig { BootstrapServers = "localhost:9092" };

using var producer = new ProducerBuilder<string, Kafka.io.Curso>(config)
    .SetValueSerializer(new AvroSerializer<Kafka.io.Curso>(schemaRegistry))
    .Build()
;

var message = new Message<string, Kafka.io.Curso>
{
    Key = Guid.NewGuid().ToString(),
    Value = new Kafka.io.Curso
    {
        Id = Guid.NewGuid().ToString(),
        Descricao = "Curso Apache Kafka",
    }
};

var result = await producer.ProduceAsync("cursos", message);

System.Console.WriteLine($"Offset: {result.Offset}");