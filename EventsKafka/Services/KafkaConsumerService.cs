using Confluent.Kafka;

namespace EventsKafka.Services
{
    public class KafkaConsumerService
    {
        private ConsumerConfig _conf;
        private IConsumer<Ignore, string> _consumer;

        public KafkaConsumerService() 
        {
            _conf = new ConsumerConfig
            {
                GroupId = "mygroup",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest,
                EnableAutoCommit = false
            };

            _consumer = new ConsumerBuilder<Ignore, string>(_conf).Build();
            _consumer.Subscribe("mytopic");
        }

        public List<string> GetMessages()
        {
            List<string> messages = new List<string>();           

            var consumerResult = _consumer.Consume();

            try
            {
                while(consumerResult != null)
                {
                    messages.Add(consumerResult.Message.Value);
                    consumerResult = _consumer.Consume(5000);                   
                }
            }
            catch (ConsumeException e)
            {
            }

            return messages;
        }
    }
}
