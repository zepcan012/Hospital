using Hospital.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class HospitalModel : IHospitalModelCommon
    {
        public Guid HospitalID {get; set;}

        public string HospitalName { get; set; }

        public string Address { get; set; }

        public List<IDepartmentModelCommon> DepartmentInfo { get; set; }
    }
}
