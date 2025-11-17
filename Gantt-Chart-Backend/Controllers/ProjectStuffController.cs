using System.Security.Claims;
using Gantt_Chart_Backend.Data.DTOs;
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
    
    private Guid GetCurrentUserId()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out var guid))
        {
            throw new UnauthorizedAccessException();
        }

        return guid;
    }
    
    
    [HttpPost]
    public async Task<IActionResult> CreateTeam(TeamDto team)
    {
        await _teamService.CreateTeam(team);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> AddTeamMember(Guid teamId, Guid memberId)
    {
        await _teamService.AddTeamMember(teamId, memberId);
        return Ok();
    }
    
    [HttpDelete]
    public async Task<IActionResult> RemoveTeamMember(Guid teamId, Guid memberId)
    {
        await _teamService.RemoveTeamMember(teamId, memberId);
        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> AddUserToProject(
        [FromQuery] Guid userId,
        [FromQuery] Guid projectId)
    {
        await _teamService.AddUserToProject(projectId, userId);
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
