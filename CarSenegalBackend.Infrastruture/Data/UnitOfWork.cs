using CarSenegalBackend.Infrastruture.Repositories;
using CarSenegalBakend.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSenegalBackend.Infrastruture.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CarSenegalDbContext _context;
        private VehicleRepository _vehicleRepository;

        public UnitOfWork(CarSenegalDbContext context)
        {
            _context = context;
        }

        public IVehicleRepository Vehicles => _vehicleRepository ??= new VehicleRepository(_context);

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
