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
    
    [HttpGet]
    [Route("/{projectId}")]
    public async Task<IActionResult> GetProjectInfo(
        [FromRoute] Guid projectId,
        [FromQuery] Guid userId)
    {
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
        [FromQuery] string projectName, 
        [FromQuery] Guid userId)
    {
        await _projectService.CreateProject(projectName, userId);
        return Ok();
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateProject(
        [FromBody] ProjectDto newProject)
    {
        await _projectService.UpdateProject(newProject);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProject(
        [FromQuery] Guid projectId,
        [FromQuery] Guid userId)
    {
        await _projectService.DeleteProject(projectId, userId);
        return Ok();
    }
}