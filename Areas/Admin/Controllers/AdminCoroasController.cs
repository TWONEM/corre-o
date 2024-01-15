using FloriculturaFlores.Context;
using FloriculturaFlores.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;

namespace FloriculturaFlores.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminCoroasController : Controller
    {
        private readonly AppDbContext _context;

        public AdminCoroasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminCoroas
        //public async Task<IActionResult> Index()
        //{
        //    var appDbContext = _context.Coroas.Include(l => l.Categoria);
        //    return View(await appDbContext.ToListAsync());
        //}

        public async Task<IActionResult> Index(string filter, int pageindex = 1, string sort = "Nome")
        {
            var resultado = _context.Coroas.Include(l => l.Categoria).AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter))
            {
                resultado = resultado.Where(p => p.Nome.Contains(filter));
            }

            var model = await PagingList.CreateAsync(resultado, 5, pageindex, sort, "Nome");
            model.RouteValue = new RouteValueDictionary { { "filter", filter } };
            return View(model);

        }


        // GET: Admin/AdminCoroas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coroa = await _context.Coroas
                .Include(l => l.Categoria)
                .FirstOrDefaultAsync(m => m.CoroaId == id);
            if (coroa == null)
            {
                return NotFound();
            }

            return View(coroa);
        }

        // GET: Admin/AdminCoroas/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome");
            return View();
        }

        // POST: Admin/AdminCoroas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CoroaId,Nome,DescricaoCurta,DescricaoDetalhada,Preco,ImagemUrl,ImagemThumbnailUrl,IsCoroaPreferida,EmEstoque,CategoriaId")] Coroa coroa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coroa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CategoriaId = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome", coroa.CategoriaId);
            return View(coroa);
        }

        // GET: Admin/AdminCoroas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coroa = await _context.Coroas.FindAsync(id);
            if (coroa == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome", coroa.CategoriaId);
            return View(coroa);
        }

        // POST: Admin/AdminCoroas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CoroaId,Nome,DescricaoCurta,DescricaoDetalhada,Preco,ImagemUrl,ImagemThumbnailUrl,IsCoroaPreferido,EmEstoque,CategoriaId")] Coroa coroa)
        {
            if (id != coroa.CoroaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coroa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoroaExists(coroa.CoroaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome", coroa.CategoriaId);
            return View(coroa);
        }

        // GET: Admin/AdminCoroas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coroa = await _context.Coroas
                .Include(l => l.Categoria)
                .FirstOrDefaultAsync(m => m.CoroaId == id);
            if (coroa == null)
            {
                return NotFound();
            }

            return View(coroa);
        }

        // POST: Admin/AdminCoroas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coroa = await _context.Coroas.FindAsync(id);
            _context.Coroas.Remove(coroa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoroaExists(int id)
        {
            return _context.Coroas.Any(e => e.CoroaId == id);
        }
    }
}
