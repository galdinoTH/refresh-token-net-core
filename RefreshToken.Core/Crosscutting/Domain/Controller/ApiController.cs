using RefreshToken.Core.Crosscutting.Domain.Bus;
using RefreshToken.Core.Crosscutting.Domain.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace RefreshToken.Core.Crosscutting.Domain.Controller;

[Route("v{version:apiVersion}/[Controller]")]
[ApiController]
public abstract class ApiController : ControllerBase
{
    private readonly DomainNotificationHandler _notifications;

    protected IMediatorHandler _mediator { get; }

    protected IEnumerable<DomainNotification> Notifications => _notifications.GetNotifications();

    protected ApiController(IMediatorHandler mediator)
    {
        _notifications = (DomainNotificationHandler)mediator.GetNotificationHandler();
        _mediator = mediator;
    }

    protected bool IsValidOperation()
    {
        return !_notifications.HasNotifications();
    }

    protected new IActionResult Response(object result = null)
    {
        if (IsValidOperation())
        {
            return Ok(new SuccessResponse<object>(result));
        }

        return BadRequest(new BadRequestResponse(from n in _notifications.GetNotifications()
                                                 select n.Value));
    }

    protected IActionResult ModalStateResponse()
    {
        NotifyModelStateErrors();
        return Response();
    }

    protected IActionResult ResponseWithError(string error)
    {
        NotifyError(error);
        return Response();
    }

    protected void NotifyModelStateErrors()
    {
        IEnumerable<ModelError> enumerable = base.ModelState.Values.SelectMany((ModelStateEntry v) => v.Errors);
        foreach (ModelError item in enumerable)
        {
            string message = ((item.Exception == null) ? item.ErrorMessage : item.Exception!.Message);
            NotifyError(string.Empty, message);
        }
    }

    protected IEnumerable<string> GetNotificationErrors()
    {
        return from t in _notifications.GetNotifications()
               select t.Value;
    }

    protected void NotifyError(string code, string message)
    {
        _mediator.RaiseEvent(new DomainNotification(code, message));
    }

    protected void NotifyError(string message)
    {
        NotifyError(string.Empty, message);
    }

    protected bool IsNullRequest(object request)
    {
        if (request != null)
        {
            return false;
        }

        NotifyError("Objeto passado é inválido. Verifique os parâmetros passados e tente novamente.");
        return true;
    }
}
