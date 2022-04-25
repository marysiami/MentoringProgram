using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            var list = numbers.Split(',');

            var intList = new List<int>();

            foreach(var item in list)
            {
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
