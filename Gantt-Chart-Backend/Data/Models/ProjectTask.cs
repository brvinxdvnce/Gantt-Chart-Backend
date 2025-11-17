using Gantt_Chart_Backend.Data.Interfaces;

namespace Gantt_Chart_Backend.Data.Models;

public class ProjectTask
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public Guid ProjectId { get; set; }
    public DateTime StartTime { get; set; } = DateTime.UtcNow;
    public DateTime EndTime { get; set; } = DateTime.UtcNow.AddDays(1);

    public List<IPerformer> Performers { get; set; } = new();
    public List<Dependence> Dependencies { get; set; } = new();
    public List<Comment> Comments { get; set; } = new();
    
    public Project Project { get; set; }
}