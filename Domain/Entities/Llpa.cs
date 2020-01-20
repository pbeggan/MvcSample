using System;
using System.Collections.Generic;
using System.Text;
using Domain.Enums;

namespace Domain.Entities
{
    public class Llpa
    {
        public int LlpaId { get; set; }

        public Occupancy? Occupancy { get; set; }

        public Purpose? Purpose { get; set; }

        public PropertyType? PropertyType { get; set; }

        public decimal PriceAdjustment { get; set; }

        public decimal? PriceCeiling { get; set; }

        public decimal? PriceFloor { get; set; }
    }
}
