using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Controle_Escolas_e_Alunos.Data;
using Controle_Escolas_e_Alunos.Models;
using Microsoft.AspNetCore.Authorization;

namespace Controle_Escolas_e_Alunos.Controllers
{
    public class AlunosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlunosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Alunos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Alunos.Include(a => a.Escolas);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Alunos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunos = await _context.Alunos
                .Include(a => a.Escolas)
                .FirstOrDefaultAsync(m => m.AlunosId == id);
            if (alunos == null)
            {
                return NotFound();
            }

            return View(alunos);
        }

        [Authorize]

        // GET: Alunos/Create
        public IActionResult Create()
        {
            ViewData["EscolasId"] = new SelectList(_context.Escolas, "EscolasId", "EscolasId");
            return View();
        }
        [Authorize]

        // POST: Alunos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlunosId,EscolasId,Nome,Escola")] Alunos alunos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alunos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EscolasId"] = new SelectList(_context.Escolas, "EscolasId", "EscolasId", alunos.EscolasId);
            return View(alunos);
        }
        [Authorize]

        // GET: Alunos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunos = await _context.Alunos.FindAsync(id);
            if (alunos == null)
            {
                return NotFound();
            }
            ViewData["EscolasId"] = new SelectList(_context.Escolas, "EscolasId", "EscolasId", alunos.EscolasId);
            return View(alunos);
        }
        [Authorize]

        // POST: Alunos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlunosId,EscolasId,Nome,Escola")] Alunos alunos)
        {
            if (id != alunos.AlunosId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alunos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunosExists(alunos.AlunosId))
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
            ViewData["EscolasId"] = new SelectList(_context.Escolas, "EscolasId", "EscolasId", alunos.EscolasId);
            return View(alunos);
        }
        [Authorize]

        // GET: Alunos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunos = await _context.Alunos
                .Include(a => a.Escolas)
                .FirstOrDefaultAsync(m => m.AlunosId == id);
            if (alunos == null)
            {
                return NotFound();
            }

            return View(alunos);
        }
        [Authorize]

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alunos = await _context.Alunos.FindAsync(id);
            _context.Alunos.Remove(alunos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunosExists(int id)
        {
            return _context.Alunos.Any(e => e.AlunosId == id);
        }
    }
}
