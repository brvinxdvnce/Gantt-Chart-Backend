namespace Gantt_Chart_Backend.Data.Models;

public class Comment
{
    public Guid AuthorId { get; set; }
    public User Author { get; set; }
}