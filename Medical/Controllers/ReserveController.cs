using Medical.Models;
using Medical.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Medical.Controllers
{

    public class ReserveController : Controller
    {
        private readonly MedicalContext _context;

        public ReserveController(MedicalContext context)
        {
            _context = context;
        }
        // 得到篩選表資料(醫生 專科 門診日期)
        public IActionResult ReserveList()
        {

            CReserveforShowViewModel datas = null;
            datas = new CReserveforShowViewModel()
            {
                doctorsList = _context.Doctors.ToList(),
                departmentList = _context.Departments.ToList(),
                treatmentDetailList = _context.TreatmentDetails.ToList(),
                clinicDetailList = _context.ClinicDetails.ToList(),
                periodlist = _context.Periods.ToList(),
                clinicRoomlist = _context.ClinicRooms.ToList()
            };

            return View(datas);

        }
        
        //條件查詢門診
        public IActionResult ReserveResult(reserveViewModel result)
        {

            int departmentId = _context.Departments.Where(a => a.DeptName == result.departmentname)
                .Select(a => a.DepartmentId).FirstOrDefault();
            int doctorId = _context.Doctors.Where(a => a.DoctorName == result.doctorname)
                .Select(a => a.DoctorId).FirstOrDefault();
            // 還有 result.txtdate

            var id = _context.ClinicDetails;

            if (departmentId > 0 && doctorId > 0 && result.txtdate != null)
            {
                id.Where(a => a.DoctorId == doctorId)
                 .Where(a => a.DepartmentId == departmentId)
                 .Where(a => a.ClinicDate.Value.Date > result.txtdate);
            }
            else if (departmentId > 0 && doctorId > 0)
            {
                id.Where(a => a.DoctorId == doctorId)
                 .Where(a => a.DepartmentId == departmentId);
            }
            else if (departmentId > 0 && result.txtdate != null)
            {
                id.Where(a => a.ClinicDate.Value.Date > result.txtdate)
                 .Where(a => a.DepartmentId == departmentId);
            }
            else if (doctorId > 0 && result.txtdate != null)
            {
                id.Where(a => a.DoctorId == doctorId)
                 .Where(a => a.ClinicDate.Value.Date > result.txtdate);
            }
            else if (doctorId > 0 && departmentId == 0)
            {
                id.Where(a => a.DoctorId == doctorId);

            }
            else if (departmentId > 0 && doctorId == 0)
            {
                id.Where(a => a.DepartmentId == departmentId);

            }
            else if (result.txtdate != null)
            {
                id.Where(a => a.ClinicDate.Value.Date > result.txtdate);

            }
            else
            {
                id.Where(a => a.DoctorId == doctorId)
                 .Where(a => a.DepartmentId == departmentId)
                 .Where(a => a.ClinicDate.Value.Date > result.txtdate);
            }
            //.Where(a => a.ClinicDate.Value.Date > result.txtdate);.Where(a => a.DoctorId == doctorId)
            //.Where(a => a.DepartmentId == departmentId)
            //.Where(a => a.ClinicDate.Value.Date > result.txtdate);

            List<reserverSearch> list = new List<reserverSearch>();
            foreach (var item in id)
            {
                reserverSearch t = new reserverSearch(_context)
                {
                    doctorid = item.DoctorId,
                    departmentid = item.DepartmentId,
                    periodid = item.PeriodId,
                    roomid=item.RoomId,
                    date = item.ClinicDate,                
                    clinicDetailid = item.ClinicDetailId,                    
                };
                
                list.Add(t);

            }
            
            return Json(list);
        }

        //判斷登入狀況  取得門診資料 進入預約畫面 
        public IActionResult CreateReserve(reserveViewModel result)
        {
            if (HttpContext.Session.Keys.Contains(CDictionary.SK_LOGINED_USE))
            {
                CMemberAdminViewModel vm = null;
                string logJson = "";
                logJson = HttpContext.Session.GetString(CDictionary.SK_LOGINED_USE);
                vm = JsonSerializer.Deserialize<CMemberAdminViewModel>(logJson);
                int memberid = vm.MemberId;
                string member = vm.MemberName;
                string email = vm.Email;


                var id = _context.ClinicDetails.Where(n => n.ClinicDetailId == result.clinicDetailid);
                List<reserverSearch> list = new List<reserverSearch>();
                foreach (var item in id)
                {
                    reserverSearch t = new reserverSearch(_context)
                    {
                        doctorid = item.DoctorId,
                        departmentid = item.DepartmentId,
                        periodid = item.PeriodId,
                        roomid = item.RoomId,
                        date = item.ClinicDate,
                        clinicDetailid = item.ClinicDetailId,
                        memberid= memberid,
                        membername= member,
                        email=email
                    };

                    list.Add(t);                  
                }
                return Json(list);
            }

            return Content("null", "text/plain", Encoding.UTF8);  
        }

        //開始預約
        //public IActionResult CreateReserve(reserveViewModel result)
        //{



        //    return RedirectToAction("Login", "Login");
        //}








        public IActionResult ReserveSearch(int? member = 4)
        {
            ViewBag.name = _context.Reserves.Where(a => a.MemberId == member).Select(a => a.Member.MemberName).FirstOrDefault();
            var list = _context.Reserves.Where(a => a.MemberId == member)
                .Include(a => a.Member)
                .Include(a => a.State)
                .Include(a => a.Source)
                .Include(a => a.ClinicDetail)
                .ThenInclude(a => a.Doctor)
                .ToList();
            return View(list);

        }

        public IActionResult Delete(int reserveId)
        {
            Reserve result = new Reserve();
            result = _context.Reserves.FirstOrDefault(a => a.ReserveId == reserveId);
            if (result != null)
            {
                _context.Reserves.Remove(result);
                _context.SaveChanges();
            }

            return RedirectToAction("ReserveSearch");
        }


    }
}
