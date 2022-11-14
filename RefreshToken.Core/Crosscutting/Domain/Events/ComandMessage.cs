using MediatR;
using System.Text.Json.Serialization;

namespace RefreshToken.Core.Crosscutting.Domain.Events;

public abstract class CommandMessage : IRequest, IRequest<Unit>, IBaseRequest, IRequestBase
{
    [JsonIgnore]
    public string MessageType { get; protected set; }

    protected CommandMessage()
    {
        MessageType = GetType().Name;
    }
}
