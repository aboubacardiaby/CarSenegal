using CarSenegalBakend.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSenegalBakend.Domain.Entities
{
    public class CommissionEntity : EntityBase
    {
        public Guid PaymentId { get; set; }
        public PaymentEntity Payment { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public ECommissionStatus Status { get; set; }

    }
}
