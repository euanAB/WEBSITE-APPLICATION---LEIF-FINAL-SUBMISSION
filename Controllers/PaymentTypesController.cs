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
    public class PaymentTypesController : Controller
    {
        private readonly LeifGymManagerMdfContext _context;

        public PaymentTypesController(LeifGymManagerMdfContext context)
        {
            _context = context;
        }

        // GET: PaymentTypes
        public async Task<IActionResult> Index()
        {
              return _context.PaymentTypes != null ? 
                          View(await _context.PaymentTypes.ToListAsync()) :
                          Problem("Entity set 'LeifGymManagerMdfContext.PaymentTypes'  is null.");
        }

        // GET: PaymentTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var paymentType = await _context.PaymentTypes
                .FirstOrDefaultAsync(m => m.PaymentId == id);
            if (paymentType == null)
            {
                return NotFound();
            }

            return View(paymentType);
        }

        // GET: PaymentTypes/Create
        public IActionResult Create()
        {
            ViewData["members"] = new SelectList(_context.Members, "FirstName", "FirstName");
            ViewData["PaymentStatusId"] = new SelectList(_context.PaymentStatuses, "PaymentStatus1", "PaymentStatus1");
            ViewData["PaymentMethodId"] = new SelectList(_context.PaymentMethodsus, "PaymentMethods1", "PaymentMethods1");

            return View();
        }

        // POST: PaymentTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaymentId,PaymentAmount,Method,Status,CreatedAt,UpdatedAt")] PaymentType paymentType)
        {
            ModelState.Remove("CreatedAt");
            ModelState.Remove("Members");
            if (ModelState.IsValid)
            {
                paymentType.CreatedAt = DateTime.Now;
                _context.Add(paymentType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["members"] = new SelectList(_context.Members, "FirstName", "FirstName");

            ViewData["PaymentStatusId"] = new SelectList(_context.PaymentStatuses, "PaymentStatus1", "PaymentStatus1");
            ViewData["PaymentMethodId"] = new SelectList(_context.PaymentMethodsus, "PaymentMethods1", "PaymentMethods1");

            return View(paymentType);
        }

        // GET: PaymentTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var paymentType = await _context.PaymentTypes.FindAsync(id);
            if (paymentType == null)
            {
                return NotFound();
            }
            ViewData["members"] = new SelectList(_context.Members, "FirstName", "FirstName");

            ViewData["PaymentStatusId"] = new SelectList(_context.PaymentStatuses, "PaymentStatus1", "PaymentStatus1");
            ViewData["PaymentMethodId"] = new SelectList(_context.PaymentMethodsus, "PaymentMethods1", "PaymentMethods1");

            return View(paymentType);
        }

        // POST: PaymentTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaymentId,PaymentAmount,Method,Status,CreatedAt,UpdatedAt")] PaymentType paymentType)
        {
            ViewData["PaymentStatusId"] = new SelectList(_context.PaymentStatuses, "PaymentStatus1", "PaymentStatus1");
            ViewData["PaymentMethodId"] = new SelectList(_context.PaymentMethodsus, "PaymentMethods1", "PaymentMethods1");
            ViewData["members"] = new SelectList(_context.Members, "FirstName", "FirstName");

            if (id != paymentType.PaymentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    paymentType.UpdatedAt = DateTime.Now;
                    _context.Update(paymentType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentTypeExists(paymentType.PaymentId))
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
            return View(paymentType);
        }

        // GET: PaymentTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var paymentType = await _context.PaymentTypes
                .FirstOrDefaultAsync(m => m.PaymentId == id);
            if (paymentType == null)
            {
                return NotFound();
            }

            return View(paymentType);
        }

        // POST: PaymentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PaymentTypes == null)
            {
                return Problem("Entity set 'LeifGymManagerMdfContext.PaymentTypes'  is null.");
            }
            var paymentType = await _context.PaymentTypes.FindAsync(id);
            if (paymentType != null)
            {
                _context.PaymentTypes.Remove(paymentType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentTypeExists(int id)
        {
          return (_context.PaymentTypes?.Any(e => e.PaymentId == id)).GetValueOrDefault();
        }
    }
}
