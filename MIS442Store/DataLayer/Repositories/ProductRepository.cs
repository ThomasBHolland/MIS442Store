using MIS442Store.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MIS442Store.DataLayer.DataModels;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace MIS442Store.DataLayer.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Product Get(int id)
        {
            Product p = null;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[@"OW206_5037\SQLEXPRESS_MIS"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spProduct_Get";
                    command.Parameters.AddWithValue("@ProductID",id);

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                       if (reader.Read())
                        {
                            p = new Product();
                            p.ProductID = int.Parse(reader["ProductID"].ToString());
                            p.ProductName = reader["ProductName"].ToString();
                            p.ProductCode = reader["ProductCode"].ToString();
                            p.ProductVersion = decimal.Parse(reader["ProductVersion"].ToString());
                            p.ProductReleaseDate = DateTime.Parse( reader["ProductName"].ToString());

                        }
                    }

                }
            }
            return (p);
        }
        public List<Product> GetList()
        {
            Product p = null;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MIS442"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spProduct_Get";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            p = new Product();
                            p.ProductID = int.Parse(reader["ProductID"].ToString());
                            p.ProductName = reader["ProductName"].ToString();
                            p.ProductCode = reader["ProductCode"].ToString();
                            p.ProductVersion = decimal.Parse(reader["ProductVersion"].ToString());
                            p.ProductReleaseDate = DateTime.Parse(reader["ProductName"].ToString());
                        }
                    }

                }
            }
            return ();
        }

        public void Save(Product product)
        {
            Product p = null;
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MIS442"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spProduct_InsertUpdate";
                    command.Parameters.AddWithValue("@ProductID", product.ProductID);
                    command.Parameters.AddWithValue("@ProductCode", product.ProductCode);
                    command.Parameters.AddWithValue("@ProductName", product.ProductName);
                    command.Parameters.AddWithValue("@ProductVersion", product.ProductVersion);
                    command.Parameters.AddWithValue("@ProductReleaseDate", product.ProductReleaseDate);

                    connection.Open();

                    command.ExecuteNonQuery();

                }
            }
            
        }
    }
}