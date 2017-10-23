using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutosRa.API.Models
{
    public class VehicleResponse
    {
        
        public int VehicleId { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public bool IsActive { get; set; }

        
        public DateTime LastPurchase { get; set; }

        public string Image { get; set; }

        public double Stock { get; set; }

        
        public string Remarks { get; set; }

        
    }
}