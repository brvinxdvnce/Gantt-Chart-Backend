using Gantt_Chart_Backend.Data.Interfaces;

namespace Gantt_Chart_Backend.Data.Models;

public class Project
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid CreatorId { get; set; }
    public DateTime? DeadLine { get; set; }
    public ProjectTask RootTask { get; set; }
    public List<ProjectTask> Tasks { get; set; }
    public List<IPerformer> Members { get; set; }
    
    public User Creator { get; set; }
}