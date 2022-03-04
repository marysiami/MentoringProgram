using System;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                var value = Console.ReadLine();
                try
                {
                    Console.WriteLine(value[0]);
                }
                catch(IndexOutOfRangeException ex)
                {
                    Console.WriteLine("string is null or empty \nError: "+ ex.Message);
                    break;
                }
                
            }   
        }
    }
}