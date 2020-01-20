using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos;
using Application.Interfaces;
using System.Threading;

namespace Infrastructure.Services
{
    public class LlpaService : ILlpaService
    {
        private ISampleDbContext _ctx;

        public LlpaService(ISampleDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task CreateAsync(LlpaUpsertDto dto, CancellationToken cancellationToken)
        {
            _ctx.Llpas.Add(dto.Map());

            await _ctx.SaveChangesAsync(cancellationToken);
        }

        public async Task<ICollection<LlpaLookupDto>> GetAllAsync()
        {
            var llpas = _ctx.Llpas.ToList();

            await Task.CompletedTask;

            return llpas.Select(s => new LlpaLookupDto
            {
                Occupancy = s.Occupancy?.ToString(),
                Purpose = s.Purpose?.ToString(),
                PropertyType = s.PropertyType?.ToString(),
                PriceAdjustment = s.PriceAdjustment,
                PriceCeiling = s.PriceCeiling,
                PriceFloor = s.PriceFloor
            }).ToList();
        }

        public async Task<int> GetCount()
        {
            await Task.CompletedTask;

            return _ctx.Llpas.Count();
        }
    }
}
