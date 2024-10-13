using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSenegalBakend.Domain.Common
{
    public enum VehicleType
    {
        Sedan,
        SUV,
        Van,
        Truck
    }

    public enum ReservationStatus
    {
        Pending,
        Confirmed,
        Cancelled,
        Completed
    }

    public enum PaymentStatus
    {
        Pending,
        Completed,
        Failed,
        Refunded
    }

    public enum TicketStatus
    {
        Open,
        InProgress,
        Resolved,
        Closed
    }

    public enum UserRole
    {
        VehicleOwner,
        Renter
    }

    public enum ECommissionStatus { 
        Pending, 
        Paid, 
        Cancelled
    }

    public enum ReviewStatus { 
        Pending,
        Approved,
        Rejected
    }
}
