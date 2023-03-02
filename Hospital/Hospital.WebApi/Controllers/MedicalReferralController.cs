using Hospital.Model;
using Hospital.Service;
using Hospital.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Hospital.WebApi.Controllers
{
    public class MedicalReferralController : ApiController
    {
        static List<MedicalReferralModel> medicalReferral = new List<MedicalReferralModel>();

        protected IMedicalReferralServiceCommon Service { get; set; }

        public MedicalReferralController(IMedicalReferralServiceCommon service)
        {
            Service = service;
        }


        [HttpGet]
        [Route("api/MedicalReferrals")]
        public async Task<HttpResponseMessage> GetAllMedicalReferrals()
        {


            medicalReferral = await Service.GetAllMedicalReferralsAsync();

            if (medicalReferral != null)
            {

                return Request.CreateResponse(HttpStatusCode.OK, medicalReferral);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Medical Referral Not Found");
            }

        }


        [HttpGet]
        [Route("api/Referralid/{id}")]
        public async Task<HttpResponseMessage> GetMedicalReferralAsync(Guid id)
        {


            medicalReferral = await Service.GetMedicalReferralAsync(id);

            if (medicalReferral != null)
            {

                return Request.CreateResponse(HttpStatusCode.OK, medicalReferral);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Medical Referral Not Found");
            }

        }


        [HttpPost]
        [Route("api/insertReferral")]
        public async Task<HttpResponseMessage> PostReferralAsync(MedicalReferralModelRest referral)
        {
        //        public Guid MedicalReferralID { get; set; }
        //public Guid AnamnesisID { get; set; }
        //public string Diagnosis { get; set; }
        //public string Department { get; set; }
        //public DateTime ReferralDate { get; set; }
        //public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }
        //public Boolean IsActive { get; set; }

            if (referral != null)
            {
                MedicalReferralModel insert = new MedicalReferralModel();

                insert.MedicalReferralID = Guid.NewGuid();
                insert.AnamnesisID = referral.AnamnesisID;
                insert.Diagnosis = referral.Diagnosis;
                insert.Department = referral.Department;
                insert.ReferralDate = referral.ReferralDate;
        

                await Service.PutReferralAsync(insert);
                return Request.CreateResponse(HttpStatusCode.OK, "Added new Medical Referral.");
            }

            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Insert failed.");
            }



            //MedicalReferralModel newReferral = new MedicalReferralModel();

            //newReferral.MedicalReferralID = Guid.NewGuid();
            //newReferral = await Service.PutReferralAsync(referral);

            //MedicalReferralModelRest newReferralRest = new MedicalReferralModelRest();
            //newReferralRest.Diagnosis = referral.Diagnosis;
            //newReferralRest.Department = referral.Department;
            //newReferralRest.ReferralDate = referral.ReferralDate;


            //return Request.CreateResponse(HttpStatusCode.OK, newReferralRest);

        }



        //ne treba nam jer radimo update zajedno sa anamnezom
        [Route("api/updateReferral")]
        public async Task<HttpResponseMessage> UpdateReferralAsync(int id, MedicalReferralModel referral)
        {


            MedicalReferralModel update = new MedicalReferralModel();

            update = await Service.UpdateReferralAsync(id, referral);

            if (update != null)
            {
                MedicalReferralModelRest newReferral = new MedicalReferralModelRest();
                newReferral.Diagnosis = referral.Diagnosis;
                newReferral.ReferralDate = referral.ReferralDate;
                newReferral.UpdatedAt = referral.UpdatedAt;


                return Request.CreateResponse(HttpStatusCode.OK, newReferral);
            }



            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Medical Referral does not exist in database.");
            }

        }


        [Route("api/deleteReferral")]
        public async Task<HttpResponseMessage> DeleteAsync(int id, MedicalReferralModel referral)
        {


            MedicalReferralModel delete = new MedicalReferralModel();

            delete = await Service.DeleteReferralAsync(id, referral);

            if (delete != null)
            {

                return Request.CreateResponse(HttpStatusCode.OK, "From now, this medical referral is inactive in database.");
            }



            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Medical referral does not exist in database.");
            }

        }


    }


    public class MedicalReferralModelRest
    {
        public Guid MedicalReferralID { get; set; }
        public Guid AnamnesisID { get; set; }
        public string Diagnosis { get; set; }
        public string Department { get; set; }
        public DateTime ReferralDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Boolean IsActive { get; set; }
    }

}

