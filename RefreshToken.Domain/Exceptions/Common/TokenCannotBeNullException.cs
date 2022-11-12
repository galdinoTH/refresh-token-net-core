using RefreshToken.Domain.Exceptions.Base;
using RefreshToken.Core.Resources;

namespace RefreshToken.Domain.Exceptions.Common;

public class TokenCannotBeNullException : DomainException
{
    public TokenCannotBeNullException() : base(DomainMessages.Token_CannotBeNull) { }
}
