using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP.Interfaces;

namespace OOP.Models
{
    public class Center : ICenter
    {
        public List<ITeacher> Teachers { get; set; }
        public List<IStudent> Students { get; set; }
        public List<ICourse> Courses { get; set; }

        public Center()
        {
            Teachers = new List<ITeacher>();
            Students = new List<IStudent>();
            Courses = new List<ICourse>();
        }
        public void AddCourse(ICourse course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }
            Courses.Add(course);
        }

        public void AddLesson(ICourse course, Lesson lesson)
        {
            if (lesson == null || course == null)
            {
                throw new ArgumentNullException(nameof(course), nameof(lesson));
            }
            course.Lessons.Add(lesson);
        }

        public void AddStudent(IStudent student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }
            Students.Add(student);
        }

        public void AddStudentToCourse(IStudent student, ICourse course)
        {
            if (course == null || student == null)
            {
                throw new ArgumentNullException(nameof (course));
            }

            Students.Find(x => x.Equals(student)).Courses.Add(course);

            Courses.Find(x => x.Equals(course)).CourseStudents.Add(student);
        }

        public void AddTeacher(ITeacher teacher)
        {
            if (teacher == null)
            {
                throw new ArgumentNullException(nameof(teacher));
            }
            Teachers.Add(teacher);
        }

        public void Summary(ICourse course)
        {
            foreach (IStudent student in course.CourseStudents)
            {
                int averageScore = 0;
                foreach (Lesson lesson in course.Lessons)
                {
                    averageScore += lesson.Scores[student];
                }
                averageScore = averageScore / course.Lessons.Count;
                course.FinalScore.Add(student, averageScore);
            }
        }

        public void TeacherToCourse(ITeacher teacher, ICourse course)
        {
            if (teacher == null)
            {
                throw new ArgumentNullException(nameof(teacher));
            }
            else
            {
                Teachers.Find(x => x.Equals(teacher)).Courses.Add(course);
                course.CourseTeacher = teacher;
            }
        }
    }
}
