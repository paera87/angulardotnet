using Ardalis.GuardClauses;
using Hogstorp.Core.Events;
using Hogstorp.Core.Interfaces;

namespace Hogstorp.Core.Services
{
    public class ToDoItemService : IHandle<ToDoItemCompletedEvent>
    {
        public void Handle(ToDoItemCompletedEvent domainEvent)
        {
            Guard.Against.Null(domainEvent, nameof(domainEvent));
            // Do Nothing
        }
    }
}
