using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Leif_Gym_Manager.Models;

namespace Leif_Gym_Manager.Controllers
{
    public class PaymentMethodsController : Controller
    {
        private readonly LeifGymManagerMdfContext _context;

        public PaymentMethodsController(LeifGymManagerMdfContext context)
        {
            _context = context;
        }

        // GET: PaymentMethods
        public async Task<IActionResult> Index()
        {
              return _context.PaymentMethodsus != null ? 
                          View(await _context.PaymentMethodsus.ToListAsync()) :
                          Problem("Entity set 'LeifGymManagerMdfContext.PaymentMethodsus'  is null.");
        }

        // GET: PaymentMethods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var paymentMethods = await _context.PaymentMethodsus
                .FirstOrDefaultAsync(m => m.PaymentMethodsId == id);
            if (paymentMethods == null)
            {
                return NotFound();
            }

            return View(paymentMethods);
        }

        // GET: PaymentMethods/Create
        public IActionResult Create()
        {
            ViewData["PaymentMethodId"] = new SelectList(_context.PaymentMethodsus, "PaymentMethods1", "PaymentMethods1");

            return View();
        }

        // POST: PaymentMethods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaymentMethodsId,PaymentMethods1,IsActive,CreatedAt,UpdatedAt")] PaymentMethodss paymentMethods)
        {
            ViewData["PaymentMethodId"] = new SelectList(_context.PaymentMethodsus, "PaymentMethods1", "PaymentMethods1");

            paymentMethods.CreatedAt = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(paymentMethods);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paymentMethods);
        }

        // GET: PaymentMethods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["PaymentMethodId"] = new SelectList(_context.PaymentMethodsus, "PaymentMethods1", "PaymentMethods1");

            if (id == null || _context.PaymentMethodsus == null)
            {
                return NotFound();
            }

            var paymentMethods = await _context.PaymentMethodsus.FindAsync(id);
            if (paymentMethods == null)
            {
                return NotFound();
            }
            return View(paymentMethods);
        }

        // POST: PaymentMethods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaymentMethodsId,PaymentMethods1,IsActive,CreatedAt,UpdatedAt")] PaymentMethodss paymentMethods)
        {
            ViewData["PaymentMethodId"] = new SelectList(_context.PaymentMethodsus, "PaymentMethods1", "PaymentMethods1");

            if (id != paymentMethods.PaymentMethodsId)
            {
                return NotFound();
            }
            paymentMethods.UpdatedAt = DateTime.Now;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paymentMethods);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentMethodsExists(paymentMethods.PaymentMethodsId))
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
            return View(paymentMethods);
        }

        // GET: PaymentMethods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PaymentMethodsus == null)
            {
                return NotFound();
            }

            var paymentMethods = await _context.PaymentMethodsus
                .FirstOrDefaultAsync(m => m.PaymentMethodsId == id);
            if (paymentMethods == null)
            {
                return NotFound();
            }

            return View(paymentMethods);
        }

        // POST: PaymentMethods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PaymentMethodsus == null)
            {
                return Problem("Entity set 'LeifGymManagerMdfContext.PaymentMethodsus'  is null.");
            }
            var paymentMethods = await _context.PaymentMethodsus.FindAsync(id);
            if (paymentMethods != null)
            {
                _context.PaymentMethodsus.Remove(paymentMethods);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentMethodsExists(int id)
        {
          return (_context.PaymentMethodsus?.Any(e => e.PaymentMethodsId == id)).GetValueOrDefault();
        }
    }
}
