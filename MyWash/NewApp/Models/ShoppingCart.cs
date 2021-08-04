using System;
using System.Collections.Generic;
using System.Text;

namespace NewApp.Models
{
    public class ShoppingCart
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
