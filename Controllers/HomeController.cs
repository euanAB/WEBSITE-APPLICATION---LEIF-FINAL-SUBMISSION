using Leif_Gym_Manager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace Leif_Gym_Manager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            using (var db = new LeifGymManagerMdfContext())
            {
                var getstaff = db.Staff.ToList();
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult Index(LoginModel login)
        {
            using (var db = new LeifGymManagerMdfContext())
            {
                if (ModelState.IsValid)
                {
                    var isvalidstaff = db.Staff.Where(n=>n.Username  == login.username && n.Password == login.Password).FirstOrDefault();
                    if(isvalidstaff != null && isvalidstaff.RoleId > 0)
                    {
                        HttpContext.Session.SetString("Staffid", isvalidstaff.StaffId.ToString());
                        var istest = HttpContext.Session.GetString("Staffid"); 
                        return RedirectToAction("Dashboard", "Dashboard");

                    }
                }
            }
            return View(login);
        }

        public IActionResult Register()
        {
            using (var db = new LeifGymManagerMdfContext())
            {
                ViewBag.Role = db.Roles.Select(g => new SelectListItem { Value = g.RoleId.ToString(), Text = g.RoleName }).ToList();
            }
            return View();
        }

        [HttpPost]
        public IActionResult Register(Staff staff)
        {

            using (var db = new LeifGymManagerMdfContext())
            {
                ViewBag.Role = db.Roles.Select(g => new SelectListItem { Value = g.RoleId.ToString(), Text = g.RoleName }).ToList();

                ModelState.Remove("Role");


                if (ModelState.IsValid)
                {
                    staff.CreatedAt = DateTime.Now;
                    db.Staff.Add(staff);
                    var save = db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                return View(staff);

            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}