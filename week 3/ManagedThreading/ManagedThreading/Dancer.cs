using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagedThreading
{
    public class Dancer
    {
        public string? Dance { get; private set; }

        public void DanceFunc(string music)
        {
            if (music == null)
            {
                return;
            }
            if (music == "Hardbass")
            {
                this.Dance = "Elbow for Hardbass";
            }
            if (music == "Latino")
            {
                this.Dance = "Hips for Latino";
            }
            if (music == "Rock")
            {
                this.Dance = "Head for Rock";
            }
            Console.WriteLine("Dance: " + this.Dance + ". ****Thread Id : " + Environment.CurrentManagedThreadId + "****");
        }
    }
}
