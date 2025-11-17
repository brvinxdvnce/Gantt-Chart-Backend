using Gantt_Chart_Backend.Data.DTOs;
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

    public Task SetUserRoleInProject(Guid userId, Guid projectId, Guid roleId)
    {
        throw new NotImplementedException();
    }
}