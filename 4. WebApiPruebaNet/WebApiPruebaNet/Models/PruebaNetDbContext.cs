using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiPruebaNet.Models
{
    public class PruebaNetDbContext : DbContext
    {        
        public PruebaNetDbContext(DbContextOptions<PruebaNetDbContext> options)
            : base(options) { }
        public PruebaNetDbContext() { }
        public DbSet<OrdenesPago> OrdenesPago { get; set; }
        public DbSet<Estados> Estado { get; set; }
        public DbSet<Sucursales> Sucursales { get; set; }
        //public DbSet<OrdenPagoSucursal> OrdenPagoSucursal { get; set; }

    }
}
