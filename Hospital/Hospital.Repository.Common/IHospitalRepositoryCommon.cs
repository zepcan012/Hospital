using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repository.Common
{
    public interface IHospitalRepositoryCommon
    {
        Task<List<HospitalModel>> ShowHospital();

        Task<List<HospitalModel>> GetDepartmentInfo();
    }
}
