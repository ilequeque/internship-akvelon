using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagedThreading
{
    public class Music
    {
        public string Type { get; private set; }
        public Music(string type)
        {
            this.Type = type;
        }
    }
}
