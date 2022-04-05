using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP.Interfaces;


namespace OOP.Models
{
    internal class Course : ICourse
    {
        public string CourseName { get; set; }
        public ITeacher CourseTeacher { get; set; }
        public List<IStudent> CourseStudents { get; set; }
        public List<Lesson> Lessons { get; set; }
        public Dictionary<IStudent, int?> FinalScore { get; set; }

        public Course(string CourseName, ITeacher teacher) : this(CourseName)
        {
            CourseTeacher = teacher;
        }

        public Course(string name)
        {
            CourseName = name;
        }
        
        public Dictionary<string, int> GetScores(IStudent student)
        {
            Dictionary<string, int> scores = new Dictionary<string, int>();

            foreach (Lesson lesson in this.Lessons)
            {
                scores.Add(lesson.Title, lesson.Scores[student]);
            }

            return scores;
        }
    }
}
