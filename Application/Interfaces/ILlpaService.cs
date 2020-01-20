using System;
using System.Collections.Generic;
using System.Text;
using Application.Dtos;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ILlpaService
    {
        Task<ICollection<LlpaLookupDto>> GetAllAsync();

        Task<int> GetCount();

        Task CreateAsync(LlpaUpsertDto dto, CancellationToken cancellationToken);
    }
}
