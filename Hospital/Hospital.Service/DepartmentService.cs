using Hospital.Common;
using Hospital.Model;
using Hospital.Repository;
using Hospital.Repository.Common;
using Hospital.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service
{
    public class DepartmentService : IDepartmentServiceCommon
    {
        protected IDepartmentRepositoryCommon DepartmentRepository { get; set; }



        public DepartmentService(IDepartmentRepositoryCommon departmentRepository)
        {
            DepartmentRepository = departmentRepository;
        }

        public async Task<List<DepartmentModel>> GetAllDepartmentsAsync() { 
    
            return await DepartmentRepository.GetAllDepartmentsAsync();
        }

        public async Task<List<DepartmentModel>> GetDepartmentAsync(DepartmentModel getDepartment)
        {


            return await DepartmentRepository.GetDepartmentAsync(getDepartment);

        }

        public async Task<List<DepartmentModel>> GetDoctorInfo()
        {


            return await DepartmentRepository.GetDoctorInfo();

        }

        public async Task<List<DepartmentModel>> DepartmentFiltering(IDepartmentFiltering filterDepartment)
        {
            return await DepartmentRepository.DepartmentFiltering(filterDepartment);
        }
    }
    
}
