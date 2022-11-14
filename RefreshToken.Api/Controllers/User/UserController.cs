using Microsoft.AspNetCore.Mvc;
using RefreshToken.Application.Services.Interfaces;
using RefreshToken.Application.ViewModels;
using RefreshToken.Core.Crosscutting.Domain.Bus;
using RefreshToken.Core.Crosscutting.Domain.Controller;

namespace RefreshToken.Api.Controllers.User;

[Route("v1/user")]
[ApiController]
public class UserController : ApiController
{
    private readonly IUserApplicationService _userApplicationService;

    public UserController(IMediatorHandler mediator, IUserApplicationService userApplicationService)
        : base(mediator)
    {
        _userApplicationService = userApplicationService;
    }

    /// <summary>
    /// Criar Usuário
    /// </summary>
    /// <returns>Criação de Usuário</returns>
    [HttpPost]
    [Route("accounts")]
    public async Task<IActionResult> Add([FromBody] AddUserViewModel addUserViewModel)
    {
        return Response(await this._userApplicationService.AddUser(addUserViewModel));
    }
}
