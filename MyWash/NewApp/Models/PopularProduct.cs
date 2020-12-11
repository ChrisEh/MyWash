using System;
using System.Collections.Generic;
using System.Text;

namespace NewApp.Models
{
    public class PopularProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public string FullImageUrl => AppSettings.ApiUrl.TrimEnd(new char[] { 'a', 'p', 'i' }) + ImageUrl;
    }
}
