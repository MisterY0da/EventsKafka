using Confluent.Kafka;

namespace EventsKafka.Services
{
    public class KafkaProducerService
    {
        private ProducerConfig _config;

        public KafkaProducerService()
        {
            _config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092"
            };
        }

        public async Task SendMessageAsync(string message)
        {
            using (var p = new ProducerBuilder<Null, string>(_config).Build())
            {
                try
                {
                    var dr = await p.ProduceAsync("mytopic", new Message<Null, string> { Value = message });
                }
                catch (ProduceException<Null, string> e)
                {
                }
            }
        }

    }
}
