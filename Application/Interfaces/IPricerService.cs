using System;
using System.Collections.Generic;
using System.Text;
using Application.Dtos;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPricerService
    {
        Task<ICollection<PriceDto>> GetAdjustedPrices(LoanDto dto, CancellationToken cancellationToken);
    }
}
