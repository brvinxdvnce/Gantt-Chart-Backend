namespace Gantt_Chart_Backend.Data.Models;

public class Comment
{
    public Guid TaskId { get; set; }
    public Guid Id { get; set; }
    public Guid AuthorId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public Project Project { get; set; }
    public User Author { get; set; }
}