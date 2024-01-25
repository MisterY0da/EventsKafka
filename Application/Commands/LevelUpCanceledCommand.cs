using Domain.Events;

namespace Application.Commands
{
    public class LevelUpCanceledCommand
    {
        public int Level { get; set; }

        public LevelUpCanceledDomainEvent CreateDomainEvent()
        {
            return new LevelUpCanceledDomainEvent(Level);
        }
    }
}
