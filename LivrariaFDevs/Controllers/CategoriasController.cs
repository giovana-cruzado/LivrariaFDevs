using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LivrariaFDevs.Data;
using LivrariaFDevs.Models;

namespace LivrariaFDevs.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly AppDbContext _db;
        public CategoriasController(AppDbContext db) => _db = db;

        public async Task<IActionResult> Index()
        {
            var categorias = await _db.Categorias.OrderBy(c => c.Nome).ToListAsync();
            return View(categorias);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var categoria = await _db.Categorias.FirstOrDefaultAsync(c => c.Id == id);
            if (categoria == null) return NotFound();

            return View(categoria);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Categoria categoria)
        {
            if (!ModelState.IsValid) return View(categoria);

            _db.Categorias.Add(categoria);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var categoria = await _db.Categorias.FindAsync(id);
            if (categoria == null) return NotFound();
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Categoria categoria)
        {
            if (id != categoria.Id) return BadRequest();
            if (!ModelState.IsValid) return View(categoria);

            try
            {
                _db.Update(categoria);
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _db.Categorias.AnyAsync(c => c.Id == id)) return NotFound();
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var categoria = await _db.Categorias.FirstOrDefaultAsync(c => c.Id == id);
            if (categoria == null) return NotFound();
            return View(categoria);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoria = await _db.Categorias.FindAsync(id);
            if (categoria != null)
            {
                var temLivros = await _db.Livros.AnyAsync(l => l.CategoriaId == id);
                if (temLivros)
                {
                    TempData["Erro"] = "Não é possível excluir: existem livros nessa categoria.";
                    return RedirectToAction(nameof(Delete), new { id });
                }

                _db.Categorias.Remove(categoria);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
