namespace VotifySystem
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ctrMainDefault = new Common.Controls.ctrMainDefault();
            ctrLoginBase = new Controls.ctrLoginBase();
            SuspendLayout();
            // 
            // ctrMainDefault
            // 
            ctrMainDefault.Location = new Point(25, 16);
            ctrMainDefault.Margin = new Padding(3, 5, 3, 5);
            ctrMainDefault.Name = "ctrMainDefault";
            ctrMainDefault.Size = new Size(857, 567);
            ctrMainDefault.TabIndex = 0;
            // 
            // ctrLoginBase
            // 
            ctrLoginBase.Location = new Point(25, 34);
            ctrLoginBase.Name = "ctrLoginBase";
            ctrLoginBase.Size = new Size(802, 496);
            ctrLoginBase.TabIndex = 1;
            ctrLoginBase.Visible = false;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(ctrLoginBase);
            Controls.Add(ctrMainDefault);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmMain";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Common.Controls.ctrMainDefault ctrMainDefault;
        private Controls.ctrLoginBase ctrLoginBase;
    }
}
