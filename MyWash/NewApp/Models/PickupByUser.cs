using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NewApp.Models
{
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
    }
}
