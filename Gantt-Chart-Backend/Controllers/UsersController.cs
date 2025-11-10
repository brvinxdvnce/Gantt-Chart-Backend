using Gantt_Chart_Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Gantt_Chart_Backend.Controllers;

[ApiController]
[Route("users")]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;
    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetUser(Guid id)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> RegisterUser()
    {

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Login()
    {
        return Ok();
    }
}