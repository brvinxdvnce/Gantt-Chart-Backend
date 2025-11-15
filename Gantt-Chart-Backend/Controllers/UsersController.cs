using Gantt_Chart_Backend.Data.DbContext;
using Gantt_Chart_Backend.Data.DTOs;
using Gantt_Chart_Backend.Data.Models;
using Gantt_Chart_Backend.Exceptions;
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
    [Route("{userId}")]
    public async Task<IActionResult> GetUser(Guid userId)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> RegisterUser(
        [FromBody] UserRequestDto userRequestDto)
    {
        try
        {
            return Ok(_usersService.Register(userRequestDto));
        }
        catch (UserAlreadyExistsException ex)
        {
            return Conflict(ex.Message);
        } 
    }

    [HttpGet]
    public async Task<IActionResult> Login([FromBody]LoginUserRequest user, HttpContext httpContext)
    {
        try
        {
            var token = await _usersService.Login(user);
            httpContext.Response.Cookies.Append("jwt-token", token);
            return Ok(token);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (InvalidCredentialsException ex)
        {
            return Unauthorized(ex.Message);
        }
    }
}