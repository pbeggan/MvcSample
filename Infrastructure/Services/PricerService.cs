using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Interfaces;
using System.Threading;
using Domain.Entities;

namespace Infrastructure.Services
{
    public class PricerService : IPricerService
    {
        private ISampleDbContext _ctx;

        private static readonly List<PriceItem> Prices = new List<PriceItem>
        {
            new PriceItem{Rate = 3.00m, Days = 15, Price = 100m},
            new PriceItem{Rate = 3.00m, Days = 30, Price = 100.25m},
            new PriceItem{Rate = 3.00m, Days = 45, Price = 100.50m},
            new PriceItem{Rate = 3.00m, Days = 60, Price = 100.75m},
            new PriceItem{Rate = 3.00m, Days = 75, Price = 101m},
            new PriceItem{Rate = 4.25m, Days = 15, Price = 102m},
            new PriceItem{Rate = 4.25m, Days = 30, Price = 102.25m},
            new PriceItem{Rate = 4.25m, Days = 45, Price = 102.50m},
            new PriceItem{Rate = 4.25m, Days = 60, Price = 102.75m},
            new PriceItem{Rate = 4.25m, Days = 75, Price = 103m}
        };

        public PricerService(ISampleDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<ICollection<PriceDto>> GetAdjustedPrices(LoanDto dto, CancellationToken cancellationToken)
        {
            var dtos = new List<PriceDto>();

            var llpas = _ctx.Llpas.ToList();

            var validLlpas = GetValidLlpas(dto, llpas);

            var priceAdjustment = validLlpas.Sum(s => s.PriceAdjustment);
            var priceCeiling = validLlpas.Count > 0 ? validLlpas.Min(m => m.PriceCeiling ?? decimal.MaxValue) : decimal.MaxValue;
            var priceFloor = validLlpas.Count > 0 ? validLlpas.Max(m => m.PriceFloor ?? decimal.MinValue) : decimal.MinValue;
           
            foreach (var price in Prices)
            {
                var adjustedPrice = price.Price + priceAdjustment;

                var priceDto = new PriceDto
                {
                    Days = price.Days,
                    Rate = price.Rate,
                    Price = price.Price,
                    AdjustedPrice = adjustedPrice,
                    IsValid = adjustedPrice >= priceFloor && adjustedPrice <= priceCeiling
                };

                dtos.Add(priceDto);
            }

            await Task.CompletedTask;

            return dtos;
        }

        private ICollection<Llpa> GetValidLlpas(LoanDto loan, ICollection<Llpa> llpas)
        {
            return llpas.Where(w => (w.Occupancy == null || w.Occupancy == loan.Occupancy) &&
                                    (w.PropertyType == null || w.PropertyType == loan.PropertyType) &&
                                    (w.Purpose == null || w.Purpose == loan.Purpose)).ToList();
        }
    }
}
