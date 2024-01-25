using EventsKafka.Services;
using Microsoft.AspNetCore.Mvc;
using Application.Commands;
using Application.Queries;
using System.Text.Json;
using Domain.Dtos;
using System.Linq;
using Domain.AggregationModels.CharacterAggregate;

namespace EventsKafka.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private KafkaConsumerService _consumerService;

        private KafkaProducerService _producerService;

        public CharacterController(KafkaProducerService kafkaProducerService, KafkaConsumerService kafkaConsumerService) 
        {
            _consumerService = kafkaConsumerService;
            _producerService = kafkaProducerService;
        }

        [HttpPost("createcharacter")]
        public async Task CreateCharacter(string name, string characterClass, int level)
        {
            var cmd = new CreateCharacterCommand()
            {
                Name = name,
                CharacterClass = characterClass,
                Level = level
            };

            var domainEvent = cmd.CreateDomainEvent();

            var serialized = JsonSerializer.Serialize(domainEvent);

            await _producerService.SendMessageAsync(serialized);
        }

        [HttpPost("levelup")]
        public async Task LevelUp()
        {
            var cmd = new LevelUpCommand() { Level = 1 };

            var domainEvent = cmd.CreateDomainEvent();

            var serialized = JsonSerializer.Serialize(domainEvent);

            await _producerService.SendMessageAsync(serialized);
        }

        [HttpPost("levelupcancel")]
        public async Task LevelUpCancel()
        {
            var cmd = new LevelUpCanceledCommand() { Level = -1 };

            var domainEvent = cmd.CreateDomainEvent();

            var serialized = JsonSerializer.Serialize(domainEvent);

            await _producerService.SendMessageAsync(serialized);
        }

        [HttpGet("getcharacter")]
        public async Task<OkObjectResult> GetCharacter()
        {
            List<CharacterDto> eventDtos = new List<CharacterDto>();

            var query = new GetCharacterQuery();

            var events = _consumerService.GetMessages();

            foreach (var e in events)
            {
                eventDtos.Add(JsonSerializer.Deserialize<CharacterDto>(e));
            }

            query.Name = eventDtos.First(e => !string.IsNullOrEmpty(e.Name)).Name;

            query.CharacterClass = eventDtos.First(e => !string.IsNullOrEmpty(e.CharacterClass)).CharacterClass;

            query.Level = eventDtos.Select(e => e.Level).ToList().Sum();

            Character character = new Character(new Name(query.Name), new CharacterClass (query.CharacterClass),new Level(query.Level));

            return Ok(character);
        }
    }
}
