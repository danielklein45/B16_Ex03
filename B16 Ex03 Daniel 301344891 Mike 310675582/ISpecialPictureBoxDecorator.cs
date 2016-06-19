using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookSmartView
{
    interface ISpecialPictureBoxDecorator
    {
        void SpecialPictureBox_Hover(EventArgs e);
        void SpecialPictureBox_Leave(EventArgs e);
    }
}
