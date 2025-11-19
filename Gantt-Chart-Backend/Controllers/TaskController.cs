using System.Security.Claims;
using Gantt_Chart_Backend.Data.DTOs;
using Gantt_Chart_Backend.Data.Enums;
using Gantt_Chart_Backend.Exceptions;
using Gantt_Chart_Backend.Services;
using Gantt_Chart_Backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gantt_Chart_Backend.Controllers;

[Route("api/tasks")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
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
    [Authorize(Permissions.AddUser)]
    [Route("{taskId}")]
    public async Task<IActionResult> GetTaskInfo(
        [FromRoute] Guid taskId)
    {
        return Ok(await _taskService.GetTask(taskId));
    }
    
    [HttpPost]
    public async Task<IActionResult> AddTask(ProjectTaskDto dto)
    {
        try
        {
            return Ok(await _taskService.AddTask(dto));
        }
        catch (Exception ex)
        {
            return Ok(ex.Message);
        }
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
    
    [HttpPost]
    [Route("{taskId}/dependence")]
    public async Task<IActionResult> AddTaskDependence(
        [FromBody] DependenceDto dep)
    {
        await _taskService.AddTaskDependence(dep);
        return Ok();
    }

    [HttpDelete]
    [Route("{taskId}/dependence")]
    public async Task<IActionResult> RemoveTaskDependence(
        [FromBody] DependenceDto dep)
    {
        try
        {
            await _taskService.RemoveTaskDependence(dep);
            return Ok();
        }
        catch (NotFoundException ex)
        {
            return NotFound();
        }
    }
    
    [HttpPost]
    [Route("{taskId}/performers")]
    public async Task<IActionResult> AddTaskPerformers(
        [FromRoute] Guid taskId,
        [FromQuery] Guid userId)
    {
        await _taskService.AddTaskPerformer(taskId, userId);
        return Ok();
    }

    [HttpDelete]
    [Route("{taskId}/performers")]
    public async Task<IActionResult> RemoveTaskPerformers(
        [FromRoute] Guid taskId,
        [FromQuery] Guid userId)
    { 
        await _taskService.RemoveTaskPerformer(taskId, userId);
        return Ok();
    }
}