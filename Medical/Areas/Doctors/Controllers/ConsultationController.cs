using Medical.Models;
using Medical.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.Areas.Doctors.Controllers
{
    [Area(areaName: "Doctors")]
    public class ConsultationController : Controller
    {
        private readonly MedicalContext _medicalContext;
        public ConsultationController(MedicalContext medicalContext)
        {
            _medicalContext = medicalContext;
        }

        public IActionResult List()
        {
            int doctorId = 2;
            List<CClinicDetailAdminViewModel> list = new List<CClinicDetailAdminViewModel>();
            var result = _medicalContext.ClinicDetails.Include(x=>x.Doctor).Include(x=>x.Department).Include(x=>x.Room).Include(x=>x.Period).Where(x => x.DoctorId.Equals(doctorId));

            foreach (var c in result)
            {
                CClinicDetailAdminViewModel cc = new CClinicDetailAdminViewModel();
                cc.clinicDetail = c;
                list.Add(cc);
            }
            return View(list.ToList());
        }

        public IActionResult WorkSpace(int id)
        {
            List<CReserveViewModel> list = new List<CReserveViewModel>();
            var result = _medicalContext.Reserves.Include(x => x.Member).Where(x => x.ClinicDetailId.Equals(id));

            foreach (var c in result)
            {
                CReserveViewModel cr = new CReserveViewModel();
                cr.reserve = c;
                list.Add(cr);
            }
            return View(list.ToList());
        }

        public IActionResult History()
        {
            //int id = 1;

            return View();
        }

        public IActionResult user(int id)
        {
            var user = _medicalContext.CaseRecords.Include(x=>x.Reserve).Where(x => x.MemberId.Equals(id)).Select(x=> new {x.Reserve.ReserveDate, x.DiagnosticRecord });
            return Json(user);
        }
    }
}
