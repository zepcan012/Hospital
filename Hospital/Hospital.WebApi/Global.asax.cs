using Autofac;
using Autofac.Integration.WebApi;
using Hospital.Model;
using Hospital.Model.Common;
using Hospital.Repository;
using Hospital.Repository.Common;
using Hospital.Service;
using Hospital.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Hospital.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<HospitalModel>().As<IHospitalModelCommon>();
            builder.RegisterType<HospitalRepository>().As<IHospitalRepositoryCommon>();
            builder.RegisterType<HospitalService>().As<IHospitalServiceCommon>();

            builder.RegisterType<DepartmentModel>().As<IDepartmentModelCommon>();
            builder.RegisterType<DepartmentRepository>().As<IDepartmentRepositoryCommon>();
            builder.RegisterType<DepartmentService>().As<IDepartmentServiceCommon>();

            builder.RegisterType<DoctorModel>().As<IDoctorModelCommon>();
            builder.RegisterType<DoctorRepository>().As<IDoctorRepositoryCommon>();
            builder.RegisterType<DoctorService>().As<IDoctorServiceCommon>();

            builder.RegisterType<PatientModel>().As<IPatientModelCommon>();
            builder.RegisterType<PatientRepository>().As<IPatientRepositoryCommon>();
            builder.RegisterType<PatientService>().As<IPatientServiceCommon>();

            builder.RegisterType<AnamnesisModel>().As<IAnamnesisModelCommon>();
            builder.RegisterType<AnamnesisRepository>().As<IAnamnesisRepositoryCommon>();
            builder.RegisterType<AnamnesisService>().As<IAnamnesisServiceCommon>();

            builder.RegisterType<MedicalReferralModel>().As<IMedicalReferralModelCommon>();
            builder.RegisterType<MedicalReferralRepository>().As<IMedicalReferralRepositoryCommon>();
            builder.RegisterType<MedicalReferralService>().As<IMedicalReferralServiceCommon>();

            builder.RegisterType<DoctorPatientModel>().As<IDoctorPatientModelCommon>();
            builder.RegisterType<DoctorPatientRepository>().As<IDoctorPatientRepositoryCommon>();
            builder.RegisterType<DoctorPatientService>().As<IDoctorPatientServiceCommon>();


            var container = builder.Build();
            var config = GlobalConfiguration.Configuration;
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
