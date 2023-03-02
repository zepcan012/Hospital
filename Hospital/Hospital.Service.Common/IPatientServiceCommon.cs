using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service.Common
{
    public interface IPatientServiceCommon
    {
        Task<List<PatientModel>> GetAllPatientsAsync();

        Task<List<PatientModel>> GetPatientAsync(Guid id);

        Task<PatientModel> PutPatientAsync(PatientModel patient);

        Task<PatientModel> UpdatePatientAsync(int id, PatientModel patient);

        Task<PatientModel> DeletePatientAsync(Guid id);
    }
}
