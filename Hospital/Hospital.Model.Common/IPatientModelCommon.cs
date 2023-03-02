using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model.Common
{
    public interface IPatientModelCommon
    {
        Guid PatientID { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }

        string IdentificationNumber { get; set; }

        DateTime CreatedAt { get; set; }

        DateTime UpdatedAt { get; set; }

        Boolean? IsActive { get; set; } 
    }
}
