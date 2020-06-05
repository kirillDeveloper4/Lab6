using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    class SensorDataConfiguration : IEntityTypeConfiguration<SensorData>
    {
        public void Configure(EntityTypeBuilder<SensorData> builder)
        {
            builder.ToTable("SensorDatas");

            builder.HasIndex(a => a.Id)
                .IsUnique();

            builder.HasOne(s => s.Sensor)
                .WithMany(s => s.SensorData)
                .HasForeignKey(a => a.SensorId);
        }
    }
}
