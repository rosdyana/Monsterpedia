using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Monsterpedia.Models;

namespace Monsterpedia.Controllers
{
    public class MonsterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MonsterController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Monster
        public async Task<IActionResult> Index(string monsterType, string searchString)
        {
            // use LINQ to get list of types. retrieve all data
            IQueryable<string> typeQuery = from m in _context.Monsters
                                           orderby m.Type
                                           select m.Type;

            // LINQ query to select monster
            var monsters = from m in _context.Monsters
                           select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                monsters = monsters.Where(s => s.Name.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(monsterType))
            {
                monsters = monsters.Where(x => x.Type == monsterType);
            }

            var monsterTypeVM = new MonsterTypeViewModel();
            monsterTypeVM.Types = new SelectList(await typeQuery.Distinct().ToListAsync());
            monsterTypeVM.Monsters = await monsters.ToListAsync();
            monsterTypeVM.SearchString = searchString;

            return View(monsterTypeVM);
        }
        // GET: Monster/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monster = await _context.Monsters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monster == null)
            {
                return NotFound();
            }

            return View(monster);
        }

        // GET: Monster/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Monster/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Type,DateAdded")] Monster monster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(monster);
        }

        // GET: Monster/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monster = await _context.Monsters.FindAsync(id);
            if (monster == null)
            {
                return NotFound();
            }
            return View(monster);
        }

        // POST: Monster/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Type,DateAdded")] Monster monster)
        {
            if (id != monster.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(monster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonsterExists(monster.Id))
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
            return View(monster);
        }

        // GET: Monster/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monster = await _context.Monsters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (monster == null)
            {
                return NotFound();
            }

            return View(monster);
        }

        // POST: Monster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var monster = await _context.Monsters.FindAsync(id);
            _context.Monsters.Remove(monster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MonsterExists(int id)
        {
            return _context.Monsters.Any(e => e.Id == id);
        }
    }
}
