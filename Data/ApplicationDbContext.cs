using Microsoft.EntityFrameworkCore;
using RestauranteApp.Models;

namespace RestauranteApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Gasto> Gastos { get; set; }
        public DbSet<CierreDiario> CierresDiarios { get; set; }
        public DbSet<CierreSemanal> CierresSemanales { get; set; }
    }
}
