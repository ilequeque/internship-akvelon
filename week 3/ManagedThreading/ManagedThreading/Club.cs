using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagedThreading
{
    public class Club
    {
        private string musicType;
        public List<Dancer> DancerList { get; set; }
        public List<Music> Music { get; set; }

        public Club(List<Dancer> dancers, List<Music> playlist)
        {
            DancerList = dancers;
            Music = playlist;
        }

        public void DanceOnMusic()
        {
            if (Music == null || DancerList == null)
            {
                throw new ArgumentNullException(musicType);
            }

            while (Music.Count > 0)
            {
                this.musicType = NextSong();
                foreach(var temp in DancerList)
                {
                    Dance(temp, musicType);
                }
            }
        }

        private string NextSong()
        {   
            Thread t = new(() => this.musicType = Next());
            t.Start();
            Thread.Sleep(1000);     //time to change song genre
            return this.musicType;
        }

        private string Next()
        {
            if (Music.Count > 0)
            {
                var temp = Music[^1].Type;
                Music.Remove(Music[^1]);
                Console.WriteLine("\n Now Playing: " + temp + ". \n Track number: " + (20 - Music.Count) + "\n");
                return temp;
            }
            else
            {
                return null;
            }
        }

        private void Dance(Dancer dancer, string song)
        {
            Thread th = new(() => dancer.DanceFunc(song));
            th.Start();
        }
    }
}
