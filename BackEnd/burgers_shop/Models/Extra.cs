using System;
using System.Collections.Generic;

namespace BurgersShop.Models
{
    public partial class Extra
    {
        public Extra()
        {
            OrderExtras = new HashSet<OrderExtra>();
        }

        public int Id { get; set; }
        public string? MealName { get; set; }
        public string? MealDescription { get; set; }
        public string? ImageFileName { get; set; }
        public double? Price { get; set; }
        public int? Calories { get; set; }

        public virtual ICollection<OrderExtra> OrderExtras { get; set; }
    }
}
