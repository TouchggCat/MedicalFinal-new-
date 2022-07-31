using Medical.Hubs;
using Medical.Models;
using Medical.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.Areas.Admin.Controllers
{
    [Area(areaName: "Admin")]
    public class HomeController : Controller
    {
        private readonly MedicalContext _medicalContext;
        public HomeController(MedicalContext medicalContext)
        {
            _medicalContext = medicalContext;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
