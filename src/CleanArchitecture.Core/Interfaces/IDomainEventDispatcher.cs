using Hogstorp.Core.SharedKernel;

namespace Hogstorp.Core.Interfaces
{
    public interface IDomainEventDispatcher
    {
        void Dispatch(BaseDomainEvent domainEvent);
    }
}