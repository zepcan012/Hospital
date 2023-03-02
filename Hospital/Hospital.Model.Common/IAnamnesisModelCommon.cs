using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model.Common
{
    public interface IAnamnesisModelCommon
    {
        Guid AnamnesisID { get; set; }

        Guid DoctorPatientID { get; set; }

        string Diagnosis { get; set; }

        DateTime CreatedAt { get; set; }

        DateTime UpdatedAt { get; set; }

        Boolean IsActive { get; set; }

        List<IMedicalReferralModelCommon> MedicalReferralInfo { get; set; }

        List<IDoctorPatientModelCommon> DoctorPatientInfo { get; set; }
    }
}
