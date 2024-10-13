using CarSenegalBakend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarSenegalBackend.Infrastruture.Data.Configuration
{
    public class ReservationEntityConfiguration : IEntityTypeConfiguration<ReservationEntity>
    {
        public void Configure(EntityTypeBuilder<ReservationEntity> builder)
        {
            builder.ToTable("Reservations");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.StartDate)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasComment("The start date and time of the reservation");

            builder.Property(r => r.EndDate)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasComment("The end date and time of the reservation");

            builder.Property(r => r.TotalCost)
                .IsRequired()
                .HasColumnType("decimal(18,2)")
                .HasComment("The total cost of the reservation");

            builder.Property(r => r.Status)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("The status of the reservation (e.g., Pending, Confirmed, Cancelled, Completed)")
                .HasConversion<string>();

            // Relationship with Vehicle
            builder.HasOne(r => r.Vehicle)
                .WithMany(v => v.Reservations)
                .HasForeignKey("VehicleId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Relationship with Renter
            builder.HasOne(r => r.Renter)
                .WithMany(renter => renter.Reservations)
                .HasForeignKey("RenterId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Relationship with Payment (optional, as payment might be made later)
            builder.HasOne(r => r.Payment)
                .WithOne(p => p.Reservation)
                .HasForeignKey<PaymentEntity>("ReservationId")
                .OnDelete(DeleteBehavior.Restrict);

            // Indexes for faster querying
            builder.HasIndex(r => r.StartDate);
            builder.HasIndex(r => r.EndDate);
            builder.HasIndex(r => r.Status);
            builder.HasIndex("VehicleId", "StartDate", "EndDate");
            builder.HasIndex("RenterId", "Status");

            // Add audit fields
            builder.Property<DateTime>("CreatedAt")
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()")
                .HasComment("The date and time when the reservation was created");

            builder.Property<DateTime>("UpdatedAt")
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAddOrUpdate()
                .HasComment("The date and time when the reservation was last modified");

            // Add a field for cancellation reason
            builder.Property(r => r.CancellationReason)
                .HasMaxLength(500)
                .HasComment("The reason for cancellation, if applicable");
    }
    }
}