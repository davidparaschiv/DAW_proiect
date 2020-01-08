using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HttpTest.Models;
using Microsoft.AspNetCore.Authorization;

namespace HttpTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProfileController _profileController;

        public HomeController(ILogger<HomeController> logger, ProfileController profileController)
        {
            _logger = logger;
            _profileController = profileController;
        }

        public async Task<IActionResult> Index()
        {
            // auth & authr
            var isSignedIn = await _profileController.IsSignedIn();

            if (isSignedIn == false)
            {
                return RedirectToAction("LogIn", "Profile");
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
