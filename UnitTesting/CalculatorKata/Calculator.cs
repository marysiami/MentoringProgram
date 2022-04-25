using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalculatorKata
{
    public static class Calculator
    {
        public static int Add(string numbers)
        {
            if(string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var delimiter = numbers[0];

            if (!Int32.TryParse(delimiter.ToString(), out int d) && numbers[1] == '\n')
            {
               numbers = numbers.Substring(2);
            }
            else
            {
                delimiter = ',';
            }

            numbers = numbers.Replace('\n', delimiter);

            var list = numbers.Split(delimiter);

            var intList = new List<int>();

            foreach(var item in list)
            {
                if (string.IsNullOrEmpty(item))
                {
                    continue;
                }

                if (Int32.TryParse(item, out int i))
                {
                    intList.Add(i);
                }
                else
                {
                    return 0;
                }
            }

            return intList.Sum();            
        }
    }
}
