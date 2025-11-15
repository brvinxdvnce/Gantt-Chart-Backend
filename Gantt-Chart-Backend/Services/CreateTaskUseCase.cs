using Gantt_Chart_Backend.Data.DbContext;
using Gantt_Chart_Backend.Data.Models;

namespace Gantt_Chart_Backend.Services;

public class CreateTaskUseCase
{
    private readonly GanttPlatformDbContext _context;

    public CreateTaskUseCase(GanttPlatformDbContext  context)
    {
        _context = context;
    }
    public async Task Execute()
    {
        //

        _context.Tasks.Add(new ProjectTask());
    }
}