using MediatR;

namespace RefreshToken.Core.Crosscutting.Domain.Events;

public abstract class Event : CommandMessage, INotification
{
    public DateTime Timestamp { get; private set; }

    protected Event()
    {
        Timestamp = DateTime.UtcNow;
    }
}
