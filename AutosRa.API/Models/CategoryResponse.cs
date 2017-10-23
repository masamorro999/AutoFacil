using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutosRa.API.Models
{
    public class CategoryResponse
    {
        public int CategoryId { get; set; }

        public string Description { get; set; }

        public List<VehicleResponse> Vehicles { get; set; }
    }
}