using Gantt_Chart_Backend.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gantt_Chart_Backend.Data.Configurations;

public class TaskConfiguration : IEntityTypeConfiguration<ProjectTask>
{
    public void Configure(EntityTypeBuilder<ProjectTask> builder)
    {
        builder.ToTable("task");

        builder.HasKey(t => t.Id);

        builder.Ignore(t => t.Performers); 
        
        builder.Property(t => t.Name)
            .IsRequired();

        builder.Property(t => t.Description);

        builder.Property(t => t.ProjectId)
            .IsRequired();

        builder.Property(t => t.StartTime)
            .IsRequired();

        builder.Property(t => t.EndTime)
            .IsRequired();
    }
}