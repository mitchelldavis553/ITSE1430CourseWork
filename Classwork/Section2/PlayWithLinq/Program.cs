using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayWithLinq
{
    class Program
    {
        static void Main( string[] args )
        {
            var products = GetProducts();

            //Get discounted products
            //var discounted = products.Where(IsDiscounted); // Function Object idea, Functions as data, What if I only call this once?
            var discounted = products.Where(p => p.IsDiscounted); //Lambdas: "=>" " In-line Function" This LINQ query needs a Product, infers p is product

            var expensive = products.FirstOrDefault(p => p.Price > 100);

            var discounteExpensive = products.Where(p => { // Demo Statement Lambda rather than expression
                return p.IsDiscounted && p.Price > 100;
            });


        }

        //static bool IsDiscounted( Product product)
        //{
        //    return product.IsDiscounted;
        //}
        static IEnumerable<Product> GetProducts()
        {
            return new[]
            {
                new Product()
                {
                    Name = "Product A", Price = 50, IsDiscounted = false },
                 new Product()
                {
                    Name = "Product B", Price = 35, IsDiscounted = true },
                  new Product()
                {
                    Name = "Product C", Price = 40, IsDiscounted = false },
                   new Product()
                {
                    Name = "Product D", Price = 69, IsDiscounted = true },
                    new Product()
                {
                    Name = "Product E", Price = 101, IsDiscounted = true },
                     new Product()
                {
                    Name = "Product F", Price = 51, IsDiscounted = false },
                      new Product()
                {
                    Name = "Product G", Price = 88, IsDiscounted = false },
                       new Product()
                {
                    Name = "Product H", Price = 21, IsDiscounted = true },
            };
        }
    }

    class Product
    {
        public string Name { get; set; }
        public bool IsDiscounted { get; set; }
        public decimal Price { get; set; }
    }
}
