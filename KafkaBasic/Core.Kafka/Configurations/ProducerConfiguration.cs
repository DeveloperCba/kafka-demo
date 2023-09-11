using Confluent.Kafka;

namespace Core.Kafka.Configurations;

public static class ProducerConfiguration
{
    public static ProducerConfig ProducerConfig()
    {
        var producerConfig = new ProducerConfig
        {
            BootstrapServers = "localhost:9092",    // Servidores de bootstrap Kafka
            ClientId = "my-producer",               // Identificador exclusivo do produtor
        };

        return producerConfig;
    }
}
 
public class ConsumerConfiguration
{

}