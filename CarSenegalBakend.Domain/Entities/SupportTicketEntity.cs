using CarSenegalBakend.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSenegalBakend.Domain.Entities
{
    public class SupportTicketEntity : EntityBase
    {
        public Guid RenterId { get; set; }
        public RenterEntity Renter { get; set; }
        public string Issue { get; set; }
        public string Description { get; set; }
        public TicketStatus Status { get; set; }
        public DateTime CreationDate { get; set; }
        public string Priority { get; set; }
        public string Category { get; set; }
    }
}
