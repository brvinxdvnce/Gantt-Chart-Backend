using Gantt_Chart_Backend.Data.DTOs;
using Gantt_Chart_Backend.Data.Enums;

namespace Gantt_Chart_Backend.Data.Models;

public class Dependence
{
    public Guid Id { get; set; }
    public DependencyType Type { get; set; }
    public Guid ChildId { get; set; }
    public Guid ParentId { get; set; }
    
    public ProjectTask ChildTask { get; set; }
    public ProjectTask ParentTask { get; set; }

    public static Dependence FromDto(DependenceDto dto)
    {
        return new Dependence
        {
            Id = Guid.NewGuid(),
            ChildId = dto.ChildId,
            ParentId = dto.ParentId,
            Type = dto.Type
        };
    }

    public bool Completed()
    {
        return Type switch
        {
            DependencyType.FS => ChildTask.EndTime <= ParentTask.StartTime 
                                 && ChildTask.IsCompleted,
            
            DependencyType.SS => ParentTask.StartTime >= ChildTask.EndTime,
            
            DependencyType.FF => ParentTask.EndTime >= ChildTask.EndTime 
                                 && ChildTask.IsCompleted,
            
            DependencyType.SF => ParentTask.EndTime >= ChildTask.StartTime,
            
            _ => false
        };
    }
}