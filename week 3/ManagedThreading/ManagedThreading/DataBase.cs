using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagedThreading
{
    public class DataBase
    {
        public IEnumerable<Dancer> DancerList()
        {
            var dancers = new List<Dancer>()
            {
                new Dancer(), new Dancer(), 
                new Dancer(), new Dancer(),
                new Dancer(), new Dancer(),
                new Dancer(), new Dancer(), 
                new Dancer(), new Dancer()
            };
            return dancers;
        }

        public IEnumerable<Music> PlayList()
        {
            var playlist = new List<Music>()
            {
                new Music("Hardbass"), new Music ("Rock"), new Music("Latino"),
                new Music("Hardbass"), new Music ("Rock"), new Music("Latino"),
                new Music("Hardbass"), new Music ("Rock"), new Music("Latino"),
                new Music("Hardbass"), new Music ("Rock"), new Music("Latino"),
                new Music("Hardbass"), new Music ("Rock"), new Music("Latino"),
                new Music("Hardbass"), new Music ("Rock"), new Music("Latino"),
                new Music("Hardbass"), new Music ("Rock")
            };
            return playlist;
        }
    }
}
