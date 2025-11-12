using Gantt_Chart_Backend.Data.DbContext;
using Gantt_Chart_Backend.Data.DTOs;
using Gantt_Chart_Backend.Data.Enums;
using Gantt_Chart_Backend.Data.Models;
using Gantt_Chart_Backend.Services.Interfaces;

namespace Gantt_Chart_Backend.Services.Implementations;

public class ProjectService : IProjectService
{
    private readonly GanttPlatformDbContext _dbcontext;

    public ProjectService(GanttPlatformDbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public Task CreateProject()
    {
        throw new NotImplementedException();
    }

    public Task UpdateProject()
    {
        throw new NotImplementedException();
    }

    public Task DeleteProject()
    {
        throw new NotImplementedException();
    }

    public async Task<ProjectResponse<ProjectFullInfoDto>> GetFullProjectInfo 
        (Guid projectId, Guid userId)
    {
        var project =  await _dbcontext.Projects.FindAsync(projectId);
        if (project is null)
            return ProjectResponse<ProjectFullInfoDto>.NotFound();
        
        var user = project.Members.FirstOrDefault(m => m.Id == userId);
        if (user is not null)
        {
            var projectInfo = new ProjectFullInfoDto()
            {
                    //!!!!!!!!!!!!!!!!!
            };
            return ProjectResponse<ProjectFullInfoDto>.Success(projectInfo);
        }
        else return ProjectResponse<ProjectFullInfoDto>.Forbidden();
    }

    public Task<IEnumerable<ProjectTask>> GetTasksInProject(Guid projectId)
    {
        throw new NotImplementedException();
    }

    public Task GetTask()
    {
        throw new NotImplementedException();
    }

    public Task CreateTask()
    {
        throw new NotImplementedException();
    }

    public Task UpdateTask()
    {
        throw new NotImplementedException();
    }

    public Task DeleteTask()
    {
        throw new NotImplementedException();
    }

    public Task AddTaskDependence()
    {
        throw new NotImplementedException();
    }

    public Task RemoveTaskDependence()
    {
        throw new NotImplementedException();
    }

    public Task AddTaskPerformers()
    {
        throw new NotImplementedException();
    }

    public Task RemoveTaskPerformers()
    {
        throw new NotImplementedException();
    }

    public Task CreateTeam()
    {
        throw new NotImplementedException();
    }

    public Task AddTeamMember()
    {
        throw new NotImplementedException();
    }

    public Task RemoveTeamMember()
    {
        throw new NotImplementedException();
    }

    public Task AddUserToProject(Guid userId, Guid projectId)
    {
        throw new NotImplementedException();
    }

    public Task RemoveUserFromProject(Guid userId, Guid projectId)
    {
        throw new NotImplementedException();
    }

    public Task SetUserRoleInProject(Guid userId, Guid projectId, Guid roleId)
    {
        throw new NotImplementedException();
    }

    public Task AddDependence()
    {
        throw new NotImplementedException();
    }

    public Task RemoveDependence()
    {
        throw new NotImplementedException();
    }

    public Task AddUser()
    {
        throw new NotImplementedException();
    }

    public Task RemoveUser()
    {
        throw new NotImplementedException();
    }

    public Task SetUserRole()
    {
        throw new NotImplementedException();
    }

    Task<ProjectFullInfoDto> IProjectService.GetFullProjectInfo(Guid projectId, Guid userId)
    {
        throw new NotImplementedException();
    }
}