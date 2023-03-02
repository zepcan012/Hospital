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
    public class PatientController : ApiController
    {

        static List<PatientModel> patient = new List<PatientModel>();

        protected IPatientServiceCommon Service { get; set; }

        public PatientController(IPatientServiceCommon service)
        {
            Service = service;
        }

        [HttpGet]
        [Route("api/ShowAllPatients")]
        public async Task<HttpResponseMessage> GetAllPatients()
        {


            patient = await Service.GetAllPatientsAsync();

            if (patient != null)
            {

                return Request.CreateResponse(HttpStatusCode.OK, patient);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Patient Not Found");
            }

        }


        [HttpGet]
        [Route("api/getbyid/{id}")]
        public async Task<HttpResponseMessage> GetPatientAsync(Guid id)
        {


            patient = await Service.GetPatientAsync(id);

            if (patient != null)
            {

                return Request.CreateResponse(HttpStatusCode.OK, patient);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Patient Not Found");
            }

        }


        [HttpPost]
        [Route("api/insertPatient")]
        public async Task<HttpResponseMessage> PutPatientAsync(PatientModel patient)
        {


            PatientModel newPatient = new PatientModel();

            newPatient.PatientID = Guid.NewGuid();
            newPatient = await Service.PutPatientAsync(patient);

            PatientModelRest newPatientRest = new PatientModelRest();
            newPatientRest.PatientID = newPatient.PatientID;
            newPatientRest.FirstName = newPatient.FirstName;
            newPatientRest.LastName = newPatient.LastName;
            //newPatientRest.Diagnosis = newPatient.Diagnosis;
            newPatientRest.IdentificationNumber = newPatient.IdentificationNumber;
            //newPatientRest.MedicalRecordNumber = newPatient.MedicalRecordNumber;
            //newPatientRest.CreatedAt = newPatient.CreatedAt;


            return Request.CreateResponse(HttpStatusCode.OK, newPatientRest);

        }

        [Route("api/updatePatient")]
        public async Task<HttpResponseMessage> UpdatePatientAsync(int IdentificationNumber, PatientModel patient)
        {


            PatientModel update = new PatientModel();

            update = await Service.UpdatePatientAsync(IdentificationNumber, patient);

            if (update != null)
            {
                PatientModelRest newPatient = new PatientModelRest();
                newPatient.FirstName = patient.FirstName;
                newPatient.LastName = patient.LastName;
                //newPatient.Diagnosis = patient.Diagnosis;
                newPatient.IdentificationNumber = patient.IdentificationNumber;
                //newPatient.MedicalRecordNumber = patient.MedicalRecordNumber;
               // newPatient.UpdatedAt = patient.UpdatedAt;


                return Request.CreateResponse(HttpStatusCode.OK, newPatient);
            }



            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Patient does not exist in database.");
            }

        }


        [Route("api/deletePatient/{id}")]
        public async Task<HttpResponseMessage> DeletePatientAsync(Guid id)
        {


            PatientModel delete = new PatientModel();

            delete = await Service.DeletePatientAsync(id);

            if (delete != null)
            {

                return Request.CreateResponse(HttpStatusCode.OK, "From now, this patient is inactive in database.");
            }



            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Patient does not exist in database.");
            }

        }



    }


    public class PatientModelRest
    {
        public Guid PatientID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string IdentificationNumber { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Boolean IsActive { get; set; }
    }




}

