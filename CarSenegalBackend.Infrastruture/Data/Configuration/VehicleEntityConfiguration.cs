using CarSenegalBakend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSenegalBackend.Infrastruture.Data.Configuration
{
    public class VehicleEntityConfiguration : IEntityTypeConfiguration<VehicleEntity>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<VehicleEntity> builder)
        {
            builder.HasKey(v => v.Id);

            builder.Property(v => v.Make)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(v => v.Model)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(v => v.Year)
                .IsRequired();

            builder.Property(v => v.LicensePlate)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(v => v.Type)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(v => v.DailyRate)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(v => v.Description)
                .HasMaxLength(500);

            builder.HasOne(v => v.Owner)
                .WithMany(o => o.Vehicles)
                .HasForeignKey("OwnerId")
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property<DateTime>("CreatedAt")
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property<DateTime>("UpdatedAt")
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            builder.HasIndex(v => v.LicensePlate)
                .IsUnique();

            // Configure the Photos property as a JSON column
            builder.Property(v => v.Photos)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList())
                .HasColumnType("nvarchar(max)");
        }
    }
}
