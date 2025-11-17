using System.Security.Claims;
using Gantt_Chart_Backend.Data.DTOs;
using Gantt_Chart_Backend.Exceptions;
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

    private Guid GetCurrentUserId()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId) || !Guid.TryParse(userId, out var guid))
        {
            throw new UnauthorizedAccessException();
        }

        return guid;
    }
    
    [HttpDelete]
    [Route("{taskId}")]
    public async Task<IActionResult> DeleteTask([FromRoute] Guid taskId)
    {
        await _taskService.DeleteTask(taskId);
        return Ok();
    }

    [HttpPatch]
    [Route("{taskId}")]
    public async Task<IActionResult> UpdateTask(
        [FromRoute] Guid taskId,
        [FromBody] ProjectTaskDto taskDto)
    {
        await _taskService.UpdateTask(taskDto, taskId);
        return Ok();
    }
    
    [HttpGet]
    [Route("/{taskId}")]
    public async Task<IActionResult> GetTaskInfo(
        [FromRoute] Guid taskId)
    {
        return Ok(await _taskService.GetTask(taskId));
    }
    
    [HttpPost]
    [Route("/{taskId}/dependence")]
    public async Task<IActionResult> AddTaskDependence(
        [FromBody] DependenceDto dep)
    {
        await _taskService.AddTaskDependence(dep);
        return Ok();
    }

    [HttpDelete]
    [Route("/{taskId}/dependence")]
    public async Task<IActionResult> RemoveTaskDependence(
        [FromBody] DependenceDto dep)
    {
        try
        {
            _taskService.RemoveTaskDependence(dep);
            return Ok();
        }
        catch (NotFoundException ex)
        {
            return NotFound();
        }
    }
    
    [HttpPost]
    [Route("/{taskId}/performers")]
    public async Task<IActionResult> AddTaskPerformers(
        [FromRoute] Guid taskId)
    {
        var userId = GetCurrentUserId();
        await _taskService.AddTaskPerformer(taskId, userId);
        return Ok();
    }

    [HttpDelete]
    [Route("/{taskId}/performers")]
    public async Task<IActionResult> RemoveTaskPerformers(
        [FromRoute] Guid taskId)
    {
        var userId = GetCurrentUserId(); 
        await _taskService.RemoveTaskPerformer(taskId, userId);
        return Ok();
    }
}