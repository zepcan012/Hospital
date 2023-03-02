using Hospital.Common;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service.Common
{
    public interface IDepartmentServiceCommon
    {
        Task<List<DepartmentModel>> GetAllDepartmentsAsync();

        Task<List<DepartmentModel>> GetDepartmentAsync(DepartmentModel getDepartment);

        Task<List<DepartmentModel>> GetDoctorInfo();

        Task<List<DepartmentModel>> DepartmentFiltering(IDepartmentFiltering filterDepartment);
    }
}
