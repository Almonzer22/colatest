using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ColaProject.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult LOGIN()
        {
            return View();
        }
    }
}