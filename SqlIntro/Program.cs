using System;
using System.Linq;

namespace SqlIntro
{
    class Program
    {
        static void Main(string[] args) 
        {
            var connectionString = "Server=localhost;Database=adventureworks;Uid=root;Pwd=Password;"; //get connectionString format from connectionstrings.com and change to match your database
            var repo = new ProductRepository(connectionString);
            foreach (var prod in repo.GetProducts().Take(1))
            {
                Console.WriteLine("Modified Date:" + " " + prod.ModifiedDate.ToLongDateString());
            }
            repo.DeleteProduct(4);
            Console.WriteLine("Product with ID 4 is deleted");
            var product = new Product()
            {
                ProductId = 316,
                Name = "Jake",
            };
            repo.UpdateProduct(product);
            Console.WriteLine("Product Name with ID 316 is Updated");

            var products = new Product()
            {
                Name = "John Dane",
                ProductNumber = "BA-2325",
                Color = "Blue",
                SafetyStockLevel = 2234,
                ReorderPoint = 854,
                ListPrice = 741.23,
            };

            repo.InsertProduct(products);
            Console.WriteLine("Inserted new Product ");
            Console.ReadLine();
        }  
    }
}
