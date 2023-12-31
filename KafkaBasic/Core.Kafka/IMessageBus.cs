using Core.Kafka.Messages.Integration;

namespace Core.Kafka;

public interface IMessageBus : IDisposable
{
    Task ProducerAsync<T>(string topic, T message) where T : IntegrationEvent;
    Task ConsumerAsync<T>(string topic, Func<T, Task> onMessage, CancellationToken cancellation) where T : IntegrationEvent;
}