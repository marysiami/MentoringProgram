using System;
using System.Text;

namespace WordWrapKata
{
    public class WordWrap
    {
        public int Column { get; set; }
        public WordWrap(int column)
        {
            this.Column = column;
        }

        public static string Wrap(string term, int column)
        {
            return new WordWrap(column).Wrap(term);
        }

        private string Wrap(string term)
        {
            if (string.IsNullOrEmpty(term))
            {
                throw new ArgumentNullException(term);
            }

            if(term.Length <= Column)
            {                
                return term;
            }
            else
            {
                int space = (term.Substring(0, Column).LastIndexOf(' '));
                if (space != -1)
                {
                    return BreakLine(term, space, 1);
                }
                else if (term[Column] == ' ')
                {
                    return BreakLine(term, Column, 1);
                }
                else
                {
                    return BreakLine(term, Column, 0);
                }
            }            
        }
       

        private string BreakLine(string s, int pos, int gap)
        {
            return s.Substring(0, pos) + "\n" + Wrap(s.Substring(pos + gap), Column);
        }
    }
}
