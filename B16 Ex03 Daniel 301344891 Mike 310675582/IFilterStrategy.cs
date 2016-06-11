using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookSmartView
{
    public interface IFilterStrategy
    {
        bool IsMatch(string i_TextToCheck);
    }
}
