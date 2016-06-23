using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FacebookSmartView
{
    abstract class ASpecialPictureBoxDecorator: ASpecialPictureBox
    {

        private ASpecialPictureBox m_Component;

        protected ASpecialPictureBox Component
        {
            get 
            {
                // Just to go up the tree to get the concrete class
                if (m_Component is SpecialPictureBoxConcrete)
                    return m_Component;
                else
                   return (m_Component as ASpecialPictureBoxDecorator).Component;
                
            }
   
        }

        public ASpecialPictureBoxDecorator(ASpecialPictureBox i_aspbCompenent)
        {
            this.m_Component = i_aspbCompenent;


        }
        // This function i crucial for proper calls to concrete class
        public void InitiateConcrete(ASpecialPictureBox i_ConcreteSpBox)
        {
            Component.FatherPanel = this.m_FatherPanel;
            Component.PictureObject = this.m_PoPictureObjectID;
            Component.PicLabel = this.m_BotLabel;
            Component.BoxPanel = this.m_BoxPanel;
        }

        public override void SpecialPictureBox_Hover(EventArgs e)
        {
            if (m_Component != null)
            {
                m_Component.SpecialPictureBox_Hover(e);
            }
        }

        public override void SpecialPictureBox_Leave(EventArgs e)
        {
            if (m_Component != null)
            {
                m_Component.SpecialPictureBox_Leave(e);
            }
        }

       #region Getters for the concrete Object

        public override Point ObjectLocation
        {
            get
            {
                return Component.ObjectLocation; 
            }
            set
            {
                Component.ObjectLocation = value;
            }
        }

        public override Panel FatherPanel
        {
            get
            {
                return Component.FatherPanel;
            }
        }

        public override Label PicLabel
        {
            get
            {
                return Component.PicLabel;
            }
        }

        public override Panel BoxPanel
        {
            get
            {
                return Component.BoxPanel;
            }
        }

           #endregion

    }
    
  
}
