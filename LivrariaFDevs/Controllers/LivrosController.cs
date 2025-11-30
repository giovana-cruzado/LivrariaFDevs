using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LivrariaFDevs.Data;
using LivrariaFDevs.Models;

namespace LivrariaFDevs.Controllers
{
    public class LivrosController : Controller
    {
        private readonly AppDbContext _db;

        public LivrosController(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var livros = await _db.Livros
                .Include(l => l.Categoria)
                .ToListAsync();

            return View(livros);
        }

        public IActionResult Create()
        {
            ViewBag.Categorias = _db.Categorias.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Livro livro)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categorias = _db.Categorias.ToList();
                return View(livro);
            }

            _db.Livros.Add(livro);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
