using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enums;
using Domain.Entities;

namespace Application.Dtos
{
    public class PriceDto
    {
        public int Days { get; set; }

        public decimal Rate { get; set; }

        public decimal Price { get; set; }

        public decimal AdjustedPrice { get; set; }

        public bool IsValid { get; set; }
    }
}
