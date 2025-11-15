using Gantt_Chart_Backend.Data.Interfaces;
using Gantt_Chart_Backend.Data.Models;

namespace Gantt_Chart_Backend.Data.DTOs;

public record ProjectTaskDto(
    Guid? ProjectId,
    string? Name,
    string? Description,
    bool? IsCompleted,
    List<Dependence>?  Dependences,
    DateTime? StartTime,
    DateTime? EndTime
    );