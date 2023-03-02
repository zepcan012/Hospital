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
    public class PatientService : IPatientServiceCommon
    {
        protected IPatientRepositoryCommon PatientRepository { get; set; }

        public PatientService(IPatientRepositoryCommon patientRepository)
        {
            PatientRepository = patientRepository;
        }

        public async Task<List<PatientModel>> GetAllPatientsAsync()
        {


            return await PatientRepository.GetAllPatientsAsync();

        }

        public async Task<List<PatientModel>> GetPatientAsync(Guid id)
        {


            return await PatientRepository.GetPatientAsync(id);

        }

        public async Task<PatientModel> PutPatientAsync(PatientModel patient)
        {


            return await PatientRepository.PutPatientAsync(patient);
        }


        public async Task<PatientModel> UpdatePatientAsync(int IdentificationNumber, PatientModel patient)
        {

            return await PatientRepository.UpdatePatientAsync(IdentificationNumber, patient);

        }

        public async Task<PatientModel> DeletePatientAsync(Guid id)
        {

            return await PatientRepository.DeletePatientAsync(id);

        }
    }
}
