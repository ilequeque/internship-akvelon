using System;
using Fraction;

namespace Fraction
{
   internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Fraction f1 = new Fraction(7, 9);
                Fraction f2 = new Fraction(4, 5);


                Console.WriteLine("{0} + {1} = {2}", f1, f2, f2 + f1);//Вариант 

                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught:{0}", e.Message);
                Console.ReadKey();
            }
        }
    }
}
