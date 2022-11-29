using System;
using System.Collections.Generic;

namespace BurgersShop.Models
{
    public partial class FoodOrder
    {
        public FoodOrder()
        {
            OrderBurgers = new HashSet<OrderBurger>();
            OrderSides = new HashSet<OrderSide>();
        }

        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? OrderDate { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual ICollection<OrderBurger> OrderBurgers { get; set; }
        public virtual ICollection<OrderSide> OrderSides { get; set; }
    }
}
