using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Practico2HDP.Models;

namespace Practico2HDP.Data
{
    public class BiciContext : DbContext
    {
        public BiciContext (DbContextOptions<BiciContext> options)
            : base(options)
        {
        }

        public DbSet<Practico2HDP.Models.Moto> Moto { get; set; } = default!;

        public DbSet<Practico2HDP.Models.Concesionario> Concesionario { get; set; } = default!;

        public DbSet<Practico2HDP.Models.Cliente> Cliente { get; set; } = default!;
    }
}
