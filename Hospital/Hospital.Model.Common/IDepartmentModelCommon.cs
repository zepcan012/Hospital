using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model.Common
{
    public interface IDepartmentModelCommon
    {
        Guid DepartmentID { get; set; }

        string DepartmentName { get; set; }

        int HospitalFloor { get; set; }

        string TelephoneNumber { get; set; }

        Guid HospitalID { get; set; }

        string Specialization { get; set; }



        List<IDoctorModelCommon> DoctorInfo { get; set; }
    }
}
