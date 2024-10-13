using CarSenegalBakend.Domain.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSenegalBakend.Domain.Entities
{
    public class ReservationEntity : EntityBase
    {
        public Guid VehicleId { get; set; }
        public Guid RenterId { get; set; }
        public VehicleEntity Vehicle { get; set; }
        public RenterEntity Renter { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalCost { get; set; }
        public ReservationStatus Status { get; set; }
        public PaymentEntity Payment { get; set; }
        public string CancellationReason {  get; set; }

    }
}
