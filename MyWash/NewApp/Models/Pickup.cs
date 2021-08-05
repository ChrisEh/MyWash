using System;

namespace NewApp.Models
{
    public class Pickup
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public DateTime PickupPlaced { get; set; }
        public bool IsPickupCompleted { get; set; }
        public double PickupTotal { get; set; }
    }
}