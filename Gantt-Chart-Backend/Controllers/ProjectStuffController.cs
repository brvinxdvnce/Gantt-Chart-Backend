using Gantt_Chart_Backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gantt_Chart_Backend.Controllers;


[Authorize]
[ApiController]
public class ProjectStuffController : ControllerBase
{
    private readonly ITeamService _teamService;


    public ProjectStuffController(ITeamService teamService)
    {
        _teamService = teamService;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateTeam()
    {
        _teamService.CreateTeam();
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> AddTeamMember()
    {
        _teamService.AddTeamMember();
        return Ok();
    }
    
    [HttpDelete]
    public async Task<IActionResult> RemoveTeamMember()
    {
        _teamService.RemoveTeamMember();
        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> AddUserToProject(
        [FromQuery] Guid userId,
        [FromQuery] Guid projectId)
    {
        _teamService.AddUserToProject(projectId, userId);
        return Ok();
    }
    
    [HttpDelete]
    public async Task<IActionResult> RemoveUserFromProject()
    {
        
        return Ok();
    }
    
    [HttpPatch]
    public async Task<IActionResult> SetUserRoleInProject()
    {
        return Ok();
    }
}
