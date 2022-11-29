using System;
using System.Collections.Generic;

namespace BurgersShop.Models
{
    public partial class OrderExtra
    {
        public int Id { get; set; }
        public int? OrderExtra1 { get; set; }
        public int? OrderBurgerId { get; set; }

        public virtual OrderBurger? OrderBurger { get; set; }
        public virtual Extra? OrderExtra1Navigation { get; set; }
    }
}
