using System;
using System.Collections.Generic;
using System.Text;

namespace NewApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int OrderTotal { get; set; }
        public DateTime OrderPlaced { get; set; }
        public bool IsOrderCompleted { get; set; }
        public bool IsOrderCancelled { get; set; }
        public int UserId { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
