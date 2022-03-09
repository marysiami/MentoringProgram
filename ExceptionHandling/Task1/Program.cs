using System;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var value = Console.ReadLine();

            while (value != null)
            {
                try
                {
                    Console.WriteLine(value[0]);
                }
                catch(IndexOutOfRangeException ex)
                {
                    Console.WriteLine("string is empty \nError: "+ ex.Message);                 
                }

                value = Console.ReadLine();
            }   
        }
    }
}