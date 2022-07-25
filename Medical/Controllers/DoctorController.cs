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


        public IActionResult List(CKeyWordViewModel vModel)   //醫生前台資料 權限=1
        {
            //if (role != 1)
            //{
            //    return RedirectToAction("Index");
            //}

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
                //||
                //t.Education.Contains(vModel.txtKeyword) || t.JobTitle.Contains(vModel.txtKeyword));
            }
            return View(datas);
        }
        //public IActionResult getDep()    //開發中 Department選單
        //{
        //    var dep = _db.Departments.Select(a => a.DeptName).Distinct();
        //    return Json(dep);
        //}
        //public IActionResult getDoc(string depName)   //開發中 Department選單
        //{
        //    Department depN = _db.Departments.FirstOrDefault(b => b.DeptName == depName);
        //    var doc = _db.Doctors.Where(d => d.DepartmentId == depN.DepartmentId).Select(b => b.DoctorName).Distinct();
        //    return Json(doc);
        //}
        public IActionResult getTreatment(int? dcID)
        {
            var trt = from a in _db.Treatments
                      join b in _db.TreatmentDetails on a.TreatmentDetailId equals b.TreatmentDetailId
                      where a.DoctorId == dcID
                      select b.TreatmentDetail1;
            
            return Json(trt);
        }
        //public IActionResult getTreatmentDetail(int? trtID)
        //{
        //    Treatment trt = _db.Treatments.FirstOrDefault(b => b.TreatmentId == trtID);
        //    var trtD = _db.TreatmentDetails.Where(d => d.TreatmentDetailId == trt.TreatmentDetailId).Select(b => b.TreatmentDetail1).Distinct();
        //    return Json(trtD);
        //}
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
        
        public IActionResult GetDoctorWeb(string docName)   //讀取醫生資料
        {
            if (docName == null)
            {
                var docs = _db.Doctors.Where(t => t.DoctorName.Contains(""));
                return Json(docs);
            }
            else
            {
                var docs = _db.Doctors.Where(d => d.DoctorName == docName).Distinct();
                return Json(docs);
            }
        }
        
        
        
        
        
        public IActionResult SugDoc() {
            
            return View();
        }
        //==========冠名==========
        //瀏覽醫生評論
        //id寫死
        public IActionResult RatingDoctorpartail(int id)
        {
            ViewBag.name = _db.RatingDoctors.Where(a => a.DoctorId == id).Select(a => a.Doctor.DoctorName).FirstOrDefault();
            ViewBag.count = _db.RatingDoctors.Where(a => a.DoctorId == id).Where(a => a.Shade == false).Select(a=>a.Rating).Count();

            var result = _db.RatingDoctors.Where(a => a.DoctorId == id).Where(a => a.Shade == false)
                .Include(a => a.Doctor)
                .Include(a => a.RatingType)
                .ToList();
            return PartialView(result);
        }


    }
}
