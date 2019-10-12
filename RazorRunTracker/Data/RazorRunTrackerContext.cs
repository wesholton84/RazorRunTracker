using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorRunTracker.Models;

namespace RazorRunTracker.Data
{
    public class RazorRunTrackerContext : DbContext
    {
        public RazorRunTrackerContext (DbContextOptions<RazorRunTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<RazorRunTracker.Models.Run> Run { get; set; }
    }
}
