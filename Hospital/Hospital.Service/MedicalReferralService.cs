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
    public class MedicalReferralService : IMedicalReferralServiceCommon
    {
        protected IMedicalReferralRepositoryCommon MedicalReferralRepository { get; set; }

        public MedicalReferralService(IMedicalReferralRepositoryCommon medicalReferralRepository)
        {
            MedicalReferralRepository = medicalReferralRepository;
        }
        public async Task<List<MedicalReferralModel>> GetAllMedicalReferralsAsync()
        {


            return await MedicalReferralRepository.GetAllMedicalReferralsAsync();

        }

        public async Task<List<MedicalReferralModel>> GetMedicalReferralAsync(Guid id)
        {

            return await MedicalReferralRepository.GetMedicalReferralAsync(id);

        }


        public async Task<MedicalReferralModel> PutReferralAsync(MedicalReferralModel referral)
        {


            return await MedicalReferralRepository.PutReferralAsync(referral);
        }

        public async Task<MedicalReferralModel> UpdateReferralAsync(int id, MedicalReferralModel referral)
        {

            return await MedicalReferralRepository.UpdateReferralAsync(id, referral);

        }

        public async Task<MedicalReferralModel> DeleteReferralAsync(int id, MedicalReferralModel referral)
        {

            return await MedicalReferralRepository.DeleteReferralAsync(id, referral);

        }
    }
}
