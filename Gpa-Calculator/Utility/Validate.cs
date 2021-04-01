using System;
using System.Collections.Generic;
using System.Text;

namespace Gpa_Calculator.Utility
{
    public static class Validate
    {
        /// <summary>
        /// validate number entered 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
       public static Boolean validateEnteredNumber(string number)
        {

            if (IsvalidNumber(number) &&  ConvertStringToNumber(number) > 0  &&  ConvertStringToNumber(number) < 3)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        ///  chek if number is valid 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static Boolean IsvalidNumber(string number)
        {
            int num ;
            if (int.TryParse(number , out num))
            {
              return true;
            } 
            
                return false;
        }

        /// <summary>
        /// convert string to number 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int ConvertStringToNumber(string number)
        {
          return  int.Parse(number);

        }
        /// <summary>
        ///  confirm score range 
        /// </summary>
        /// <param name="score"></param>
        /// <returns></returns>
        public static Boolean ConfirmScoreRange(string score)
        {
            if (IsvalidNumber(score)  && ConvertStringToNumber(score) >= 1 && ConvertStringToNumber(score)  <= 100)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// confirm Unit 
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public static Boolean ConfirmUnit(string unit)
        {
            if (IsvalidNumber(unit) && ConvertStringToNumber(unit) >= 1)
            {
                return true;
            }
            return false;

        }
    }
}
