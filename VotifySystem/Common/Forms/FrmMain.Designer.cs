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
            pnlMain = new Panel();
            ctrMainDefault = new Common.Controls.ctrMainDefault();
            pnlMain.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(ctrMainDefault);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(914, 600);
            pnlMain.TabIndex = 0;
            // 
            // ctrMainDefault
            // 
            ctrMainDefault.Location = new Point(3, 4);
            ctrMainDefault.Margin = new Padding(3, 4, 3, 4);
            ctrMainDefault.Name = "ctrMainDefault1";
            ctrMainDefault.Size = new Size(908, 596);
            ctrMainDefault.TabIndex = 0;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(pnlMain);
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmMain";
            Text = "Form1";
            pnlMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMain;
        private Common.Controls.ctrMainDefault ctrMainDefault;
    }
}
