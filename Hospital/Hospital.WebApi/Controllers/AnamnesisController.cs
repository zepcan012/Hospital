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
    public class AnamnesisController : ApiController
    {
        static List<AnamnesisModel> anamnesis = new List<AnamnesisModel>();

        protected IAnamnesisServiceCommon Service { get; set; }

        public AnamnesisController(IAnamnesisServiceCommon service)
        {
            Service = service;
        }

        [HttpGet]
        [Route("api/Anamnesis")]
        public async Task<HttpResponseMessage> GetAllAnamnesisAsync()
        {


            anamnesis = await Service.GetAllAnamnesisAsync();

            if (anamnesis != null)
            {

                return Request.CreateResponse(HttpStatusCode.OK, anamnesis);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Anamnesis Not Found");
            }

        }




        [HttpGet]
        [Route("api/Anamnesisid/{id}")]
        public async Task<HttpResponseMessage> GetAnamnesisAsync(Guid id)
        {


            anamnesis = await Service.GetAnamnesisAsync(id);

            if (anamnesis != null)
            {

                return Request.CreateResponse(HttpStatusCode.OK, anamnesis);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Anamnesis Not Found");
            }

        }


        [HttpPost]
        [Route("api/insertAnamnesis")]

        public async Task<HttpResponseMessage> PostAnamnesisAsync(AnamnesisModelRest anamnesis)
        {

            if (anamnesis != null)
            {
                AnamnesisModel insert = new AnamnesisModel();

                insert.AnamnesisID = Guid.NewGuid();
                insert.DoctorPatientID = anamnesis.DoctorPatientID;
                insert.Diagnosis = anamnesis.Diagnosis;

                await Service.PutAnamnesisAsync(insert);
                return Request.CreateResponse(HttpStatusCode.OK, "Added new Anamnesis.");
            }

            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Insert failed.");
            }


        }

        //public async Task<HttpResponseMessage> PostAnamnesisAsync(AnamnesisModel anamnesis)
        //{


        //    AnamnesisModel newAnamnesis = new AnamnesisModel();


        //    newAnamnesis = await Service.PutAnamnesisAsync(anamnesis);

        //    AnamnesisModelRest newAnamnesisRest = new AnamnesisModelRest();
        //    anamnesis.AnamnesisID = Guid.NewGuid();

        //    newAnamnesisRest.AnamnesisID = anamnesis.AnamnesisID;
        //    newAnamnesisRest.Diagnosis = anamnesis.Diagnosis;
        //    newAnamnesisRest.CreatedAt = anamnesis.CreatedAt;


        //    return Request.CreateResponse(HttpStatusCode.OK, newAnamnesisRest);

        //}


        [Route("api/updateAnamnesis/{id}")]
        public async Task<HttpResponseMessage> PutAnamnesisAsync(Guid id, UpdateAnamnesisModelRest anamnesis)
        {
            //await customerService.PostNewCustomerAsync(customer);


            if (anamnesis != null)
            {
                AnamnesisModel update = new AnamnesisModel();

                //update.AnamnesisID = anamnesis.AnamnesisID;
                update.Diagnosis = anamnesis.Diagnosis;

                await Service.UpdateAnamnesisAsync(id, update);
                return Request.CreateResponse(HttpStatusCode.OK, "Diagnosis has been updated.");
            }

            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Diagnosis does not exist.");
            }
            

        }


        [Route("api/deleteAnamnesis/{id}")]
        public async Task<HttpResponseMessage> DeleteAnamnesisAsync(Guid id)
        {


            AnamnesisModel delete = new AnamnesisModel();

            delete = await Service.DeleteAnamnesisAsync(id);

            if (delete != null)
            {

                return Request.CreateResponse(HttpStatusCode.OK, "From now, this anamnesis is inactive in database.");
            }



            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Anamnesis does not exist in database.");
            }

        }



        [HttpGet]
        [Route("api/MedicalReferral")]
        public async Task<HttpResponseMessage> GetMedicalReferralInfo()
        {


            anamnesis = await Service.GetMedicalReferralInfo();

            if (anamnesis != null)
            {

                return Request.CreateResponse(HttpStatusCode.OK, anamnesis);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Anamnesis Not Found");
            }

        }




        [HttpGet]
        [Route("api/AnamnesisDoctorPatientInfo")]
        public async Task<HttpResponseMessage> GetDoctorPatientInfo()
        {


            anamnesis = await Service.GetDoctorPatientInfo();

            if (anamnesis != null)
            {

                return Request.CreateResponse(HttpStatusCode.OK, anamnesis);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Doctor-Patient Not Found");
            }

        }




    }

    public class AnamnesisModelRest
    {
        public Guid AnamnesisID { get; set; }
        public Guid DoctorPatientID { get; set; }
        public string Diagnosis { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Boolean IsActive { get; set; }

    }

    public class UpdateAnamnesisModelRest
    {
        public Guid AnamnesisID { get; set; }
        public string Diagnosis { get; set; }

    }


   
}



