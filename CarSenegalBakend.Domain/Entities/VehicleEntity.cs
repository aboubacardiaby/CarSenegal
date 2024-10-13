using CarSenegalBakend.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSenegalBakend.Domain.Entities
{
    public class VehicleEntity : EntityBase
    {
        public Guid OwnerId { get; set; }
        public VehicleOwnerEntity Owner { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string LicensePlate { get; set; }
        public VehicleType Type { get; set; }
        public float DailyRate { get; set; }
        public string Description { get; set; }
        public List<string> Photos { get; set; }
        public ICollection<ReservationEntity> Reservations { get; set; }

    }
}
