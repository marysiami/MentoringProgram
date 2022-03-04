using System;
using System.Text.RegularExpressions;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            if (string.IsNullOrEmpty(stringValue))
            {
                if(stringValue == null)
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    throw new FormatException();
                }
            }

            stringValue = stringValue.Trim();

            if (!Regex.IsMatch(stringValue, @"[\d++-]$"))
            {
                throw new FormatException();
            }

            int response = 0;
            bool minus = false;

            for (int i =0; i < stringValue.Length; i++)
            {
                if(i == 0)
                {
                    if(stringValue[i] == '-')
                    {
                        minus = true;
                        continue;
                    }
                    if (stringValue[i] == '+')
                    {
                        continue;
                    }
                }                              

                try
                {
                    var value = stringValue[i] - '0';

                    if (minus)
                    {
                        response = checked(response * 10 - value);
                    }
                    else
                    {
                        response = checked(response * 10 + value);
                    }    
                }
                catch (OverflowException e)
                {
                    throw e;
                }
            }    

            return response;
        }
    }
}