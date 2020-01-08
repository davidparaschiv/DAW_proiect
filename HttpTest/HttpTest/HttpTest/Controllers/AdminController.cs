using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HttpTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace HttpTest.Controllers
{
    public class AdminController : Controller
    {
        private AdminClient _adminClient;

        public AdminController(AdminClient adminClient)
        {
            _adminClient = adminClient;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _adminClient.GetAllAdmins());
        }
    }
}