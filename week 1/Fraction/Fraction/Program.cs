using System;
using Fraction;

namespace Fraction
{
    static void Main(string[] args)
    {
        try
        {
            FractionClass f1 = new FractionClass(7, 9);
            FractionClass f2 = new FractionClass(4, 5);


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
