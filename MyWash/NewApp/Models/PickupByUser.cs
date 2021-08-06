using System;

namespace NewApp.Models
{
    public enum PickupStatus
    {
        Requested,
        Washing,
        OutForDelivery,
        PaymentPending,
        Finished
    }

    public class PickupByUser
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public double PickupTotal { get; set; }
        public DateTime PickupPlaced { get; set; }
        public bool IsPickupCompleted { get; set; }
        public int UserId { get; set; }
        public object PickupDetails { get; set; }
        public PickupStatus PickupStatus { get; set; }
    }
}
