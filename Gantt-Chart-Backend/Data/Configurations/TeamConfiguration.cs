using Gantt_Chart_Backend.Data.Interfaces;
using Gantt_Chart_Backend.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gantt_Chart_Backend.Data.Configurations;

public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        builder.ToTable("team");

        builder.HasKey(t => t.Id);

        builder.Ignore(t => t.Performers);
        
        builder.Property(t => t.LeaderId)
            .IsRequired();
            
        builder.HasOne(t => t.Leader)
            .WithMany() 
            .HasForeignKey(t => t.LeaderId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
