using Leif_Gym_Manager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Leif_Gym_Manager.Controllers
{
    public class DashBoardController : Controller
    {
        public IActionResult Dashboard()
        {
            DashboardModel dash = new DashboardModel();
            //List<string> dashboards = new List<string>();
            //dashboards.Add("10:10");
            //dashboards.Add("11:11");
            //List<string> dashboards1 = new List<string>();
            //dashboards1.Add("10-11-2024");
            using (var db = new LeifGymManagerMdfContext())
            {
                var getmembercurrent = db.MemberCurrentVisitLogs.ToList();
                foreach (var member in getmembercurrent.GroupBy(v => v.CheckIn.ToString("hh:mm:ss tt")).Select(b => getmembercurrent.First().CheckIn).Take(50).ToList()) 
                {
                    Dashchart da = new Dashchart();
                    da.X = member.ToString("dd-MM-yyyy") ;
                    da.Y = member.ToString("hh:mm:ss tt") ;
                    dash.charts.Add(da);
                }

                dash.visislog_checkin_in_Timie_100 = getmembercurrent.Take(100).Select(x => x.CheckIn.ToString("hh:mm:ss tt")).ToList();
                dash.visislog_checkin_in_date_100 = getmembercurrent.Take(100).GroupBy(v => v).Select(b => getmembercurrent.First().CheckIn.ToString("dd-MM-yyyy")).ToList();

                dash.visislog_checkin_in_Timie_150 = getmembercurrent.Take(150).Select(x => x.CheckIn.ToString("hh:mm:ss tt")).ToList();
                dash.visislog_checkin_in_date_150 = getmembercurrent.Take(150).GroupBy(v => v).Select(b => getmembercurrent.First().CheckIn.ToString("dd-MM-yyyy")).ToList();
                ViewBag.TotalMember = db.Members.ToList().Count;
                int counts = 0;
                var getfobnumber = db.Members.Select(o => o.FobNumber).ToList();
                foreach (var member in getfobnumber)
                {
                    var current = db.MemberCurrentVisitLogs.Select(n=>n.FobNumber).ToList();
                    var history = db.MemberHistoricalVisitLogs.Select(n => n.FobNumber).ToList();
                    if(current.Contains(member) && !history.Contains(member))
                    {
                        counts++;
                    }

                }

                ViewBag.CurrentChecking = counts;
            }
            return View(dash);
        }

        public IActionResult Getdatachart()
        {
            DashboardModel dash = new DashboardModel();
            using (var db = new LeifGymManagerMdfContext())
            {
                var getmembercurrent = db.MemberCurrentVisitLogs.ToList();

                dash.visislog_checkin_in_Timie_100 = getmembercurrent.Take(100).Select(x => x.CheckIn.ToString("hh:mm:ss tt")).ToList();
                dash.visislog_checkin_in_date_100 = getmembercurrent.Take(100).GroupBy(v => v).Select(b => getmembercurrent.First().CheckIn.ToString("dd-MM-yyyy")).ToList();

                dash.visislog_checkin_in_Timie_150 = getmembercurrent.Take(150).Select(x => x.CheckIn.ToString("hh:mm:ss tt")).ToList();
                dash.visislog_checkin_in_date_150 = getmembercurrent.Take(150).GroupBy(v => v).Select(b => getmembercurrent.First().CheckIn.ToString("dd-MM-yyyy")).ToList();
            }
            return Json(dash);
        }
    }
}
