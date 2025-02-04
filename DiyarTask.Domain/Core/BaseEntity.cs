namespace DiyarTask.Domain.Core;

using MediatR;

public abstract class BaseEntity<TId> where TId : notnull
{
    private readonly IList<INotification> _domainEvents = new List<INotification>();
    public TId Id { get; protected set; }

    public IEnumerable<INotification> GetDomainEvents()
    {
        return _domainEvents.AsEnumerable();
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    protected void AddDomainEvent(INotification @event)
    {
        _domainEvents.Add(@event);
    }
}