using Gantt_Chart_Backend.Data.DTOs;
using Gantt_Chart_Backend.Data.Enums;

namespace Gantt_Chart_Backend.Data.Models;

public class Dependence
{
    public DependencyType Type { get; set; }
    public Guid ChildId { get; set; }
    public Guid ParentId { get; set; }
    
    public ProjectTask ChildTask { get; set; }
    public ProjectTask ParentTask { get; set; }

    public static Dependence FromDto(DependenceDto dto)
    {
        return new Dependence
        {
            ChildId = dto.ChildId,
            ParentId = dto.ParentId,
            Type = dto.Type
        };
    } 
}