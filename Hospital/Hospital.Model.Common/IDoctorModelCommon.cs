using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model.Common
{
    public interface IDoctorModelCommon
    {
        Guid DoctorID { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }

        string TelephoneNumber { get; set; }

        string Email { get; set; }

        string DoctorPassword { get; set; }

        DateTime CreatedAt { get; set; }

        Guid DepartmentID { get; set; }
    }
}
