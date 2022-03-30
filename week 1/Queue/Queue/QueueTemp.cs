using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueTemp
{
    public class QueueSM<T> : IQueue<T>
    {
        LinkedList<T> Queue { get; set; } = new();
        public T Dequeue()
        {
            var element = Queue.FirstOrDefault();

            if (element == null)
            {
                NullReferenceException nullReferenceException = new();
                throw nullReferenceException;
            }

            Queue.Remove(element);
            return element;
        }

        public void Enqueue(T? element)
        {
            if (element == null)
            {
                NullReferenceException nullReferenceException = new();
                throw nullReferenceException;
            }

            Queue.AddLast(element);
        }

        public T Peek()
        {
            var element = Queue.FirstOrDefault();

            if (element == null)
            {
                NullReferenceException nullReferenceException = new();
                throw nullReferenceException;
            }

            return element;
        }

        public int Size()
        {
            return Queue.Count;
        }
    }
}
