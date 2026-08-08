using AzmoonGaj.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzmoonGaj.Infrastructure.Data
{
    public class AzmoonGajDb1Context : DbContext
    {
        public AzmoonGajDb1Context(
            DbContextOptions<AzmoonGajDb1Context> options)
            : base(options)
        {
        }

        public DbSet<Exam> Exams => Set<Exam>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(AzmoonGajDb1Context).Assembly);
        }
    }
}
