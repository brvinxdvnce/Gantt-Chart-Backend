
namespace Gantt_Chart_Backend.Data.Models;

public class Team
{
    public Guid Id { get; set; }
    public Guid LeaderId { get; set; }
    
    public Guid ProjectId { get; set; }
    public List<ProjectMember> Performers { get; set; }
    public ProjectMember Leader { get; set; }
    public Project Project { get; set; }
}