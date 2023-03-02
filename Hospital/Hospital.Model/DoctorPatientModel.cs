using Hospital.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class DoctorPatientModel : IDoctorPatientModelCommon
    {
        public Guid PatientID { get; set; }

        public  Guid DoctorID { get; set; }

        public Guid DoctorPatientID { get; set; }
        public List<IDoctorModelCommon> DoctorInfo { get; set; }

        public List<IPatientModelCommon> PatientInfo { get; set; }

    }
}
