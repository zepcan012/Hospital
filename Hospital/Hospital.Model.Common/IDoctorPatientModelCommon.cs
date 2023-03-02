using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model.Common
{
    public interface IDoctorPatientModelCommon
    {
        Guid PatientID { get; set; }

        Guid DoctorID { get; set; }

        Guid DoctorPatientID { get; set; }

        List<IDoctorModelCommon> DoctorInfo { get; set; }

        List<IPatientModelCommon> PatientInfo { get; set; }
    }
}
