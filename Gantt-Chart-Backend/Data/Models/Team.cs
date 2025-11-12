using Gantt_Chart_Backend.Data.Interfaces;

namespace Gantt_Chart_Backend.Data.Models;

public class Team : IPerformer
{
    public Guid Id { get; set; }
    public Guid LeaderId { get; set; }
    public List<ProjectMember> Performers { get; set; }
    
    public ProjectMember Leader { get; set; }
}