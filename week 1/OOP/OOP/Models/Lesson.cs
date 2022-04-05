using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP.Interfaces;

namespace OOP.Models
{
    public class Lesson
    {
        public string Title { get; set; }
        public Dictionary<IStudent, int> Scores { get; set; }

        public Lesson (string title)
        {
            Title = title;
            Scores = new Dictionary<IStudent, int>();
        }
    }
}
