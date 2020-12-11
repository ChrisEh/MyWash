using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NewApp.Models
{
    public class OrderByUser
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public double OrderTotal { get; set; }
        public DateTime OrderPlaced { get; set; }
        public bool IsOrderCompleted { get; set; }
        public int UserId { get; set; }
        public object OrderDetails { get; set; }
    }
}
