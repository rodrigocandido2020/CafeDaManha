using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CafeDaManha.Models;

namespace CafeDaManha.Data
{
    public class CafeDaManhaContext : DbContext
    {
        public CafeDaManhaContext (DbContextOptions<CafeDaManhaContext> options)
            : base(options)
        {
        }

        public DbSet<CafeDaManha.Models.CadastroCafe> CadastroCafe { get; set; }
        public object Reservations { get; internal set; }
    }
}
