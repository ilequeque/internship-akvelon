using System;
using System.Collections.Generic;
using System.Linq;
using OOP.Models;
using OOP.Interfaces;

namespace TrainingCenter
{
    class Program
    {
        static void Main(string[] args)
        {
            Center trainingCenter = new();

            Course Dotnet = new Course(".NET");

            Teacher teacher1 = new Teacher("Michael", "Klump", 35);

            Student student1 = new Student("Prison", "Mike", 23);
            Student student2 = new Student("Date", "Mike", 24);

            trainingCenter.AddCourse(Dotnet);

            trainingCenter.AddTeacher(teacher1);

            trainingCenter.AddStudent(student1);
            trainingCenter.AddStudent(student2);

            trainingCenter.TeacherToCourse(teacher1, Dotnet);

            trainingCenter.AddStudentToCourse(student1, Dotnet);
            trainingCenter.AddStudentToCourse(student2, Dotnet);

            Lesson lesson1 = new Lesson("Introduction");
            Lesson lesson2 = new Lesson("Data Types");

            trainingCenter.AddLesson(Dotnet, lesson1);
            trainingCenter.AddLesson(Dotnet, lesson2);

            teacher1.FinalGrade(Dotnet, student1, lesson1, 100);
            teacher1.FinalGrade(Dotnet, student1, lesson2, 95);

            teacher1.FinalGrade(Dotnet, student2, lesson1, 95);
            teacher1.FinalGrade(Dotnet, student2, lesson2, 85);

            foreach (IStudent student in Dotnet.CourseStudents)
            {
                Console.WriteLine(student.Name);
                foreach (var lessonMark in student.Scores(Dotnet))
                {
                    Console.WriteLine(lessonMark.Key + "   " + lessonMark.Value);
                }

            }
            trainingCenter.Summary(Dotnet);

            Console.WriteLine(Dotnet.CourseName);
            foreach (var studentMark in trainingCenter.Courses.Find(x => x.Equals(Dotnet)).FinalScore)
            {

                Console.WriteLine(studentMark.Key.Name + "   " + studentMark.Value);
            }
        }
    }
}