using CarSenegalBakend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarSenegalBackend.Infrastruture.Data.Configuration
{
    public class PaymentEntityConfiguration : IEntityTypeConfiguration<PaymentEntity>
    {
        public void Configure(EntityTypeBuilder<PaymentEntity> builder)
        {
            builder.ToTable("Payments");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Amount)
                .IsRequired()
                .HasColumnType("decimal(18,2)")
                .HasComment("The total amount of the payment");

            builder.Property(p => p.CommissionAmount)
                .IsRequired()
                .HasColumnType("decimal(18,2)")
                .HasComment("The amount of commission deducted from the total payment");

            builder.Property(p => p.OwnerPayout)
                .IsRequired()
                .HasColumnType("decimal(18,2)")
                .HasComment("The amount paid out to the vehicle owner");

            builder.Property(p => p.PaymentDate)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasComment("The date and time when the payment was made");

            builder.Property(p => p.Status)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("The status of the payment (e.g., Pending, Completed, Failed, Refunded)")
                .HasConversion<string>();

            builder.Property(p => p.PaymentMethod)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("The method used for payment (e.g., CreditCard, PayPal, BankTransfer)")
                .HasConversion<string>();

            builder.Property(p => p.TransactionId)
                .HasMaxLength(100)
                .HasComment("The transaction ID from the payment processor");

            // Relationship with Reservation
            builder.HasOne(p => p.Reservation)
                .WithOne()
                .HasForeignKey<PaymentEntity>("ReservationId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Relationship with Renter (the user making the payment)
            builder.HasOne<RenterEntity>()
                .WithMany()
                .HasForeignKey("RenterId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Index for faster queries on PaymentDate
            builder.HasIndex(p => p.PaymentDate);

            // Index for faster queries on Status
            builder.HasIndex(p => p.Status);

            // Composite index for RenterId and Status for quick lookup of a user's payments with a certain status
            builder.HasIndex("RenterId", "Status");


            // Add audit fields
            builder.Property<DateTime>("CreatedAt")
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()")
                .HasComment("The date and time when the payment record was created");

            builder.Property<DateTime>("UpdatedAt")
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAddOrUpdate()
                .HasComment("The date and time when the payment record was last modified");
        }
    }
    
}