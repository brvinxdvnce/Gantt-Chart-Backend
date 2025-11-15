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

    public Task<Guid> CreateProject(string name, Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateProject(ProjectDto projectDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteProject(Guid projectId, Guid userId)
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

    
    Task<ProjectFullInfoDto> IProjectService.GetFullProjectInfo(Guid projectId, Guid userId)
    {
        throw new NotImplementedException();
    }
}