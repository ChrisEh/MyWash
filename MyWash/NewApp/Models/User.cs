using System;
using System.Collections.Generic;

namespace NewApp.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public ICollection<Order> Orders { get; set; }
        public string Place { get; set; }
        public string PostCode { get; set; }
        public string PhoneNumber { get; set; }
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
    }
}
