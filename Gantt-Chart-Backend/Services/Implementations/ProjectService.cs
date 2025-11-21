using Gantt_Chart_Backend.Data.DbContext;
using Gantt_Chart_Backend.Data.DTOs;
using Gantt_Chart_Backend.Data.Enums;
using Gantt_Chart_Backend.Data.Interfaces;
using Gantt_Chart_Backend.Data.Models;
using Gantt_Chart_Backend.Exceptions;
using Gantt_Chart_Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gantt_Chart_Backend.Services.Implementations;

public class ProjectService : IProjectService
{
    private readonly GanttPlatformDbContext _dbcontext;

    public ProjectService(GanttPlatformDbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public Task<Guid> CreateProject(ProjectDto project)
    {
        var newProject = new Project
        {
            Id =  Guid.NewGuid(),
            Name = project.Name,
            CreatorId = project.CreatorId,
            DeadLine = project.DeadLine ??  DateTime.Now.AddDays(10),
            RootTask = project.RootTask ??  new ProjectTask(),
            Members = project.Members ?? new List<Performer>()
        };

        return Task.FromResult(newProject.Id);
    }

    public async Task UpdateProject(Guid projectId, ProjectDto projectDto)
    {
        var p = await _dbcontext.Projects
            .FirstOrDefaultAsync(p => p.Id == projectId)
            ?? throw new NotFoundException();
        
        p.Name = projectDto.Name;
        p.DeadLine = projectDto.DeadLine;
        p.CreatorId = projectDto.CreatorId;
        p.RootTask = projectDto.RootTask;
        p.Members = projectDto.Members;
        p.Tasks =  projectDto.Tasks;

        await _dbcontext.SaveChangesAsync();
    }

    public async Task DeleteProject(Guid projectId, Guid userId)
    {
        var project = _dbcontext.Projects
            .FirstOrDefaultAsync(p => p.Id == projectId)
            ??  throw new NotFoundException();

        _dbcontext.Remove(project);
        await _dbcontext.SaveChangesAsync();
    }
    
    public async Task<ProjectOnLoadDto> GetFullProjectInfo 
        (Guid projectId, Guid userId)
    {
        var project =  await _dbcontext.Projects
            .FirstOrDefaultAsync(p=> p.Id == projectId)
            ?? throw new NotFoundException();
        
        var user = project.Members
            .FirstOrDefault(m => m.Id == userId)
            ?? throw new ForbidException();
        
        var projectInfo = new ProjectOnLoadDto
        (
                project.Id,
                project.Name,
                project.Creator,
                project.DeadLine,
                project.RootTask,
                project.Tasks,
                project.Members
        );
        return projectInfo;
    }

    public async Task SetProjectRootTask(Guid projectId, Guid taskId)
    {
        var task = _dbcontext.Tasks
            .FirstOrDefault(t => t.Id == taskId)
            ?? throw new NotFoundException();
        
        var project = _dbcontext.Projects
            .FirstOrDefault(p => p.Id == projectId)
            ?? throw new NotFoundException();
        
        project.RootTaskId =  taskId;
        project.RootTask = task;

        await _dbcontext.SaveChangesAsync();
    }
}