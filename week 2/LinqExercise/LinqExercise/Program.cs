using LINQ_Exercises.Classes;
using LinqExercise;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            Services purchaseService = new();

            Goods product1 = new Goods() { ArticleNumber = 1, Category = "Toys", Country = "China" };
            Goods product2 = new Goods() { ArticleNumber = 12, Category = "Auto", Country = "Germany" };
            Goods product3 = new Goods() { ArticleNumber = 123, Category = "Suits", Country = "Bulgaria" };
            Goods product4 = new Goods() { ArticleNumber = 111, Category = "Materials", Country = "Tunis" };
            Goods product5 = new Goods() { ArticleNumber = 132, Category = "Sport", Country = "England" };
            Goods product6 = new Goods() { ArticleNumber = 169, Category = "Instruments", Country = "Norway" };
            Goods product7 = new Goods() { ArticleNumber = 690, Category = "Shoes", Country = "Bulgaria" };
            Goods product8 = new Goods() { ArticleNumber = 2369, Category = "Tea", Country = "England" };

            Consumer consumer1 = new Consumer() { ConsumerCode = 1, YearOfBirth = 1989, Address = "Illinois" };
            Consumer consumer2 = new Consumer() { ConsumerCode = 2, YearOfBirth = 1991, Address = "Pensylvania" };
            Consumer consumer3 = new Consumer() { ConsumerCode = 3, YearOfBirth = 1996, Address = "Scranton" };
            Consumer consumer4 = new Consumer() { ConsumerCode = 4, YearOfBirth = 2005, Address = "Manhattan" };

            purchaseService.AddProd(product1);
            purchaseService.AddProd(product2);
            purchaseService.AddProd(product3);
            purchaseService.AddProd(product4);
            purchaseService.AddProd(product5);
            purchaseService.AddProd(product6);
            purchaseService.AddProd(product7);
            purchaseService.AddProd(product8);

            purchaseService.AddConsumer(consumer1);
            purchaseService.AddConsumer(consumer2);
            purchaseService.AddConsumer(consumer3);
            purchaseService.AddConsumer(consumer4);

            purchaseService.AddDiscount(consumer1, "Dunder Mifflin", 10);
            purchaseService.AddDiscount(consumer1, "MS Paper Company", 25);

            purchaseService.AddDiscount(consumer2, "Dunder Mifflin", 5);
            purchaseService.AddDiscount(consumer2, "MS Paper Company", 25);

            purchaseService.AddDiscount(consumer3, "Dunder Mifflin", 15);

            purchaseService.AddDiscount(consumer4, "MS Paper Company", 45);


            purchaseService.AddProductToStore(product1, "Dunder Mifflin", 500);
            purchaseService.AddProductToStore(product1, "Store2", 520);
            purchaseService.AddProductToStore(product1, "Store3", 510);

            purchaseService.AddProductToStore(product2, "Dunder Mifflin", 1000);
            purchaseService.AddProductToStore(product2, "Store2", 1100);

            purchaseService.AddProductToStore(product3, "Dunder Mifflin", 2289);
            purchaseService.AddProductToStore(product3, "Store3", 2299);

            purchaseService.AddProductToStore(product3, "Dunder Mifflin", 5480);

            purchaseService.AddProductToStore(product4, "Store3", 700);

            purchaseService.AddProductToStore(product5, "Store2", 560);

            purchaseService.AddProductToStore(product5, "Store3", 600);

            purchaseService.AddProductToStore(product6, "Store1", 4560);
            purchaseService.AddProductToStore(product7, "Store2", 2020);
            purchaseService.AddProductToStore(product8, "Store3", 30000);

            //purchaseService.Buy(consumer3, product1, "Store1");
            //purchaseService.Buy(consumer3, product2, "Store2");


            purchaseService.StartActivityImitation();

            
            var anonType = new
            {
                ConsumerCode = 0,
                ProductArticleNumber = "",
                StoreName = "",
                Discount = 0
            };

            var list = new[] { anonType }.ToList();
            list.Clear();

            foreach (var item in purchaseService.purchaseInfos)
            {
                if (!purchaseService.consumersStores.Exists(x => x.ConsumerCode == item.ConsumerCode && x.StoreName == item.StoreName))
                {
                    list.Add(new
                    {
                        ConsumerCode = item.ConsumerCode,
                        ProductArticleNumber = item.ProductArticleNumber,
                        StoreName = item.StoreName,
                        Discount = 0
                    });
                }
                else
                {
                    list.Add(new
                    {
                        ConsumerCode = item.ConsumerCode,
                        ProductArticleNumber = item.ProductArticleNumber,
                        StoreName = item.StoreName,
                        Discount = purchaseService.consumersStores.Find(x => x.ConsumerCode == item.ConsumerCode && x.StoreName == item.StoreName).Discount
                    });
                }
            }

            #region Linq like SQL
            //var test = from pi in purchaseService.purchaseInfos
            //           join cs in purchaseService.consumersStores
            //               on new { pi.ConsumerCode, pi.StoreName } equals new { cs.ConsumerCode, cs.StoreName }
            //           select new
            //           {
            //               ConsumerCode = pi.ConsumerCode,
            //               ProductArticleNumber = pi.ProductArticleNumber,
            //               StoreName = pi.StoreName,
            //               Discount = cs.Discount
            //           };

            #endregion

            var temp1 = list.Join(purchaseService.products,
                current => current.ProductArticleNumber,
                p => p.ArticleNumber,
                (current, p) => new
                {
                    ConsumerCode = current.ConsumerCode,
                    ProductArticleNumber = current.ProductArticleNumber,
                    StoreName = current.StoreName,
                    Discount = current.Discount,
                    ProductCategory = p.Category,
                    MadeIn = p.CountryOfOrigin
                });


            var temp2 = temp1.Join(purchaseService.consumers,
                current => current.ConsumerCode,
                c => c.ConsumerCode,
                (current, c) => new
                {
                    ConsumerCode = current.ConsumerCode,
                    ProductArticleNumber = current.ProductArticleNumber,
                    StoreName = current.StoreName,
                    Discount = current.Discount,
                    ProductCategory = current.ProductCategory,
                    MadeIn = current.MadeIn,
                    YearOfBirth = c.YearOfBirth,
                    Address = c.Address
                });

            var temp3 = from current in temp2
                        join sp in purchaseService.storesProducts
                            on new { current.ProductArticleNumber, current.StoreName } equals new { sp.ProductArticleNumber, sp.StoreName }
                        select new
                        {
                            ConsumerCode = current.ConsumerCode,
                            YearOfBirth = current.YearOfBirth,
                            Address = current.Address,
                            ProductArticleNumber = current.ProductArticleNumber,
                            ProductCategory = current.ProductCategory,
                            MadeIn = current.MadeIn,
                            StoreName = current.StoreName,
                            ProductPrice = sp.ProductPrice,
                            Discount = current.Discount
                        };

            foreach (var item in temp3)
            {
                Console.WriteLine("Consumer code:    {0}\n" +
                    "Year of birth:    {1}\n" +
                    "Consumer address: {2}\n" +
                    "Product article:  {3}\n" +
                    "Product category: {4}\n" +
                    "Made in:          {5}\n" +
                    "Store name:       {6}\n" +
                    "Product price:    {7}\n" +
                    "Consumer discount:{8}\n\n",
                    item.ConsumerCode,
                    item.YearOfBirth,
                    item.Address,
                    item.ProductArticleNumber,
                    item.ProductCategory,
                    item.MadeIn,
                    item.StoreName,
                    item.ProductPrice,
                    item.Discount);
            }

            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("----------------------------------------------------");

            //Task LINQ---------------------

            var groupbyStorname = temp3.GroupBy(t => new
            {
                t.StoreName,
                t.MadeIn,
                t.ConsumerCode
            })
            .Select(x => new
            {
                MadeIn = x.Key.MadeIn,
                StoreName = x.Key.StoreName,
                YearOfBirth = x.Max(e => e.YearOfBirth),
                ConsumerCode = x.Key.ConsumerCode,
                TotalSumOfAllPurchases = x.Sum(s => (s.ProductPrice - s.ProductPrice * s.Discount / 100))
            }).ToList();

            //Task LINQ---------------------

            foreach (var item in groupbyStorname)
            {
                    Console.WriteLine("\nMade in:          {0}\n"+
                    "Store Name:       {1}\n" +
                    "Year of birth:    {2}\n" +
                    "Consumer code:    {3}\n" +
                    "TotalSumOfAllPurchases: {4}\n\n",
                    item.MadeIn,
                    item.StoreName,
                    item.YearOfBirth,
                    item.ConsumerCode,
                    item.TotalSumOfAllPurchases
                   );
            }
        }
    }
}