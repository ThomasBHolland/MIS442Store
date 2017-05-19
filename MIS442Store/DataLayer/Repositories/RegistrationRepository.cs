using MIS442Store.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MIS442Store.DataLayer.DataModels;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace MIS442Store.DataLayer.Repositories
{
    public class RegistrationRepository : IRegistrationRepository
    {
        public Registration GetRegistration(int id)
        {
            Registration p = null;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_MIS442_Tholland"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Registration";
                    command.CommandType = CommandType.Text;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            p = new Registration();
                            p.RegistrationID = int.Parse(reader["RegistrationID"].ToString());
                            p.RegistrationDate = DateTime.Parse(reader["RegistrationDate"].ToString());
                            p.RegistrationProductID = int.Parse(reader["RegistrationProductID"].ToString());
                            p.RegistrationSerialNumber = reader["RegistrationSerialNumber"].ToString();
                            p.RegistrationVerified = bool.Parse(reader["RegistrationVerified"].ToString());
                            p.RegistrationUserName = reader["RegistrationUserName"].ToString();
                            p.RegistrationAddress = reader["RegistrationAddress"].ToString();
                            p.RegistrationState = reader["RegistrationState"].ToString();
                            p.RegistrationCity = reader["RegistrationCity"].ToString();
                            p.RegistrationZip = reader["RegistrationZip"].ToString();
                            p.RegistrationPhone = reader["RegistrationPhone"].ToString();


                        }
                    }

                }
            }
            return (p);
        }

        public List<Registration> GetRegistrations()
        {
            List<Registration> p = new List<Registration>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_MIS442_Tholland"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Registration";
                    command.CommandType = CommandType.Text;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Registration r = new Registration();
                            r.RegistrationID = int.Parse(reader["RegistrationID"].ToString());
                            r.RegistrationDate = DateTime.Parse(reader["RegistrationDate"].ToString());
                            r.RegistrationProductID = int.Parse(reader["RegistrationProductID"].ToString());
                            r.RegistrationSerialNumber = reader["RegistrationSerialNumber"].ToString();
                            r.RegistrationVerified = bool.Parse(reader["RegistrationVerified"].ToString());
                            r.RegistrationUserName = reader["RegistrationUserName"].ToString();
                            r.RegistrationAddress = reader["RegistrationAddress"].ToString();
                            r.RegistrationState = reader["RegistrationState"].ToString();
                            r.RegistrationCity = reader["RegistrationCity"].ToString();
                            r.RegistrationZip = reader["RegistrationZip"].ToString();
                            r.RegistrationPhone = reader["RegistrationPhone"].ToString();
                            p.Add(r);

                        }
                    }

                }
            }
            return (p);
        }


        public List<Registration> GetUserRegistrations(string username)
        {
            List<Registration> r = new List<Registration>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_MIS442_Tholland"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Registration";
                    command.CommandType = CommandType.Text;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Registration p = new Registration();
                            p.RegistrationID = int.Parse(reader["RegistrationID"].ToString());
                            p.RegistrationDate = DateTime.Parse(reader["RegistrationDate"].ToString());
                            p.RegistrationProductID = int.Parse(reader["RegistrationProductID"].ToString());
                            p.RegistrationSerialNumber = reader["RegistrationSerialNumber"].ToString();
                            p.RegistrationVerified = bool.Parse(reader["RegistrationVerified"].ToString());
                            p.RegistrationUserName = reader["RegistrationUserName"].ToString();
                            p.RegistrationAddress = reader["RegistrationAddress"].ToString();
                            p.RegistrationState = reader["RegistrationState"].ToString();
                            p.RegistrationCity = reader["RegistrationCity"].ToString();
                            p.RegistrationZip = reader["RegistrationZip"].ToString();
                            p.RegistrationPhone = reader["RegistrationPhone"].ToString();
                            r.Add(p);

                        }
                    }

                }
            }
            return (r);
        }

        public void SaveRegistration(Registration registration)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_MIS442_Tholland"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"Insert INTO Registration 
                    (RegistrationDate, RegistrationProductID, RegistrationSerialNumber, RegistrationVerified, 
                    RegistrationUserName, RegistrationAddress, RegistrationState, RegistrationCity, 
                    RegistrationZip, RegistrationPhone) VALUES 
                    (@RegistrationDate, @RegistrationProductID, @RegistrationSerialNumber, @RegistrationVerified, 
                    @RegistrationUserName, @RegistrationAddress, @RegistrationState, @RegistrationCity, 
                    @RegistrationZip, @RegistrationPhone)";
                    command.CommandType = CommandType.Text;
                    if (registration.RegistrationID != 0)
                    {
                        command.Parameters.AddWithValue("@RegistrationID", registration.RegistrationID);
                    }
                    command.Parameters.AddWithValue("@RegistrationDate", registration.RegistrationDate);
                    command.Parameters.AddWithValue("@RegistrationProductID", registration.RegistrationProductID);
                    command.Parameters.AddWithValue("@RegistrationSerialNumber", registration.RegistrationSerialNumber);
                    command.Parameters.AddWithValue("@RegistrationVerified", registration.RegistrationVerified);
                    command.Parameters.AddWithValue("@RegistrationUserName", registration.RegistrationUserName);
                    command.Parameters.AddWithValue("@RegistrationAddress", registration.RegistrationAddress);
                    command.Parameters.AddWithValue("@RegistrationState", registration.RegistrationState);
                    command.Parameters.AddWithValue("@RegistrationCity", registration.RegistrationCity);
                    command.Parameters.AddWithValue("@RegistrationZip", registration.RegistrationZip);
                    command.Parameters.AddWithValue("@RegistrationPhone", registration.RegistrationPhone);

                    connection.Open();
                    command.ExecuteNonQuery();



                }
            }

        }
    }

}