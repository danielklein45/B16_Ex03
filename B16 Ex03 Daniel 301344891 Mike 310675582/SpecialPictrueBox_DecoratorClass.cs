using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace FacebookSmartView
{
   class SpecialPictrueBoxBlueHover : ASpecialPictureBoxDecorator
    {
       public SpecialPictrueBoxBlueHover(ASpecialPictureBox i_AbstractPictureBox)
           : base(i_AbstractPictureBox)
       {
       }

        public override void SpecialPictureBox_Hover(EventArgs e)
        {
            base.SpecialPictureBox_Hover(e);
            Component.PicLabel.BackColor = Color.LightSkyBlue;
        }

       public override void SpecialPictureBox_Leave(EventArgs e)
        {
            base.SpecialPictureBox_Leave(e);
        }
       
    }

   class SpecialPictrueBoxBlueLeaver : ASpecialPictureBoxDecorator
   {
       public SpecialPictrueBoxBlueLeaver(ASpecialPictureBox i_AbstractPictureBox)
           : base(i_AbstractPictureBox)
       {
       }

       public override void SpecialPictureBox_Hover(EventArgs e)
       {
           base.SpecialPictureBox_Hover(e);
       }

       public override void SpecialPictureBox_Leave(EventArgs e)
       {
           base.SpecialPictureBox_Leave(e);
           Component.PicLabel.BackColor = SystemColors.ButtonHighlight;
       }

   }

   class SpecialPictrueBoxGreyLeaver : ASpecialPictureBoxDecorator
   {
       public SpecialPictrueBoxGreyLeaver(ASpecialPictureBox i_AbstractPictureBox)
            : base(i_AbstractPictureBox)
        {
        }

       public override void SpecialPictureBox_Leave(EventArgs e)
       {
           base.SpecialPictureBox_Leave(e);
           Component.PicLabel.BackColor = Color.Gray;
       }

       public override void SpecialPictureBox_Hover(EventArgs e)
       {
           base.SpecialPictureBox_Hover(e);
           Component.PicLabel.BackColor = Color.LightGray;
       }
   }

   class SpecialPictrueBoxRedHoverAndLeaver : ASpecialPictureBoxDecorator
   {
       public SpecialPictrueBoxRedHoverAndLeaver(ASpecialPictureBox i_AbstractPictureBox)
           : base(i_AbstractPictureBox)
       {
       }

       public override void SpecialPictureBox_Hover(EventArgs e)
       {
           base.SpecialPictureBox_Hover(e);
           Component.PicLabel.BackColor = Color.Red;
       }

       public override void SpecialPictureBox_Leave(EventArgs e)
       {
           base.SpecialPictureBox_Leave(e);
           Component.PicLabel.BackColor = Color.RosyBrown;
       }
   }
       
}
