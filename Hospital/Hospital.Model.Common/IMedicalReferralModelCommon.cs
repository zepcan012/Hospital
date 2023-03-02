using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model.Common
{
    public interface IMedicalReferralModelCommon
    {
        Guid MedicalReferralID { get; set; }

        Guid AnamnesisID { get; set; }

        string Diagnosis { get; set; }

        string Department { get; set; }

        DateTime ReferralDate { get; set; }

        DateTime CreatedAt { get; set; }

        DateTime UpdatedAt { get; set; }

        Boolean IsActive { get; set; }

    }
}
