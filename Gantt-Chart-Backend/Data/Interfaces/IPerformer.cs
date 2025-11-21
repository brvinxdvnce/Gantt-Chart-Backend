using System.ComponentModel.DataAnnotations.Schema;

namespace Gantt_Chart_Backend.Data.Interfaces;

[NotMapped]
public abstract class Performer
{
    public Guid Id { get; set; }
}