using CarSenegalBakend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarSenegalBackend.Infrastruture.Data.Configuration
{
    public class VehicleOwnerEntityConfiguration : IEntityTypeConfiguration<VehicleOwnerEntity>
    {
        public void Configure(EntityTypeBuilder<VehicleOwnerEntity> builder)
        {
            builder.ToTable("VehicleOwners");
            
            builder.HasKey(x => x.Id);

            // Properties specific to VehicleOwner
            builder.Property(vo => vo.Rating)
                .HasColumnType("decimal(3,2)")
                .HasComment("The overall rating of the vehicle owner");

            builder.Property(vo => vo.TotalRatings)
                .IsRequired()
                .HasComment("The total number of ratings received");

            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(u => u.Phone)
                .IsRequired()
                .HasMaxLength(20);

            
            // Additional properties for VehicleOwner
            builder.Property(vo => vo.BusinessName)
                .HasMaxLength(100)
                .HasComment("Business name, if the owner is a company");

            builder.Property(vo => vo.PreferredPayoutFrequency)
                .IsRequired()
                .HasMaxLength(20)
                .HasComment("Preferred frequency for payouts (e.g., Weekly, Biweekly, Monthly)")
                .HasConversion<string>();

            builder.Property(vo => vo.IsVerified)
                .IsRequired()
                .HasDefaultValue(false)
                .HasComment("Indicates if the vehicle owner's account is verified");

            builder.Property(vo => vo.VerificationDate)
                .HasColumnType("datetime2")
                .HasComment("Date when the owner's account was verified");

            // Relationship with Vehicles
            builder.HasMany(vo => vo.Vehicles)
                .WithOne(v => v.Owner)
                .HasForeignKey("OwnerId")
                .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder.HasIndex(vo => vo.Rating);
            builder.HasIndex(vo => vo.IsVerified);
            builder.HasIndex(u => u.Email)
                .IsUnique();
            builder.HasIndex(u => u.Phone)
                .IsUnique();

            // Audit fields
            builder.Property(vo => vo.CreatedAt)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasDefaultValueSql("GETUTCDATE()")
                .HasComment("The date and time when the vehicle owner account was created");

            builder.Property(vo => vo.UpdatedAt)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasDefaultValueSql("GETUTCDATE()")
                .ValueGeneratedOnAddOrUpdate()
                .HasComment("The date and time when the vehicle owner account was last modified");
        }
    }
}