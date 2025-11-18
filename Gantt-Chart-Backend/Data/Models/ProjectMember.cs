using Gantt_Chart_Backend.Data.Enums;
using Gantt_Chart_Backend.Data.Interfaces;

namespace Gantt_Chart_Backend.Data.Models;

public class ProjectMember : IPerformer
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ProjectId { get; set; }
    
    public Role Role { get; set; }
    
    public User User { get; set; }
    public Project Project { get; set; }
}