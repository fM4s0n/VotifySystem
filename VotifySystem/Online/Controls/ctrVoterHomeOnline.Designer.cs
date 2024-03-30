namespace VotifySystem.Online.Controls;

partial class ctrVoterHomeOnline
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
        btnGenerateLoginCode = new Button();
        grpLoginCode = new GroupBox();
        lblExpiryWarning = new Label();
        lblLoginCode = new Label();
        grpVoteOnline = new GroupBox();
        grpLoginCode.SuspendLayout();
        SuspendLayout();
        // 
        // btnGenerateLoginCode
        // 
        btnGenerateLoginCode.Location = new Point(61, 32);
        btnGenerateLoginCode.Name = "btnGenerateLoginCode";
        btnGenerateLoginCode.Size = new Size(165, 23);
        btnGenerateLoginCode.TabIndex = 0;
        btnGenerateLoginCode.Text = "Generate Login Code";
        btnGenerateLoginCode.UseVisualStyleBackColor = true;
        btnGenerateLoginCode.Click += btnGenerateLoginCode_Click;
        // 
        // grpLoginCode
        // 
        grpLoginCode.Controls.Add(lblExpiryWarning);
        grpLoginCode.Controls.Add(lblLoginCode);
        grpLoginCode.Controls.Add(btnGenerateLoginCode);
        grpLoginCode.Location = new Point(25, 147);
        grpLoginCode.Name = "grpLoginCode";
        grpLoginCode.Size = new Size(362, 188);
        grpLoginCode.TabIndex = 1;
        grpLoginCode.TabStop = false;
        grpLoginCode.Text = "Generate In Person Login Code";
        // 
        // lblExpiryWarning
        // 
        lblExpiryWarning.AutoSize = true;
        lblExpiryWarning.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblExpiryWarning.Location = new Point(19, 147);
        lblExpiryWarning.Name = "lblExpiryWarning";
        lblExpiryWarning.Size = new Size(274, 25);
        lblExpiryWarning.TabIndex = 2;
        lblExpiryWarning.Text = "This code will expire in 30 mins";
        lblExpiryWarning.Visible = false;
        // 
        // lblLoginCode
        // 
        lblLoginCode.AutoSize = true;
        lblLoginCode.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblLoginCode.Location = new Point(61, 90);
        lblLoginCode.Name = "lblLoginCode";
        lblLoginCode.Size = new Size(177, 37);
        lblLoginCode.TabIndex = 1;
        lblLoginCode.Text = "lblLoginCode";
        // 
        // grpVoteOnline
        // 
        grpVoteOnline.Location = new Point(417, 147);
        grpVoteOnline.Name = "grpVoteOnline";
        grpVoteOnline.Size = new Size(370, 188);
        grpVoteOnline.TabIndex = 2;
        grpVoteOnline.TabStop = false;
        grpVoteOnline.Text = "Vote Online";
        // 
        // ctrVoterHomeOnline
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(grpLoginCode);
        Controls.Add(grpVoteOnline);
        Name = "ctrVoterHomeOnline";
        Size = new Size(807, 393);
        grpLoginCode.ResumeLayout(false);
        grpLoginCode.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Button btnGenerateLoginCode;
    private GroupBox grpLoginCode;
    private Label lblLoginCode;
    private Label lblExpiryWarning;
    private GroupBox grpVoteOnline;
}
