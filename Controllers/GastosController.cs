using Microsoft.AspNetCore.Mvc;
using RestauranteApp.Data;
using RestauranteApp.Models;

namespace RestauranteApp.Controllers
{
    public class GastosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GastosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Acción para listar gastos
        public IActionResult Index()
        {
            var gastos = _context.Gastos.ToList().OrderByDescending(g => g.Fecha);
            return View(gastos);
        }

        // Acción para crear un nuevo gasto
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Gasto gasto)
        {
            if (ModelState.IsValid)
            {
                _context.Gastos.Add(gasto);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gasto);
        }
    }
}
