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
    public class ClassesController : Controller
    {
        private readonly LeifGymManagerMdfContext _context;
        public string _staffid = string.Empty;
        public ClassesController(LeifGymManagerMdfContext context)
        {
            _context = context;

        }

        // GET: Classes
        public async Task<IActionResult> Index()
        {
            var leifGymManagerMdfContext = _context.Classes.Include(b => b.Staff);
            return View(await leifGymManagerMdfContext.ToListAsync());
        }

        // GET: Classes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @class = await _context.Classes
                .Include(b => b.Staff)
                .FirstOrDefaultAsync(m => m.ClassId == id);
            if (@class == null)
            {
                return NotFound();
            }

            return View(@class);
        }

        // GET: Classes/Create
        public IActionResult Create()
        {
            var list = new List<SelectListItem>
    {
        new SelectListItem{ Text="Monday", Value = "Monday" },
        new SelectListItem{ Text="Tuesday", Value = "Tuesday" },
        new SelectListItem{ Text="Wednesday", Value = "Wednesday" },
        new SelectListItem{ Text="Thursday", Value = "Thursday" },
        new SelectListItem{ Text="Friday", Value = "Friday" },
        new SelectListItem{ Text="Saturday", Value = "Saturday" },
        new SelectListItem{ Text="Sunday", Value = "Sunday" },
    };

            ViewData["Day"] = list;
            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "Email");
            ViewData["Location"] = new SelectList(_context.Locations, "LocationId", "Location1");
            return View();
        }

        // POST: Classes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(Class @class)
        {
            ModelState.Remove("StaffId");
            ModelState.Remove("Staff");
            @class.StaffId = Convert.ToInt32(HttpContext.Session.GetString("Staffid"));
            @class.CreatedAt = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(@class);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var list = new List<SelectListItem>
    {
        new SelectListItem{ Text="Monday", Value = "Monday" },
        new SelectListItem{ Text="Tuesday", Value = "Tuesday" },
        new SelectListItem{ Text="Wednesday", Value = "Wednesday" },
        new SelectListItem{ Text="Thursday", Value = "Thursday" },
        new SelectListItem{ Text="Friday", Value = "Friday" },
        new SelectListItem{ Text="Saturday", Value = "Saturday" },
        new SelectListItem{ Text="Sunday", Value = "Sunday" },
    };

            ViewData["Day"] = list;
            ViewData["Location"] = new SelectList(_context.Locations, "LocationId", "Location1");

            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "Email", @class.StaffId);
            return View(@class);
        }

        // GET: Classes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @class = await _context.Classes.FindAsync(id);
            if (@class == null)
            {
                return NotFound();
            }
            var list = new List<SelectListItem>
    {
        new SelectListItem{ Text="Monday", Value = "Monday" },
        new SelectListItem{ Text="Tuesday", Value = "Tuesday" },
        new SelectListItem{ Text="Wednesday", Value = "Wednesday" },
        new SelectListItem{ Text="Thursday", Value = "Thursday" },
        new SelectListItem{ Text="Friday", Value = "Friday" },
        new SelectListItem{ Text="Saturday", Value = "Saturday" },
        new SelectListItem{ Text="Sunday", Value = "Sunday" },
    };

            ViewData["Day"] = list;
            ViewData["Location"] = new SelectList(_context.Locations, "LocationId", "Location1");

            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "Email", @class.StaffId);
            return View(@class);
        }

        // POST: Classes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClassId,StaffId,ClassName,Time,Day,Capacity,Field,Location,CreatedAt,UpdatedAt")] Class @class)
        {
            if (id != @class.ClassId)
            {
                return NotFound();
            }
            ModelState.Remove("Staff");

            if (ModelState.IsValid)
            {
                try
                {
                    @class.StaffId = Convert.ToInt32(HttpContext.Session.GetString("Staffid"));
                    @class.UpdatedAt = DateTime.Now;
                    _context.Update(@class);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!ClassExists(@class.ClassId))
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
            var list = new List<SelectListItem>
    {
        new SelectListItem{ Text="Monday", Value = "Monday" },
        new SelectListItem{ Text="Tuesday", Value = "Tuesday" },
        new SelectListItem{ Text="Wednesday", Value = "Wednesday" },
        new SelectListItem{ Text="Thursday", Value = "Thursday" },
        new SelectListItem{ Text="Friday", Value = "Friday" },
        new SelectListItem{ Text="Saturday", Value = "Saturday" },
        new SelectListItem{ Text="Sunday", Value = "Sunday" },
    };

            ViewData["Day"] = list;
            ViewData["Location"] = new SelectList(_context.Locations, "LocationId", "Location1");

            ViewData["StaffId"] = new SelectList(_context.Staff, "StaffId", "Email", @class.StaffId);
            return View(@class);
        }

        // GET: Classes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @class = await _context.Classes
                .Include(b => b.Staff)
                .FirstOrDefaultAsync(m => m.ClassId == id);
            if (@class == null)
            {
                return NotFound();
            }

            return View(@class);
        }

        // POST: Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Classes == null)
            {
                return Problem("Entity set 'LeifGymManagerMdfContext.Classes'  is null.");
            }
            var @class = await _context.Classes.FindAsync(id);
            if (@class != null)
            {
                _context.Classes.Remove(@class);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassExists(int id)
        {
            return (_context.Classes?.Any(e => e.ClassId == id)).GetValueOrDefault();
        }
    }
}
