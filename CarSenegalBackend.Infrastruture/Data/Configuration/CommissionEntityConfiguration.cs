using CarSenegalBakend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarSenegalBackend.Infrastruture.Data.Configuration
{
    public class CommissionEntityConfiguration : IEntityTypeConfiguration<CommissionEntity>
    {
        public void Configure(EntityTypeBuilder<CommissionEntity> builder)
        {
            builder.ToTable("Commissions");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Amount)
                .IsRequired()
                .HasColumnType("decimal(18,2)")
                .HasComment("The amount of commission in the platform's base currency");

            builder.Property(c => c.Date)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasComment("The date and time when the commission was calculated and recorded");

            builder.Property(c => c.Rate)
                .IsRequired()
                .HasColumnType("decimal(5,2)")
                .HasComment("The commission rate applied, stored as a percentage (e.g., 10.00 for 10%)");

            builder.Property(c => c.Status)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("The status of the commission (e.g., Pending, Paid, Cancelled)")
                .HasConversion<string>();

            // Relationship with Payment
            builder.HasOne(c => c.Payment)
                .WithOne()
                .HasForeignKey<CommissionEntity>("PaymentId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Index for faster queries on date
            builder.HasIndex(c => c.Date);

            // Index for faster queries on status
            builder.HasIndex(c => c.Status);

            // Add audit fields
            builder.Property(c => c.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()")
                .HasComment("The date and time when the commission record was created");

            builder.Property(c => c.UpdatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAddOrUpdate()
                .HasComment("The date and time when the commission record was last modified");
        }
    }
}