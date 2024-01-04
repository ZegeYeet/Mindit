using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mindit.Data;

namespace Mindit.Models
{
    public class MinditCategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MinditCategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MinditCategory
        /*public async Task<IActionResult> Index()
        {
              return _context.MinditCategoryModel != null ? 
                          View(await _context.MinditCategoryModel.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.MinditCategoryModel'  is null.");
        }*/

        // GET: MinditCategory/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.MinditCategoryModel == null)
            {
                return NotFound();
            }

            var minditCategoryModel = await _context.MinditCategoryModel
                .FirstOrDefaultAsync(m => m.categoryName == id);
            if (minditCategoryModel == null)
            {
                return NotFound();
            }

            return View(minditCategoryModel);
        }

        // GET: MinditCategory/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: MinditCategory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("categoryName")] MinditCategoryModel minditCategoryModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(minditCategoryModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(minditCategoryModel);
        }

        // GET: MinditCategory/Edit/5
        /*public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.MinditCategoryModel == null)
            {
                return NotFound();
            }

            var minditCategoryModel = await _context.MinditCategoryModel.FindAsync(id);
            if (minditCategoryModel == null)
            {
                return NotFound();
            }
            return View(minditCategoryModel);
        }*/

        // POST: MinditCategory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(string id, [Bind("categoryName")] MinditCategoryModel minditCategoryModel)
        {
            if (id != minditCategoryModel.categoryName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(minditCategoryModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MinditCategoryModelExists(minditCategoryModel.categoryName))
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
            return View(minditCategoryModel);
        }*/

        // GET: MinditCategory/Delete/5
        /*public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.MinditCategoryModel == null)
            {
                return NotFound();
            }

            var minditCategoryModel = await _context.MinditCategoryModel
                .FirstOrDefaultAsync(m => m.categoryName == id);
            if (minditCategoryModel == null)
            {
                return NotFound();
            }

            return View(minditCategoryModel);
        }

        // POST: MinditCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.MinditCategoryModel == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MinditCategoryModel'  is null.");
            }
            var minditCategoryModel = await _context.MinditCategoryModel.FindAsync(id);
            if (minditCategoryModel != null)
            {
                _context.MinditCategoryModel.Remove(minditCategoryModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MinditCategoryModelExists(string id)
        {
          return (_context.MinditCategoryModel?.Any(e => e.categoryName == id)).GetValueOrDefault();
        }*/
    }
}
