using Gantt_Chart_Backend.Data.DbContext;
using Gantt_Chart_Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Gantt_Chart_Backend.Controllers;

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
    [Route("/{projectId}/tasks/{taskId}")]
    public async Task<IActionResult> GetTaskInfo(
        [FromRoute] string projectId,
        [FromRoute] string taskId)
    {
        return Ok();
    }

    public async Task<IActionResult> AddTask()
    {
        return Ok();
    }

    public async Task<IActionResult> DeleteTask()
    {
        return Ok();
    }

    public async Task<IActionResult> UpdateTask()
    {
        return Ok();
    }
    
    [HttpGet]
    [Route("projects/{projectId:guid}")]
    public async Task<IActionResult> GetProjectInfo(
        [FromRoute] Guid projectId,
        [FromBody] Guid userId)
    {
        var res = await _projectService.GetFullProjectInfo(projectId, userId);
        return Ok();
    }

    public async Task<IActionResult> CreateProject()
    {
        return Ok();
    }

    public async Task<IActionResult> UpdateProject()
    {
        return Ok();
    }

    public async Task<IActionResult> DeleteProject()
    {
        return Ok();
    }
}