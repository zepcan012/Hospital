using Hospital.Model;
using Hospital.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repository
{
    public class DoctorRepository : IDoctorRepositoryCommon
    {
        static string constr = @"Data Source=DESKTOP-9Q8TC1B\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True";

        static List<DoctorModel> doctor = new List<DoctorModel>();
        public async Task<List<DoctorModel>> GetDoctorsAsync()
        {
            SqlConnection connection = new SqlConnection(constr);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Doctor", connection);
                await connection.OpenAsync();

                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {

                        DoctorModel doctorModel = new DoctorModel();
                        doctorModel.DoctorID = reader.GetGuid(0);
                        doctorModel.FirstName = reader.GetString(1);
                        doctorModel.LastName = reader.GetString(2);
                        doctorModel.TelephoneNumber = reader.GetString(3);
                        doctorModel.Email = reader.GetString(4);
                        doctorModel.DoctorPassword = reader.GetString(5);
                        doctorModel.CreatedAt = reader.GetDateTime(6);
                        doctorModel.DepartmentID = reader.GetGuid(7);

                        doctor.Add(doctorModel);
               
                    }

                }
                return doctor;
                connection.Close();
            }
        }



        public async Task<List<DoctorModel>> GetDoctorsByIdAsync(Guid id)
        {
            SqlConnection connection = new SqlConnection(constr);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Doctor WHERE doctorId='{id}'", connection);
                await connection.OpenAsync();

                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        DoctorModel doctorModel = new DoctorModel();
                        doctorModel.DoctorID = reader.GetGuid(0);
                        doctorModel.FirstName = reader.GetString(1);
                        doctorModel.LastName = reader.GetString(2);
                        doctorModel.TelephoneNumber = reader.GetString(3);
                        doctorModel.Email = reader.GetString(4);
                        doctorModel.DoctorPassword = reader.GetString(5);
                        doctorModel.CreatedAt = reader.GetDateTime(6);
                        doctorModel.DepartmentID = reader.GetGuid(7);

                        doctor.Add(doctorModel);


                    }

                    return doctor;

                }
                else
                {
                    return null;
                }

                connection.Close();
            }
        }




    }
}
