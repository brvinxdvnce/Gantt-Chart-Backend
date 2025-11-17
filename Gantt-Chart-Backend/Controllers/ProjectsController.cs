using System.Security.Claims;
using Gantt_Chart_Backend.Data.DbContext;
using Gantt_Chart_Backend.Data.DTOs;
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

    public ProjectsController(IProjectService projectService)
    {
        _projectService = projectService;
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
    
    [HttpGet]
    [Route("/{projectId:guid}")]
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

    [HttpPost]
    public async Task<IActionResult> CreateProject(
        [FromBody] ProjectDto project)
    {
        return Ok(await _projectService.CreateProject(project));
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateProject(
        [FromBody] ProjectDto newProject)
    {
        await _projectService.UpdateProject(newProject);
        return Ok();
    }

    [HttpDelete]
    [Route("/{projectId:guid}")]
    public async Task<IActionResult> DeleteProject(
        [FromRoute] Guid projectId)
    {
        Guid userId = GetCurrentUserId();
        await _projectService.DeleteProject(projectId, userId);
        return Ok();
    }
}