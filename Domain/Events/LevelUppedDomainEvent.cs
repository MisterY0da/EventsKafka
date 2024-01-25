namespace Domain.Events
{
    public class LevelUppedDomainEvent
    {
        public string Name { get; set; }

        public string CharacterClass { get; set; }

        public int Level { get; set; }

        public LevelUppedDomainEvent(int level)
        {
            Level = level;
        }
    }
}
