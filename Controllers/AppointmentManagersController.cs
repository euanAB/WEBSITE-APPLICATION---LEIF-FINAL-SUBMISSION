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
    public class AppointmentManagersController : Controller
    {
        private readonly LeifGymManagerMdfContext _context;

        public AppointmentManagersController(LeifGymManagerMdfContext context)
        {
            _context = context;
        }

        // GET: AppointmentManagers
        public async Task<IActionResult> Index()
        {
            var leifGymManagerMdfContext = _context.AppointmentManagers.Include(a => a.Class).Include(a => a.Member);
            return View(await leifGymManagerMdfContext.ToListAsync());
        }

        // GET: AppointmentManagers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentManager = await _context.AppointmentManagers
                .Include(a => a.Class)
                .Include(a => a.Member)
                .FirstOrDefaultAsync(m => m.AppointmentManagerId == id);
            if (appointmentManager == null)
            {
                return NotFound();
            }

            return View(appointmentManager);
        }

        // GET: AppointmentManagers/Create
        public IActionResult Create()
        {
            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "ClassName");
            ViewData["MemberId"] = new SelectList(_context.Members, "MembersId", "LastName");
            return View();
        }

        // POST: AppointmentManagers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AppointmentManagerId,MemberId,ClassId,Date,Time")] AppointmentManager appointmentManager)
        {
            ModelState.Remove("Member");
            ModelState.Remove("Class");
            if (ModelState.IsValid)
            {
                _context.Add(appointmentManager);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "ClassName", appointmentManager.ClassId);
            ViewData["MemberId"] = new SelectList(_context.Members, "MembersId", "LastName", appointmentManager.MemberId);
            return View(appointmentManager);
        }

        // GET: AppointmentManagers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var appointmentManager = await _context.AppointmentManagers.FindAsync(id);
            if (appointmentManager == null)
            {
                return NotFound();
            }
            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "ClassName", appointmentManager.ClassId);
            ViewData["MemberId"] = new SelectList(_context.Members, "MembersId", "LastName", appointmentManager.MemberId);
            return View(appointmentManager);
        }

        // POST: AppointmentManagers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AppointmentManagerId,MemberId,ClassId,Date,Time")] AppointmentManager appointmentManager)
        {
            ModelState.Remove("Member");
            ModelState.Remove("Class");
            if (id != appointmentManager.AppointmentManagerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointmentManager);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentManagerExists(appointmentManager.AppointmentManagerId))
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
            ViewData["ClassId"] = new SelectList(_context.Classes, "ClassId", "ClassName", appointmentManager.ClassId);
            ViewData["MemberId"] = new SelectList(_context.Members, "MembersId", "LastName", appointmentManager.MemberId);
            return View(appointmentManager);
        }

        // GET: AppointmentManagers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var appointmentManager = await _context.AppointmentManagers
                .Include(a => a.Class)
                .Include(a => a.Member)
                .FirstOrDefaultAsync(m => m.AppointmentManagerId == id);
            if (appointmentManager == null)
            {
                return NotFound();
            }

            return View(appointmentManager);
        }

        // POST: AppointmentManagers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AppointmentManagers == null)
            {
                return Problem("Entity set 'LeifGymManagerMdfContext.AppointmentManagers'  is null.");
            }
            var appointmentManager = await _context.AppointmentManagers.FindAsync(id);
            if (appointmentManager != null)
            {
                _context.AppointmentManagers.Remove(appointmentManager);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentManagerExists(int id)
        {
          return (_context.AppointmentManagers?.Any(e => e.AppointmentManagerId == id)).GetValueOrDefault();
        }
    }
}
