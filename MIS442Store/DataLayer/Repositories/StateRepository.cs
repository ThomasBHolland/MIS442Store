using MIS442Store.DataLayer.DataModels;
using MIS442Store.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MIS442Store.DataLayer.Repositories
{
    public class StateRepository : IStateRepository
    {
        public List<USState> GetStates()
        {
            List<USState> StateList = new List<USState>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_MIS442_Tholland"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM State";
                    command.CommandType = CommandType.Text;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            USState item = new USState();
                            item.code = reader["Code"].ToString();
                            item.name = reader["Name"].ToString();
                            StateList.Add(item);


                        }
                    }
                    return StateList;
                }
            }
        }
    }
}