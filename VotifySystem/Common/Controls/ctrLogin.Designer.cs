namespace VotifySystem.Controls;

partial class ctrLogin
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
        btnLogin = new Button();
        btnCreateAccount = new Button();
        txtLoginCode = new TextBox();
        lblLoginCode = new Label();
        grpLoginOneTimeCode = new GroupBox();
        btnSubmitLoginCode = new Button();
        grpLoginOneTimeCode.SuspendLayout();
        SuspendLayout();
        // 
        // btnLogin
        // 
        btnLogin.Location = new Point(268, 446);
        btnLogin.Name = "btnLogin";
        btnLogin.Size = new Size(135, 29);
        btnLogin.TabIndex = 0;
        btnLogin.Text = "Login";
        btnLogin.UseVisualStyleBackColor = true;
        btnLogin.Click += btnLogin_Click;
        // 
        // btnCreateAccount
        // 
        btnCreateAccount.Location = new Point(602, 446);
        btnCreateAccount.Name = "btnCreateAccount";
        btnCreateAccount.Size = new Size(144, 29);
        btnCreateAccount.TabIndex = 1;
        btnCreateAccount.Text = "Create Account";
        btnCreateAccount.UseVisualStyleBackColor = true;
        btnCreateAccount.Click += btnCreateAccount_Click;
        // 
        // txtLoginCode
        // 
        txtLoginCode.Location = new Point(59, 80);
        txtLoginCode.Name = "txtLoginCode";
        txtLoginCode.Size = new Size(313, 27);
        txtLoginCode.TabIndex = 2;
        txtLoginCode.Visible = false;
        // 
        // lblLoginCode
        // 
        lblLoginCode.AutoSize = true;
        lblLoginCode.Location = new Point(6, 83);
        lblLoginCode.Name = "lblLoginCode";
        lblLoginCode.Size = new Size(47, 20);
        lblLoginCode.TabIndex = 3;
        lblLoginCode.Text = "Code:";
        lblLoginCode.Visible = false;
        // 
        // grpLoginOneTimeCode
        // 
        grpLoginOneTimeCode.Controls.Add(btnSubmitLoginCode);
        grpLoginOneTimeCode.Controls.Add(txtLoginCode);
        grpLoginOneTimeCode.Controls.Add(lblLoginCode);
        grpLoginOneTimeCode.Location = new Point(268, 262);
        grpLoginOneTimeCode.Name = "grpLoginOneTimeCode";
        grpLoginOneTimeCode.Size = new Size(478, 134);
        grpLoginOneTimeCode.TabIndex = 5;
        grpLoginOneTimeCode.TabStop = false;
        grpLoginOneTimeCode.Text = "Log in to vote with one-time code here:";
        // 
        // btnSubmitLoginCode
        // 
        btnSubmitLoginCode.Location = new Point(378, 80);
        btnSubmitLoginCode.Name = "btnSubmitLoginCode";
        btnSubmitLoginCode.Size = new Size(94, 29);
        btnSubmitLoginCode.TabIndex = 4;
        btnSubmitLoginCode.Text = "Submit";
        btnSubmitLoginCode.UseVisualStyleBackColor = true;
        btnSubmitLoginCode.Click += btnSubmitLoginCode_Click;
        // 
        // ctrLogin
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(grpLoginOneTimeCode);
        Controls.Add(btnCreateAccount);
        Controls.Add(btnLogin);
        Name = "ctrLogin";
        Size = new Size(1000, 600);
        grpLoginOneTimeCode.ResumeLayout(false);
        grpLoginOneTimeCode.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Button btnLogin;
    private Button btnCreateAccount;
    private TextBox txtLoginCode;
    private Label lblLoginCode;
    private GroupBox grpLoginOneTimeCode;
    private Button btnSubmitLoginCode;
}
