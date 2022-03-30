using System;
namespace QueueTemp
{
    internal class Program
    {
        static void Main()
        {
            QueueSM<int> sm = new();
            sm.Enqueue(1);
            sm.Enqueue(2);
            sm.Enqueue(3);
            sm.Enqueue(4);
            sm.Enqueue(5);
            sm.Enqueue(6);
            Console.WriteLine("{0} customers ready to be served.", sm.Size());
            Console.WriteLine(sm.Peek());
            Console.WriteLine("Customer number {0} was served.", sm.Dequeue());
            Console.WriteLine("Customer number {0} was served.", sm.Dequeue());
            Console.WriteLine("Customer number {0} was served.", sm.Dequeue());
            Console.WriteLine("Customer number {0} was served.", sm.Dequeue());
            Console.WriteLine("Customer number {0} was served.", sm.Dequeue());
            Console.WriteLine("Customer number {0} was served.", sm.Dequeue());
        }
    }
}