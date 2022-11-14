using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefreshToken.Core.Crosscutting.Domain.Events;

public interface IRequestBase
{
    string MessageType { get; }
}
