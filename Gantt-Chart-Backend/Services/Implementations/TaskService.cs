using Gantt_Chart_Backend.Data.DbContext;
using Gantt_Chart_Backend.Data.DTOs;
using Gantt_Chart_Backend.Data.Enums;
using Gantt_Chart_Backend.Data.Models;
using Gantt_Chart_Backend.Exceptions;
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
    
    public async Task<ProjectTask> GetTask(Guid taskId)
    {
        return await _dbcontext.Tasks
            .FirstOrDefaultAsync(t => t.Id == taskId) 
               ?? throw new NotFoundException();
    }

    public async Task<Guid> AddTask(ProjectTaskDto task)
    {
        var newTask = new ProjectTask()
        {
            Id = Guid.NewGuid(),
            Name = task.Name ?? throw new ArgumentException(),
            ProjectId = task.ProjectId,
            Description = task.Description ?? "",
            IsCompleted = task.IsCompleted ?? false,
            Dependencies = task.Dependencies ?? new List<Dependence>(),
            StartTime = task.StartTime ??  DateTime.UtcNow,
            EndTime = task.EndTime ??  DateTime.UtcNow.AddDays(1),
        };
        
        await _dbcontext.Tasks.AddAsync(newTask);
        await _dbcontext.SaveChangesAsync();
        
        return newTask.Id;
    }
    
    public async Task UpdateTask(ProjectTaskDto taskDto, Guid taskId)
    {
        var task = await _dbcontext.Tasks
                       .Include(projectTask => projectTask.Dependencies)
                       .FirstOrDefaultAsync(t => t.Id == taskId)
                   ?? throw new NotFoundException();
        
        task.Name = taskDto.Name ?? task.Name;
        task.Description = taskDto.Description ?? task.Description;
        task.IsCompleted = taskDto.IsCompleted ?? task.IsCompleted;
        task.Dependencies = taskDto.Dependencies ?? task.Dependencies;
        task.StartTime = taskDto.StartTime ?? task.StartTime;
        task.EndTime = taskDto.EndTime ?? task.EndTime;

        await _dbcontext.SaveChangesAsync();
    }

    public async Task DeleteTask(Guid taskId)
    {
         _dbcontext.Tasks
             .Remove(
                 _dbcontext.Tasks
                     .FirstOrDefault(t => t.Id == taskId) 
                 ?? throw new NotFoundException());
         
         await _dbcontext.SaveChangesAsync();
    }
    
    public async Task AddTaskDependence(DependenceDto depDto)
    {
        var task = await _dbcontext.Tasks.FirstOrDefaultAsync(t => t.Id == depDto.ParentId);
        task?.Dependencies.Add(Dependence.FromDto(depDto));
        
        await _dbcontext.SaveChangesAsync();
    }

    public async Task RemoveTaskDependence(DependenceDto depDto)
    {
        var task = await _dbcontext.Tasks
            .Include(t => t.Dependencies)
            .FirstOrDefaultAsync(t => t.Id == depDto.ParentId)
            ?? throw new NotFoundException();
        
        var dep = await _dbcontext.Dependences
            .FirstOrDefaultAsync(d => d.ParentId == depDto.ParentId 
                                      && d.ChildId == depDto.ChildId)
            ?? throw new NotFoundException();
        
        task?.Dependencies.Remove(dep);
        
        await _dbcontext.SaveChangesAsync();
    }

    public Task AddTaskPerformer(Guid taskId, Guid userId, int n)
    {
        var task = _dbcontext.Tasks
            .FirstOrDefault(t => t.Id == taskId) ?? throw new NotFoundException();
        
        if (n == 0)
        {
            var performer = _dbcontext.ProjectMembers.FirstOrDefault(u => u.Id == userId) ?? throw new NotFoundException();
            task.Performers.Add(performer);
        }
        else
        {
            var team = _dbcontext.Teams.FirstOrDefault(u => u.Id == userId) ?? throw new NotFoundException();
            task.Teams.Add(team);
        }
        _dbcontext.SaveChanges();
        
        return Task.CompletedTask;
    }

    public async Task RemoveTaskPerformer(Guid taskId, Guid userId, int n)
    {
        var task = _dbcontext.Tasks
            .FirstOrDefault(t => t.Id == taskId) ?? throw new NotFoundException();
        
        if (n == 0)
        {
            var performer = _dbcontext.ProjectMembers.FirstOrDefault(u => u.Id == userId) ?? throw new NotFoundException();
            task.Performers.Remove(performer);
        }
        else
        {
            var team = _dbcontext.Teams.FirstOrDefault(u => u.Id == userId) ?? throw new NotFoundException();
            task.Teams.Remove(team);
        }
        await _dbcontext.SaveChangesAsync();
    }
}