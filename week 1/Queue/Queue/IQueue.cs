using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueTemp
{
    internal interface IQueue<T>
    {
        T Dequeue();
        void Enqueue(T element);
        T Peek();
    }
}
