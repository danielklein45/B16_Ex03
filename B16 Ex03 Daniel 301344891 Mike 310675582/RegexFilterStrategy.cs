using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FacebookSmartView
{
    public class RegexFilterStrategy: IFilterStrategy
    {
        private Regex m_Regex;
        public RegexFilterStrategy(string i_Text)
        {
            m_Regex = new Regex(i_Text);
        }
        public bool IsMatch(string i_TextToCheck)
        {
            return m_Regex.Match(i_TextToCheck).Success;
        }

        public override string ToString()
        {
            return m_Regex.ToString();
        }
    }
}
