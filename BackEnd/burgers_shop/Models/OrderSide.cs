using System;
using System.Collections.Generic;

namespace BurgersShop.Models
{
    public partial class OrderSide
    {
        public OrderSide(){}
        public int Id { get; set; }
        public int? SideId { get; set; }
        public int? OrderId { get; set; }

        public virtual FoodOrder? Order { get; set; }
        public virtual Side? OrderSide1Navigation { get; set; }
    }
}
