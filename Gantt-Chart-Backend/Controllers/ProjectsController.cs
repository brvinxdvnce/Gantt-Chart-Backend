using Microsoft.AspNetCore.Mvc;

namespace Gantt_Chart_Backend.Controllers;

[ApiController]
[Route("projects")]
public class ProjectsController : ControllerBase
{
    private readonly ;

    [HttpGet]
    [Route("projects/{projectId}/tasks/{taskId}")]
    public async Task<IActionResult> GetTask(
        [FromRoute] string projectId)
    {

        return Ok();
    }

    [HttpGet]
    [Route("projects/{projectId}")]
    public async Task<IActionResult> GetProjectInfo(
        [FromRoute] string projectId,
        [FromBody] Guid UserId)
    {
        
    }
}