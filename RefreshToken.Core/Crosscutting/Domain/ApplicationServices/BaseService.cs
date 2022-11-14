using Microsoft.EntityFrameworkCore;
using RefreshToken.Core.Crosscutting.Domain.Bus;
using RefreshToken.Core.Crosscutting.Domain.Events;
using RefreshToken.Core.Crosscutting.Domain.Notifications;
using RefreshToken.Core.Crosscutting.Domain.UnitOfWork;

namespace RefreshToken.Core.Crosscutting.Domain.ApplicationServices;

public abstract class BaseService<TContext> where TContext : DbContext
{
    protected readonly IMediatorHandler _mediator;

    protected readonly IUnitOfWork<TContext> _unitOfWork;

    public BaseService(IMediatorHandler mediator, IUnitOfWork<TContext> unitOfWork)
    {
        _mediator = mediator;
        _unitOfWork = unitOfWork;
    }

    public void NotifyError(string code, string message)
    {
        _mediator.RaiseEvent(new DomainNotification(code, message));
    }

    public void NotifyError(string message)
    {
        _mediator.RaiseEvent(new DomainNotification(string.Empty, message));
    }

    public bool HasNotification()
    {
        return _mediator.HasNotification();
    }

    public async Task<bool> CommitAsync()
    {
        return await _unitOfWork.CommitAsync();
    }

    public async Task RaiseEvent<T>(T @event) where T : Event
    {
        await _mediator.RaiseEvent(@event);
    }
}
