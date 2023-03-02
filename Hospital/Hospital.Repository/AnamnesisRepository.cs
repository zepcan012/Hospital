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
    public class AnamnesisRepository : IAnamnesisRepositoryCommon
    {
        static string constr = @"Data Source=DESKTOP-9Q8TC1B\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True";

        static List<AnamnesisModel> anamnesis = new List<AnamnesisModel>();
        public async Task<List<AnamnesisModel>> GetAllAnamnesisAsync()
        {
            SqlConnection connection = new SqlConnection(constr);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Anamnesis", connection);
                await connection.OpenAsync();

                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {

                        AnamnesisModel anamnesisModel = new AnamnesisModel();
                        anamnesisModel.AnamnesisID = reader.GetGuid(0);
                        anamnesisModel.DoctorPatientID = reader.GetGuid(1);
                        anamnesisModel.Diagnosis = reader.GetString(2);
                        anamnesisModel.CreatedAt = reader.GetDateTime(3);
                        anamnesisModel.UpdatedAt = reader.GetDateTime(4);
                        anamnesisModel.IsActive = reader.GetBoolean(5);

                        anamnesis.Add(anamnesisModel);

                    }

                }
                return anamnesis;
                connection.Close();
            }
        }

        public async Task<List<AnamnesisModel>> GetAnamnesisAsync(Guid id)
        {
            SqlConnection connection = new SqlConnection(constr);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM Anamnesis WHERE AnamnesisID='{id}'", connection);
                await connection.OpenAsync();

                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {

                        AnamnesisModel anamnesisModel = new AnamnesisModel();
                        anamnesisModel.AnamnesisID = reader.GetGuid(0);
                        anamnesisModel.DoctorPatientID = reader.GetGuid(1);
                        anamnesisModel.Diagnosis = reader.GetString(2);
                        anamnesisModel.CreatedAt = reader.GetDateTime(3);
                        anamnesisModel.UpdatedAt = reader.GetDateTime(4);
                        anamnesisModel.IsActive = reader.GetBoolean(5);

                        anamnesis.Add(anamnesisModel);

                    }

                    return anamnesis;

                }
                else
                {
                    return null;
                }
                connection.Close();
            }
        }

        public async Task<AnamnesisModel> PutAnamnesisAsync(AnamnesisModel anamnesis)
        {
            //string connectionString = "Data Source=DESKTOP-9Q8TC1B;Initial Catalog=people;Integrated Security=True";
            SqlConnection connection = new SqlConnection(constr);
            SqlCommand command = new SqlCommand($"INSERT INTO Anamnesis (AnamnesisID, DoctorPatientID, Diagnosis, CreatedAt, UpdatedAt, IsActive) VALUES ('{anamnesis.AnamnesisID}', '{anamnesis.DoctorPatientID}', '{anamnesis.Diagnosis}',GETDATE(), GETDATE(), 1);", connection);


            connection.Open();

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = command;
            await adapter.InsertCommand.ExecuteNonQueryAsync();

            connection.Close();
            return anamnesis;
        }

        public async Task<AnamnesisModel> UpdateAnamnesisAsync(Guid id, AnamnesisModel anamnesis)
        {

            SqlConnection connection = new SqlConnection(constr);
          
           
                    await connection.OpenAsync();
                    string query1 = $"UPDATE Anamnesis SET Diagnosis = '{anamnesis.Diagnosis}', UpdatedAt = GETDATE() WHERE AnamnesisID = '{id}';";
                    string query2 = $"UPDATE MedicalReferral SET Diagnosis = '{anamnesis.Diagnosis}', UpdatedAt = GETDATE() WHERE AnamnesisID = '{id}';";
                    SqlTransaction transaction;
                    transaction = connection.BeginTransaction();
                    try
                    {
                        new SqlCommand(query1, connection, transaction)
                           .ExecuteNonQuery();
                        new SqlCommand(query2, connection, transaction)
                           .ExecuteNonQuery();
                        transaction.Commit();
                    }
                    catch (SqlException sqlError)
                    {
                        transaction.Rollback();
                    }  

                    connection.Close();
                    return null;
               

        }

        public async Task<AnamnesisModel> DeleteAnamnesisAsync(Guid id)
        {
            SqlConnection connection = new SqlConnection(constr);
            await connection.OpenAsync();
            string query1 = $"UPDATE Anamnesis SET IsActive='0' WHERE AnamnesisID = '{id}';";
            string query2 = $"UPDATE MedicalReferral SET IsActive='0' WHERE AnamnesisID = '{id}';";
            SqlTransaction transaction;
            transaction = connection.BeginTransaction();
            try
            {
                new SqlCommand(query1, connection, transaction)
                   .ExecuteNonQuery();
                new SqlCommand(query2, connection, transaction)
                   .ExecuteNonQuery();
                transaction.Commit();
            }
            catch (SqlException sqlError)
            {
                transaction.Rollback();
            }

            connection.Close();
            return null;

        }

        public async Task<List<AnamnesisModel>> GetMedicalReferralInfo()
        {
            SqlConnection connection = new SqlConnection(constr);
            string sql = @"SELECT 
                Anamnesis.AnamnesisID AS IDAnamnesis,
                Anamnesis.DoctorPatientID AS DoctorPatientID,
                Anamnesis.Diagnosis AS DiagnosisAnamnesis,
                Anamnesis.CreatedAt AS Created,
                Anamnesis.UpdatedAt AS Updated,
                Anamnesis.DeletedAt AS Deleted,
                MedicalReferral.MedicalReferralID AS MedicalReferralID,
                MedicalReferral.AnamnesisID AS AnamnesisID,
                MedicalReferral.Diagnosis AS Diagnosis,
                MedicalReferral.Department AS Department,
                MedicalReferral.ReferralDate AS ReferralDate,
                MedicalReferral.CreatedAt AS CreatedAt,
                MedicalReferral.UpdatedAt AS UpdatedAt,
                MedicalReferral.DeletedAt AS DeletedAt
                FROM Anamnesis
                INNER JOIN MedicalReferral on Anamnesis.AnamnesisID = MedicalReferral.AnamnesisID
                ORDER BY AnamnesisID
                ";
            using (SqlCommand comm = new SqlCommand(sql, connection))
            {
                List<AnamnesisModel> anamnesisList = new List<AnamnesisModel>();

                await connection.OpenAsync();
                SqlDataReader reader = await comm.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {

                        AnamnesisModel anamnesisModel = new AnamnesisModel();

                        anamnesisModel.AnamnesisID = reader.GetGuid(0);
                        anamnesisModel.DoctorPatientID = reader.GetGuid(1);
                        anamnesisModel.Diagnosis = reader.GetString(2);
                        anamnesisModel.CreatedAt = reader.GetDateTime(3);
                        anamnesisModel.UpdatedAt = reader.GetDateTime(4);
                        //anamnesisModel.DeletedAt = reader.GetDateTime(5);

                        MedicalReferralModel medicalReferralModel = new MedicalReferralModel();

                        medicalReferralModel.MedicalReferralID = reader.GetGuid(6);
                        medicalReferralModel.AnamnesisID = reader.GetGuid(7);
                        medicalReferralModel.Diagnosis = reader.GetString(8);
                        medicalReferralModel.Department = reader.GetString(9);
                        medicalReferralModel.ReferralDate = reader.GetDateTime(10);
                        medicalReferralModel.CreatedAt = reader.GetDateTime(11);
                        medicalReferralModel.UpdatedAt = reader.GetDateTime(12);
                        //medicalReferralModel.DeletedAt = reader.GetDateTime(13);


                        anamnesisModel.MedicalReferralInfo = new List<IMedicalReferralModelCommon>();


                        anamnesisModel.MedicalReferralInfo.Add(medicalReferralModel);


                        anamnesisList.Add(anamnesisModel);



                    }
                    return anamnesisList;
                    connection.Close();
                }
                else
                {
                    return anamnesisList;
                    connection.Close();
                }
            }
        }

        public async Task<List<AnamnesisModel>> GetDoctorPatientInfo()
        {
            SqlConnection connection = new SqlConnection(constr);
            string sql = @"SELECT 
                Anamnesis.AnamnesisID AS IDAnamnesis,
                Anamnesis.DoctorPatientID AS DoctorPatientID,
                Anamnesis.Diagnosis AS DiagnosisAnamnesis,
                Anamnesis.CreatedAt AS Created,
                Anamnesis.UpdatedAt AS Updated,
                Anamnesis.DeletedAt AS Deleted,

                DoctorPatient.PatientID AS PatientID,
                DoctorPatient.DoctorID AS DoctorID,
                DoctorPatient.DoctorPatientID AS IDDoctorPatient
                
                FROM Anamnesis
                INNER JOIN DoctorPatient on Anamnesis.DoctorPatientID = DoctorPatient.DoctorPatientID
                ORDER BY DoctorPatientID
                ";
            using (SqlCommand comm = new SqlCommand(sql, connection))
            {
                List<AnamnesisModel> anamnesisList = new List<AnamnesisModel>();

                await connection.OpenAsync();
                SqlDataReader reader = await comm.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {

                        AnamnesisModel anamnesisModel = new AnamnesisModel();

                        anamnesisModel.AnamnesisID = reader.GetGuid(0);
                        anamnesisModel.DoctorPatientID = reader.GetGuid(1);
                        anamnesisModel.Diagnosis = reader.GetString(2);
                        anamnesisModel.CreatedAt = reader.GetDateTime(3);
                        anamnesisModel.UpdatedAt = reader.GetDateTime(4);
                       //anamnesisModel.DeletedAt = reader.GetDateTime(5);

                        DoctorPatientModel doctorPatientModel = new DoctorPatientModel();

                        doctorPatientModel.PatientID = reader.GetGuid(6);
                        doctorPatientModel.DoctorID = reader.GetGuid(7);
                        doctorPatientModel.DoctorPatientID = reader.GetGuid(8);



                        anamnesisModel.DoctorPatientInfo = new List<IDoctorPatientModelCommon>();


                        anamnesisModel.DoctorPatientInfo.Add(doctorPatientModel);


                        anamnesisList.Add(anamnesisModel);



                    }
                    return anamnesisList;
                    connection.Close();
                }
                else
                {
                    return anamnesisList;
                    connection.Close();
                }
            }
        }



    }
}
