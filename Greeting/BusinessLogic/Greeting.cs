using System;

namespace BusinessLogic
{
    public static class Greeting
    {
        public static string Welcome(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var date = DateTime.Now;
                return $"{date.ToShortTimeString()} {date.ToShortDateString()}\n\nHello, {name}!";
            }

            return "There is no name.";
        }
    }
}
