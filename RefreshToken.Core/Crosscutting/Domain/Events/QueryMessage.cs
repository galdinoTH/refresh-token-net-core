using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefreshToken.Core.Crosscutting.Domain.Events;

public class QueryMessage<TResponse> : IRequest<TResponse>, IBaseRequest, IRequestBase
{
    public string MessageType { get; set; }

    protected QueryMessage()
    {
        MessageType = GetType().Name;
    }
}
