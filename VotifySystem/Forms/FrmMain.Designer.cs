namespace VotifySystem
{
    partial class FrmMain
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
            btnOnline = new Button();
            btnInPerson = new Button();
            pnlMain.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(btnOnline);
            pnlMain.Controls.Add(btnInPerson);
            pnlMain.Location = new Point(12, 12);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(890, 576);
            pnlMain.TabIndex = 0;
            // 
            // btnOnline
            // 
            btnOnline.Location = new Point(474, 249);
            btnOnline.Name = "btnOnline";
            btnOnline.Size = new Size(94, 29);
            btnOnline.TabIndex = 1;
            btnOnline.Text = "Online";
            btnOnline.UseVisualStyleBackColor = true;
            btnOnline.Click += btnOnline_Click;
            // 
            // btnInPerson
            // 
            btnInPerson.Location = new Point(218, 249);
            btnInPerson.Name = "btnInPerson";
            btnInPerson.Size = new Size(133, 29);
            btnInPerson.TabIndex = 0;
            btnInPerson.Text = "In person";
            btnInPerson.UseVisualStyleBackColor = true;
            btnInPerson.Click += btnInPerson_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(pnlMain);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmMain";
            Text = "Form1";
            pnlMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMain;
        private Button btnOnline;
        private Button btnInPerson;
    }
}
