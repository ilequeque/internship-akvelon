using System;
using System.Threading;

namespace Threads
{
    internal class Program
    {
        static void Main()
        {
            Thread t = new(new ThreadStart(WriteY));
            t.Start();

            for (int i = 0; i < 10; i++) Console.Write("X");

        }
        public static void WriteY()
        {
            for (int i = 0; i < 10; i++) Console.Write("Y");
        }
    }
}