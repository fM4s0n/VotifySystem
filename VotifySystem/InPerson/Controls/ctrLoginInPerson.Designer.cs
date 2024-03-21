namespace VotifySystem.Common.Controls.Login;

partial class ctrLoginInPerson
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
        grpLoginOneTimeCode = new GroupBox();
        btnSubmitLoginCode = new Button();
        txtLoginCode = new TextBox();
        lblLoginCode = new Label();
        btnCreateAccount = new Button();
        btnLogin = new Button();
        txtUsername = new TextBox();
        txtPassword = new TextBox();
        groupBox1 = new GroupBox();
        lblPassword = new Label();
        lblUsername = new Label();
        grpLoginOneTimeCode.SuspendLayout();
        groupBox1.SuspendLayout();
        SuspendLayout();
        // 
        // grpLoginOneTimeCode
        // 
        grpLoginOneTimeCode.Controls.Add(btnSubmitLoginCode);
        grpLoginOneTimeCode.Controls.Add(txtLoginCode);
        grpLoginOneTimeCode.Controls.Add(lblLoginCode);
        grpLoginOneTimeCode.Location = new Point(3, 3);
        grpLoginOneTimeCode.Name = "grpLoginOneTimeCode";
        grpLoginOneTimeCode.Size = new Size(489, 147);
        grpLoginOneTimeCode.TabIndex = 8;
        grpLoginOneTimeCode.TabStop = false;
        grpLoginOneTimeCode.Text = "Log in to vote with one-time code here:";
        // 
        // btnSubmitLoginCode
        // 
        btnSubmitLoginCode.Location = new Point(359, 112);
        btnSubmitLoginCode.Name = "btnSubmitLoginCode";
        btnSubmitLoginCode.Size = new Size(123, 29);
        btnSubmitLoginCode.TabIndex = 2;
        btnSubmitLoginCode.Text = "Submit";
        btnSubmitLoginCode.UseVisualStyleBackColor = true;
        btnSubmitLoginCode.Click += btnSubmitLoginCode_Click;
        // 
        // txtLoginCode
        // 
        txtLoginCode.Location = new Point(128, 71);
        txtLoginCode.Name = "txtLoginCode";
        txtLoginCode.Size = new Size(354, 27);
        txtLoginCode.TabIndex = 1;
        // 
        // lblLoginCode
        // 
        lblLoginCode.AutoSize = true;
        lblLoginCode.Location = new Point(78, 75);
        lblLoginCode.Name = "lblLoginCode";
        lblLoginCode.Size = new Size(47, 20);
        lblLoginCode.TabIndex = 3;
        lblLoginCode.Text = "Code:";
        // 
        // btnCreateAccount
        // 
        btnCreateAccount.Location = new Point(362, 328);
        btnCreateAccount.Name = "btnCreateAccount";
        btnCreateAccount.Size = new Size(123, 29);
        btnCreateAccount.TabIndex = 6;
        btnCreateAccount.Text = "Create Account";
        btnCreateAccount.UseVisualStyleBackColor = true;
        btnCreateAccount.Click += btnCreateAccount_Click;
        // 
        // btnLogin
        // 
        btnLogin.Location = new Point(359, 129);
        btnLogin.Name = "btnLogin";
        btnLogin.Size = new Size(123, 29);
        btnLogin.TabIndex = 5;
        btnLogin.Text = "Login";
        btnLogin.UseVisualStyleBackColor = true;
        btnLogin.Click += btnLogin_Click;
        // 
        // txtUsername
        // 
        txtUsername.Location = new Point(128, 57);
        txtUsername.Margin = new Padding(3, 4, 3, 4);
        txtUsername.Name = "txtUsername";
        txtUsername.Size = new Size(354, 27);
        txtUsername.TabIndex = 3;
        // 
        // txtPassword
        // 
        txtPassword.Location = new Point(128, 96);
        txtPassword.Margin = new Padding(3, 4, 3, 4);
        txtPassword.Name = "txtPassword";
        txtPassword.Size = new Size(354, 27);
        txtPassword.TabIndex = 4;
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(lblPassword);
        groupBox1.Controls.Add(lblUsername);
        groupBox1.Controls.Add(txtUsername);
        groupBox1.Controls.Add(txtPassword);
        groupBox1.Controls.Add(btnLogin);
        groupBox1.Location = new Point(3, 156);
        groupBox1.Margin = new Padding(3, 4, 3, 4);
        groupBox1.Name = "groupBox1";
        groupBox1.Padding = new Padding(3, 4, 3, 4);
        groupBox1.Size = new Size(489, 165);
        groupBox1.TabIndex = 11;
        groupBox1.TabStop = false;
        groupBox1.Text = "Login with Username / Email";
        // 
        // lblPassword
        // 
        lblPassword.AutoSize = true;
        lblPassword.Location = new Point(56, 107);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(70, 20);
        lblPassword.TabIndex = 12;
        lblPassword.Text = "Password";
        // 
        // lblUsername
        // 
        lblUsername.AutoSize = true;
        lblUsername.Location = new Point(-1, 60);
        lblUsername.Name = "lblUsername";
        lblUsername.Size = new Size(126, 20);
        lblUsername.TabIndex = 11;
        lblUsername.Text = "Username / Email";
        // 
        // ctrLoginInPerson
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(groupBox1);
        Controls.Add(grpLoginOneTimeCode);
        Controls.Add(btnCreateAccount);
        Margin = new Padding(3, 4, 3, 4);
        Name = "ctrLoginInPerson";
        Size = new Size(502, 372);
        grpLoginOneTimeCode.ResumeLayout(false);
        grpLoginOneTimeCode.PerformLayout();
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private GroupBox grpLoginOneTimeCode;
    private Button btnSubmitLoginCode;
    private TextBox txtLoginCode;
    private Label lblLoginCode;
    private Button btnCreateAccount;
    private Button btnLogin;
    private TextBox txtUsername;
    private TextBox txtPassword;
    private GroupBox groupBox1;
    private Label lblPassword;
    private Label lblUsername;
}
