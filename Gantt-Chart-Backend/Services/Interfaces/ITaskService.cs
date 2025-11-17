using Gantt_Chart_Backend.Data.DTOs;
using Gantt_Chart_Backend.Data.Enums;
using Gantt_Chart_Backend.Data.Models;

namespace Gantt_Chart_Backend.Services.Interfaces;

public interface ITaskService
{
    public Task<IEnumerable<ProjectTask>> GetTasksInProject(Guid projectId);
    public Task<ProjectTask> GetTask(Guid taskId);
    public Task<Guid> AddTask(ProjectTaskDto task);
    public Task UpdateTask(ProjectTaskDto taskDto, Guid taskId);
    public Task DeleteTask(Guid taskId);
    public Task AddTaskDependence(DependenceDto depDto);
    public Task RemoveTaskDependence(DependenceDto depDto);
    public Task AddTaskPerformer(Guid taskId, Guid userId);
    public Task RemoveTaskPerformer(Guid taskId, Guid userId);
}