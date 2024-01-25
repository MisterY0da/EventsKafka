using Domain.Events;

namespace Application.Commands
{
    public class LevelUpCommand
    {
        public int Level { get; set; }

        public LevelUppedDomainEvent CreateDomainEvent()
        {
            return new LevelUppedDomainEvent(Level);
        }
    }
}
