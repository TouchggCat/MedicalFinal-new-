using Medical.Models;
using Medical.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.Controllers
{
    public class ClinicDetailController : Controller
    {
        
        private readonly MedicalContext _context;
        public ClinicDetailController(MedicalContext medicalContext)
        {
            _context = medicalContext;
        }
        


        public IActionResult List()
        {


            ViewBag.Time = DateTime.Now.ToString("yyyy/MM/dd");

            int hour = DateTime.Now.Hour;
            int Period = 0;

            if (hour <= 12)
            {
                Period = 1; //上午時段
            }
            if (hour > 12 &&hour<17)
            {
                Period = 2; //下午時段
            }
            if (hour > 17 && hour < 21)
            {
                Period = 3; //晚上時段
            }
            ViewBag.period = Period;
            var result = _context.ClinicDetails.Where(a => a.ClinicDate.Value.Date.Equals(DateTime.Today.Date))

                .Select(a => new CClinicDetailViewModel {
                    clinicDetail=a,
                    Doctor=a.Doctor,
                    Department=a.Department,
                    Room=a.Room,
                    Period=a.Period
                                                   
                });
                 


            return View(result);
        }


        public IActionResult Listjson()
        {           
            var result = _context.ClinicDetails.Where(a => a.ClinicDate.Value.Date.Equals(DateTime.Today.Date));
            List<Clinictime> list = new List<Clinictime>();
            foreach (var item in result)
            {
                Clinictime t = new Clinictime(_context)
                {
                    clinicDetailid=item.ClinicDetailId

                };
                list.Add(t);

            }
 
            return Json(list);
        }
        public IActionResult ListAjax()
        {
            return View();
        }
        public IActionResult loadClinicDetail(int period)
        {
            var details = from c in _context.ClinicDetails
                              join d in _context.Doctors on c.DoctorId equals d.DoctorId
                              join p in _context.Periods on c.PeriodId equals p.PeriodId
                              where c.PeriodId == period
                          select new { c.ClinicDetailId,d.DoctorName, p.PeriodDetail };
            return Json(details);
        }

        


        


    }
}
