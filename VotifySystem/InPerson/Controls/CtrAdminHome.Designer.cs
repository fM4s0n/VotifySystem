namespace VotifySystem.Controls;

partial class ctrAdminHome
{
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        btnCreateElection = new Button();
        btnManageElection = new Button();
        pictureBox1 = new PictureBox();
        btnLogOut = new Button();
        btnManageParties = new Button();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // btnCreateElection
        // 
        btnCreateElection.Location = new Point(102, 248);
        btnCreateElection.Name = "btnCreateElection";
        btnCreateElection.Size = new Size(162, 23);
        btnCreateElection.TabIndex = 1;
        btnCreateElection.Text = "Create New Election";
        btnCreateElection.UseVisualStyleBackColor = true;
        btnCreateElection.Click += BtnCreateElection_Click;
        // 
        // btnManageElection
        // 
        btnManageElection.Location = new Point(342, 248);
        btnManageElection.Name = "btnManageElection";
        btnManageElection.Size = new Size(162, 23);
        btnManageElection.TabIndex = 2;
        btnManageElection.Text = "Manage Elections";
        btnManageElection.UseVisualStyleBackColor = true;
        btnManageElection.Click += btnManageElection_Click;
        // 
        // pictureBox1
        // 
        pictureBox1.Location = new Point(228, 32);
        pictureBox1.Margin = new Padding(3, 2, 3, 2);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(377, 147);
        pictureBox1.TabIndex = 3;
        pictureBox1.TabStop = false;
        // 
        // btnLogOut
        // 
        btnLogOut.Location = new Point(342, 374);
        btnLogOut.Name = "btnLogOut";
        btnLogOut.Size = new Size(162, 23);
        btnLogOut.TabIndex = 4;
        btnLogOut.Text = "Log Out";
        btnLogOut.UseVisualStyleBackColor = true;
        btnLogOut.Click += btnLogOut_Click;
        // 
        // btnManageParties
        // 
        btnManageParties.Location = new Point(617, 248);
        btnManageParties.Name = "btnManageParties";
        btnManageParties.Size = new Size(162, 23);
        btnManageParties.TabIndex = 5;
        btnManageParties.Text = "Manage Parties";
        btnManageParties.UseVisualStyleBackColor = true;
        btnManageParties.Click += btnManageParties_Click;
        // 
        // ctrAdminHome
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(btnManageParties);
        Controls.Add(btnLogOut);
        Controls.Add(pictureBox1);
        Controls.Add(btnManageElection);
        Controls.Add(btnCreateElection);
        Name = "ctrAdminHome";
        Size = new Size(875, 450);
        Load += ctrAdminHome_Load;
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Button btnCreateElection;
    private Button btnManageElection;
    private PictureBox pictureBox1;
    private Button btnLogOut;
    private Button btnManageParties;
}
