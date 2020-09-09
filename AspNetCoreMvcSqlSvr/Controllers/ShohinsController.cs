using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspNetCoreMvcSqlSvr.Data;
using AspNetCoreMvcSqlSvr.Models;

namespace AspNetCoreMvcSqlSvr.Controllers
{
    public class ShohinsController : Controller
    {
        private readonly MvcShohinContext _context;

        public ShohinsController(MvcShohinContext context)
        {
            _context = context;
        }

        // GET: Shohins
        public async Task<IActionResult> Index(string searchString)
        {
            var movies = from m in _context.Shohin
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.ShohinName.Contains(searchString));
            }

            return View(await movies.ToListAsync());
            //return View(await _context.Shohin.ToListAsync());
        }

        // GET: Shohins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shohin = await _context.Shohin
                .FirstOrDefaultAsync(m => m.NumId == id);
            if (shohin == null)
            {
                return NotFound();
            }

            return View(shohin);
        }

        // GET: Shohins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shohins/Create
        // オーバーポスト攻撃から保護するには、バインドしたい特定のプロパティを有効にしてください。
        // 詳細を見る http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NumId,ShohinCode,ShohinName,EditDate,EditTime,Note")] Shohin shohin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shohin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shohin);
        }

        // GET: Shohins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shohin = await _context.Shohin.FindAsync(id);
            if (shohin == null)
            {
                return NotFound();
            }
            return View(shohin);
        }

        // POST: Shohins/Edit/5
        // オーバーポスト攻撃から保護するには、バインドしたい特定のプロパティを有効にしてください。
        // 詳細を見る http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NumId,ShohinCode,ShohinName,EditDate,EditTime,Note")] Shohin shohin)
        {
            if (id != shohin.NumId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shohin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShohinExists(shohin.NumId))
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
            return View(shohin);
        }

        // GET: Shohins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shohin = await _context.Shohin
                .FirstOrDefaultAsync(m => m.NumId == id);
            if (shohin == null)
            {
                return NotFound();
            }

            return View(shohin);
        }

        // POST: Shohins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shohin = await _context.Shohin.FindAsync(id);
            _context.Shohin.Remove(shohin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShohinExists(int id)
        {
            return _context.Shohin.Any(e => e.NumId == id);
        }
    }
}
