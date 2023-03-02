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
    public class HospitalController : ApiController
    {
        static List<HospitalModel> hospital = new List<HospitalModel>();

        protected IHospitalServiceCommon Service { get; set; }

        public HospitalController(IHospitalServiceCommon service)
        {
            Service = service;
        }

        [HttpGet]
        [Route("api/ShowHospital")]
        public async Task<HttpResponseMessage> ShowHospital()
        {


            hospital = await Service.ShowHospital();

            if (hospital != null)
            {

                return Request.CreateResponse(HttpStatusCode.OK, hospital);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Hospital Not Found");
            }

        }


        [HttpGet]
        [Route("api/ShowDepartment")]
        public async Task<HttpResponseMessage> GetDepartmentInfo()
        {


            hospital = await Service.GetDepartmentInfo();

            if (hospital != null)
            {

                return Request.CreateResponse(HttpStatusCode.OK, hospital);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Department Not Found");
            }

        }
    }
}
