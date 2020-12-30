using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assessment67A.Data;

namespace Assessment67A.Controllers
{
    public class FruitController : Controller
    {
        private readonly FruitDbContext _context;

        public FruitController(FruitDbContext context)
        {
            _context = context;
        }

        // GET: Fruit
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fruit.ToListAsync());
        }

        // GET: Fruit/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fruit = await _context.Fruit
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fruit == null)
            {
                return NotFound();
            }

            return View(fruit);
        }

        // GET: Fruit/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fruit/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Color,Price")] Fruit fruit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fruit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fruit);
        }

        // GET: Fruit/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fruit = await _context.Fruit.FindAsync(id);
            if (fruit == null)
            {
                return NotFound();
            }
            return View(fruit);
        }

        // POST: Fruit/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Color,Price")] Fruit fruit)
        {
            if (id != fruit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fruit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FruitExists(fruit.Id))
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
            return View(fruit);
        }

        // GET: Fruit/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fruit = await _context.Fruit
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fruit == null)
            {
                return NotFound();
            }

            return View(fruit);
        }

        // POST: Fruit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fruit = await _context.Fruit.FindAsync(id);
            _context.Fruit.Remove(fruit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FruitExists(int id)
        {
            return _context.Fruit.Any(e => e.Id == id);
        }
    }
}
