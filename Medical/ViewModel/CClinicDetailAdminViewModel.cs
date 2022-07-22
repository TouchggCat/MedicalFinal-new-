using Medical.Controllers;
using Medical.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.ViewModel
{
    public class CClinicDetailAdminViewModel
    {

        private ClinicDetail _clinicDetail;

        public CClinicDetailAdminViewModel()
        {
            _clinicDetail = new ClinicDetail();
        }
        public ClinicDetail clinicDetail
        {
            get { return _clinicDetail; }
            set { _clinicDetail = value; }
        }

        public int ClinicDetailId
        {
            get { return _clinicDetail.ClinicDetailId; }
            set { _clinicDetail.ClinicDetailId = value; }
        }
        public int? DoctorId
        {
            get { return _clinicDetail.DoctorId; }
            set { _clinicDetail.DoctorId = value; }
        }
        public int? DepartmentId
        {
            get { return _clinicDetail.DepartmentId; }
            set { _clinicDetail.DepartmentId = value; }
        }
        public int PeriodId
        {
            get { return _clinicDetail.PeriodId; }
            set { _clinicDetail.PeriodId = value; }
        }
        public int? Online
        {
            get { return _clinicDetail.Online; }
            set { _clinicDetail.Online = value; }
        }
        public int? RoomId
        {
            get { return (int)_clinicDetail.RoomId; }
            set { _clinicDetail.RoomId = value; }
        }
        public DateTime? ClinicDate
        {
            get { return _clinicDetail.ClinicDate; }
            set { _clinicDetail.ClinicDate = value; }
        }
        [DisplayName("預約上限")]
        public int? LimitNum
        {
            get { return _clinicDetail.LimitNum; }
            set { _clinicDetail.LimitNum = value; }
        }
        public int id
        {
            set; get;
        }
        //public int doctorId
        //{
        //    set; get;
        //}

        public string doctorName
        {
            set; get;
        }

        //public int deptId
        //{
        //    set; get;
        //}

        public string deptName
        {
            set; get;
        }

        //public int period
        //{
        //    set; get;
        //}

        public string periodName
        {
            set; get;
        }

        public int room
        {
            set; get;
        }

        public string dateForm
        {
            set; get;
        }

        public string dateTo
        {
            set; get;
        }

        public int[] day
        {
            set; get;
        }

        public int[] time
        {
            set; get;
        }

        public bool repeat
        {
            set; get;
        }



        public virtual Department Department { get { return _clinicDetail.Department; } set { _clinicDetail.Department = value; } }
        public virtual Doctor Doctor { get { return _clinicDetail.Doctor; } set { _clinicDetail.Doctor = value; } }
        public virtual Period Period { get { return _clinicDetail.Period; } set { _clinicDetail.Period = value; } }
        public virtual ClinicRoom Room { get { return _clinicDetail.Room; } set { _clinicDetail.Room = value; } }
        public virtual ICollection<Reserve> Reserves { get { return _clinicDetail.Reserves; } set { _clinicDetail.Reserves = value; } }
    }
}
