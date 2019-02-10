using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MobileAvailability.Models;

namespace MobileAvailability.Models
{
    public class MobileAvailabilityContext : DbContext
    {
        public MobileAvailabilityContext (DbContextOptions<MobileAvailabilityContext> options)
            : base(options)
        {
        }

        public DbSet<MobileAvailability.Models.Producer> Producer { get; set; }

        public DbSet<MobileAvailability.Models.Market> Market { get; set; }

        public DbSet<MobileAvailability.Models.Availabilities> Availabilities { get; set; }
    }
}
