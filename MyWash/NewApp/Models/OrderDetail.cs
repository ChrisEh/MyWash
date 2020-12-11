﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NewApp.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public int Qty { get; set; }
        public double TotalAmount { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}