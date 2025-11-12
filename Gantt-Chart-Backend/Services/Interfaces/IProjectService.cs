using Gantt_Chart_Backend.Data.DbContext;
using Gantt_Chart_Backend.Data.DTOs;
using Gantt_Chart_Backend.Data.Models;

namespace Gantt_Chart_Backend.Services.Interfaces;

public interface IProjectService
{
    public Task CreateProject();
    public Task UpdateProject();
    public Task DeleteProject();
    public Task<ProjectFullInfoDto> GetFullProjectInfo (Guid projectId, Guid userId);
    
    
    public Task<IEnumerable<ProjectTask>> GetTasksInProject(Guid projectId);
    public Task GetTask();
    public Task CreateTask();
    public Task UpdateTask();
    public Task DeleteTask();
    public Task AddTaskDependence();
    public Task RemoveTaskDependence();
    public Task AddTaskPerformers();
    public Task RemoveTaskPerformers();

    public Task CreateTeam();
    public Task AddTeamMember();
    public Task RemoveTeamMember();
    
    public Task AddUserToProject(Guid userId, Guid projectId);
    public Task RemoveUserFromProject(Guid userId, Guid projectId);
    public Task SetUserRoleInProject(Guid userId, Guid projectId, Guid roleId);
}