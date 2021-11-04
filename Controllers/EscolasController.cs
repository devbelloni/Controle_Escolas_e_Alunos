using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Controle_Escolas_e_Alunos.Data;
using Controle_Escolas_e_Alunos.Models;
using Microsoft.AspNetCore.Authorization;

namespace Controle_Escolas_e_Alunos.Controllers
{
    public class EscolasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EscolasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Escolas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Escolas.ToListAsync());
        }

        // GET: Escolas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escolas = await _context.Escolas
                .FirstOrDefaultAsync(m => m.EscolasId == id);
            if (escolas == null)
            {
                return NotFound();
            }

            return View(escolas);
        }
        [Authorize]

        // GET: Escolas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Escolas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EscolasId,Registro,Escola")] Escolas escolas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(escolas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(escolas);
        }
        [Authorize]

        // GET: Escolas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escolas = await _context.Escolas.FindAsync(id);
            if (escolas == null)
            {
                return NotFound();
            }
            return View(escolas);
        }
        [Authorize]

        // POST: Escolas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EscolasId,Registro,Escola")] Escolas escolas)
        {
            if (id != escolas.EscolasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(escolas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EscolasExists(escolas.EscolasId))
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
            return View(escolas);
        }
        [Authorize]

        // GET: Escolas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var escolas = await _context.Escolas
                .FirstOrDefaultAsync(m => m.EscolasId == id);
            if (escolas == null)
            {
                return NotFound();
            }

            return View(escolas);
        }
        [Authorize]

        // POST: Escolas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var escolas = await _context.Escolas.FindAsync(id);
            _context.Escolas.Remove(escolas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EscolasExists(int id)
        {
            return _context.Escolas.Any(e => e.EscolasId == id);
        }
    }
}
