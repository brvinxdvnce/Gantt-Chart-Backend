using Microsoft.AspNetCore.Mvc;

namespace Gantt_Chart_Backend.Controllers;

[ApiController]
//[Route("tasks")]
public class TasksController : ControllerBase
{

    [HttpGet]
    [Route("projects/{projectId}/tasks/{taskId}")]
    public async Task<IActionResult> GetTasks(
        [FromRoute] string projectId)
    {

        return Ok();
    }
    
}