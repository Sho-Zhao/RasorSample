using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RasorSample.Model;

namespace RasorSample.Data
{
    public class RasorSampleContext : DbContext
    {
        public RasorSampleContext (DbContextOptions<RasorSampleContext> options)
            : base(options)
        {
        }

        public DbSet<RasorSample.Model.Writing> Writing { get; set; }
    }
}
