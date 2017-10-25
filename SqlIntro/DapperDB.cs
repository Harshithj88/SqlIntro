using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;

namespace SqlIntro
{
    public class DapperDb
    {
        private readonly string _connectionString;

        public DapperDb(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Product> GetProducts()
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                return conn.Query<Product>("select * from product");
            }
        }

        public void DeleteProduct(int productid)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                conn.Execute("Delete from product where productid = @id", new {id = productid});
            }
        }

        public void UpdateProduct(Product prod)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                conn.Execute("update Product set name = @name where productid = @id", new { id = prod.ProductId, name = prod.Name });
            }
        }

        public void InsertProduct(Product prod)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                conn.Execute("insert into product(Name,ProductNumber,Color,SafetyStockLevel,ReorderPoint,ListPrice) values (@name,@ProductNumber,@Color,@SafetyStockLevel,@ReorderPoint,@ListPrice)", new {name = prod.Name,number = prod.ProductNumber,color = prod.Color,safetystocklevel = prod.SafetyStockLevel,reorderpoint = prod.ReorderPoint,listprice = prod.ListPrice});
            }
        }
    }
}
