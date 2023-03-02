using Hospital.Common;
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
    public class DepartmentController : ApiController
    {
        static List<DepartmentModel> department = new List<DepartmentModel>();

        protected IDepartmentServiceCommon Service { get; set; }

        public DepartmentController(IDepartmentServiceCommon service)
        {
            Service = service;
        }

        [HttpGet]
        [Route("api/Departments")]
        public async Task<HttpResponseMessage> GetAllDepartmentsAsync()
        {

            department = await Service.GetAllDepartmentsAsync();

            if (department != null)
            {

                return Request.CreateResponse(HttpStatusCode.OK, department);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Department Not Found");
            }

        }



        [HttpGet]
        [Route("api/Departmentsid")]


        public async Task<HttpResponseMessage> GetDepartmentAsync(DepartmentRest departmentRest)
        {


            

            if (departmentRest != null)
            {
                DepartmentModel getDepartment = new DepartmentModel();
                getDepartment.DepartmentID = departmentRest.DepartmentID;
                department= await Service.GetDepartmentAsync(getDepartment);
                return Request.CreateResponse(HttpStatusCode.OK, department);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Department Not Found");
            }

        }
        //public async Task<HttpResponseMessage> GetDepartmentAsync(Guid id)
        //{


        //    department = await Service.GetDepartmentAsync(id);

        //    if (department != null)
        //    {

        //        return Request.CreateResponse(HttpStatusCode.OK, department);
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound, "Department Not Found");
        //    }

        //}




        [HttpGet]
        [Route("api/Doctors")]
        public async Task<HttpResponseMessage> GetDoctorInfo()
        {


            department = await Service.GetDoctorInfo();

            if (department != null)
            {

                return Request.CreateResponse(HttpStatusCode.OK, department);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Doctor Not Found");
            }

        }



        [HttpGet]
        [Route("api/DepartmentFilter")]

        public async Task<HttpResponseMessage> DepartmentFiltering([FromUri] IDepartmentFiltering filterDepartment)
        {
            department = await Service.DepartmentFiltering(filterDepartment);
            if (department != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, department);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Department does not exist");
            }

        }


    }


    public class DepartmentRest
    {
        public Guid DepartmentID { get; set; }

    }

}

