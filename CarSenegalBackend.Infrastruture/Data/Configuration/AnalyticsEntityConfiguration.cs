using CarSenegalBakend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarSenegalBackend.Infrastruture.Data.Configuration
{
    public class AnalyticsEntityConfiguration : IEntityTypeConfiguration<AnalyticsEntity>
    {
        public void Configure(EntityTypeBuilder<AnalyticsEntity> builder)
        {
            builder.ToTable("Analytics");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Date)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(a => a.ActiveUsers)
                .IsRequired();

            builder.Property(a => a.TotalReservations)
                .IsRequired();

            builder.Property(a => a.TotalRevenue)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(a => a.TotalCommissions)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            // Ensure that there's only one record per date
            builder.HasIndex(a => a.Date)
                .IsUnique();

            // Add a check constraint to ensure TotalRevenue is not negative
            builder.HasCheckConstraint("CK_Analytics_TotalRevenue", "[TotalRevenue] >= 0");

            // Add a check constraint to ensure TotalCommissions is not negative
            builder.HasCheckConstraint("CK_Analytics_TotalCommissions", "[TotalCommissions] >= 0");

            // Add a computed column for average revenue per reservation
            builder.Property<decimal>("AverageRevenuePerReservation")
                .HasComputedColumnSql("[TotalRevenue] / NULLIF([TotalReservations], 0)", stored: true);
        }
    }
    
}