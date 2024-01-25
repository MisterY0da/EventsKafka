namespace Domain.Events
{
    public class LevelUpCanceledDomainEvent
    {
        public string Name { get; set; }

        public string CharacterClass { get; set; }

        public int Level { get; set; }

        public LevelUpCanceledDomainEvent(int level)
        {
            Level = level;
        }
    }
}
