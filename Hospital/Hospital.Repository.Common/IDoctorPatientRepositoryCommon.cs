using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repository.Common
{
    public interface IDoctorPatientRepositoryCommon
    {
        Task<List<DoctorPatientModel>> GetDoctorPatientInfo();

        Task<List<DoctorPatientModel>> GetDoctorPatientPatientInfo();
    }
}
