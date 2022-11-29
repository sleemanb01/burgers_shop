using System;
using System.Collections.Generic;

namespace BurgersShop.Models
{
    public partial class CustCustomer
    {
        public CustCustomer()
        {
            
        }

        public int Id { get; set; }
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public DateTime? Bdate { get; set; }

    }
}
