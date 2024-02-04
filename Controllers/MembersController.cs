using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Leif_Gym_Manager.Models;
using System.Text;

namespace Leif_Gym_Manager.Controllers
{
    public class MembersController : Controller
    {
        private readonly LeifGymManagerMdfContext _context;

        public MembersController(LeifGymManagerMdfContext context)
        {
            _context = context;
        }

        // GET: Members
        public async Task<IActionResult> Index()
        {
            var leifGymManagerMdfContext = _context.Members.Include(m => m.MemberShipType).Include(m => m.PaymentType);
            return View(await leifGymManagerMdfContext.ToListAsync());
        }

        // GET: Members/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Members == null)
            {
                return NotFound();
            }

            var member = await _context.Members
                .Include(m => m.MemberShipType)
                .Include(m => m.PaymentType)
                .FirstOrDefaultAsync(m => m.MembersId == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }
        private static Random RNG = new Random();

        public string Create16DigitString()
        {
            var builder = new StringBuilder();
            while (builder.Length < 16)
            {
                builder.Append(RNG.Next(10).ToString());
            }
            return builder.ToString();
        }
        // GET: Members/Create
        public IActionResult Create()
        {
            Member mem = new Member();
            mem.FobNumber = Create16DigitString();
            var list = new List<SelectListItem>
    {
        new SelectListItem{ Text="African Traditional &amp; Diasporic", Value = "African Traditional &amp; Diasporic" },
        new SelectListItem{ Text="Agnostic", Value = "Agnostic" },
        new SelectListItem{ Text="Atheist", Value = "Atheist" },
        new SelectListItem{ Text="Baha'i", Value = "Baha'i" },
        new SelectListItem{ Text="Buddhism", Value = "Buddhism" },
        new SelectListItem{ Text="Cao Dai", Value = "Cao Dai" },
        new SelectListItem{ Text="Chinese traditional religion", Value = "Chinese traditional religion" },
        new SelectListItem{ Text="Christianity", Value = "Christianity" },
        new SelectListItem{ Text="Hinduism", Value = "Hinduism" },
        new SelectListItem{ Text="Islam", Value = "Islam" },
        new SelectListItem{ Text="Jainism", Value = "Jainism" },
        new SelectListItem{ Text="Juche", Value = "Juche" },
        new SelectListItem{ Text="Judaism", Value = "Judaism" },
        new SelectListItem{ Text="Neo-Paganism", Value = "Neo-Paganism" },
        new SelectListItem{ Text="Nonreligious", Value = "Nonreligious" },
        new SelectListItem{ Text="Rastafarianism", Value = "Rastafarianism" },
        new SelectListItem{ Text="Secular", Value = "Secular" },
        new SelectListItem{ Text="Shinto", Value = "Shinto" },
        new SelectListItem{ Text="Sikhism", Value = "Sikhism" },
        new SelectListItem{ Text="Spiritism", Value = "Spiritism" },
        new SelectListItem{ Text="Tenrikyo", Value = "Tenrikyo" },
        new SelectListItem{ Text="Unitarian-Universalism", Value = "Unitarian-Universalism" },
        new SelectListItem{ Text="Zoroastrianism", Value = "Zoroastrianism" },
        new SelectListItem{ Text="primal-indigenous", Value = "primal-indigenous" },
        new SelectListItem{ Text="Other", Value = "Other" },

    };

            ViewData["Region"] = list;
            ViewData["MemberShipTypeId"] = new SelectList(_context.MemberShipTypes, "MemberShipTypeId", "MemberShipName");
            ViewData["PaymentTypeId"] = new SelectList(_context.PaymentTypes, "PaymentId", "Method");
            ViewData["MemberStatusId"] = new SelectList(_context.MemberStatuses, "MemberStatusId", "MemberStatus1");
            return View(mem);
        }

        // POST: Members/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MembersId,FobNumber,MemberShipTypeId,PaymentTypeId,MemberStatus,FirstName,LastName,DateOfBirth,Email,Phone,Ethinicity,Religion,Title,MedicalNotes,StartDate,Weight,Height,CreatedAt,UpdatedAt")] Member member)
        {
            ModelState.Remove("MemberShipType");
            ModelState.Remove("PaymentType");
            if (ModelState.IsValid)
            {
                var isfobmemberdup = _context.Members.Where(m => m.FobNumber == member.FobNumber).Any();
                if (!isfobmemberdup)
                {
                    member.CreatedAt = DateTime.Now;
                    _context.Add(member);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, "Fob Number already exist , please try unique");

            }
            var list = new List<SelectListItem>
    {
        new SelectListItem{ Text="African Traditional &amp; Diasporic", Value = "African Traditional &amp; Diasporic" },
        new SelectListItem{ Text="Agnostic", Value = "Agnostic" },
        new SelectListItem{ Text="Atheist", Value = "Atheist" },
        new SelectListItem{ Text="Baha'i", Value = "Baha'i" },
        new SelectListItem{ Text="Buddhism", Value = "Buddhism" },
        new SelectListItem{ Text="Cao Dai", Value = "Cao Dai" },
        new SelectListItem{ Text="Chinese traditional religion", Value = "Chinese traditional religion" },
        new SelectListItem{ Text="Christianity", Value = "Christianity" },
        new SelectListItem{ Text="Hinduism", Value = "Hinduism" },
        new SelectListItem{ Text="Islam", Value = "Islam" },
        new SelectListItem{ Text="Jainism", Value = "Jainism" },
        new SelectListItem{ Text="Juche", Value = "Juche" },
        new SelectListItem{ Text="Judaism", Value = "Judaism" },
        new SelectListItem{ Text="Neo-Paganism", Value = "Neo-Paganism" },
        new SelectListItem{ Text="Nonreligious", Value = "Nonreligious" },
        new SelectListItem{ Text="Rastafarianism", Value = "Rastafarianism" },
        new SelectListItem{ Text="Secular", Value = "Secular" },
        new SelectListItem{ Text="Shinto", Value = "Shinto" },
        new SelectListItem{ Text="Sikhism", Value = "Sikhism" },
        new SelectListItem{ Text="Spiritism", Value = "Spiritism" },
        new SelectListItem{ Text="Tenrikyo", Value = "Tenrikyo" },
        new SelectListItem{ Text="Unitarian-Universalism", Value = "Unitarian-Universalism" },
        new SelectListItem{ Text="Zoroastrianism", Value = "Zoroastrianism" },
        new SelectListItem{ Text="primal-indigenous", Value = "primal-indigenous" },
        new SelectListItem{ Text="Other", Value = "Other" },

    };

            ViewData["Region"] = list;
            ViewData["MemberStatusId"] = new SelectList(_context.MemberStatuses, "MemberStatusId", "MemberStatus1");

            ViewData["MemberShipTypeId"] = new SelectList(_context.MemberShipTypes, "MemberShipTypeId", "MemberShipName", member.MemberShipTypeId);
            ViewData["PaymentTypeId"] = new SelectList(_context.PaymentTypes, "PaymentId", "Method", member.PaymentTypeId);
            return View(member);
        }

        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var list = new List<SelectListItem>
    {
        new SelectListItem{ Text="African Traditional &amp; Diasporic", Value = "African Traditional &amp; Diasporic" },
        new SelectListItem{ Text="Agnostic", Value = "Agnostic" },
        new SelectListItem{ Text="Atheist", Value = "Atheist" },
        new SelectListItem{ Text="Baha'i", Value = "Baha'i" },
        new SelectListItem{ Text="Buddhism", Value = "Buddhism" },
        new SelectListItem{ Text="Cao Dai", Value = "Cao Dai" },
        new SelectListItem{ Text="Chinese traditional religion", Value = "Chinese traditional religion" },
        new SelectListItem{ Text="Christianity", Value = "Christianity" },
        new SelectListItem{ Text="Hinduism", Value = "Hinduism" },
        new SelectListItem{ Text="Islam", Value = "Islam" },
        new SelectListItem{ Text="Jainism", Value = "Jainism" },
        new SelectListItem{ Text="Juche", Value = "Juche" },
        new SelectListItem{ Text="Judaism", Value = "Judaism" },
        new SelectListItem{ Text="Neo-Paganism", Value = "Neo-Paganism" },
        new SelectListItem{ Text="Nonreligious", Value = "Nonreligious" },
        new SelectListItem{ Text="Rastafarianism", Value = "Rastafarianism" },
        new SelectListItem{ Text="Secular", Value = "Secular" },
        new SelectListItem{ Text="Shinto", Value = "Shinto" },
        new SelectListItem{ Text="Sikhism", Value = "Sikhism" },
        new SelectListItem{ Text="Spiritism", Value = "Spiritism" },
        new SelectListItem{ Text="Tenrikyo", Value = "Tenrikyo" },
        new SelectListItem{ Text="Unitarian-Universalism", Value = "Unitarian-Universalism" },
        new SelectListItem{ Text="Zoroastrianism", Value = "Zoroastrianism" },
        new SelectListItem{ Text="primal-indigenous", Value = "primal-indigenous" },
        new SelectListItem{ Text="Other", Value = "Other" },

    };

            ViewData["Region"] = list;
            if (id == null )
            {
                return NotFound();
            }

            var member = await _context.Members.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            ViewData["MemberStatusId"] = new SelectList(_context.MemberStatuses, "MemberStatusId", "MemberStatus1");

            ViewData["MemberShipTypeId"] = new SelectList(_context.MemberShipTypes, "MemberShipTypeId", "MemberShipName", member.MemberShipTypeId);
            ViewData["PaymentTypeId"] = new SelectList(_context.PaymentTypes, "PaymentId", "Method", member.PaymentTypeId);
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MembersId,FobNumber,MemberShipTypeId,PaymentTypeId,MemberStatus,FirstName,LastName,DateOfBirth,Email,Phone,Ethinicity,Religion,Title,MedicalNotes,StartDate,Weight,Height,CreatedAt,UpdatedAt")] Member member)
        {
            ModelState.Remove("MemberShipType");
            ModelState.Remove("PaymentType");
            if (id != member.MembersId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                try
                {
                    member.UpdatedAt = DateTime.Now;
                    _context.Update(member);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberExists(member.MembersId))
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
        new SelectListItem{ Text="African Traditional &amp; Diasporic", Value = "African Traditional &amp; Diasporic" },
        new SelectListItem{ Text="Agnostic", Value = "Agnostic" },
        new SelectListItem{ Text="Atheist", Value = "Atheist" },
        new SelectListItem{ Text="Baha'i", Value = "Baha'i" },
        new SelectListItem{ Text="Buddhism", Value = "Buddhism" },
        new SelectListItem{ Text="Cao Dai", Value = "Cao Dai" },
        new SelectListItem{ Text="Chinese traditional religion", Value = "Chinese traditional religion" },
        new SelectListItem{ Text="Christianity", Value = "Christianity" },
        new SelectListItem{ Text="Hinduism", Value = "Hinduism" },
        new SelectListItem{ Text="Islam", Value = "Islam" },
        new SelectListItem{ Text="Jainism", Value = "Jainism" },
        new SelectListItem{ Text="Juche", Value = "Juche" },
        new SelectListItem{ Text="Judaism", Value = "Judaism" },
        new SelectListItem{ Text="Neo-Paganism", Value = "Neo-Paganism" },
        new SelectListItem{ Text="Nonreligious", Value = "Nonreligious" },
        new SelectListItem{ Text="Rastafarianism", Value = "Rastafarianism" },
        new SelectListItem{ Text="Secular", Value = "Secular" },
        new SelectListItem{ Text="Shinto", Value = "Shinto" },
        new SelectListItem{ Text="Sikhism", Value = "Sikhism" },
        new SelectListItem{ Text="Spiritism", Value = "Spiritism" },
        new SelectListItem{ Text="Tenrikyo", Value = "Tenrikyo" },
        new SelectListItem{ Text="Unitarian-Universalism", Value = "Unitarian-Universalism" },
        new SelectListItem{ Text="Zoroastrianism", Value = "Zoroastrianism" },
        new SelectListItem{ Text="primal-indigenous", Value = "primal-indigenous" },
        new SelectListItem{ Text="Other", Value = "Other" },

    };

            ViewData["Region"] = list;
            ViewData["MemberStatusId"] = new SelectList(_context.MemberStatuses, "MemberStatusId", "MemberStatus1");

            ViewData["MemberShipTypeId"] = new SelectList(_context.MemberShipTypes, "MemberShipTypeId", "MemberShipName", member.MemberShipTypeId);
            ViewData["PaymentTypeId"] = new SelectList(_context.PaymentTypes, "PaymentId", "Method", member.PaymentTypeId);
            return View(member);
        }

        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var member = await _context.Members
                .Include(m => m.MemberShipType)
                .Include(m => m.PaymentType)
                .FirstOrDefaultAsync(m => m.MembersId == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id == null)
            {
                return Problem("Entity set 'LeifGymManagerMdfContext.Members'  is null.");
            }
          
            var member = await _context.Members.FindAsync(id);
            if (member != null)
            {
                var appoitnt = await _context.AppointmentManagers.FindAsync(member.MembersId);
                _context.AppointmentManagers.Remove(appoitnt);

                _context.Members.Remove(member);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberExists(int id)
        {
          return (_context.Members?.Any(e => e.MembersId == id)).GetValueOrDefault();
        }
    }
}
