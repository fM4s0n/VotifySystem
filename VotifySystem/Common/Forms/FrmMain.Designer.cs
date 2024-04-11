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
            ctrAdminHome = new Controls.ctrAdminHome();
            ctrVoterHome = new Controls.ctrVoterHome();
            ctrVoterHomeOnline = new Online.Controls.ctrVoterHomeOnline();
            lblHello = new Label();
            SuspendLayout();
            // 
            // ctrMainDefault
            // 
            ctrMainDefault.Location = new Point(114, 51);
            ctrMainDefault.Margin = new Padding(3, 4, 3, 4);
            ctrMainDefault.Name = "ctrMainDefault";
            ctrMainDefault.Size = new Size(750, 425);
            ctrMainDefault.TabIndex = 0;
            // 
            // ctrLoginBase
            // 
            ctrLoginBase.Location = new Point(22, 26);
            ctrLoginBase.Margin = new Padding(3, 2, 3, 2);
            ctrLoginBase.Name = "ctrLoginBase";
            ctrLoginBase.Size = new Size(702, 372);
            ctrLoginBase.TabIndex = 1;
            ctrLoginBase.Visible = false;
            // 
            // ctrAdminHome
            // 
            ctrAdminHome.Location = new Point(12, 12);
            ctrAdminHome.Name = "ctrAdminHome";
            ctrAdminHome.Size = new Size(875, 450);
            ctrAdminHome.TabIndex = 2;
            ctrAdminHome.Visible = false;
            // 
            // ctrVoterHome
            // 
            ctrVoterHome.Location = new Point(51, 51);
            ctrVoterHome.Margin = new Padding(3, 2, 3, 2);
            ctrVoterHome.Name = "ctrVoterHome";
            ctrVoterHome.Size = new Size(875, 450);
            ctrVoterHome.TabIndex = 3;
            ctrVoterHome.Visible = false;
            // 
            // ctrVoterHomeOnline
            // 
            ctrVoterHomeOnline.Location = new Point(105, 81);
            ctrVoterHomeOnline.Name = "ctrVoterHomeOnline1";
            ctrVoterHomeOnline.Size = new Size(807, 393);
            ctrVoterHomeOnline.TabIndex = 4;
            ctrVoterHomeOnline.Visible = false;
            // 
            // lbHello
            // 
            lblHello.AutoSize = true;
            lblHello.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHello.Location = new Point(6, 2);
            lblHello.Name = "lbHello";
            lblHello.Size = new Size(52, 21);
            lblHello.TabIndex = 4;
            lblHello.Text = "label1";
            lblHello.Visible = false;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(967, 560);
            Controls.Add(ctrVoterHomeOnline);
            Controls.Add(lblHello);
            Controls.Add(ctrVoterHome);
            Controls.Add(ctrAdminHome);
            Controls.Add(ctrLoginBase);
            Controls.Add(ctrMainDefault);
            Name = "frmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Votify";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Common.Controls.ctrMainDefault ctrMainDefault;
        private Controls.ctrLoginBase ctrLoginBase;
        private Controls.ctrAdminHome ctrAdminHome;
        private Controls.ctrVoterHome ctrVoterHome;
        private Online.Controls.ctrVoterHomeOnline ctrVoterHomeOnline;
        private Label lblHello;
    }
}
