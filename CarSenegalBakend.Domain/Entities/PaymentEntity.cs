using CarSenegalBakend.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSenegalBakend.Domain.Entities
{
    public class PaymentEntity : EntityBase
    {
        public Guid ReservationId { get; set; }
        public Guid RenterId { get; set; }
        public ReservationEntity Reservation { get; set; }
        public RenterEntity Renter { get; set; }
        public decimal Amount { get; set; }
        public decimal CommissionAmount { get; set; }
        public decimal OwnerPayout { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentStatus Status { get; set; }
        public string PaymentMethod { get; set; }
        public string TransactionId { get; set; }

    }
}
