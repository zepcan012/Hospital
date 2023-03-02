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
    public class HospitalService : IHospitalServiceCommon
    {
        protected IHospitalRepositoryCommon HospitalRepository { get; set; }

        public HospitalService(IHospitalRepositoryCommon hospitalRepository)
        {
            HospitalRepository = hospitalRepository;
        }

        public async Task<List<HospitalModel>> ShowHospital()
        {


            return await HospitalRepository.ShowHospital();

        }

        public async Task<List<HospitalModel>> GetDepartmentInfo()
        {


            return await HospitalRepository.GetDepartmentInfo();

        }
    }
}
