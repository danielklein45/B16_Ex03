using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace FacebookSmartView
{
    abstract class ASpecialPictureBoxDecorator: ASpecialPictureBox
    {
        protected ASpecialPictureBox m_Compenent;

        public ASpecialPictureBoxDecorator(ASpecialPictureBox i_aspbCompenent)
        {
            this.m_Compenent = i_aspbCompenent;

        }

        public override void SpecialPictureBox_Hover(EventArgs e)
        {
            if (m_Compenent != null)
            {
                m_Compenent.SpecialPictureBox_Hover(e);
            }
        }

        public override void SpecialPictureBox_Leave(EventArgs e)
        {
            if (m_Compenent != null)
            {
                m_Compenent.SpecialPictureBox_Leave(e);
            }
        }
    }

    class SpecialPictrueBoxBlueHover : ASpecialPictureBoxDecorator
    {
        public SpecialPictrueBoxBlueHover(ASpecialPictureBox i_AbstractPictureBox):base(i_AbstractPictureBox)
        {
        }

         public override void SpecialPictureBox_Hover(EventArgs e)
        {
            base.SpecialPictureBox_Hover(e);
            m_BotLabel.BackColor = Color.LightSkyBlue;
        }
         public override void SpecialPictureBox_Leave(EventArgs e)
         {
             base.SpecialPictureBox_Leave(e);
            m_BotLabel.BackColor = SystemColors.ButtonHighlight;
         }
    }
}
