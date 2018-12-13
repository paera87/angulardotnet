using Hogstorp.Core.Interfaces;
using Hogstorp.Core.SharedKernel;

namespace CleanArchitecture.Tests
{
    public class NoOpDomainEventDispatcher : IDomainEventDispatcher
    {
        public void Dispatch(BaseDomainEvent domainEvent) { }
    }
}
