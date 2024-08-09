using CarDealer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarDealer.Controllers
{
    public class PartsController : Controller
    {
        private readonly MyDbContext _context;

        public PartsController(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var parts = await _context.Parts
                .Select(p => new PartViewModel
                {
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    SupplierId = p.SupplierId
                })
                .ToListAsync();

            return View(parts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PartViewModel model)
        {
            if (ModelState.IsValid)
            {
                var part = new Part
                {
                    Name = model.Name,
                    Price = model.Price,
                    Quantity = model.Quantity,
                    SupplierId = model.SupplierId
                };

                _context.Parts.Add(part);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}
