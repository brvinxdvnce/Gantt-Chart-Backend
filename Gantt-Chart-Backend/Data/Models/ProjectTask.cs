using Gantt_Chart_Backend.Data.Interfaces;

namespace Gantt_Chart_Backend.Data.Models;

public class ProjectTask
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public Guid ProjectId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    
    public List<IPerformer> Performers  { get; set; }
    public List<Dependence> Dependencies  { get; set; }
    public List<Comment> Comments { get; set; }
    
    public Project Project { get; set; }
}