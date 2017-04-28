using MIS442Store.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MIS442Store.DataLayer.DataModels;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.UI.WebControls;

namespace MIS442Store.DataLayer.Repositories
{
    public class NewsRepository : INewsRepository
    {
        List<News> INewsRepository.GetList()
        {
            List<News> NewsList = new List<News>();
            News listitem2 = new News();
            listitem2.id = 3;
            listitem2.title = "Story 3";
            listitem2.body = "45 years it has been since the start of this journey.";
            listitem2.Author = "Thomas Holland";
            listitem2.DatePosted = "Posted on 03/14/1915";

            NewsList.Add(listitem2);
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_MIS442"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM News";
                    command.CommandType = CommandType.Text;

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listitem2 = new News();
                            listitem2.id = int.Parse(reader["id"].ToString());
                            listitem2.title = reader["Title"].ToString();
                            listitem2.Author = reader["Author"].ToString();
                            listitem2.DatePosted = reader["DatePosted"].ToString();

                            NewsList.Add(listitem2);
                        }
                    }

                }
            }

            return NewsList;
        }
    }
}