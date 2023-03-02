using Hospital.Common;
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
    public class DepartmentRepository : IDepartmentRepositoryCommon
    {
        static string constr = @"Data Source=DESKTOP-9Q8TC1B\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True";

        static List<DepartmentModel> department = new List<DepartmentModel>();
        public async Task<List<DepartmentModel>> GetAllDepartmentsAsync()
        {
            SqlConnection connection = new SqlConnection(constr);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Department", connection);
                await connection.OpenAsync();

                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {

                        DepartmentModel departmentModel = new DepartmentModel();
                        departmentModel.DepartmentID = reader.GetGuid(0);
                        departmentModel.DepartmentName = reader.GetString(1);
                        departmentModel.HospitalFloor = reader.GetInt32(2);
                        departmentModel.TelephoneNumber = reader.GetString(3);
                        departmentModel.HospitalID = reader.GetGuid(4);
                        departmentModel.Specialization = reader.GetString(5);
                  

                        department.Add(departmentModel);

                    }

                    return department;

                }
                else
                {
                    return null;
                }
               
                connection.Close();
            }
        }


        public async Task<List<DepartmentModel>> GetDepartmentAsync(DepartmentModel getDepartment)
        {
            SqlConnection connection = new SqlConnection(constr);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Department WHERE DepartmentID='{getDepartment.DepartmentID}';", connection);
                await connection.OpenAsync();

                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {

                        DepartmentModel departmentModel = new DepartmentModel();
                        departmentModel.DepartmentID = reader.GetGuid(0);
                        departmentModel.DepartmentName = reader.GetString(1);
                        departmentModel.HospitalFloor = reader.GetInt32(2);
                        departmentModel.TelephoneNumber = reader.GetString(3);
                        departmentModel.HospitalID = reader.GetGuid(4);
                        departmentModel.Specialization = reader.GetString(5);


                        department.Add(departmentModel);

                    }

                    return department;

                }
                else
                {
                    return null;
                }

                connection.Close();
            }
        }

        //public async Task<List<DepartmentModel>> GetDepartmentAsync(Guid id)
        //{
        //    SqlConnection connection = new SqlConnection(constr);
        //    using (connection)
        //    {
        //        SqlCommand cmd = new SqlCommand($"SELECT * FROM Department WHERE departmentID='{id}';", connection);
        //        await connection.OpenAsync();

        //        SqlDataReader reader = await cmd.ExecuteReaderAsync();

        //        if (reader.HasRows)
        //        {
        //            while (await reader.ReadAsync())
        //            {

        //                DepartmentModel departmentModel = new DepartmentModel();
        //                departmentModel.DepartmentID = reader.GetGuid(0);
        //                departmentModel.DepartmentName = reader.GetString(1);
        //                departmentModel.HospitalFloor = reader.GetInt32(2);
        //                departmentModel.TelephoneNumber = reader.GetString(3);
        //                departmentModel.HospitalID = reader.GetGuid(4);
        //                departmentModel.Specialization = reader.GetString(5);


        //                department.Add(departmentModel);

        //            }

        //            return department;

        //        }
        //        else
        //        {
        //            return null;
        //        }

        //        connection.Close();
        //    }
        //}

        public async Task<List<DepartmentModel>> GetDoctorInfo()
        {
            SqlConnection connection = new SqlConnection(constr);
            string sql = @"SELECT 
                Department.DepartmentID AS DepartmentID,
                Department.DepartmentName AS DepartmentName,
                Department.HospitalFloor AS HospitalFLoor,
                Department.TelephoneNumber AS TelephoneNumber,
                Department.HospitalID AS HospitalID,
                Department.Specialization AS Specialization,
                
                Doctor.DoctorID AS DoctorID,
                Doctor.FirstName AS FirstName,
                Doctor.LastName AS LastName,
                Doctor.TelephoneNumber AS TelephoneNumber,
                Doctor.Email AS Email,
                Doctor.DoctorPassword AS DoctorPassword,
                Doctor.CreatedAt AS CreatedAt,
                Doctor.DepartmentID AS IDDepartment
                FROM Department
                INNER JOIN Doctor on Department.DepartmentID = Doctor.DepartmentID
                ORDER BY DepartmentID
                ";
            using (SqlCommand comm = new SqlCommand(sql, connection))
            {
                List<DepartmentModel> departmentList = new List<DepartmentModel>();

                await connection.OpenAsync();
                SqlDataReader reader = await comm.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        DepartmentModel departmentModel = new DepartmentModel();

                        departmentModel.DepartmentID = reader.GetGuid(0);
                        departmentModel.DepartmentName = reader.GetString(1);
                        departmentModel.HospitalFloor = reader.GetInt32(2);
                        departmentModel.TelephoneNumber = reader.GetString(3);
                        departmentModel.Specialization = reader.GetString(5);
                        departmentModel.HospitalID = reader.GetGuid(4);

                        DoctorModel doctorModel = new DoctorModel();

                        doctorModel.DoctorID = reader.GetGuid(6);
                        doctorModel.FirstName = reader.GetString(7);
                        doctorModel.LastName = reader.GetString(8);
                        doctorModel.TelephoneNumber = reader.GetString(9);
                        doctorModel.Email = reader.GetString(10);
                        doctorModel.DoctorPassword = reader.GetString(11);
                        doctorModel.CreatedAt = reader.GetDateTime(12);
                        doctorModel.DepartmentID = reader.GetGuid(13);

                        departmentModel.DoctorInfo = new List<IDoctorModelCommon>();
                        departmentModel.DoctorInfo.Add(doctorModel);
                        departmentList.Add(departmentModel);

                    }
                    return departmentList;
                    connection.Close();
                }
                else
                {
                    return departmentList;
                    connection.Close();
                }
            }
        }














        public async Task<List<DepartmentModel>> DepartmentFiltering(IDepartmentFiltering filterDepartment)
        {
            List<DepartmentModel> department = new List<DepartmentModel>();

            StringBuilder allDataString = new StringBuilder($"SELECT * FROM Department");

            if (filterDepartment != null)
            {
                allDataString.Append($"WHERE 1=1 ");

                if (!string.IsNullOrWhiteSpace(filterDepartment.DepartmentName))
                {
                    allDataString.Append($"AND DepartmentName LIKE '{filterDepartment.DepartmentName}' ");
                }
            }

            SqlConnection connection = new SqlConnection(constr);

            using (connection)
            {
                SqlCommand cmd = new SqlCommand(allDataString.ToString(), connection);

                SqlDataReader reader = await cmd.ExecuteReaderAsync();
                await connection.OpenAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        DepartmentModel departmentModel = new DepartmentModel();
                        departmentModel.DepartmentName = reader.GetString(1);
                        department.Add(departmentModel);
                    }
                    connection.Close();
                    return department;
                }
                else
                {
                    return department;
                }
            }
        }

    }
}
