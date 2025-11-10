using Gantt_Chart_Backend.Data.Models;

namespace Gantt_Chart_Backend.Data.DbContext;
using Microsoft.EntityFrameworkCore;

public class AppDbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectTask> Tasks { get; set; }
}