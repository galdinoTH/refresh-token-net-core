using MediatR;
using RefreshToken.Core.Crosscutting.Domain.Commands;
using RefreshToken.Core.Crosscutting.Domain.Events;
using RefreshToken.Core.Crosscutting.Domain.Notifications;
using RefreshToken.Core.Crosscutting.Domain.Queries;

namespace RefreshToken.Core.Crosscutting.Domain.Bus;

public interface IMediatorHandler
{
    IEnumerable<string> Errors { get; }

    Task SendCommand<T>(T command) where T : Command;

    Task<TResponse> SendQuery<TResponse>(Query<TResponse> query) where TResponse : class;

    Task RaiseEvent<T>(T @event) where T : Event;

    Task NotifyError(string code, string message);

    Task NotifyError(string message);

    Task Clear();

    Task<List<DomainNotification>> GetNotifications();

    bool HasNotification();

    INotificationHandler<DomainNotification> GetNotificationHandler();
}
