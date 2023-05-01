using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Clase6.Models;

namespace Clase6.Data
{
    public class MenuContext : DbContext
    {
        public MenuContext (DbContextOptions<MenuContext> options)
            : base(options)
        {
        }

        public DbSet<Clase6.Models.Menu> Menu { get; set; } = default!;
    }
}
