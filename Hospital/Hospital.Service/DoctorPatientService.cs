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
    public class DoctorPatientService : IDoctorPatientServiceCommon
    {
        protected IDoctorPatientRepositoryCommon DoctorPatientRepository { get; set; }

        public DoctorPatientService(IDoctorPatientRepositoryCommon doctorPatientRepository)
        {
            DoctorPatientRepository = doctorPatientRepository;
        }

        public async Task<List<DoctorPatientModel>> GetDoctorPatientInfo()
        {


            return await DoctorPatientRepository.GetDoctorPatientInfo();

        }

        public async Task<List<DoctorPatientModel>> GetDoctorPatientPatientInfo()
        {


            return await DoctorPatientRepository.GetDoctorPatientPatientInfo();

        }
    }
}
