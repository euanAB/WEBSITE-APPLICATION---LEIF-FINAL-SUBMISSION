using Leif_Gym_Manager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Leif_Gym_Manager.Controllers
{
    public class CheckInOutController : Controller
    {
        public IActionResult Index()
        {
            using (var db  = new LeifGymManagerMdfContext())
            {
                CheckInOuts checkInOuts = new CheckInOuts();
                var getfobnumber = db.Members.Select(v => v.FobNumber).ToList();
                foreach (var item in getfobnumber)
                {
                    CheckInOutsList lst = new CheckInOutsList();
                    lst.FobNumber = item;
                    lst.CheckIn = db.MemberCurrentVisitLogs.Where(v => v.FobNumber == item).Select(b => b.CheckIn).FirstOrDefault();
                    lst.CheckOut = db.MemberHistoricalVisitLogs.Where(v => v.FobNumber == item).Select(b => b.CheckOut).FirstOrDefault();
                    checkInOuts.check_IN_OUT.Add(lst);
                }
                return View(checkInOuts);

            }
        }

        public IActionResult EditCheckIn(string Fobnumber)
        {
            using (var db = new LeifGymManagerMdfContext())
            {
                var currentvistlog = db.MemberCurrentVisitLogs.Where(v => v.FobNumber == Fobnumber).FirstOrDefault();
                if (currentvistlog != null)
                {
                    currentvistlog.CheckIn = DateTime.Now;
                    currentvistlog.CreatedAt = DateTime.Now;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index", "CheckInOut");
        }

        public IActionResult EditCheckOut(string Fobnumber)
        {
            using (var db = new LeifGymManagerMdfContext())
            {
               var currentvistlog =  db.MemberHistoricalVisitLogs.Where(v => v.FobNumber == Fobnumber).FirstOrDefault();
                if(currentvistlog != null)
                {
                    currentvistlog.CreatedAt = DateTime.Now;
                    currentvistlog.CheckOut = DateTime.Now;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index", "CheckInOut");
        }
    }
}
