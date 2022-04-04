using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }

        public Order(int id, string name, int amount)
        {
            Id = id;
            Name = name;
            Amount = amount;
        }
    }
}
