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
    public class DoctorController : ApiController
    {
        static List<DoctorModel> doctor = new List<DoctorModel>();

        protected IDoctorServiceCommon Service { get; set; }

        public DoctorController(IDoctorServiceCommon service)
        {
            Service = service;
        }

        [HttpGet]
        [Route("api/GetAllDoctors")]

        public async Task<HttpResponseMessage> GetDoctorsAsync()
        {


            List<DoctorModel> doctorList = new List<DoctorModel>();

            doctorList = await Service.GetDoctorsAsync();

            if (doctor != null)
            {
                List<DoctorModelRest> doctorMapped = new List<DoctorModelRest>();

                foreach (DoctorModel doctor in doctorList)
                {
                    DoctorModelRest doctorRest = new DoctorModelRest
                    {
                        DoctorID = doctor.DoctorID,
                        FirstName = doctor.FirstName,
                        LastName = doctor.LastName,
                        TelephoneNumber = doctor.TelephoneNumber,
                        Email = doctor.Email,
                        DepartmentID = doctor.DepartmentID
                    };
                    doctorMapped.Add(doctorRest);
                }
                return Request.CreateResponse(HttpStatusCode.OK, doctorMapped);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Doctor Not Found!");
            }

        }



        [HttpGet]
        [Route("api/values/getbyid/{id}")]
        public async Task<HttpResponseMessage> GetDoctorsByIdAsync(Guid id)
        {


            List<DoctorModel> doctorList = new List<DoctorModel>();

            doctorList = await Service.GetDoctorsByIdAsync(id);
            if (doctor != null)
            {
                List<DoctorModelRest> doctorMapped = new List<DoctorModelRest>();

                foreach (DoctorModel doctor in doctorList)
                {
                    DoctorModelRest doctorRest = new DoctorModelRest
                    {
                        DoctorID = doctor.DoctorID,
                        FirstName = doctor.FirstName,
                        LastName = doctor.LastName,
                        TelephoneNumber = doctor.TelephoneNumber,
                        Email = doctor.Email,
                        DepartmentID = doctor.DepartmentID
                    };
                    doctorMapped.Add(doctorRest);
                }
                return Request.CreateResponse(HttpStatusCode.OK, doctorMapped);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Doctor Not Found!");
            }

        }



    }


    public class DoctorModelRest
    {
        public Guid DoctorID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string TelephoneNumber { get; set; }

        public string Email { get; set; }

        public Guid DepartmentID { get; set; }
    }
}

