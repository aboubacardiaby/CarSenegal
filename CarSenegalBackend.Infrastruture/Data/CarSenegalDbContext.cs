using CarSenegalBackend.Infrastruture.Data.Configuration;
using CarSenegalBakend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSenegalBackend.Infrastruture.Data
{
    public class CarSenegalDbContext : DbContext
    {
        public CarSenegalDbContext(DbContextOptions<CarSenegalDbContext> options) : base(options) { }

        public DbSet<RenterEntity> Renters { get; set; }
        public DbSet<VehicleOwnerEntity> VehicleOwner { get; set; }
        public DbSet<PlatformEntity> Platforms { get; set; }
        public DbSet<VehicleEntity> Vehicles { get; set; }
        public DbSet<ReservationEntity> Reservations { get; set; }
        public DbSet<PaymentEntity> Payments { get; set; }
        public DbSet<CommissionEntity> Commissions { get; set; }
        public DbSet<ReviewEntity> Reviews { get; set; }
        public DbSet<SupportTicketEntity> SupportTickets { get; set; }
        public DbSet<AnalyticsEntity> Analytics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlatformEntityConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleOwnerEntityConfiguration());
            modelBuilder.ApplyConfiguration(new RenterEntityConfiguration());
            modelBuilder.ApplyConfiguration(new VehicleEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CommissionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SupportTicketEntityConfiguration());
            modelBuilder.ApplyConfiguration(new AnalyticsEntityConfiguration());
        }
    }
    
}
