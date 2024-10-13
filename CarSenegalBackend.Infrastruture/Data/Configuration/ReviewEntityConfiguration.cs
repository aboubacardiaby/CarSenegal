using CarSenegalBakend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarSenegalBackend.Infrastruture.Data.Configuration
{
    public class ReviewEntityConfiguration : IEntityTypeConfiguration<ReviewEntity>
    {
        public void Configure(EntityTypeBuilder<ReviewEntity> builder)
        {
            builder.ToTable("Reviews");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Rating)
                .IsRequired()
                .HasColumnType("decimal(3,1)")
                .HasComment("The rating given in the review (e.g., 4.5)");

            builder.Property(r => r.Comment)
                .HasMaxLength(1000)
                .HasComment("The text content of the review");

            builder.Property(r => r.ReviewDate)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasComment("The date and time when the review was submitted");

            // Relationship with Reviewer (User who wrote the review)
            builder.HasOne(r => r.Renter)
                .WithMany()
                .HasForeignKey("ReviewerId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Relationship with Reviewee (User being reviewed)
            builder.HasOne(r => r.VehicleOwner)
                .WithMany()
                .HasForeignKey("RevieweeId")
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Indexes for faster querying
            builder.HasIndex(r => r.ReviewDate);
            builder.HasIndex(r => r.Rating);
            builder.HasIndex("ReviewerId");
            builder.HasIndex("RevieweeId");

            // Add audit fields
            builder.Property<DateTime>("CreatedAt")
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()")
                .HasComment("The date and time when the review record was created");

            builder.Property<DateTime>("UpdatedAt")
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAddOrUpdate()
                .HasComment("The date and time when the review record was last modified");

            // Add a field for review status (e.g., Pending, Approved, Rejected)
            builder.Property(r => r.Status)
                .IsRequired()
                .HasMaxLength(50)
                .HasDefaultValue("Pending")
                .HasComment("The status of the review (e.g., Pending, Approved, Rejected)")
                .HasConversion<string>();
        }
    }
}