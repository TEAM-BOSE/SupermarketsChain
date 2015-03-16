namespace TestApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using SupermarketsChain.MsSQL;
    using SupermarketsChain.MySQL;
    using SupermarketsChain.Models;


    class Program
    {
        static void Main(string[] args)
        {
            var products = new List<Product>();

            var data2 = new MsSqlContext();
            var data = new MySqlContext();

            products = data.Products.ToList();

            foreach (var pr in products)
            {
                data.Entry<Product>(pr).State = System.Data.Entity.EntityState.Detached;
             
                data.Products.Add(pr);
            }

            data.SaveChanges();

            var vendorss = data.Products.ToList();
            foreach (var item in vendorss)
            {
                Console.WriteLine(item.Name);
            }

            //data2.Products.Add(new Product()
            //{
            //    Measure = new Measure() { Name = "Kilograms" },
            //    Name = "Meat",
            //    Vendor = new Vendor() { Name = "Go6o" },
            //    Price = 12.0m
            //});

            //data2.SaveChanges();

            //var vendors2 = data2.Vendors.ToList();

            //foreach (var vendor in vendors2)
            //{

            //    Console.WriteLine(vendor.Name);
            //}

            //Console.WriteLine();


            //var data = new MySqlContext();

            //data.Products.Add(new Product()
            //{
            //    Measure = new Measure() { Name = "Kilograms" },
            //    Name = "Meat",
            //    Vendor = new Vendor() { Name = "Go6o" },
            //    Price = 12.0m
            //});

            //data.SaveChanges();

            //var vendors = data.Vendors.ToList();

            //foreach (var vendor in vendors)
            //{

            //    Console.WriteLine(vendor.Name);
            //}
        }
    }
}
