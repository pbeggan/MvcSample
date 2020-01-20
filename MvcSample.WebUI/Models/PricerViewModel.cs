using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enums;
using Application.Dtos;

namespace MvcSample.WebUI.Models
{
    public class PricerViewModel
    {
        public PricerViewModel()
        {
            Rates = new Dictionary<decimal, List<PriceDto>>();
        }

        public Occupancy Occupancy { get; set; }

        public Purpose Purpose { get; set; }

        public PropertyType PropertyType { get; set; }

        public Dictionary<decimal, List<PriceDto>> Rates { get; set; }

        public int LlpaCount { get; set; }
    }
}
