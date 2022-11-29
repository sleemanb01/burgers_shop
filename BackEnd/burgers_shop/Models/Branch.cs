using System;
using System.Collections.Generic;

namespace BurgersShop.Models
{
    public partial class Branch
    {
        public int Id { get; set; }
        public string? BranchName { get; set; }
        public string? Street { get; set; }
        public int? HouseNum { get; set; }
        public string? City { get; set; }
        public string? Phone { get; set; }
        public string? OpeningHrs { get; set; }
    }
}
