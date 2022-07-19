using Medical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.ViewModel
{
    public class reserverSearch
    {
        private readonly MedicalContext _context;
        public reserverSearch(MedicalContext db)
        {
            _context = db;
        }

        public int? day { get; set; }
       
        public int? doctorid { get; set; }
        public int? departmentid { get; set; }
        public int? periodid { get; set; }
        public int? roomid { get; set; }        
        
        public int? clinicDetailid { get; set; }

        
        public string doctor { get { return _context.Doctors.FirstOrDefault(n => n.DoctorId == doctorid).DoctorName; } }
        public string department { get { return _context.Departments.FirstOrDefault(n => n.DepartmentId == departmentid).DeptName; } }
        public string period { get { return _context.Periods.FirstOrDefault(n => n.PeriodId == periodid).PeriodDetail; } }

        public string roomName { get { return _context.ClinicRooms.FirstOrDefault(n => n.RoomId == roomid).RoomName; } }

        public int? treatmentDetailId { get { return _context.Treatments.FirstOrDefault(n => n.DoctorId==doctorid).TreatmentDetailId; } }

        public string treatmentDetail { get { return _context.TreatmentDetails.FirstOrDefault(n => n.TreatmentDetailId == treatmentDetailId).TreatmentDetail1; } }
        
        //剩餘的可預約人數
        public int? sequence_number 
        { 
            get 
            {
                int? sequence = 0;
                //如果有診 但還沒有人預約 回傳可預約人數6人
                var result= _context.Reserves.Where(n => n.ClinicDetailId == clinicDetailid);
                if (result.Count()==0)
                {
                    sequence= 6;
                }
                foreach (var item in result)
                {
                    //如果有人預約 sequence_number卻是null
                    if (item.SequenceNumber == null)
                    { sequence = 6; }
                    //6減最大的sequence_number 等於 剩餘人數
                    sequence = 6 - item.SequenceNumber;                                  
                }
                return sequence;  
            }
             
        }

       
    }
}
