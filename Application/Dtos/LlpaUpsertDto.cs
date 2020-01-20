using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enums;
using Domain.Entities;

namespace Application.Dtos
{
    public class LlpaUpsertDto
    {
        public Occupancy? Occupancy { get; set; }

        public Purpose? Purpose { get; set; }

        public PropertyType? PropertyType { get; set; }

        public decimal PriceAdjustment { get; set; }

        public decimal? PriceCeiling { get; set; }

        public decimal? PriceFloor { get; set; }

        public Llpa Map()
        {
            return new Llpa
            {
                Occupancy = Occupancy,
                Purpose = Purpose,
                PropertyType = PropertyType,
                PriceAdjustment = PriceAdjustment,
                PriceCeiling = PriceCeiling,
                PriceFloor = PriceFloor
            };
        }
    }
}
