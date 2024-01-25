namespace Domain.AggregationModels.CharacterAggregate
{
    public class Character
    {
        public Name Name { get; set; }

        public CharacterClass CharacterClass { get; set; }

        public Level Level { get; set; }

        public Character(Name name, CharacterClass characterClass, Level level) 
        {
            Name = name;
            CharacterClass = characterClass;
            Level = level;
        }
    }
}
