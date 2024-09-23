using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CA.Blocks.Domain.Common;

public abstract class BaseEntity
{
    [Key]
    public int Id { get; set; }


    //public void AddDomainEvent(BaseEvent domainEvent)
    //{
    //    _domainEvents.Add(domainEvent);
    //}
    //public void ClearDomainEvents()
    //{
    //    _domainEvents.Clear();
    //}
    //private readonly List<BaseEvent> _domainEvents = new();

    //[NotMapped]
    //public IReadOnlyCollection<BaseEvent> DomainEvents => _domainEvents.AsReadOnly();

    //public void RemoveDomainEvent(BaseEvent domainEvent)
    //{
    //    _domainEvents.Remove(domainEvent);
    //}

}