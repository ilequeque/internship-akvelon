using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP.Interfaces;

namespace OOP.Models
{
    internal class Teacher : ITeacher
    {
        public List<ICourse> Courses { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public Teacher(string Name, string Surname, int Age)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Age = Age;
        }
        public Teacher(string Name, string Surname, int Age, List<ICourse> Courses) : this(Name, Surname, Age)
        {
            this.Courses = Courses;
        }

        public void FinalGrade(ICourse course, IStudent student, Lesson lesson, int score)
        {
            Courses.Find(x => x.CourseName == course.CourseName).Lessons
                .Find(x => x.Equals(lesson)).Scores
                .Add(student, score);
        }
    }
}
