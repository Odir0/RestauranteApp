using Microsoft.AspNetCore.Mvc;
using RestauranteApp.Data;
using RestauranteApp.Models;

namespace RestauranteApp.Controllers
{
    public class VentasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VentasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Acción para listar ventas
        public IActionResult Index()
        {
            var ventas = _context.Ventas.ToList().OrderByDescending(v => v.Fecha);
            return View(ventas);
        }

        // Acción para crear una nueva venta
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Venta venta)
        {
            if (ModelState.IsValid)
            {
                _context.Ventas.Add(venta);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(venta);
        }
    }
}
