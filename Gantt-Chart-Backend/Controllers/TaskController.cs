using Gantt_Chart_Backend.Data.DTOs;
using Gantt_Chart_Backend.Services;
using Gantt_Chart_Backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gantt_Chart_Backend.Controllers;


[Authorize]
[Route("tasks")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TaskController(IProjectService projectService, ITaskService taskService)
    {
        _taskService = taskService;
    }
    
    [HttpGet]
    [Route("")]
    public async Task<IActionResult> AddTask([FromServices] CreateTaskUseCase useCase)
    {
        try
        {
            return Ok(useCase.Execute());
        }
        catch (Exception ex)
        {
            return Ok();
        }
    }

    [HttpDelete]
    [Route("{taskId}")]
    public async Task<IActionResult> DeleteTask([FromRoute] Guid taskId)
    {
        _taskService.DeleteTask(taskId);
        return Ok();
    }

    [HttpPatch]
    [Route("{taskId}")]
    public async Task<IActionResult> UpdateTask(ProjectTaskDto task)
    {
        _taskService.UpdateTask(task);
        return Ok();
    }
    
    [HttpGet]
    [Route("/{taskId}")]
    public async Task<IActionResult> GetTaskInfo(
        [FromRoute] string projectId,
        [FromRoute] Guid taskId)
    {
        var task = _taskService.GetTask(taskId);
        return Ok(task);
    }
    
    [HttpPost]
    [Route("/{taskId}/dependence")]
    public async Task<IActionResult> AddTaskDependence([FromBody] DependenceDto dep)
    {
        await _taskService.AddTaskDependence(dep);
        return Ok();
    }

    [HttpDelete]
    [Route("/{taskId}/dependence")]
    public async Task<IActionResult> RemoveTaskDependence([FromBody] DependenceDto dep)
    {
        await _taskService.RemoveTaskDependence(dep);
        return Ok();
    }
    
    [HttpPost]
    [Route("/{taskId}/performers")]
    public async Task<IActionResult> AddTaskPerformers(
        [FromQuery] Guid userId, 
        [FromQuery] Guid taskId)
    {
        await _taskService.AddTaskPerformers(taskId, userId);
        return Ok();
    }

    [HttpDelete]
    [Route("/{taskId}/performers")]
    public async Task<IActionResult> RemoveTaskPerformers(
        [FromQuery] Guid userId, 
        [FromQuery] Guid taskId)
    {
        _taskService.RemoveTaskPerformers(taskId, userId);
        return Ok();
    }
}