using Hospital.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class DepartmentModel : IDepartmentModelCommon
    {
        public Guid DepartmentID { get; set; }

        public string DepartmentName { get; set; }

        public int HospitalFloor { get; set; }

        public string TelephoneNumber { get; set; }

        public Guid HospitalID { get; set; }

        public string Specialization { get; set; }



        public List<IDoctorModelCommon> DoctorInfo { get; set; }
    }
}
