using CarSenegalBakend.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSenegalBakend.Domain.Entities
{
    public class ReviewEntity : EntityBase
    {
        public Guid ReviewerId { get; set; }
        public Guid RevieweeId { get; set; }
        public RenterEntity Renter { get; set; }
        public VehicleOwnerEntity VehicleOwner { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
        public ReviewStatus Status { get; set; }
    }
}
