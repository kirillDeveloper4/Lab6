using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class LocalPointConfiguration : IEntityTypeConfiguration<LocalPoint>
    {
        public void Configure(EntityTypeBuilder<LocalPoint> builder)
        {
            builder.ToTable("LocalPoints");

            builder.HasIndex(a => a.Id)
                .IsUnique();

            builder.HasMany(r => r.Calls)
                .WithOne(s => s.LocalPoint
                )
                .HasForeignKey(a => a.LocalPointId);
        }
    }
}