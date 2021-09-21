using System;
using static System.Console;
using System.Linq;

namespace Exercicio02
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var db = new Northwind())
            {
                WriteLine("\tCidades com residência de clientes:");
                IQueryable<string> cities = db.Customers.Select(customer => customer.City).Distinct();
                WriteLine($"{string.Join(", ", cities)}");


                WriteLine("\n\nDigite o nome de uma cidade: ");
                string city = ReadLine();
                var query = db.Customers.Where(c => c.City == city).Select(customer => new {
                    customer.CompanyName
                });

                WriteLine($"\nExiste {query.Count()} cliente(s) em {city}:");
                foreach (var item in query)
                {
                    WriteLine(item.CompanyName);
                }
            }
        }
    }
}