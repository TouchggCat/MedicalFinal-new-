using Medical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.ViewModel
{
    public class reserveViewModel
    {
        public string departmentname { get; set; }

        public string doctorname { get; set; }
        public string treatmentDetailname{ get; set; }

        public DateTime txtdate { get; set; }

    }
}
