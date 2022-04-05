using OOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Interfaces
{
    public interface ICourse
    {
        string CourseName { get; set; }
        ITeacher CourseTeacher { get; set; }
        List<IStudent> CourseStudents { get; set; }
        List<Lesson> Lessons { get; set; }
        public Dictionary<IStudent, int?> FinalScore { get; set; }

        Dictionary<string, int> GetScores(IStudent student);
    }
}
