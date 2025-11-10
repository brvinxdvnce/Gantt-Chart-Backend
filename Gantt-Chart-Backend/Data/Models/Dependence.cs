using Gantt_Chart_Backend.Data.Enums;

namespace Gantt_Chart_Backend.Data.Models;

public class Dependence
{
    public DependencyType Type { get; set; }
    public Guid ChildId { get; set; }
    
    public ProjectTask ChildTask { get; set; }
}