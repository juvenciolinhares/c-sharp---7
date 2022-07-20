using System;
using System.Collections.Generic;
using System.Text;

namespace ComparacaoDeIgualdades.Entities
{
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + Price.GetHashCode(); //soma dos 2 hashcodes
        }
        public override bool Equals(object obj)
        {
            if(!(obj is Product))
            {
                return false;
            }

            //downcast:
            Product other = obj as Product;

            return Name.Equals(other.Name) && Price.Equals(other.Price);
        }
    }
}
