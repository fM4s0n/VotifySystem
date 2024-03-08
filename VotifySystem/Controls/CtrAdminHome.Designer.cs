namespace VotifySystem.Controls;

partial class CtrAdminHome
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
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // btnCreateElection
        // 
        btnCreateElection.Location = new Point(116, 331);
        btnCreateElection.Margin = new Padding(3, 4, 3, 4);
        btnCreateElection.Name = "btnCreateElection";
        btnCreateElection.Size = new Size(185, 31);
        btnCreateElection.TabIndex = 1;
        btnCreateElection.Text = "Create New Election";
        btnCreateElection.UseVisualStyleBackColor = true;
        btnCreateElection.Click += BtnCreateElection_Click;
        // 
        // btnManageElection
        // 
        btnManageElection.Location = new Point(391, 331);
        btnManageElection.Margin = new Padding(3, 4, 3, 4);
        btnManageElection.Name = "btnManageElection";
        btnManageElection.Size = new Size(185, 31);
        btnManageElection.TabIndex = 2;
        btnManageElection.Text = "Manage Election";
        btnManageElection.UseVisualStyleBackColor = true;
        btnManageElection.Click += btnManageElection_Click;
        // 
        // pictureBox1
        // 
        pictureBox1.Location = new Point(261, 43);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new Size(431, 196);
        pictureBox1.TabIndex = 3;
        pictureBox1.TabStop = false;
        // 
        // btnLogOut
        // 
        btnLogOut.Location = new Point(391, 499);
        btnLogOut.Margin = new Padding(3, 4, 3, 4);
        btnLogOut.Name = "btnLogOut";
        btnLogOut.Size = new Size(185, 31);
        btnLogOut.TabIndex = 4;
        btnLogOut.Text = "Log Out";
        btnLogOut.UseVisualStyleBackColor = true;
        btnLogOut.Click += btnLogOut_Click;
        // 
        // CtrAdminHome
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(btnLogOut);
        Controls.Add(pictureBox1);
        Controls.Add(btnManageElection);
        Controls.Add(btnCreateElection);
        Margin = new Padding(3, 4, 3, 4);
        Name = "CtrAdminHome";
        Size = new Size(1000, 600);
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Button btnCreateElection;
    private Button btnManageElection;
    private PictureBox pictureBox1;
    private Button btnLogOut;
}
