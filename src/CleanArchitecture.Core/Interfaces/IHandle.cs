using Hogstorp.Core.SharedKernel;

namespace Hogstorp.Core.Interfaces
{
    public interface IHandle<T> where T : BaseDomainEvent
    {
        void Handle(T domainEvent);
    }
}