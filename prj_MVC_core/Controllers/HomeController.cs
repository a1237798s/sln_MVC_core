using Microsoft.AspNetCore.Mvc;
using prj_MVC_core.Models;
using prj_MVC_core.ViewModels;
using System.Diagnostics;
using System.Text.Json;

namespace prj_MVC_core.Controllers
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
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(CLoginViewModel vm)
        {
            TCustomer user = (new DbdemoContext()).TCustomers.FirstOrDefault(m => m.FEmail.Equals(vm.txtAccount) && m.FPassword.Equals(vm.txtPassword));

            if (user != null && user.FEmail.Equals(vm.txtAccount) && user.FPassword.Equals(vm.txtPassword))
            {
                string json = JsonSerializer.Serialize(user);
                HttpContext.Session.SetString(CDictionary.SK_LOGEDIN_USER, json);
                return RedirectToAction("Index");
            }
            else 
            {
                return RedirectToAction("Error");
            }
           
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
