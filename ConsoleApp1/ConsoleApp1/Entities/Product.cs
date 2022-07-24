using System;
using System.Globalization;
namespace Predicate.Entities

{
    internal class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return String.Format("{0}, {1}", Name, Price.ToString("F2", CultureInfo.InvariantCulture));

        }
    }
}
