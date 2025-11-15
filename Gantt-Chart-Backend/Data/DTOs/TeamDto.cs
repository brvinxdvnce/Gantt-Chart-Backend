using Gantt_Chart_Backend.Data.Models;

namespace Gantt_Chart_Backend.Data.DTOs;

public record TeamDto(
    Guid Id,
    Guid LeaderId,
    List<ProjectMember> Members
    );