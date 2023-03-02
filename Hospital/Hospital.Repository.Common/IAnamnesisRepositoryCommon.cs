using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repository.Common
{
    public interface IAnamnesisRepositoryCommon
    {
        Task<List<AnamnesisModel>> GetAllAnamnesisAsync();

        Task<List<AnamnesisModel>> GetAnamnesisAsync(Guid id);

        Task<AnamnesisModel> PutAnamnesisAsync(AnamnesisModel anamnesis);

        Task<AnamnesisModel> UpdateAnamnesisAsync(Guid id,AnamnesisModel anamnesis);

        Task<AnamnesisModel> DeleteAnamnesisAsync(Guid id);

        Task<List<AnamnesisModel>> GetMedicalReferralInfo();

        Task<List<AnamnesisModel>> GetDoctorPatientInfo();
    }
}
