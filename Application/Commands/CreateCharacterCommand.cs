using Domain.Events;

namespace Application.Commands
{
    public class CreateCharacterCommand
    {
        public string Name { get; set; }

        public string CharacterClass { get; set; }

        public int Level { get; set; }

        public CharacterCreatedDomainEvent CreateDomainEvent()
        {
            return new CharacterCreatedDomainEvent(Name, CharacterClass, Level);
        }
    }
}
