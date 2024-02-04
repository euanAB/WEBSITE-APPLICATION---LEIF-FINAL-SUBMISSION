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
    public class MemberShipTypesController : Controller
    {
        private readonly LeifGymManagerMdfContext _context;

        public MemberShipTypesController(LeifGymManagerMdfContext context)
        {
            _context = context;
        }

        // GET: MemberShipTypes
        public async Task<IActionResult> Index()
        {
              return _context.MemberShipTypes != null ? 
                          View(await _context.MemberShipTypes.ToListAsync()) :
                          Problem("Entity set 'LeifGymManagerMdfContext.MemberShipTypes'  is null.");
        }

        // GET: MemberShipTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var memberShipType = await _context.MemberShipTypes
                .FirstOrDefaultAsync(m => m.MemberShipTypeId == id);
            if (memberShipType == null)
            {
                return NotFound();
            }

            return View(memberShipType);
        }

        // GET: MemberShipTypes/Create
        public IActionResult Create()
        {
            var list = new List<SelectListItem>
    {
        new SelectListItem{ Text="Daily", Value = "Daily" },
        new SelectListItem{ Text="Weekly", Value = "Weekly" },
        new SelectListItem{ Text="Monthly", Value = "Monthly" },
        new SelectListItem{ Text="Quartey", Value = "Quartey" },
        new SelectListItem{ Text="Yearly", Value = "Yearly" },
    };

            ViewData["Frequency"] = list;
            return View();
        }

        // POST: MemberShipTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MemberShipTypeId,Price,Frequency,MemberShipName,ContactTerm,MinimumAge,MaximumAge,CreatedAt,UpdatedAt")] MemberShipType memberShipType)
        {
            memberShipType.CreatedAt = DateTime.Now;
            ModelState.Remove("Members");
            if (ModelState.IsValid)
            {
                _context.Add(memberShipType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var list = new List<SelectListItem>
    {
        new SelectListItem{ Text="Daily", Value = "Daily" },
        new SelectListItem{ Text="Weekly", Value = "Weekly" },
        new SelectListItem{ Text="Monthly", Value = "Monthly" },
        new SelectListItem{ Text="Quartey", Value = "Quartey" },
        new SelectListItem{ Text="Yearly", Value = "Yearly" },
    };

            ViewData["Frequency"] = list;
            return View(memberShipType);
        }

        // GET: MemberShipTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var list = new List<SelectListItem>
    {
        new SelectListItem{ Text="Daily", Value = "Daily" },
        new SelectListItem{ Text="Weekly", Value = "Weekly" },
        new SelectListItem{ Text="Monthly", Value = "Monthly" },
        new SelectListItem{ Text="Quartey", Value = "Quartey" },
        new SelectListItem{ Text="Yearly", Value = "Yearly" },
    };

            ViewData["Frequency"] = list;
            if (id == null )
            {
                return NotFound();
            }

            var memberShipType = await _context.MemberShipTypes.FindAsync(id);
            if (memberShipType == null)
            {
                return NotFound();
            }
            return View(memberShipType);
        }

        // POST: MemberShipTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MemberShipTypeId,Price,Frequency,MemberShipName,ContactTerm,MinimumAge,MaximumAge,CreatedAt,UpdatedAt")] MemberShipType memberShipType)
        {
            var list = new List<SelectListItem>
    {
        new SelectListItem{ Text="Daily", Value = "Daily" },
        new SelectListItem{ Text="Weekly", Value = "Weekly" },
        new SelectListItem{ Text="Monthly", Value = "Monthly" },
        new SelectListItem{ Text="Quartey", Value = "Quartey" },
        new SelectListItem{ Text="Yearly", Value = "Yearly" },
    };

            ViewData["Frequency"] = list;
            if (id != memberShipType.MemberShipTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    memberShipType.UpdatedAt = DateTime.Now;
                    _context.Update(memberShipType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberShipTypeExists(memberShipType.MemberShipTypeId))
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
            return View(memberShipType);
        }

        // GET: MemberShipTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var memberShipType = await _context.MemberShipTypes
                .FirstOrDefaultAsync(m => m.MemberShipTypeId == id);
            if (memberShipType == null)
            {
                return NotFound();
            }

            return View(memberShipType);
        }

        // POST: MemberShipTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MemberShipTypes == null)
            {
                return Problem("Entity set 'LeifGymManagerMdfContext.MemberShipTypes'  is null.");
            }
            var memberShipType = await _context.MemberShipTypes.FindAsync(id);
            if (memberShipType != null)
            {
                _context.MemberShipTypes.Remove(memberShipType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberShipTypeExists(int id)
        {
          return (_context.MemberShipTypes?.Any(e => e.MemberShipTypeId == id)).GetValueOrDefault();
        }
    }
}
