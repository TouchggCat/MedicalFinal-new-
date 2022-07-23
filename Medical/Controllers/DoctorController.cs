using Medical.Models;
using Medical.ViewModel;
using Medical.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.Controllers
{
    public class DoctorController : Controller
    {
        private IWebHostEnvironment _enviroment;
        private readonly MedicalContext _db;
        public DoctorController(IWebHostEnvironment p, MedicalContext db)
        {
            _enviroment = p;
            _db = db;
        }
        public IActionResult Index(CKeyWordViewModel vModel)     //醫生後台主頁
        {
            IEnumerable<Doctor> datas = null;
            if (string.IsNullOrEmpty(vModel.txtKeyword))
            {
                datas = from t in _db.Doctors
                        join d in _db.Departments on t.DepartmentId equals d.DepartmentId
                        select t;
            }
            else
            {
                datas = _db.Doctors.Where(t => t.DoctorName.Contains(vModel.txtKeyword) ||
                t.Education.Contains(vModel.txtKeyword) || t.JobTitle.Contains(vModel.txtKeyword));
            }
            return View(datas);
        }

     
        public IActionResult ListTest(CKeyWordViewModel vModel)
        {
            IEnumerable<Doctor> datas = null;
            if (string.IsNullOrEmpty(vModel.txtKeyword))
            {
                datas = from doc in _db.Doctors
                        join d in _db.Departments on doc.DepartmentId equals d.DepartmentId
                        select doc;
            }
            else
            {
                datas = _db.Doctors.Where(t => t.DoctorName.Contains(vModel.txtKeyword));
               
            }
            return View(datas);
        }

        public IActionResult getTreatment(int? dcID)
        {
            var trt = from a in _db.Treatments
                      join b in _db.TreatmentDetails on a.TreatmentDetailId equals b.TreatmentDetailId
                      where a.DoctorId == dcID
                      select b.TreatmentDetail1;
            
            return Json(trt);
        }


        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("ListTest");
            }
            CDoctorDetailViewModel prod = new CDoctorDetailViewModel();
            Doctor DD = _db.Doctors.FirstOrDefault(t => t.DoctorId == id);
            Experience exp = _db.Experiences.FirstOrDefault(t => t.DoctorId == id);
            Treatment trt = _db.Treatments.FirstOrDefault(t => t.DoctorId == id);
            
            prod.doctor = DD;
            if (DD.DepartmentId != null)
                prod.department = _db.Departments.FirstOrDefault(t => t.DepartmentId == prod.doctor.DepartmentId);
            if (exp != null)
                prod.experience = _db.Experiences.FirstOrDefault(t => t.DoctorId == prod.doctor.DoctorId);
            if (trt != null)
            {
                prod.treatment = trt;
                TreatmentDetail trtD = _db.TreatmentDetails.FirstOrDefault(t => t.TreatmentDetailId == trt.TreatmentDetailId);
                if (trtD != null)
                prod.treatmentDetail = _db.TreatmentDetails.FirstOrDefault(t => t.TreatmentDetailId == prod.treatment.TreatmentDetailId);
            }
            
            if (prod == null)
                return RedirectToAction("Index");
            
            return View(prod);
        }
        public IActionResult SugDoc() {
            
            return View();
        }



        //==========冠名==========
        //瀏覽醫生評論        
        public IActionResult RatingDoctorpartail(int id)
        {
            //id = 1;
            ViewBag.name = _db.Doctors.Where(a => a.DoctorId == id).Select(a => a.DoctorName).FirstOrDefault();
            ViewBag.count = _db.RatingDoctors.Where(a => a.DoctorId == id).Where(a => a.Shade == null).Select(a=>a.Rating).Count();

            var result = _db.RatingDoctors.Where(a => a.DoctorId == id).Where(a => a.Shade == null)
                .Include(a => a.Doctor)
                .Include(a => a.RatingType)
                .ToList();
            return PartialView(result);
        }


    }
}
