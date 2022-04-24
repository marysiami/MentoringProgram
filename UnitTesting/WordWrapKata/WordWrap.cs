using System;
using System.Text;

namespace WordWrapKata
{
    public static class WordWrap
    {
        public static string Wrap(string term, int length)
        {
            if (string.IsNullOrEmpty(term))
            {
                throw new ArgumentException(term);
            }

            if (term.Length <= length)
            {
                return term;                  
            }
            else
            {
                var sb = new StringBuilder();
                var strings = term.Split(' ');
                int column = 0;
                foreach (var s in strings)
                {
                    column += s.Length;
                    if(column < length)
                    {
                        sb.Append(s + ' ');
                    }
                    else
                    {
                        sb.Append(s + '\n');
                    }                    
                }
                return sb.ToString();
            }
        }
    }
}
