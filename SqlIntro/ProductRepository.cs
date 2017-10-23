using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SqlIntro
{
    public class ProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        /// <summary>
        /// Reads all the products from the products table
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetProducts()
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "select ModifiedDate from product";
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    yield return new Product
                    {
                        //ProductID = (int)dr["ProductID"],
                        //Name = dr["Name"].ToString(),
                        //ProductNumber = dr["ProductNumber"].ToString(),
                        //ListPrice = (double)dr["ListPrice"],
                        //SafetyStockLevel = (int)dr["SafetyStockLevel"]
                        ModifiedDate = (DateTime)dr["ModifiedDate"],
                    };
                }
            }
        }
        /// <summary>
        /// Deletes a Product from the database
        /// </summary>
        /// <param name="id"></param>
        public void DeleteProduct(int id)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "delete from product where productid= " +id; //Write a delete statement that deletes by id
                cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Updates the Product in the database
        /// </summary>
        /// <param name="prod"></param>
        public void UpdateProduct(Product prod)
        {
            //This is annoying and unnecessarily tedious for large objects.
            //More on this in the future...  Nothing to do here..
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "update product set name = 'Jake' where productid = 316";
                cmd.Parameters.AddWithValue("Jake", prod.Name);
                cmd.Parameters.AddWithValue("316", prod.ProductId);
                cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Inserts a new Product into the database
        /// </summary>
        /// <param name="prod"></param>
        public void InsertProduct(Product prod)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "insert into product(Name,ProductNumber,Color,SafetyStockLevel,ReorderPoint,ListPrice) values('John Dane', 'BA-2325', 'Blue', '2234', '854', '741.23')";
                cmd.Parameters.AddWithValue("John Dane", prod.Name);
                cmd.Parameters.AddWithValue("BA-2325", prod.ProductNumber);
                cmd.Parameters.AddWithValue("Blue", prod.Color);
                cmd.Parameters.AddWithValue("2234", prod.SafetyStockLevel);
                cmd.Parameters.AddWithValue("854", prod.ReorderPoint);
                cmd.Parameters.AddWithValue("741.23", prod.ListPrice);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
