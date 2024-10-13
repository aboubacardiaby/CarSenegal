using CarSenegalBakend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSenegalBakend.Domain.Interfaces.Repositories
{
    public interface IVehicleRepository : IRepository<VehicleEntity>
    {
        Task<IEnumerable<VehicleEntity>> GetAvailableVehiclesAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<VehicleEntity>> GetVehiclesByOwnerAsync(Guid ownerId);
    }
}
