using Medical.Models;
using Medical.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using static Medical.Controllers.calendar;

namespace Medical.Controllers
{
    [Area(areaName: "Admin")]
    public class AdminClinicDetailController : Controller
    {
        private readonly MedicalContext _medicalContext;
        public AdminClinicDetailController(MedicalContext medicalContext)
        {
            _medicalContext = medicalContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddClinic()
        {
            return View();
        }

        public IActionResult Preview(CClinicDetailAdminViewModel cVM)
        {
            return ViewComponent("preview", new { cVM = cVM });
        }

        public IActionResult loadData()
        {
            List<detail> list = new List<detail>();

            var qry = _medicalContext.ClinicDetails.Include(x => x.Doctor).Include(x => x.Room).Include(x => x.Period);

            foreach (var i in qry)
            {
                int dt = (i.ClinicDate).Value.Hour;
                string color;

                if (dt == 9)
                { color = "#0073b7"; }
                else if (dt == 13)
                { color = "#FBBC05"; }
                else
                { color = "#34A853"; }

                calendar.detail detail = new calendar.detail
                {
                    id = i.ClinicDetailId,
                    start = ((DateTime)(i.ClinicDate)).ToString("yyyy-MM-dd HH:00:00"),
                    end = (((DateTime)(i.ClinicDate)).AddHours(3)).ToString("yyyy-MM-dd HH:00:00"),
                    title = $"{i.Doctor.DoctorName}-診間:{i.Room.RoomName}",
                    borderColor = color,
                    backgroundColor = color,
                    extendedProps = new calendar.ExtendedProps
                    {
                        room = i.RoomId,
                        period = i.Period.PeriodDetail
                    }

                };
                list.Add(detail);
            }
            return Json(list);
        }

        public IActionResult CountClinicDetailId()
        {
            List<CClinicDetailViewModel> list = new List<CClinicDetailViewModel>();
            var count = _medicalContext.ClinicDetails.Count().ToString();
            return Content(count, "text/plain", System.Text.Encoding.UTF8);
        }

        public void Method(CClinicDetailViewModel cVM)
        {

            var result = _medicalContext.ClinicDetails.Where(x => x.ClinicDetailId.Equals(cVM.clinicId));
            var resultDoctor = _medicalContext.Doctors.Where(x => x.DoctorName.Equals(cVM.doctorname)).SingleOrDefault();
            cVM.DoctorId = resultDoctor.DoctorId;
            cVM.DepartmentId = resultDoctor.DepartmentId;

            if (result.Count() > 0)
            {
                Update(cVM);
            }
        }

        public void Create(CClinicDetailAdminViewModel[] obj)
        {
            foreach (var i in obj)
            {
                ClinicDetail c = new ClinicDetail()
                {
                    DoctorId = _medicalContext.Doctors.Where(x => x.DoctorName.Equals(i.doctorName)).SingleOrDefault().DoctorId,
                    DepartmentId = _medicalContext.Departments.Where(x => x.DeptName.Equals(i.deptName)).SingleOrDefault().DepartmentId,
                    PeriodId = _medicalContext.Periods.Where(x => x.PeriodDetail.Equals(i.periodName)).SingleOrDefault().PeriodId,
                    Online = 0,
                    //RoomId = _medicalContext.ClinicRooms.Where(x => x.RoomName.Equals(i.room)).SingleOrDefault().RoomId,
                    RoomId = i.room,
                    ClinicDate = TranDate(i.dateForm, i.periodName),
                    LimitNum = 6
                };
                _medicalContext.ClinicDetails.Add(c);
                _medicalContext.SaveChanges();
            }
        }

        public void Update(CClinicDetailViewModel cVM)
        {
            ClinicDetail clinicDetail = _medicalContext.ClinicDetails.Where(x => x.ClinicDetailId.Equals(cVM.clinicId)).FirstOrDefault();

            if (clinicDetail != null)
            {
                clinicDetail.DoctorId = cVM.DoctorId;
                clinicDetail.PeriodId = cVM.periodID;
                clinicDetail.RoomId = cVM.roomID;
                clinicDetail.ClinicDate = cVM.date;
                _medicalContext.SaveChanges();
            }
        }

        public IActionResult Dept()
        {
            var dept = _medicalContext.Departments.Select(x => new { x.DeptName, x.DepartmentId });
            return Json(dept);
        }

        public IActionResult doctorList(int? deptid)
        {
            var doctors = from q in _medicalContext.Doctors select q;
            if (deptid > 0)
            {
                doctors = doctors.Where(x => x.DepartmentId.Equals(deptid));
            }

            doctors.Select(x => new { x.DoctorName, x.DoctorId });

            return Json(doctors);
        }

        public IActionResult roomList()
        {
            var rooms = _medicalContext.ClinicRooms.Select(x => x.RoomName);
            return Json(rooms);
        }

        public DateTime TranDate(string date, string time)
        {
            string[] aryDate = date.Split('/');
            DateTime dt = new DateTime(int.Parse(aryDate[0]), int.Parse(aryDate[1]), int.Parse(aryDate[2]), 0, 0, 0);

            switch (time)
            {
                case "上午時段":
                    dt = dt.AddHours(9);
                    break;
                case "下午時段":
                    dt = dt.AddHours(13);
                    break;
                case "晚上時段":
                    dt = dt.AddHours(17);
                    break;
            }
            return dt;
        }
    }

    class calendar
    {
        public class Data
        {
            public detail[] details { get; set; }
        }
        public class ExtendedProps
        {
            public int? room { get; set; }
            public string period { get; set; }
        }

        public class detail
        {
            public int id { get; set; }
            //public string url { get; set; }
            public string start { get; set; }
            public string end { get; set; }
            public string title { get; set; }
            //public string textColor { get; set; }
            public string borderColor { get; set; }
            public string backgroundColor { get; set; }
            public ExtendedProps extendedProps { get; set; }
        }

    }
}
