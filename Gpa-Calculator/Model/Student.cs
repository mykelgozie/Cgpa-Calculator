using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gpa_Calculator.Model
{
    public class Student
    {
     

        public string  FirstName { get; set; }
        public string  LastName { get; set; }

        public Student(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        // list object of course taken
        public List<CourseTaken> Courses { get; set; } = new List<CourseTaken>();


        //calculate cgpa 
        public double GetCgpa()
        {

            PrintCourses();

            var totalQualityPoint = 0;
            var totalGradeUnit = 0;
      

            if (Courses.Count > 0)
            {
                foreach (var course in Courses)
                {
             
                    totalQualityPoint += course.QualityPoint;
                    totalGradeUnit += course.CourseUnit;

                }

                return (double) totalQualityPoint / totalGradeUnit;

            } else
            {
                return 0;

            }



        }

        // print all courses 
        public void PrintCourses()
        {
            var table = new ConsoleTable(" COURSE & CODE",  "COURSE UNIT" , "GRADE",  "GRADE-UNIT");

            foreach (var course in Courses)
            {
                table.AddRow(course.CourseCode, course.CourseUnit, course.CourseGrade, course.CoursePoint);
            }

            table.Write();  
        }
    }
}
