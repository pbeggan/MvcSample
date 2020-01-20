using System;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISampleDbContext
    {
        DbSet<Llpa> Llpas { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
