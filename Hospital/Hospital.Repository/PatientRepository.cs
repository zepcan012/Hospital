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
    public class PatientRepository : IPatientRepositoryCommon
    {
        static string constr = @"Data Source=DESKTOP-9Q8TC1B\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True";

        static List<PatientModel> patient = new List<PatientModel>();

        public async Task<List<PatientModel>> GetAllPatientsAsync()
        {
            SqlConnection connection = new SqlConnection(constr);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Patient", connection);
                await connection.OpenAsync();

                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {

                        PatientModel patientModel = new PatientModel();
                        patientModel.PatientID = reader.GetGuid(0);
                        patientModel.FirstName = reader.GetString(1);
                        patientModel.LastName = reader.GetString(2);
                        patientModel.IdentificationNumber = reader.GetString(3);
                        patientModel.CreatedAt = reader.GetDateTime(4);
                        patientModel.UpdatedAt = reader.GetDateTime(5);
                        patientModel.IsActive = reader.GetBoolean(6);
                        //patientModel.DeletedAt = reader.GetDateTime(8);

                        //patientModel.UpdatedAt = (DateTime?)(reader.IsDBNull(7) ? null : reader[7]);
                       // patientModel.DeletedAt = (DateTime?)(reader.IsDBNull(8) ? null : reader[8]);

                        patient.Add(patientModel);

                    }

                    return patient;
                }
                else
                {
                    return null;
                }

                connection.Close();
            }
        }



        public async Task<List<PatientModel>> GetPatientAsync(Guid id)
        {
            SqlConnection connection = new SqlConnection(constr);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Patient  WHERE Patient.PatientID='{id}'", connection);
                await connection.OpenAsync();

                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {

                        PatientModel patientModel = new PatientModel();
                        patientModel.PatientID = reader.GetGuid(0);
                        patientModel.FirstName = reader.GetString(1);
                        patientModel.LastName = reader.GetString(2);
                        patientModel.IdentificationNumber = reader.GetString(3);
                        //patientModel.MedicalRecordNumber = reader.GetString(5);
                        patientModel.CreatedAt = reader.GetDateTime(4);
                        patientModel.UpdatedAt = reader.GetDateTime(5);
                        patientModel.IsActive = reader.GetBoolean(6);
                        //patientModel.DeletedAt = reader.GetDateTime(8);

                        //patientModel.UpdatedAt = (DateTime?)(reader.IsDBNull(7) ? null : reader[7]);
                        //patientModel.DeletedAt = (DateTime?)(reader.IsDBNull(8) ? null : reader[8]);



                        patient.Add(patientModel);

                    }

                    return patient;

                }
                else
                {
                    return null;
                }

                connection.Close();
            }
        }



        public async Task<PatientModel> PutPatientAsync(PatientModel patient)
        {
            //string connectionString = "Data Source=DESKTOP-9Q8TC1B;Initial Catalog=people;Integrated Security=True";
            SqlConnection connection = new SqlConnection(constr);
            SqlCommand command = new SqlCommand($"INSERT INTO Patient (PatientID, FirstName, LastName, Diagnosis, IdentificationNumber, MedicalRecordNumber, CreatedAt) VALUES ({patient.PatientID}, '{patient.FirstName}', '{patient.LastName}','{patient.IdentificationNumber}','{patient.CreatedAt}');", connection);


            connection.Open();

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = command;
            await adapter.InsertCommand.ExecuteNonQueryAsync();

            connection.Close();
            return patient;
        }



        public async Task<PatientModel> UpdatePatientAsync(int IdentificationNumber, PatientModel patient)
        {
            //string connectionString = "Data Source=DESKTOP-9Q8TC1B;Initial Catalog=people;Integrated Security=True";
            SqlConnection connection = new SqlConnection(constr);
            SqlCommand command = new SqlCommand($"SELECT * FROM Patient WHERE IdentificationNumber={IdentificationNumber};", connection);

            connection.Open();

            SqlDataReader reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                PatientModel updatePatient = new PatientModel();

                while (reader.Read())
                {
                    updatePatient.FirstName = patient.FirstName;
                    updatePatient.LastName = patient.LastName;
                    updatePatient.IdentificationNumber = patient.IdentificationNumber;
                    //updatePatient.MedicalRecordNumber = patient.MedicalRecordNumber;
                    updatePatient.UpdatedAt = patient.UpdatedAt;
                }
                reader.Close();
                SqlCommand command2 = new SqlCommand($"UPDATE Patient SET FirstName='{patient.FirstName}',LastName='{patient.LastName}', IdentificationNumber='{patient.IdentificationNumber}', updatedAt='{patient.UpdatedAt}' WHERE IdentificationNumber={IdentificationNumber};", connection);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.UpdateCommand = command2;
                await adapter.UpdateCommand.ExecuteNonQueryAsync();

                connection.Close();
                return patient;
            }
            else
            {
                return null;
            }
        }



        public async Task<PatientModel> DeletePatientAsync(Guid id)
        {
            //string connectionString = "Data Source=DESKTOP-9Q8TC1B;Initial Catalog=people;Integrated Security=True";
            SqlConnection connection = new SqlConnection(constr);
            SqlCommand command = new SqlCommand($"SELECT * FROM Patient WHERE PatientID='{id}';", connection);

            connection.Open();

            SqlDataReader reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                PatientModel deletePatient = new PatientModel();

                while (await reader.ReadAsync())
                {

                    deletePatient.PatientID = reader.GetGuid(0);
                    deletePatient.FirstName = reader.GetString(1);
                    deletePatient.LastName = reader.GetString(2);
                    deletePatient.IdentificationNumber = reader.GetString(3);
                    deletePatient.CreatedAt = reader.GetDateTime(4);
                    deletePatient.UpdatedAt = reader.GetDateTime(5);
                    deletePatient.IsActive = reader.GetBoolean(6);
                }
                reader.Close();
                SqlCommand command2 = new SqlCommand($"UPDATE Patient SET IsActive='0' WHERE PatientID='{id}';", connection);


                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.UpdateCommand = command2;
                await adapter.UpdateCommand.ExecuteNonQueryAsync();

                connection.Close();
                return deletePatient;
            }
            else
            {
                return null;
            }
        }



    }
}
