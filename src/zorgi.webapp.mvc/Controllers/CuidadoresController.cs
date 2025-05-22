using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using zorgi.core.Data;
using zorgi.core.Models;

namespace zorgi.webapp.mvc.Controllers
{
    public class CuidadoresController : Controller
    {
        private readonly AppDbContext _context;

        public CuidadoresController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Cuidadores
        public async Task<IActionResult> Index()
        {
            // TODO: Estudar verificação de presença de id na query, oriunda do link no response da inclusão do cuidador
            return View(await _context.Cuidadores.ToListAsync());
        }

        // GET: Cuidadores/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuidador = await _context.Cuidadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cuidador == null)
            {
                return NotFound();
            }

            return View(cuidador);
        }

        public IActionResult Novo()
        {
            return View();
        }

        // POST: Cuidadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Email,SalarioPorHora,Id")] Cuidador cuidador)
        {
            if (ModelState.IsValid)
            {
                cuidador.Id = Guid.NewGuid();
                _context.Add(cuidador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cuidador);
        }

        // GET: Cuidadores/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuidador = await _context.Cuidadores.FindAsync(id);
            if (cuidador == null)
            {
                return NotFound();
            }
            return View(cuidador);
        }

        // POST: Cuidadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Nome,Email,SalarioPorHora,Id")] Cuidador cuidador)
        {
            if (id != cuidador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cuidador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CuidadorExists(cuidador.Id))
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
            return View(cuidador);
        }

        // GET: Cuidadores/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuidador = await _context.Cuidadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cuidador == null)
            {
                return NotFound();
            }

            return View(cuidador);
        }

        // POST: Cuidadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var cuidador = await _context.Cuidadores.FindAsync(id);
            if (cuidador != null)
            {
                _context.Cuidadores.Remove(cuidador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CuidadorExists(Guid id)
        {
            return _context.Cuidadores.Any(e => e.Id == id);
        }
    }
}
