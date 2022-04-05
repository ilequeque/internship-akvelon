using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP.Models;

namespace OOP.Interfaces
{
    public interface ITeacher : IGeneralInfo
    {
        List<ICourse> Courses { get; set; }
        void FinalGrade(ICourse course, IStudent student, Lesson lesson, int score);
    }
}
