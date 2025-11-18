using System.Security.Claims;
using Gantt_Chart_Backend.Data.DbContext;
using Gantt_Chart_Backend.Data.DTOs;
using Gantt_Chart_Backend.Data.Enums;
using Gantt_Chart_Backend.Exceptions;
using Gantt_Chart_Backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gantt_Chart_Backend.Controllers;

[Authorize]
[ApiController]
[Route("projects")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _projectService;
    private readonly ITeamService _teamService;

    public ProjectsController(IProjectService projectService, ITeamService teamService)
    {
        _projectService = projectService;
        _teamService = teamService;
    }

    private Guid GetCurrentUserId()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId) 
            || !Guid.TryParse(userId, out var guid))
            throw new UnauthorizedAccessException();
        
        return guid;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateProject(
        [FromBody] ProjectDto project)
    {
        return Ok(await _projectService.CreateProject(project));
    }
    
    [HttpGet]
    [Route("{projectId:guid}")]
    public async Task<IActionResult> GetProjectInfo(
        [FromRoute] Guid projectId)
    {
        Guid userId = GetCurrentUserId();
        try
        {
            return Ok(await _projectService.GetFullProjectInfo(projectId, userId));
        }
        catch (NotFoundException ex)
        {
            return NotFound();
        }
        catch (ForbidException ex)
        {
            return Forbid();
        }
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateProject(
        [FromBody] ProjectDto newProject)
    {
        await _projectService.UpdateProject(newProject);
        return Ok();
    }

    [HttpDelete]
    [Route("{projectId:guid}")]
    public async Task<IActionResult> DeleteProject(
        [FromRoute] Guid projectId)
    {
        Guid userId = GetCurrentUserId();
        await _projectService.DeleteProject(projectId, userId);
        
        return NoContent();
    }
    
    [HttpPost]
    [Route("{projectId:guid}/members")]
    public async Task<IActionResult> AddUserToProject(
        [FromQuery] Guid userId,
        [FromRoute] Guid projectId)
    {
        await _teamService.AddUserToProject(projectId, userId);
        return Ok();
    }
    
    [HttpDelete]
    [Route("{projectId:guid}/members/{userId:guid}")]
    public async Task<IActionResult> RemoveUserFromProject(
        [FromRoute] Guid userId,
        [FromRoute] Guid projectId)
    {
        try
        {
            await _teamService.RemoveUserFromProject(userId, projectId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
    
    [HttpPatch]
    [Route("{projectId:guid}/members/{userId:guid}")]
    public async Task<IActionResult> SetUserRoleInProject(
        [FromRoute] Guid userId,
        [FromRoute] Guid projectId,
        [FromBody] Role role)
    {
        await _teamService.SetUserRoleInProject(userId, projectId, role);
        return NoContent();
    }
}