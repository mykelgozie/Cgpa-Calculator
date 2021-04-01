using Gpa_Calculator.Enums;
using Gpa_Calculator.Model;
using Gpa_Calculator.Utility;
using System;

namespace Gpa_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
        
            Console.WriteLine("Welcome To Your CGPA Calculator App");
            Console.WriteLine("");

            Console.Write("Enter Sudent FirstName : ");
            var firstName = Console.ReadLine();
            Console.Write("Enter Student LastName : ");
            var lastName = Console.ReadLine();

            Console.WriteLine("");

            Console.WriteLine("Welcome  " + lastName.ToUpper() + " " + firstName.ToUpper());
            var choice =  GetEnteredNumber();
            var student = new Student(firstName, lastName);

            if (Validate.ConvertStringToNumber(choice) == 1)
            {

                AddStudentCourse(student);

                Console.WriteLine("Course Added ");
                var choice2 =  GetEnteredNumber();
                var numberChoice2 = Validate.ConvertStringToNumber(choice2);

                while (numberChoice2 == 1)
                {
                    AddStudentCourse(student);
                    numberChoice2 = Validate.ConvertStringToNumber(GetEnteredNumber());
                }

                if (numberChoice2 == 2)
                {
                    var cgpa = student.GetCgpa();
                    Console.WriteLine(lastName.ToUpper() + " " + firstName.ToUpper() + " CGPA  : " + Math.Round(cgpa, 2));
                }

            } 
            else if ( Validate.ConvertStringToNumber(choice) == 2)
            {
                var cgpa = student.GetCgpa();
                Console.WriteLine(lastName + " " + firstName + " CGPA  : " +  Math.Round(cgpa, 2));
            }


        }
        public static void AddStudentCourse(Student student)
        {
            Console.Write("Enter Course Code : ");
            var courseCode = Console.ReadLine();

            Console.Write("Enter Course Unit : ");
            var courseUnit = Console.ReadLine();

            Console.Write("Enter Student Score  : ");
            var courseScore = Console.ReadLine();

            var courseValidation = false;
            if (Validate.ConfirmScoreRange(courseScore) && Validate.ConfirmUnit(courseUnit))
            {
                courseValidation = true;
            }

            while (!courseValidation)
            {
                Console.WriteLine("Invalid Course Detail");

                Console.Write("Enter Course Code : ");
                courseCode = Console.ReadLine();

                Console.Write("Enter Course Unit : ");
                courseUnit = Console.ReadLine();

                Console.Write("Enter Student Score  : ");
                courseScore = Console.ReadLine();

                if (Validate.ConfirmScoreRange(courseScore) && Validate.ConfirmUnit(courseUnit))
                {
                    courseValidation = true;
                }

            }

            var studentCourse = new CourseTaken(
                courseCode,
                Validate.ConvertStringToNumber(courseUnit),
                Validate.ConvertStringToNumber(courseScore)
                );
            student.Courses.Add(studentCourse);


        }
        public static string GetEnteredNumber()
        {

            Console.WriteLine("");
            Console.WriteLine("Enter 1 to Add Course");
            Console.WriteLine("Enter 2 to Calculate CGPA");
            var choice = Console.ReadLine();

            var choiceValidation = false;
            choiceValidation = Validate.validateEnteredNumber(choice) ? true : false;
            while (!Validate.validateEnteredNumber(choice))
            {
                Console.WriteLine("Invalid Enter Number. Please Enter the right number ");
                Console.WriteLine("");
                Console.WriteLine("Enter 1 to Add Course");
                Console.WriteLine("Enter 2 to Calculate CGPA");
                choice = Console.ReadLine();
                choiceValidation = Validate.validateEnteredNumber(choice) ? true : false;


            }

            return choice;
        }
    }
}
