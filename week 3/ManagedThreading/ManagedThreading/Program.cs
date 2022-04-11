using ManagedThreading;
using System;
using System.Threading;

namespace Threads
{
    internal class Program
    {
        static void Main()
        {
            DataBase data = new DataBase();     // initial dataset: 10 dancers, 20 songs
            var dancers = data.DancerList();
            var playlist = data.PlayList();
            
            Club club = new(dancers.ToList(), playlist.ToList());
            club.DanceOnMusic();
        }
        
    }
}