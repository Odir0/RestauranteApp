using Microsoft.AspNetCore.Mvc;
using RestauranteApp.Data;
using RestauranteApp.Models;

namespace RestauranteApp.Controllers
{
    public class CierresSemanalesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CierresSemanalesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Listar cierres semanales
        public IActionResult Index()
        {
            var cierres = _context.CierresSemanales.ToList();
            return View(cierres);
        }

        // Crear cierre semanal automáticamente
        public IActionResult CrearCierre(DateTime semanaInicio, DateTime semanaFin)
        {
            var totalVentas = _context.Ventas
                .Where(v => v.Fecha.Date >= semanaInicio.Date && v.Fecha.Date <= semanaFin.Date)
                .Sum(v => v.Monto);

            var totalGastos = _context.Gastos
                .Where(g => g.Fecha.Date >= semanaInicio.Date && g.Fecha.Date <= semanaFin.Date)
                .Sum(g => g.Monto);

            var balance = totalVentas - totalGastos;

            var cierre = new CierreSemanal
            {
                SemanaInicio = semanaInicio,
                SemanaFin = semanaFin,
                TotalVentas = totalVentas,
                TotalGastos = totalGastos,
                Balance = balance,
                CreadoEn = DateTime.Now
            };

            _context.CierresSemanales.Add(cierre);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
