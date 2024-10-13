using CarSenegalBakend.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSenegalBakend.Domain.Entities
{
    public class RenterEntity : UserEntity
    {
        public decimal Rating { get; set; }
        public int TotalRatings { get; set; }
        public ICollection<ReservationEntity> Reservations { get; set; }
        public ICollection<PaymentEntity> Payments { get; set; }
    }
}
