using System;
using System.Collections.Generic;

namespace BurgersShop.Models
{
    public partial class OrderBurger
    {
        public OrderBurger()
        {
            OrderExtras = new HashSet<OrderExtra>();
        }

        public int Id { get; set; }
        public int? BurgerId { get; set; }
        public int? OrderId { get; set; }

        public virtual Burger? Burger { get; set; }
        public virtual FoodOrder? Order { get; set; }
        public virtual ICollection<OrderExtra> OrderExtras { get; set; }
    }
}
