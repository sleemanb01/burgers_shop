using System;
using System.Collections.Generic;


namespace BurgersShop.Models
{
   public partial class OrederContent
    {
        
        public virtual Side[]? OrderSide { get; set; }
        public virtual Burger? iOrderBurger { get; set; }
        public virtual int?  customerId{ get; set; }
        public virtual Extra[]? OrderExtras { get; set; }
    }
}