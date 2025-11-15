using Gantt_Chart_Backend.Services.Interfaces;

namespace Gantt_Chart_Backend.Services.Implementations;

public class TeamService : ITeamService
{
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
}