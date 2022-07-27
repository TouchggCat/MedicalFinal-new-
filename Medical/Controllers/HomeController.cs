﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Medical.Models;
using Medical.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Medical.ViewModels;

namespace Medical.Controllers
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
            //int user = 0;
            //if (HttpContext.Session.Keys.Contains(CDictionary.SK_LOGINED_USE))
            //{
            //    CMemberAdminViewModel vm = null;

            //    string logJson = "";
            //    logJson = HttpContext.Session.GetString(CDictionary.SK_LOGINED_USE);
            //    vm = JsonSerializer.Deserialize<CMemberAdminViewModel>(logJson);


            //    user = (int)vm.Role;
            //}

            //return View(user);
            return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
