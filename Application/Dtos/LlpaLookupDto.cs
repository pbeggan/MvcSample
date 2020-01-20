using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enums;
using Domain.Entities;

namespace Application.Dtos
{
    public class LlpaLookupDto
    {
        public string Occupancy { get; set; }

        public string Purpose { get; set; }

        public string PropertyType { get; set; }

        public decimal PriceAdjustment { get; set; }

        public decimal? PriceCeiling { get; set; }

        public decimal? PriceFloor { get; set; }
    }
}
