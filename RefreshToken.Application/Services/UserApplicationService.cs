using RefreshToken.Application.Services.Interfaces;
using RefreshToken.Application.ViewModels;
using RefreshToken.Infrastructure.Contexts;

namespace RefreshTokenTemplate.Application.Services;

public class UserApplicationService : BaseService<RefreshTokenContext>, IUserApplicationService
{
    public UserApplicationService(IMediatorHandler mediatorHandler)
    : base(mediatorHandler)
    {
    }

    public Task<bool> AddUser(AddUserViewModel viewModel)
    {
        throw new NotImplementedException();
    }
}
