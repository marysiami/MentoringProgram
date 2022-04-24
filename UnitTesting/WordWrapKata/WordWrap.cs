using System;

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
                int lastSpace = 0;
                int space;
                while ((space = term.IndexOf(" ", lastSpace)) != -1)
                {
                    if (space > length)
                    {
                        term = term.Substring(0, lastSpace) + "\n" + term.Substring(lastSpace + 1);                       
                    }
                    lastSpace = space;
                }
            }

            return term;

            //return word.Replace(" ", "\n");
        }
    }
}
