using Gantt_Chart_Backend.Data.DbContext;
using Gantt_Chart_Backend.Data.DTOs;
using Gantt_Chart_Backend.Data.Models;

namespace Gantt_Chart_Backend.Services.Interfaces;

public interface IProjectService
{
    public Task<Guid> CreateProject(string name, Guid userId);
    public Task UpdateProject(ProjectDto projectDto);
    public Task DeleteProject(Guid projectId, Guid userId);
    public Task<ProjectFullInfoDto> GetFullProjectInfo (Guid projectId, Guid userId);
}