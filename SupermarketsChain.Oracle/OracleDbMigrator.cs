namespace SupermarketsChain.Oracle
{
    using SupermarketsChain.Models;
    using SupermarketsChain.MsSQL;
    using System.Data.Entity;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class OracleDbMigrator
    {


        public static void MigrateOracleToSql()
        {


            var sqlContext = new MsSqlContext();

            using (var oracle = new OracleContext())
            {

                var res = oracle.VENDORS;

                foreach (var v in res)
                {
                    var vendor = new Vendor();
                    vendor.Name = v.NAME;
                    if (sqlContext.Vendors.Any(ven => ven.Name == vendor.Name) == false)
                    {
                        sqlContext.Vendors.Add(vendor);
                        sqlContext.SaveChanges();
                    }

                }

                var mes = oracle.MEASURES;

                foreach (var m in mes)
                {
                    var measure = new Measure();
                    measure.Name = m.NAME;
                    if (sqlContext.Measures.Any(ms => ms.Name == measure.Name) == false)
                    {
                        sqlContext.Measures.Add(measure);
                        sqlContext.SaveChanges();
                    }

                }

                var prod = oracle.PRODUCTS;

                foreach (var p in prod)
                {
                    var product = new Product();
                    product.Name = p.NAME;
                    product.MeasureId = p.MEASUREID;
                    product.VendorId = p.VENDORID;
                    product.Price = p.PRICE;
                    if (sqlContext.Products.Any(pr => pr.Name == product.Name) == false)
                    {
                        sqlContext.Products.Add(product);
                        sqlContext.SaveChanges();
                    }

                }

            }

        }
    }
}
