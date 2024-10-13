using CarSenegalBakend.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSenegalBakend.Domain.Entities
{
    public class AnalyticsEntity : EntityBase
    {
        public DateTime Date { get; set; }
        public int ActiveUsers { get; set; }
        public int TotalReservations { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal TotalCommissions { get; set; }
        public decimal AverageRevenuePerReservation { get; set; }
    }
}
