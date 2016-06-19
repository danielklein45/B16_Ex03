using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FacebookSmartView
{
    [Serializable]
    abstract class ASpecialPictureBox : PictureBox, ISpecialPictureBoxDecorator
    {
        #region Private Members

        protected Panel m_FatherPanel;
        protected Panel m_BoxPanel;
        protected Label m_BotLabel;
        protected PictureObject m_PoPictureObjectID;

        #endregion


        #region Const region

        private const int k_LabelHeight = 20;
        private const int k_LabelSpacer = 3;

        private const String k_PictureName = "_PicBox";
        private const String k_GeneralPanelName = "_Panel";
        private const String k_PanelName = "_Label";

        #endregion

        #region Panel And Picture sizes

        private readonly Size r_PanelSize = new Size(sr_PictureBoxTopPhotosSize.Width, k_LabelHeight);
        private readonly Point r_PanelStartLoc = new Point(0, sr_PictureBoxTopPhotosSize.Height - k_LabelHeight);
        private readonly Size r_PictureSize = new Size(sr_PictureBoxTopPhotosSize.Width, sr_PictureBoxTopPhotosSize.Height - k_LabelHeight);
        private readonly Point r_PictureStartLoc = new Point(0, 0);
        private static readonly Size sr_PictureBoxTopPhotosSize = new Size(175, 165);

        #endregion


        #region Basic SpecialPictureBox functionality

        protected override void OnMouseHover(EventArgs e)
        {
            SpecialPictureBox_Hover(e);
            base.OnMouseHover(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            SpecialPictureBox_Leave(e);
            base.OnMouseLeave(e);
        }

        public ASpecialPictureBox InitiateSpeicalPictureBox(Panel i_FatherPanel)
        {
            this.m_FatherPanel = i_FatherPanel;

            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Size = r_PictureSize;
            this.Location = new Point(0, 0);
            this.Click += SpecialPictureBoxOnClick;

            this.m_BotLabel = new Label();
            this.m_BotLabel.Size = r_PanelSize;
            this.m_BotLabel.Location = r_PanelStartLoc;
            this.m_BotLabel.AutoSize = false;
            this.m_BotLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.Visible = true;

            this.m_BoxPanel = new Panel();
            this.m_BoxPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_BoxPanel.Size = sr_PictureBoxTopPhotosSize;


            this.m_BoxPanel.Controls.Add(this);
            this.m_BoxPanel.Controls.Add(m_BotLabel);

            this.m_FatherPanel.Controls.Add(m_BoxPanel);

            return this;
        }
        public ASpecialPictureBox()
        {

        }

        void SpecialPictureBoxOnClick(object sender, EventArgs e)
        {
            string strSelectedObjectId;
            ASpecialPictureBox spbCurrent;

            try
            {
                spbCurrent = (sender as ASpecialPictureBox);
                strSelectedObjectId = spbCurrent.PictureObject.ObjectId.ToString();
                PopularPanelMgt.Instance.CurrentObjectID = strSelectedObjectId;
            }
            catch (Exception)
            {
                spbCurrent = null;
                PopularPanelMgt.Instance.CurrentObjectID = string.Empty;
            }

            if (spbCurrent != null)
            {
                PopularPanelMgt.Instance.InformationLabel.Text = "This picture was posted on " + spbCurrent.PictureObject.PostedDate;
            }
            else
            {
                PopularPanelMgt.Instance.InformationLabel.Text = "Please select a picture from the panel.";
            }
        }

        public void UpdateNames(int i_Id)
        {
            this.Name = m_FatherPanel.Name.ToString() + k_PictureName.ToString() + "_" + i_Id.ToString();
            m_BotLabel.Name = m_FatherPanel.Name.ToString() + k_PanelName.ToString() + "_" + i_Id.ToString();
            m_BoxPanel.Name = m_FatherPanel.Name.ToString() + k_GeneralPanelName.ToString() + "_" + i_Id.ToString();
        }

        public void RemoveObjectFromPanel()
        {
            foreach (Control currControl in m_BoxPanel.Controls)
            {
                m_BoxPanel.Controls.Remove(currControl);
            }

            m_FatherPanel.Controls.Remove(m_BoxPanel);
        }

        public Point ObjectLocation
        {
            get
            {
                return this.Location;
            }
            set
            {
                this.m_BoxPanel.Location = value;
            }
        }

        public static Size PictureBoxTopPhotosSize
        {
            get
            {
                return sr_PictureBoxTopPhotosSize;
            }
        }

        public PictureObject PictureObject
        {
            get
            {
                return this.m_PoPictureObjectID;
            }
            set
            {
                this.m_PoPictureObjectID = value;
            }
        }

        public Panel FatherPanel
        {
            get
            {
                return m_FatherPanel;
            }
        }

        public Label PicLabel
        {
            get
            {
                return m_BotLabel;
            }
        }

        #endregion

        #region Abstract Functions

        public abstract void SpecialPictureBox_Hover(EventArgs e);

        public abstract void SpecialPictureBox_Leave(EventArgs e);

        #endregion

    }
}
