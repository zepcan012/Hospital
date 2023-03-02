using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service.Common
{
    public interface IDoctorServiceCommon
    {
        Task<List<DoctorModel>> GetDoctorsAsync();

        Task<List<DoctorModel>> GetDoctorsByIdAsync(Guid id);
    }
}
