using Microsoft.AspNetCore.Mvc;
using RestauranteApp.Data;

namespace RestauranteApp.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var totalVentas = _context.Ventas.Sum(v => v.Monto);
            var totalGastos = _context.Gastos.Sum(g => g.Monto);
            var balance = totalVentas - totalGastos;

            var cierresDiarios = _context.CierresDiarios
                .OrderByDescending(c => c.Fecha)
                .Take(7)
                .OrderByDescending(c => c.Fecha)
                .ToList();

            var cierresSemanales = _context.CierresSemanales
                .OrderByDescending(c => c.SemanaFin)
                .Take(4)
                .ToList();

            ViewBag.TotalVentas = totalVentas;
            ViewBag.TotalGastos = totalGastos;
            ViewBag.Balance = balance;
            ViewBag.CierresDiarios = cierresDiarios;
            ViewBag.CierresSemanales = cierresSemanales;

            return View();
        }
    }
}
