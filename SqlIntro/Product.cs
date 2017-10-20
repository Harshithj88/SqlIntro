using System;

namespace SqlIntro
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double ListPrice { get; set; }
        public int ProductID { get; set; }
        public string  ProductNumber { get; set; }
        public int SafetyStockLevel { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}