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
        //醫生id找科別
        public IActionResult getDepartment(string dcName)
        {
            var deps = from a in _db.Departments
                       join b in _db.Doctors on a.DepartmentId equals b.DepartmentId
                       where b.DoctorName == dcName
                       select a.DeptName;
            return Json(deps);
        }

        //讀取治療項
        public IActionResult getTreatment(int? dcID)
        {
            var trt = from a in _db.Treatments
                      join b in _db.TreatmentDetails on a.TreatmentDetailId equals b.TreatmentDetailId
                      where a.DoctorId == dcID
                      select b.TreatmentDetail1;
            
            return Json(trt);
        }
        public IActionResult getTreatmentByName(string doctorName)
        {
            var trt = from a in _db.Treatments
                      join b in _db.TreatmentDetails on a.TreatmentDetailId equals b.TreatmentDetailId
                      where a.DoctorId == _db.Doctors.FirstOrDefault(a => a.DoctorName == doctorName).DoctorId
                      select b.TreatmentDetail1;
            return Json(trt);
        }



        //前往醫生詳細資料
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

        //ListTest讀取醫生資料
        public IActionResult GetDoctorWeb(string docName)   
        {
            if (docName == null)
            {
                var docs = _db.Doctors.Where(t => t.DoctorName.Contains(""));
                return Json(docs);
            }
            else
            {
                var docs = _db.Doctors.Where(d => d.DoctorName == docName).Distinct().OrderBy(d=>d.DoctorId).Select(a=>a);
                return Json(docs);
            }
        }

        /////////機器人問題集/////////
        public IActionResult GetAnswer(string Qs)
        {
            Doctor dc = new Doctor();
            var Aws0 = new DocJsonViewModel
            {
                Answer = "請您說的詳細一點"
            };
            var Aws1 = new DocJsonViewModel
            {
                Question = "掛號",
                Answer = "目前我們採用線上和現場掛號\n"+
                "<a href='/Reserve/ReserveList' class='reserve'>掛號連結</a>"
            };
            var Aws2 = new DocJsonViewModel
            {
                Question = "交通",
                Answer = "106台北市大安區復興南路一段390號2樓\n" + "<iframe src='https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3615.004559158371!2d121.54122331544684!3d25.033919344447703!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3442abd3781b82e1%3A0xc0508038c1566f21!2zMTA25Y-w5YyX5biC5aSn5a6J5Yy65b6p6IiI5Y2X6Lev5LiA5q61Mzkw6JmfMuaokw!5e0!3m2!1szh-TW!2stw!4v1658825160170!5m2!1szh-TW!2stw' width='100%'style='border:0;' allowfullscreen='' loading='lazy' referrerpolicy='no-referrer-when-downgrade'></iframe>"
            };

            var Aws3 = new DocJsonViewModel
            {
                Question = "衛教",
                Answer = "這是我們的衛教文章區\n"+"<a href='/FrontArticle/List'>衛教專區</a>"+"\n這是我們推薦的知識型YouTube頻道\n" +
                "<a href='https://www.youtube.com/c/TheEyedoctorTube/featured'>大學眼科YT頻道</a>"
                
            };
            var Aws4 = new DocJsonViewModel
            {
                Question = "症狀",
                Answer = "請描述一下您的症狀"
            };
            var Aws5 = new DocJsonViewModel
            {
                Question = "痠痛",
                Answer = "是否伴隨頭暈頭痛?"
            };
            var Aws6 = new DocJsonViewModel
            {
                Question = "眼壓",
                Answer = "是否伴隨頭暈頭痛?"
            };
            var Aws7 = new DocJsonViewModel
            {
                Question = "青光眼",
                Answer = "是否伴隨頭暈頭痛?"
            };
            var Aws8 = new DocJsonViewModel
            {
                Question = "白內障",
                Answer = "是否伴隨頭暈頭痛?"
            };
            var Aws9 = new DocJsonViewModel
            {
                Question = "該掛哪科",
                Answer = "請描述一下您的症狀"
            };
            if (Qs.Contains(Aws1.Question))
                return Json(Aws1);
            if (Qs.Contains(Aws2.Question))
                return Json(Aws2);
            if (Qs.Contains(Aws3.Question))
                return Json(Aws3);
            if (Qs.Contains(Aws4.Question))
                return Json(Aws4);
            if (Qs.Contains(Aws5.Question))
                return Json(Aws5);
            if (Qs.Contains(Aws6.Question))
                return Json(Aws6);
            if (Qs.Contains(Aws7.Question))
                return Json(Aws7);
            if (Qs.Contains(Aws8.Question))
                return Json(Aws8);
            if (Qs.Contains(Aws9.Question))
                return Json(Aws9);
            else
                return Json(Aws0);
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
