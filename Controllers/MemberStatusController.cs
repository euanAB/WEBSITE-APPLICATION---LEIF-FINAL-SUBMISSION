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
    public class MemberStatusController : Controller
    {
        private readonly LeifGymManagerMdfContext _context;

        public MemberStatusController(LeifGymManagerMdfContext context)
        {
            _context = context;
        }

        // GET: MemberStatus
        public async Task<IActionResult> Index()
        {
              return _context.MemberStatuses != null ? 
                          View(await _context.MemberStatuses.ToListAsync()) :
                          Problem("Entity set 'LeifGymManagerMdfContext.MemberStatuses'  is null.");
        }

        // GET: MemberStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var memberStatus = await _context.MemberStatuses
                .FirstOrDefaultAsync(m => m.MemberStatusId == id);
            if (memberStatus == null)
            {
                return NotFound();
            }

            return View(memberStatus);
        }

        // GET: MemberStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MemberStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MemberStatusId,MemberStatus1,IsActive,CreatedAt,UpdatedAt")] MemberStatuss memberStatus)
        {
            if (ModelState.IsValid)
            {
                memberStatus.CreatedAt = DateTime.Now;
                _context.Add(memberStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(memberStatus);
        }

        // GET: MemberStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var memberStatus = await _context.MemberStatuses.FindAsync(id);
            if (memberStatus == null)
            {
                return NotFound();
            }
            return View(memberStatus);
        }

        // POST: MemberStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MemberStatusId,MemberStatus1,IsActive,CreatedAt,UpdatedAt")] MemberStatuss memberStatus)
        {
            if (id != memberStatus.MemberStatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    memberStatus.UpdatedAt = DateTime.Now;
                    _context.Update(memberStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberStatusExists(memberStatus.MemberStatusId))
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
            return View(memberStatus);
        }

        // GET: MemberStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var memberStatus = await _context.MemberStatuses
                .FirstOrDefaultAsync(m => m.MemberStatusId == id);
            if (memberStatus == null)
            {
                return NotFound();
            }

            return View(memberStatus);
        }

        // POST: MemberStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MemberStatuses == null)
            {
                return Problem("Entity set 'LeifGymManagerMdfContext.MemberStatuses'  is null.");
            }
            var memberStatus = await _context.MemberStatuses.FindAsync(id);
            if (memberStatus != null)
            {
                _context.MemberStatuses.Remove(memberStatus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberStatusExists(int id)
        {
          return (_context.MemberStatuses?.Any(e => e.MemberStatusId == id)).GetValueOrDefault();
        }
    }
}
