using System;

namespace TimerProgram
{
    public static class IntegerExtensions
    {
        public static string ToDoz(this int myInt)
        {
            string retVal;
     
            if (myInt >= 0 && myInt <= 9)
            {
                retVal = myInt.ToString();
            }
     
            else if (myInt <= 11)
            {
                retVal = myInt switch
                {
                    10 => "X",
                    11 => "E",
                    _ => string.Empty
                };
            }
            else if (myInt <= 143)
            {
                var tens = myInt / 12;
                var ones = myInt % 12;
                retVal = tens.ToDoz() + ones.ToDoz();
            }
            else
            {
                throw new Exception("This integer cannot be converted to Dozenal.");
            }

            return retVal;
        }
    }
}