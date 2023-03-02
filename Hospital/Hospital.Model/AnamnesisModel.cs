using Hospital.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class AnamnesisModel : IAnamnesisModelCommon
    {
        public Guid AnamnesisID { get; set; }

        public Guid DoctorPatientID { get; set; }

        public string Diagnosis { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Boolean IsActive { get; set; }

        public List<IMedicalReferralModelCommon> MedicalReferralInfo { get; set; }

        public List<IDoctorPatientModelCommon> DoctorPatientInfo { get; set; }

    }
}
