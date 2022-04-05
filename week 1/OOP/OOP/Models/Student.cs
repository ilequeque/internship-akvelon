using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP.Interfaces;

namespace OOP.Models
{
    internal class Student : IStudent
    {
        public List<ICourse> Courses { get; set; } = new List<ICourse>();
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public Student (string Name, string Surname, int Age)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Age = Age;
        }
        
        public Student(string Name, string Surname, int Age, List<ICourse> Courses) : this(Name, Surname, Age)
        {
            this.Courses = Courses;
        }

        public Dictionary<string, int> Scores(ICourse course)
        {
            return course.GetScores(this);
        }
    }
}
