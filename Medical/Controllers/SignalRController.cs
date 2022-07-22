using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.Controllers
{
    public class SignalRController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Partial()
        {
            return PartialView();
        }
    }
}
