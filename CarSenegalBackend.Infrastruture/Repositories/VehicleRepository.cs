using CarSenegalBackend.Infrastruture.Data;
using CarSenegalBakend.Domain.Entities;
using CarSenegalBakend.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSenegalBackend.Infrastruture.Repositories
{
    public class VehicleRepository : Repository<VehicleEntity>, IVehicleRepository
    {
        public VehicleRepository(CarSenegalDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<VehicleEntity>> GetAvailableVehiclesAsync(DateTime startDate, DateTime endDate)
        {
            return await DbSet
                .Where(v => !v.Reservations.Any(r =>
                    (r.StartDate <= startDate && r.EndDate >= startDate) ||
                    (r.StartDate <= endDate && r.EndDate >= endDate) ||
                    (r.StartDate >= startDate && r.EndDate <= endDate)))
                .ToListAsync();
        }

        public async Task<IEnumerable<VehicleEntity>> GetVehiclesByOwnerAsync(Guid ownerId)
        {
            return await DbSet
                 .Where(v => v.OwnerId == ownerId)
                 .ToListAsync(); ;
        }
        private CarSenegalDbContext AppDbContext
        {
            get { return Context as CarSenegalDbContext; }
        }
    }
}
