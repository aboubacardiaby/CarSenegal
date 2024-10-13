using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSenegalBakend.Domain.Entities
{
    public class VehicleOwnerEntity : UserEntity
    {
        public float Rating { get; set; }
        public int TotalRatings { get; set; }
        public string BusinessName { get; set; }
        public bool IsVerified { get; set; }
        public string PreferredPayoutFrequency { get; set; }
        public DateTime? VerificationDate { get; set; }
        public ICollection<VehicleEntity> Vehicles { get; set; }
    }
}
