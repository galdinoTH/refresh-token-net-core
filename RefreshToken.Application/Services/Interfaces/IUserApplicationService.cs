using RefreshToken.Application.ViewModels;

namespace RefreshToken.Application.Services.Interfaces;

public interface IUserApplicationService
{
    Task<bool> AddUser(AddUserViewModel viewModel);
}
