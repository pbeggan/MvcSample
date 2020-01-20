using System;
using System.Collections.Generic;
using System.Text;
using Domain.Enums;

namespace Domain.Entities
{
    public class PriceItem
    {
        public int PriceItemId { get; set; }

        public decimal Rate { get; set; }

        public int Days { get; set; }

        public decimal Price { get; set; }
    }
}
