using System;

namespace TreeTraverser
{
    public class Program
    {
        public static void Main()
        {
            TestClass test1 = new TestClass(1, "Jim");
            TestClass test2 = new TestClass(2, "Michael");
            TestClass test3 = new TestClass(3, "Dwight");
            
            var temp = new Tree<TestClass>(test1);
            temp.Left = new Tree<TestClass>(test2);
            temp.Right = new Tree<TestClass>(test3);
         
            Action<TestClass> action = x => Console.WriteLine($"{x.Id}, {x.Name}");

            Traverser.DoTree(temp, action);
        }
    }
}