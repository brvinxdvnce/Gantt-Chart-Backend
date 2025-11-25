using Gantt_Chart_Backend.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gantt_Chart_Backend.Data.Configurations;

public class ProjectMemberConfiguration : IEntityTypeConfiguration<ProjectMember>
{
    public void Configure(EntityTypeBuilder<ProjectMember> builder)
    {
        builder.ToTable("project_member");

        builder.HasKey(pm => pm.Id);

        builder.HasMany(pm => pm.Permissions).WithMany();
        
        builder.Property(pm => pm.Id)
            .IsRequired();

        builder.Property(pm => pm.ProjectId)
            .IsRequired();

        builder.Property(pm => pm.Role)
            .IsRequired();
            
        builder.HasOne(pm => pm.User)
            .WithMany(u => u.Roles)
            .HasForeignKey(pm => pm.Id)
            .OnDelete(DeleteBehavior.Cascade);
            
        builder.HasOne(pm => pm.Project)
            .WithMany()
            .HasForeignKey(pm => pm.ProjectId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}