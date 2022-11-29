using System;
using System.Collections.Generic;

namespace BurgersShop.Models
{
    public partial class Customer
    {
        public Customer()
        {
            FoodOrders = new HashSet<FoodOrder>();
        }

        public int Id { get; set; }
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public string? Phone { get; set; }
        public string? Pass { get; set; }
        public string? Email { get; set; }
        public DateTime? Bdate { get; set; }

         public virtual ICollection<FoodOrder>? FoodOrders { get; set; } //*****navigation ITEM
    }
}
