using Gantt_Chart_Backend.Data.DbContext;
using Gantt_Chart_Backend.Data.DTOs;
using Gantt_Chart_Backend.Data.Models;
using Gantt_Chart_Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gantt_Chart_Backend.Services.Implementations;

public class TaskService : ITaskService
{
    private readonly GanttPlatformDbContext _dbcontext;

    public TaskService(GanttPlatformDbContext dbContext)
    {
        _dbcontext = dbContext;
    }
    
    public async Task<IEnumerable<ProjectTask>> GetTasksInProject(Guid projectId)
    {
        return await _dbcontext.Tasks.ToListAsync();
    }

    public async Task<ProjectTask> GetTask(Guid taskId)
    {
        return await _dbcontext.Tasks.FirstOrDefaultAsync(t => t.Id == taskId);
    }

    public async Task<Guid> AddTask(ProjectTaskDto task)
    {
        var newTask = new ProjectTask()
        {

        };
        await _dbcontext.Tasks.AddAsync(newTask);
        await _dbcontext.SaveChangesAsync();
        
        return newTask.Id;
    }

    public Task UpdateTask(ProjectTaskDto taskId)
    {
        throw new NotImplementedException();
    }

    public bool DeleteTask(Guid taskId)
    {
         _dbcontext.Tasks.Remove(_dbcontext.Tasks.FirstOrDefault(t => t.Id == taskId));
         _dbcontext.SaveChanges();
         
        return true;
    }
    
    public async Task AddTaskDependence(DependenceDto depDto)
    {
        var task = await _dbcontext.Tasks.FirstOrDefaultAsync(t => t.Id == depDto.ParentId);
        task.Dependencies.Add(Dependence.FromDto(depDto));
    }

    public Task RemoveTaskDependence(DependenceDto depDto)
    {
        throw new NotImplementedException();
    }

    public Task AddTaskPerformers(Guid taskId, Guid userId, List<Guid> performers)
    {
        throw new NotImplementedException();
    }

    public Task RemoveTaskPerformers(Guid taskId, Guid userId)
    {
        throw new NotImplementedException();
    }
}