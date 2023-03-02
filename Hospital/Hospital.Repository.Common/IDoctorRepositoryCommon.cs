using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repository.Common
{
    public interface IDoctorRepositoryCommon
    {
        Task<List<DoctorModel>> GetDoctorsAsync();

        Task<List<DoctorModel>> GetDoctorsByIdAsync(Guid id);
    }
}
