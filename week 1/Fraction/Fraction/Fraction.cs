using System;
using System.Collections.Generic;
using System.Text;

namespace Fraction
{
    class FractionClass
    {
        private readonly int Numerator;
        private readonly int Denominator;

        public FractionClass(int N, int D)
        {
            if (D == 0)
            {
                throw new ArgumentNullException(nameof(D), $"{D} cannot be zero.");
            }
            Numerator = N; Denominator = D;
        }
        public FractionClass()
        {
            Numerator = 1; Denominator = 1;
        }
        public static FractionClass operator +(FractionClass a, FractionClass b)
        {
            return new FractionClass(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator).Normalization();
        }
        public static FractionClass operator -(FractionClass a, FractionClass b)
        {
            return new FractionClass(a.Numerator * b.Denominator - b.Numerator * a.Denominator, a.Denominator * b.Denominator).Normalization();
        }
        public static FractionClass operator *(FractionClass a, FractionClass b)
        {
            return new FractionClass(a.Numerator * b.Numerator, a.Denominator * b.Denominator).Normalization();
        }
        public static FractionClass operator /(FractionClass a, FractionClass b)
        {
            return new FractionClass(a.Numerator * b.Denominator, b.Numerator * a.Denominator).Normalization();
        }
        public FractionClass Normalization()// FractionClass Normalization
        {
            return new FractionClass(Numerator / GetCommonDivisor(Numerator, Denominator), Denominator / GetCommonDivisor(Numerator, Denominator));
        }
        private static int GetCommonDivisor(int i, int j) // greatest common divisor
        {
            i = Math.Abs(i);
            j = Math.Abs(j);
            while (i != j)
                if (i > j) { i -= j; }
                else { j -= i; }
            return i;
        }


        public override string ToString()
        {
            int iPart = Numerator / Denominator;
            if (iPart != 0)
                return string.Format("{0} {1}", iPart, GetRest());
            else
                return string.Format("{0}/{1}", Numerator, Denominator);
        }
        public object GetRest()// остаток от выделения целой части
        {
            if (Numerator != Denominator)
            { return new FractionClass(Numerator % Denominator, Denominator); }
            return null;

        }
    }

}
