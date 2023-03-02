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
    public class HospitalRepository : IHospitalRepositoryCommon
    {
        static string constr = @"Data Source=DESKTOP-9Q8TC1B\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True";

        static List<HospitalModel> hospital = new List<HospitalModel>();
        public async Task<List<HospitalModel>> ShowHospital()
        {
            SqlConnection connection = new SqlConnection(constr);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Hospital", connection);
                await connection.OpenAsync();

                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {

                        HospitalModel hospitalModel = new HospitalModel();
                        hospitalModel.HospitalID = reader.GetGuid(0);
                        hospitalModel.HospitalName = reader.GetString(1);
                        hospitalModel.Address = reader.GetString(2);

                        hospital.Add(hospitalModel);

                    }

                }
                return hospital;
                connection.Close();
            }
        }


        public async Task<List<HospitalModel>> GetDepartmentInfo()
        {
            SqlConnection connection = new SqlConnection(constr);
            string sql = @"SELECT 
                Hospital.HospitalID AS HospitalID,
                Hospital.HospitalName AS HospitalName,
                Hospital.Adress AS Adress,
                Department.DepartmentID AS DepartmentID,
                Department.DepartmentName AS DepartmentName,
                Department.HospitalFloor AS HospitalFloor,
                Department.TelephoneNumber AS TelephoneNumber,
                Department.Specialization AS Specialization,
                Department.HospitalID AS IDHospital
                FROM Hospital
                INNER JOIN Department on Hospital.HospitalID = Department.HospitalID
                ORDER BY HospitalID
                ";
            using (SqlCommand comm = new SqlCommand(sql, connection))
            {
                List<HospitalModel> hospitalList = new List<HospitalModel>();

                await connection.OpenAsync();
                SqlDataReader reader = await comm.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {

                        HospitalModel hospitalModel = new HospitalModel();

                        hospitalModel.HospitalID = reader.GetGuid(0);
                        hospitalModel.HospitalName = reader.GetString(1);
                        hospitalModel.Address = reader.GetString(2);

                        DepartmentModel departmentModel = new DepartmentModel();

                        departmentModel.DepartmentID = reader.GetGuid(3);
                        departmentModel.DepartmentName = reader.GetString(4);
                        departmentModel.HospitalFloor = reader.GetInt32(5);
                        departmentModel.TelephoneNumber = reader.GetString(6);
                        departmentModel.Specialization = reader.GetString(7);


                        hospitalModel.DepartmentInfo = new List<Model.Common.IDepartmentModelCommon>();


                        hospitalModel.DepartmentInfo.Add(departmentModel);


                        hospitalList.Add(hospitalModel);



                    }
                    return hospitalList;
                    connection.Close();
                }
                else
                {
                    return hospitalList;
                    connection.Close();
                }
            }
        }

    }
}
