using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP.Models;

namespace OOP.Interfaces
{
    public interface ICenter
    {
        public List<ITeacher> Teachers { get; set; }
        public List<IStudent> Students { get; set; }
        public List<ICourse> Courses { get; set; }

        void AddTeacher(ITeacher teacher);
        void AddStudent(IStudent student);
        void AddCourse(ICourse course);
        void AddStudentToCourse(IStudent student, ICourse course);
        void TeacherToCourse(ITeacher teacher, ICourse course);
        void AddLesson(ICourse course, Lesson lesson);
        void Summary(ICourse course);
    }
}
