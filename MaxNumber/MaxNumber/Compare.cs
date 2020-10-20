using System;
using System.Collections.Generic;
using System.Text;

namespace MaxNumber
{
    public class Compare
    {
        public int compareIntegers(int number1, int number2, int number3)
        {
            int maxNumber = 0;

            if(number1.CompareTo(number2)>0 && number1.CompareTo(number3) > 0)
            {
                maxNumber = number1;
            }
            else if (number2.CompareTo(number1) > 0 && number2.CompareTo(number3) > 0)
            {
                maxNumber = number2;
            }
            else if (number3.CompareTo(number2) > 0 && number3.CompareTo(number1) > 0)
            {
                maxNumber = number3;
            }
            else
            {
                throw new Exception("Please enter different Numbers");
            }

            return maxNumber;
        }
    }
}
