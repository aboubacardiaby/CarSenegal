using CarSenegalBakend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarSenegalBackend.Infrastruture.Data.Configuration
{
    public class SupportTicketEntityConfiguration : IEntityTypeConfiguration<SupportTicketEntity>
    {
        public void Configure(EntityTypeBuilder<SupportTicketEntity> builder)
        {
            builder.ToTable("SupportTickets");

            builder.HasKey(st => st.Id);

            builder.Property(st => st.Issue)
                .IsRequired()
                .HasMaxLength(100)
                .HasComment("Brief description of the issue");

            builder.Property(st => st.Description)
                .IsRequired()
                .HasMaxLength(2000)
                .HasComment("Detailed description of the issue");

            builder.Property(st => st.Status)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("The current status of the support ticket (e.g., Open, InProgress, Resolved, Closed)")
                .HasConversion<string>();

            builder.Property(st => st.Priority)
                .IsRequired()
                .HasMaxLength(20)
                .HasComment("The priority level of the ticket (e.g., Low, Medium, High, Urgent)")
                .HasConversion<string>();

            builder.Property(st => st.Category)
                .IsRequired()
                .HasMaxLength(50)
                .HasComment("The category of the support ticket (e.g., Technical, Billing, Account, Reservation)")
                .HasConversion<string>();

            builder.Property(st => st.CreationDate)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasDefaultValueSql("GETUTCDATE()")
                .HasComment("The date and time when the ticket was created");

            builder.Property(st => st.UpdatedAt)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAddOrUpdate()
                .HasComment("The date and time when the ticket was last updated");

            // Relationship with User who created the ticket
            builder.HasOne(st => st.Renter)
                .WithMany()
                .HasForeignKey("RenterId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Indexes for faster querying
            builder.HasIndex(st => st.CreationDate);
            builder.HasIndex(st => st.Status);
            builder.HasIndex(st => st.Priority);
            builder.HasIndex("RenterId");
        }
    }
}