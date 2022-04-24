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
            
            var temp = new Tree<TestClass>(test1); // main tree
            temp.Left = new Tree<TestClass>(test2); // left leaf of the tree
            temp.Right = new Tree<TestClass>(test3); //right leaf of the tree

            static void action(TestClass x) => Console.WriteLine($"{x.Id}, {x.Name}");

            Traverser.DoTree(temp, action);
        }
    }
}