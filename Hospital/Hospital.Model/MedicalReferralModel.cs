using Hospital.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class MedicalReferralModel : IMedicalReferralModelCommon
    {
        public Guid MedicalReferralID { get; set; }

        public Guid AnamnesisID { get; set; }

        public string Diagnosis { get; set; }

        public string Department { get; set; }

        public DateTime ReferralDate { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Boolean IsActive { get; set; } = true;

    }
}
