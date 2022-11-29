using System;
using System.Collections.Generic;

namespace BurgersShop.Models
{
    public partial class Burger
    {
        public Burger()
        {
            OrderBurgers = new HashSet<OrderBurger>();
        }

        public int Id { get; set; }
        public string? MealName { get; set; }
        public string? MealDescription { get; set; }
        public string? ImageFileName { get; set; }
        public double? Price { get; set; }
        public int? Calories { get; set; }

        public virtual ICollection<OrderBurger> OrderBurgers { get; set; }
    }
}
