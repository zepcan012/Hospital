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
    public class AnamnesisService : IAnamnesisServiceCommon
    {
        protected IAnamnesisRepositoryCommon AnamnesisRepository { get; set; }

        public AnamnesisService(IAnamnesisRepositoryCommon anamnesisRepository)
        {
            AnamnesisRepository = anamnesisRepository;
        }

        public async Task<List<AnamnesisModel>> GetAllAnamnesisAsync()
        {


            return await AnamnesisRepository.GetAllAnamnesisAsync();

        }

        public async Task<List<AnamnesisModel>> GetAnamnesisAsync(Guid id)
        {


            return await AnamnesisRepository.GetAnamnesisAsync(id);

        }


        public async Task<AnamnesisModel> PutAnamnesisAsync(AnamnesisModel anamnesis)
        {


            return await AnamnesisRepository.PutAnamnesisAsync(anamnesis);
        }

        public async Task<AnamnesisModel> UpdateAnamnesisAsync(Guid id, AnamnesisModel anamnesis)
        {

            return await AnamnesisRepository.UpdateAnamnesisAsync(id, anamnesis);

        }

        public async Task<AnamnesisModel> DeleteAnamnesisAsync(Guid id)
        {

            return await AnamnesisRepository.DeleteAnamnesisAsync(id);

        }



        public async Task<List<AnamnesisModel>> GetMedicalReferralInfo()
        {


            return await AnamnesisRepository.GetMedicalReferralInfo();

        }


        public async Task<List<AnamnesisModel>> GetDoctorPatientInfo()
        {


            return await AnamnesisRepository.GetDoctorPatientInfo();

        }
    }
}
