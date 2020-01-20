using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class SampleDbContext : DbContext, ISampleDbContext
    {
        public SampleDbContext(DbContextOptions<SampleDbContext> options)
        : base(options)
        {
        }

        public DbSet<Llpa> Llpas { get; set; }
    }
}
