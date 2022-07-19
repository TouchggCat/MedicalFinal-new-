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
        public int? doctorid { get; set; }
        public int? departmentid { get; set; }
        public int? periodid { get; set; }
        public string doctor { get { return _context.Doctors.FirstOrDefault(n => n.DoctorId == doctorid).DoctorName; } }
        public string department { get { return _context.Departments.FirstOrDefault(n => n.DepartmentId == departmentid).DeptName; } }
        public string period { get { return _context.Periods.FirstOrDefault(n => n.PeriodId == periodid).PeriodDetail; } }
    }
}
