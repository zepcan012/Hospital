using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repository.Common
{
    public interface IMedicalReferralRepositoryCommon
    {
        Task<List<MedicalReferralModel>> GetAllMedicalReferralsAsync();

        Task<List<MedicalReferralModel>> GetMedicalReferralAsync(Guid id);

        Task<MedicalReferralModel> PutReferralAsync(MedicalReferralModel referral);

        Task<MedicalReferralModel> UpdateReferralAsync(int id, MedicalReferralModel referral);

        Task<MedicalReferralModel> DeleteReferralAsync(int id, MedicalReferralModel referral);
    }
}
