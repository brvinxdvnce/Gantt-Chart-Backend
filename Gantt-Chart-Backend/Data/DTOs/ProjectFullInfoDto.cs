using Gantt_Chart_Backend.Data.Interfaces;
using Gantt_Chart_Backend.Data.Models;

namespace Gantt_Chart_Backend.Data.DTOs;

public record ProjectFullInfoDto
{
    Guid Id { get; set; }
    string Name { get; set; }
    User Creator { get; set; }
    DateTime DeadLine { get; set; }
    ProjectTask RootTask { get; set; }
    List<ProjectTask> Tasks { get; set; }
    List<IPerformer> Members { get; set; }
}