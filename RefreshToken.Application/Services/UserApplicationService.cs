using RefreshToken.Application.Services.Interfaces;
using RefreshToken.Application.ViewModels;
using RefreshToken.Core.Crosscutting.Domain.ApplicationServices;
using RefreshToken.Core.Crosscutting.Domain.Bus;
using RefreshToken.Core.Crosscutting.Domain.UnitOfWork;
using RefreshToken.Infrastructure.Contexts;

namespace RefreshToken.Application.Services;

public class UserApplicationService : BaseService<RefreshTokenContext>, IUserApplicationService
{
    public UserApplicationService(IMediatorHandler mediatorHandler, IUnitOfWork<RefreshTokenContext> unitOfWork)
    : base(mediatorHandler, unitOfWork)
    {
    }

    public Task<bool> AddUser(AddUserViewModel viewModel)
    {
        throw new NotImplementedException();
    }
}

