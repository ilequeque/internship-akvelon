using System;
namespace Fraction
{
    internal class Program
    {
        static void Main()
        {
            try
            {
                FractionClass f1 = new(7, 9);
                FractionClass f2 = new(4, 5);


                Console.WriteLine("{0} + {1} = {2}", f1, f2, f2 + f1); 

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