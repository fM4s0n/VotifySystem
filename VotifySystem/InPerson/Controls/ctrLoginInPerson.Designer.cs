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
        textBox1 = new TextBox();
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
        grpLoginOneTimeCode.Location = new Point(3, 2);
        grpLoginOneTimeCode.Margin = new Padding(3, 2, 3, 2);
        grpLoginOneTimeCode.Name = "grpLoginOneTimeCode";
        grpLoginOneTimeCode.Padding = new Padding(3, 2, 3, 2);
        grpLoginOneTimeCode.Size = new Size(428, 110);
        grpLoginOneTimeCode.TabIndex = 8;
        grpLoginOneTimeCode.TabStop = false;
        grpLoginOneTimeCode.Text = "Log in to vote with one-time code here:";
        // 
        // btnSubmitLoginCode
        // 
        btnSubmitLoginCode.Location = new Point(314, 84);
        btnSubmitLoginCode.Margin = new Padding(3, 2, 3, 2);
        btnSubmitLoginCode.Name = "btnSubmitLoginCode";
        btnSubmitLoginCode.Size = new Size(108, 22);
        btnSubmitLoginCode.TabIndex = 4;
        btnSubmitLoginCode.Text = "Submit";
        btnSubmitLoginCode.UseVisualStyleBackColor = true;
        btnSubmitLoginCode.Click += btnSubmitLoginCode_Click;
        // 
        // txtLoginCode
        // 
        txtLoginCode.Location = new Point(112, 53);
        txtLoginCode.Margin = new Padding(3, 2, 3, 2);
        txtLoginCode.Name = "txtLoginCode";
        txtLoginCode.Size = new Size(310, 23);
        txtLoginCode.TabIndex = 2;
        txtLoginCode.Visible = false;
        // 
        // lblLoginCode
        // 
        lblLoginCode.AutoSize = true;
        lblLoginCode.Location = new Point(68, 56);
        lblLoginCode.Name = "lblLoginCode";
        lblLoginCode.Size = new Size(38, 15);
        lblLoginCode.TabIndex = 3;
        lblLoginCode.Text = "Code:";
        lblLoginCode.Visible = false;
        // 
        // btnCreateAccount
        // 
        btnCreateAccount.Location = new Point(317, 246);
        btnCreateAccount.Margin = new Padding(3, 2, 3, 2);
        btnCreateAccount.Name = "btnCreateAccount";
        btnCreateAccount.Size = new Size(108, 22);
        btnCreateAccount.TabIndex = 7;
        btnCreateAccount.Text = "Create Account";
        btnCreateAccount.UseVisualStyleBackColor = true;
        btnCreateAccount.Click += btnCreateAccount_Click;
        // 
        // btnLogin
        // 
        btnLogin.Location = new Point(314, 97);
        btnLogin.Margin = new Padding(3, 2, 3, 2);
        btnLogin.Name = "btnLogin";
        btnLogin.Size = new Size(108, 22);
        btnLogin.TabIndex = 6;
        btnLogin.Text = "Login";
        btnLogin.UseVisualStyleBackColor = true;
        btnLogin.Click += btnLogin_Click;
        // 
        // textBox1
        // 
        textBox1.Location = new Point(112, 43);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(310, 23);
        textBox1.TabIndex = 9;
        // 
        // txtPassword
        // 
        txtPassword.Location = new Point(112, 72);
        txtPassword.Name = "txtPassword";
        txtPassword.Size = new Size(310, 23);
        txtPassword.TabIndex = 10;
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(lblPassword);
        groupBox1.Controls.Add(lblUsername);
        groupBox1.Controls.Add(textBox1);
        groupBox1.Controls.Add(txtPassword);
        groupBox1.Controls.Add(btnLogin);
        groupBox1.Location = new Point(3, 117);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(428, 124);
        groupBox1.TabIndex = 11;
        groupBox1.TabStop = false;
        groupBox1.Text = "Login with Username / Email";
        // 
        // lblPassword
        // 
        lblPassword.AutoSize = true;
        lblPassword.Location = new Point(49, 80);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(57, 15);
        lblPassword.TabIndex = 12;
        lblPassword.Text = "Password";
        // 
        // lblUsername
        // 
        lblUsername.AutoSize = true;
        lblUsername.Location = new Point(6, 43);
        lblUsername.Name = "lblUsername";
        lblUsername.Size = new Size(100, 15);
        lblUsername.TabIndex = 11;
        lblUsername.Text = "Username / Email";
        // 
        // ctrLoginInPerson
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(groupBox1);
        Controls.Add(grpLoginOneTimeCode);
        Controls.Add(btnCreateAccount);
        Name = "ctrLoginInPerson";
        Size = new Size(439, 279);
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
    private TextBox textBox1;
    private TextBox txtPassword;
    private GroupBox groupBox1;
    private Label lblPassword;
    private Label lblUsername;
}
