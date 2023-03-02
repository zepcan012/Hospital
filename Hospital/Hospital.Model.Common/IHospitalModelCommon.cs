using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model.Common
{
    public interface IHospitalModelCommon
    {
        Guid HospitalID { get; set; }

        string HospitalName { get; set; }

        string Address { get; set; }

        List<IDepartmentModelCommon> DepartmentInfo { get; set; }
    }
}
