using Gantt_Chart_Backend.Data.Models;

namespace Gantt_Chart_Backend.Data.DbContext;
using Microsoft.EntityFrameworkCore;

public class GanttPlatformDbContext :  DbContext
{
    public GanttPlatformDbContext(DbContextOptions<GanttPlatformDbContext> options)
        : base(options)
    {
        
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<ProjectMember> ProjectMembers { get; set; }
    public DbSet<ProjectAdmin> ProjectAdmins{ get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<ProjectTask> Tasks { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Dependence> Dependences { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}