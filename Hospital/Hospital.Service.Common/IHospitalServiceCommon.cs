using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service.Common
{
   public interface IHospitalServiceCommon
    {
        Task<List<HospitalModel>> ShowHospital();

        Task<List<HospitalModel>> GetDepartmentInfo();
    }
}
