using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelBooking.Data;
using HotelBooking.Models;

namespace HotelBooking.Controllers
{
    public class ServiceCategories1Controller : Controller
    {
        private readonly AppDbContext _context;

        public ServiceCategories1Controller(AppDbContext context)
        {
            _context = context;
        }

        // GET: ServiceCategories1
        public async Task<IActionResult> Index()
        {
            return View(await _context.ServiceCategories.ToListAsync());
        }

        // GET: ServiceCategories1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceCategories = await _context.ServiceCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceCategories == null)
            {
                return NotFound();
            }

            return View(serviceCategories);
        }

        // GET: ServiceCategories1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServiceCategories1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,CreateAt,Status")] ServiceCategories serviceCategories)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviceCategories);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serviceCategories);
        }

        // GET: ServiceCategories1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceCategories = await _context.ServiceCategories.FindAsync(id);
            if (serviceCategories == null)
            {
                return NotFound();
            }
            return View(serviceCategories);
        }

        // POST: ServiceCategories1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,CreateAt,Status")] ServiceCategories serviceCategories)
        {
            if (id != serviceCategories.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceCategories);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceCategoriesExists(serviceCategories.Id))
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
            return View(serviceCategories);
        }

        // GET: ServiceCategories1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceCategories = await _context.ServiceCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceCategories == null)
            {
                return NotFound();
            }

            return View(serviceCategories);
        }

        // POST: ServiceCategories1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serviceCategories = await _context.ServiceCategories.FindAsync(id);
            if (serviceCategories != null)
            {
                _context.ServiceCategories.Remove(serviceCategories);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceCategoriesExists(int id)
        {
            return _context.ServiceCategories.Any(e => e.Id == id);
        }
    }
}
