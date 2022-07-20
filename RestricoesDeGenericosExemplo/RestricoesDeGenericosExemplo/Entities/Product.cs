using System;
using System.Collections.Generic;
using System.Globalization;

namespace RestricoesDeGenericosExemplo.Entities
{
    //implementar a interface IComparable(vai pedir p implementar a interface(linha 26))
    internal class Product : IComparable
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
            return Name
                + ", "
                + Price.ToString("F2", CultureInfo.InvariantCulture);
        }

        //metodo IComparable(comprar um product com outro)
        public int CompareTo(object obj)
        {
            //testar se obj é da classe product:
            if(!(obj is Product))
            {
                throw new ArgumentException("Comparing erro: argument is not a product");
            }

            //downcast
            Product other = obj as Product;

            //comparar encontrando o mais caro:
            return Price.CompareTo(other.Price);

        }
    }
}
