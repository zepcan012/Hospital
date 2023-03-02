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
    public class MedicalReferralRepository : IMedicalReferralRepositoryCommon
    {
        static string constr = @"Data Source=DESKTOP-9Q8TC1B\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True";

        static List<MedicalReferralModel> medicalReferral = new List<MedicalReferralModel>();
        public async Task<List<MedicalReferralModel>> GetAllMedicalReferralsAsync()
        {
            SqlConnection connection = new SqlConnection(constr);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM MedicalReferral", connection);
                await connection.OpenAsync();

                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {

                        MedicalReferralModel medicalReferralModel = new MedicalReferralModel();
                        medicalReferralModel.MedicalReferralID = reader.GetGuid(0);
                        medicalReferralModel.AnamnesisID = reader.GetGuid(1);
                        medicalReferralModel.Diagnosis = reader.GetString(2);
                        medicalReferralModel.Department = reader.GetString(3);
                        medicalReferralModel.ReferralDate = reader.GetDateTime(4);
                        medicalReferralModel.CreatedAt = reader.GetDateTime(5);
                        medicalReferralModel.UpdatedAt = reader.GetDateTime(6);
                        medicalReferralModel.IsActive = reader.GetBoolean(7);

                        medicalReferral.Add(medicalReferralModel);

                    }

                }
                return medicalReferral;
                connection.Close();
            }
        }

        public async Task<List<MedicalReferralModel>> GetMedicalReferralAsync(Guid id)
        {
            SqlConnection connection = new SqlConnection(constr);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand($"SELECT * FROM MedicalReferral WHERE MedicalReferralID = '{id}'", connection);
                await connection.OpenAsync();

                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {

                        MedicalReferralModel medicalReferralModel = new MedicalReferralModel();
                        medicalReferralModel.MedicalReferralID = reader.GetGuid(0);
                        medicalReferralModel.AnamnesisID = reader.GetGuid(1);
                        medicalReferralModel.Diagnosis = reader.GetString(2);
                        medicalReferralModel.Department = reader.GetString(3);
                        medicalReferralModel.ReferralDate = reader.GetDateTime(4);
                        medicalReferralModel.CreatedAt = reader.GetDateTime(5);
                        medicalReferralModel.UpdatedAt = reader.GetDateTime(6);
                        medicalReferralModel.IsActive = reader.GetBoolean(7);

                        medicalReferral.Add(medicalReferralModel);

                    }
                    return medicalReferral;

                }
                else
                {
                    return null;
                }

                connection.Close();
            }
        }


        public async Task<MedicalReferralModel> PutReferralAsync(MedicalReferralModel referral)
        {
            //string connectionString = "Data Source=DESKTOP-9Q8TC1B;Initial Catalog=people;Integrated Security=True";
            SqlConnection connection = new SqlConnection(constr);
            SqlCommand command = new SqlCommand($"INSERT INTO MedicalReferral VALUES ('{referral.MedicalReferralID}', '{referral.AnamnesisID}', '{referral.Diagnosis}','{referral.Department}','{referral.ReferralDate}', GETDATE(), GETDATE(), 1);", connection);


            connection.Open();

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = command;
            await adapter.InsertCommand.ExecuteNonQueryAsync();

            connection.Close();
            return referral;
        }



        //funkcija nam ne treba jer radimo update zajedno sa anamnezom
        public async Task<MedicalReferralModel> UpdateReferralAsync(int id, MedicalReferralModel referral)
        {
            //string connectionString = "Data Source=DESKTOP-9Q8TC1B;Initial Catalog=people;Integrated Security=True";
            SqlConnection connection = new SqlConnection(constr);
            SqlCommand command = new SqlCommand($"SELECT * FROM MedicalReferral WHERE MedicalReferralID='{id}';", connection);

            connection.Open();

            SqlDataReader reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                MedicalReferralModel updateReferral = new MedicalReferralModel();

                while (reader.Read())
                {
                    updateReferral.Diagnosis = referral.Diagnosis;
                    updateReferral.ReferralDate = referral.ReferralDate;
                    updateReferral.UpdatedAt = referral.UpdatedAt;
                }
                reader.Close();
                SqlCommand command2 = new SqlCommand($"UPDATE MedicalReferral SET Diagnosis='{referral.Diagnosis}',ReferralDate='{referral.ReferralDate}',UpdatedAt='{referral.UpdatedAt}' WHERE MedicalReferralID={id};", connection);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.UpdateCommand = command2;
                await adapter.UpdateCommand.ExecuteNonQueryAsync();

                connection.Close();
                return referral;
            }
            else
            {
                return null;
            }
        }




        public async Task<MedicalReferralModel> DeleteReferralAsync(int id, MedicalReferralModel referral)
        {
            //string connectionString = "Data Source=DESKTOP-9Q8TC1B;Initial Catalog=people;Integrated Security=True";
            SqlConnection connection = new SqlConnection(constr);
            SqlCommand command = new SqlCommand($"SELECT DeletedAt FROM MedicalReferral WHERE MedicalreferralID={id};", connection);

            connection.Open();

            SqlDataReader reader = await command.ExecuteReaderAsync();

            if (reader.HasRows)
            {
                MedicalReferralModel deleteReferral = new MedicalReferralModel();

                while (reader.Read())
                {
                   // deleteReferral.DeletedAt = referral.DeletedAt;
                }
                reader.Close();
                //SqlCommand command2 = new SqlCommand($"UPDATE MedicalReferral SET DeletedAt='{referral.DeletedAt}' WHERE MedicalReferralID={id};", connection);

                SqlDataAdapter adapter = new SqlDataAdapter();
               // adapter.UpdateCommand = command2;
                await adapter.UpdateCommand.ExecuteNonQueryAsync();

                connection.Close();
                return referral;
            }
            else
            {
                return null;
            }
        }
    }
}
