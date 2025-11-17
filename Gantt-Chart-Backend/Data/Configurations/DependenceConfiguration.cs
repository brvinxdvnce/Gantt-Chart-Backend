using Gantt_Chart_Backend.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gantt_Chart_Backend.Data.Configurations;

public class DependenceConfiguration : IEntityTypeConfiguration<Dependence>
{
    public void Configure(EntityTypeBuilder<Dependence> builder)
    {
        builder.ToTable("dependence");
    }
}