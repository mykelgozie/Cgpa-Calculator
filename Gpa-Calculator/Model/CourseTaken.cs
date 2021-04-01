using Gpa_Calculator.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gpa_Calculator.Model
{
     public class CourseTaken
    {
     

        public int Id { get; set; }
        public string CourseCode { get; set; }
        public int CourseUnit { get; set; }
        public string CourseGrade { get; set; }
        public int CourseScore { get; set; }
        public int CoursePoint { get; set; }
        public int QualityPoint { get; set; }

        public CourseTaken(string courseCode, int courseUnit, int courseScore)
        {
            CourseCode = courseCode;
            CourseUnit = courseUnit;
            CourseScore = courseScore;
            // get grade 
            CourseGrade = GetGrade(CourseScore);
            // get point 
            CoursePoint  =  GetPoint(CourseGrade);
            // get quality point
            QualityPoint =  GetQualityPoint();

           

        }


        // get grade 
        public string GetGrade(int coursescore)
        {
            var grade = "";

            if (coursescore >= 0 && coursescore < 40 )
            {

                grade = Grades.F.ToString();

            } else if (coursescore >= 40 && coursescore < 45)
            {

                grade = Grades.E.ToString();

            } else if (coursescore >= 45 && coursescore < 50)
            {
                grade = Grades.D.ToString();

            } else if (coursescore >= 50 && coursescore < 60)
            {
                grade = Grades.C.ToString();

            } else if (coursescore >= 60 && coursescore < 70)
            {
                grade = Grades.B.ToString();
            } else if (coursescore >= 70 && coursescore <=100)
            {

                grade = Grades.A.ToString();
            }
            return grade;
        }

        private int GetPoint(string coursegrade)
        {
            int point = 0;

            foreach (var grade in Enum.GetNames(typeof(Grades)))
            {
                if (coursegrade == grade)
                {
                    point = (int)Enum.Parse(typeof(Grades), grade);
                    break;

                }


            }

            return point;

        }

        // return quality point
        private int GetQualityPoint()
        {
            return  CoursePoint * CourseUnit;
        }




    }
}
