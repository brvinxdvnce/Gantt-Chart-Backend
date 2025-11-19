using Gantt_Chart_Backend.Auth;
using Gantt_Chart_Backend.Data.DTOs;
using Gantt_Chart_Backend.Data.Enums;
using Gantt_Chart_Backend.Data.Models;
using Gantt_Chart_Backend.Services.Interfaces;

namespace Gantt_Chart_Backend.Services.Implementations;

public class TeamService : ITeamService
{
    public Task<Guid> CreateTeam(TeamDto team)
    {
        throw new NotImplementedException();
    }

    public Task AddTeamMember(Guid teamId, Guid memberId)
    {
        throw new NotImplementedException();
    }

    public Task RemoveTeamMember(Guid teamId, Guid memberId)
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

    public Task SetUserRoleInProject(Guid userId, Guid projectId, Role roleId)
    {
        throw new NotImplementedException();
    }

    public ICollection<Permission> GetMemberPermissions()
    {
        var permissions = new List<Permission>();
        
        permissions.Add(new Permission(Permissions.CreateProject));
        permissions.Add(new Permission(Permissions.CreateTask));
        permissions.Add(new Permission(Permissions.ReadTask));
        permissions.Add(new Permission(Permissions.UpdateTask));
        permissions.Add(new Permission(Permissions.DeleteTask));
        permissions.Add(new Permission(Permissions.SetPerformer));
        permissions.Add(new Permission(Permissions.SetTaskDuration));
        permissions.Add(new Permission(Permissions.SetDependence));
        permissions.Add(new Permission(Permissions.AddComment));
        permissions.Add(new Permission(Permissions.RemoveComment));
        permissions.Add(new Permission(Permissions.UpdateTaskStatus));
        permissions.Add(new Permission(Permissions.CreateTeam));
        permissions.Add(new Permission(Permissions.ReadTeam));
        permissions.Add(new Permission(Permissions.UpdateTeam));
        permissions.Add(new Permission(Permissions.DeleteTeam));
        permissions.Add(new Permission(Permissions.DeleteProject));

        return permissions;
    } 
    
    public ICollection<Permission> GetAdminPermissions()
    {
        var permissions =  new List<Permission>();
        
        permissions.Add(new Permission(Permissions.CreateProject));
        permissions.Add(new Permission(Permissions.CreateTask));
        permissions.Add(new Permission(Permissions.ReadTask));
        permissions.Add(new Permission(Permissions.UpdateTask));
        permissions.Add(new Permission(Permissions.DeleteTask));
        permissions.Add(new Permission(Permissions.SetPerformer));
        permissions.Add(new Permission(Permissions.SetTaskDuration));
        permissions.Add(new Permission(Permissions.SetDependence));
        permissions.Add(new Permission(Permissions.AddComment));
        permissions.Add(new Permission(Permissions.RemoveComment));
        permissions.Add(new Permission(Permissions.UpdateTaskStatus));
        permissions.Add(new Permission(Permissions.CreateTeam));
        permissions.Add(new Permission(Permissions.ReadTeam));
        permissions.Add(new Permission(Permissions.UpdateTeam));
        permissions.Add(new Permission(Permissions.DeleteTeam));
        permissions.Add(new Permission(Permissions.DeleteProject));
        permissions.Add(new Permission(Permissions.UpdateProject));
        permissions.Add(new Permission(Permissions.SetRootTask));
        permissions.Add(new Permission(Permissions.SetProjectDuration));
        permissions.Add(new Permission(Permissions.AddUser));
        permissions.Add(new Permission(Permissions.RemoveUser));
        permissions.Add(new Permission(Permissions.SetUserRole));

        return permissions;

    } 
}