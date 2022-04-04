using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public Level Type { get; set; }

        public Customer(string name, string surname, Level type, string address)
        {
            Name = name;
            Surname = surname;
            Address = address;
            Type = type;
        }
        private delegate double Calculate(Order order);

        private static double Formula(Order order, Calculate func)
        {
            return func(order);
        }

        public double Calculation(Order order)
        {
            if (Type == Level.New)
            {
                return Formula(order, (order) => order.Amount);
            }
            else if (Type == Level.SmallOrdersPermanent)
            {
                return Formula(order, (order) => order.Amount * 0.95);
            }
            else
            {
                return Formula(order, (order) =>
                {
                    if (order.Amount > 100000)
                    {
                        return order.Amount * 0.85;
                    }
                    else
                    {
                        return order.Amount * 0.9;
                    }
                });
            }
        }

    }
    public enum Level
    {
        New,
        SmallOrdersPermanent,
        LargeOrdersPermanent
    }
}
