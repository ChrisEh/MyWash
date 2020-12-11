﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NewApp.Models
{
    public class ProductByCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Detail { get; set; }
        public int CetegoryId { get; set; }
        public string ImageUrl { get; set; }
    }
}