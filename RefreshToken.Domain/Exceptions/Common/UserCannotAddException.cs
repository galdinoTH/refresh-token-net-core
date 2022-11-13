using RefreshToken.Domain.Exceptions.Base;
using RefreshToken.Core.Resources;

namespace RefreshToken.Domain.Exceptions.Common;

public class UserCannotAddException : DomainException
{
    public UserCannotAddException() : base(DomainMessages.User_CannotBeAdd) { }
}
