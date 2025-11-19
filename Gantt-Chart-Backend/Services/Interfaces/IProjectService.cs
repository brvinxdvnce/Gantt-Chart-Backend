using Gantt_Chart_Backend.Data.DbContext;
using Gantt_Chart_Backend.Data.DTOs;
using Gantt_Chart_Backend.Data.Models;

namespace Gantt_Chart_Backend.Services.Interfaces;

public interface IProjectService
{
    public Task<Guid> CreateProject(ProjectDto project);
    public Task UpdateProject(Guid projectId, ProjectDto projectDto);
    public Task DeleteProject(Guid projectId, Guid userId);
    public Task<ProjectOnLoadDto> GetFullProjectInfo (Guid projectId, Guid userId);
}