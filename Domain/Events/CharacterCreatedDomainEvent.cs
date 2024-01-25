namespace Domain.Events
{
    public class CharacterCreatedDomainEvent
    {
        public string Name { get; set; }

        public string CharacterClass { get; set; }

        public int Level { get; set; }

        public CharacterCreatedDomainEvent(string name, string characterClass, int level)
        {
            Name = name;
            CharacterClass = characterClass;
            Level = level;
        }
    }
}
