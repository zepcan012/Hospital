using Hospital.Model;
using Hospital.Model.Common;
using Hospital.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repository
{
    public class DoctorPatientRepository : IDoctorPatientRepositoryCommon
    {
        static string constr = @"Data Source=DESKTOP-9Q8TC1B\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True";

        static List<DoctorPatientModel> doctorPatient = new List<DoctorPatientModel>();


        public async Task<List<DoctorPatientModel>> GetDoctorPatientInfo()
        {
            SqlConnection connection = new SqlConnection(constr);
            string sql = @"SELECT 
                DoctorPatient.PatientID AS PatientID,
                DoctorPatient.DoctorID AS DoctorID,
                DoctorPatient.DoctorPatientID AS DoctorPatientID,

                Doctor.DoctorID AS IDDoctor,
                Doctor.FirstName AS FirstName,
                Doctor.LastName AS LastName,
                Doctor.TelephoneNumber AS TelephoneNumber,
                Doctor.Email AS Email,
                Doctor.DoctorPassword AS DoctorPassword,
                Doctor.CreatedAt AS CreatedAt,
                Doctor.DepartmentID AS DepartmentID
                FROM DoctorPatient
                INNER JOIN Doctor on DoctorPatient.DoctorID = Doctor.DoctorID
                ORDER BY DoctorID
                ";
            using (SqlCommand comm = new SqlCommand(sql, connection))
            {
                List<DoctorPatientModel> doctorPatientList = new List<DoctorPatientModel>();

                await connection.OpenAsync();
                SqlDataReader reader = await comm.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {

                        DoctorPatientModel doctorPatientModel = new DoctorPatientModel();

                        doctorPatientModel.PatientID = reader.GetGuid(0);
                        doctorPatientModel.DoctorID = reader.GetGuid(1);
                        doctorPatientModel.DoctorPatientID = reader.GetGuid(2);

                        DoctorModel doctorModel = new DoctorModel();

                        doctorModel.DoctorID = reader.GetGuid(3);
                        doctorModel.FirstName = reader.GetString(4);
                        doctorModel.LastName = reader.GetString(5);
                        doctorModel.TelephoneNumber = reader.GetString(6);
                        doctorModel.Email = reader.GetString(7);
                        doctorModel.DoctorPassword = reader.GetString(8);
                        doctorModel.CreatedAt = reader.GetDateTime(9);
                        doctorModel.DepartmentID = reader.GetGuid(10);


                        doctorPatientModel.DoctorInfo = new List<IDoctorModelCommon>();


                        doctorPatientModel.DoctorInfo.Add(doctorModel);


                        doctorPatientList.Add(doctorPatientModel);



                    }
                    return doctorPatientList;
                    connection.Close();
                }
                else
                {
                    return doctorPatientList;
                    connection.Close();
                }
            }
        }



        public async Task<List<DoctorPatientModel>> GetDoctorPatientPatientInfo()
        {
            SqlConnection connection = new SqlConnection(constr);
            string sql = @"SELECT 
                DoctorPatient.PatientID AS PatientID,
                DoctorPatient.DoctorID AS DoctorID,
                DoctorPatient.DoctorPatientID AS DoctorPatientID,

                Patient.PatientID AS IDPatient,
                Patient.FirstName AS FirstName,
                Patient.LastName AS LastName,
                Patient.Diagnosis AS Diagnosis,
                Patient.IdentificationNumber AS IdentificationNumber,
                Patient.MedicalRecordNumber AS MedicalRecordNumber,
                Patient.CreatedAt AS CreatedAt,
                Patient.UpdatedAt AS UpdatedAt,
                Patient.DeletedAt AS DeletedAt
                FROM DoctorPatient
                INNER JOIN Patient on DoctorPatient.PatientID = Patient.PatientID
                ORDER BY PatientID
                ";
            using (SqlCommand comm = new SqlCommand(sql, connection))
            {
                List<DoctorPatientModel> doctorPatientList = new List<DoctorPatientModel>();

                await connection.OpenAsync();
                SqlDataReader reader = await comm.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {

                        DoctorPatientModel doctorPatientModel = new DoctorPatientModel();

                        doctorPatientModel.PatientID = reader.GetGuid(0);
                        doctorPatientModel.DoctorID = reader.GetGuid(1);
                        doctorPatientModel.DoctorPatientID = reader.GetGuid(2);

                        PatientModel patientModel = new PatientModel();

                        patientModel.PatientID = reader.GetGuid(3);
                        patientModel.FirstName = reader.GetString(4);
                        patientModel.LastName = reader.GetString(5);
                        //patientModel.Diagnosis = reader.GetString(6);
                        patientModel.IdentificationNumber = reader.GetString(7);
                        //patientModel.MedicalRecordNumber = reader.GetString(8);
                        patientModel.CreatedAt = reader.GetDateTime(8);
                        patientModel.UpdatedAt = reader.GetDateTime(9);
                        patientModel.IsActive = reader.GetBoolean(10);


                        doctorPatientModel.PatientInfo = new List<IPatientModelCommon>();


                        doctorPatientModel.PatientInfo.Add(patientModel);


                        doctorPatientList.Add(doctorPatientModel);



                    }
                    return doctorPatientList;
                    connection.Close();
                }
                else
                {
                    return doctorPatientList;
                    connection.Close();
                }
            }
        }

    }
}
