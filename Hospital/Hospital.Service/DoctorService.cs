using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Repository;
using Hospital.Repository.Common;
using Hospital.Service.Common;

namespace Hospital.Service
{
    public class DoctorService : IDoctorServiceCommon
    {
        protected IDoctorRepositoryCommon DoctorRepository { get; set; }

        public DoctorService(IDoctorRepositoryCommon doctorRepository)
        {
            DoctorRepository = doctorRepository;
        }

        public async Task<List<DoctorModel>> GetDoctorsAsync()
        {


            return await DoctorRepository.GetDoctorsAsync();
        }

        public async Task<List<DoctorModel>> GetDoctorsByIdAsync(Guid id)
        {

            return await DoctorRepository.GetDoctorsByIdAsync(id);
        }
    }
}
