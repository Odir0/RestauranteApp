using Microsoft.AspNetCore.Mvc;
using RestauranteApp.Data;
using RestauranteApp.Models;

namespace RestauranteApp.Controllers
{
    public class CierresDiariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CierresDiariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Listar cierres diarios
        public IActionResult Index()
        {
            var cierres = _context.CierresDiarios.ToList().OrderByDescending(c => c.Fecha);
            return View(cierres);
        }

        // Crear cierre diario automáticamente
        public IActionResult CrearCierre(DateTime fecha)
        {
            // Calcular totales del día
            var totalVentas = _context.Ventas
                .Where(v => v.Fecha.Date == fecha.Date)
                .Sum(v => v.Monto);

            var totalGastos = _context.Gastos
                .Where(g => g.Fecha.Date == fecha.Date)
                .Sum(g => g.Monto);

            var balance = totalVentas - totalGastos;

            // Crear registro
            var cierre = new CierreDiario
            {
                Fecha = fecha,
                TotalVentas = totalVentas,
                TotalGastos = totalGastos,
                Balance = balance,
                CreadoEn = DateTime.Now
            };

            _context.CierresDiarios.Add(cierre);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
