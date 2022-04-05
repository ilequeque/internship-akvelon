using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExercise
{
    public class Services
    {
        public List<Consumer> cons = new();
        public List<Goods> goods = new();
        public List<ProdPrice> prodPrices = new();
        public List<Disc> discs = new();
        public List<Purchases> purchases = new();

        public void Buy(Consumer consumer, Goods good, string StoreName)
        {
            if (cons.Exists(x => x.ConsumerCode == consumer.ConsumerCode) &&
                goods.Exists(x => x.ArticleNumber == good.ArticleNumber) &&
                prodPrices.Exists(x => x.StoreName == StoreName && x.ArticleNumber == good.ArticleNumber))
            {
                purchases.Add(new Purchases()
                {
                    ConsumerCode = consumer.ConsumerCode,
                    ArticleNumber = good.ArticleNumber,
                    StoreName = StoreName
                });
            }
        }

        public void AddConsumer(Consumer consumer)
        {
            if (cons.Exists(x => x.ConsumerCode == consumer.ConsumerCode))
            {
                Console.WriteLine("This consumer is already in a list");
            }
            cons.Add(consumer);
        }

        public void AddProd (Goods good)
        {
            if (goods.Exists(x => x.ArticleNumber == good.ArticleNumber))
            {
                Console.WriteLine("This prod/good is already in a list");
            }
            goods.Add(good);
        }

        public void AddDiscount(Consumer consumer, string StoreName, int discount)
        {
            if(!cons.Exists(x => x.ConsumerCode == consumer.ConsumerCode))
            {
                Console.WriteLine("There is no such customer");
                return;
            }
            discs.Add(new Disc()
            {
                ConsumerCode = consumer.ConsumerCode,
                StoreName = StoreName,
                Discount = discount
            });
        }

        public void AddProductToStore(Goods good, string StoreName, int price)
        {
            if (goods.Exists(x => x.ArticleNumber == good.ArticleNumber))
            {
                Console.WriteLine("No such product available");
                return;
            }
            prodPrices.Add(new ProdPrice()
            {
                Price = price,
                StoreName = StoreName,
                ArticleNumber = good.ArticleNumber
            });
        }
    }
}
