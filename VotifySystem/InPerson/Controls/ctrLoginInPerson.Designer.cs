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
        grpLoginOneTimeCode.SuspendLayout();
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
        grpLoginOneTimeCode.Size = new Size(418, 100);
        grpLoginOneTimeCode.TabIndex = 8;
        grpLoginOneTimeCode.TabStop = false;
        grpLoginOneTimeCode.Text = "Log in to vote with one-time code here:";
        // 
        // btnSubmitLoginCode
        // 
        btnSubmitLoginCode.Location = new Point(331, 60);
        btnSubmitLoginCode.Margin = new Padding(3, 2, 3, 2);
        btnSubmitLoginCode.Name = "btnSubmitLoginCode";
        btnSubmitLoginCode.Size = new Size(82, 22);
        btnSubmitLoginCode.TabIndex = 4;
        btnSubmitLoginCode.Text = "Submit";
        btnSubmitLoginCode.UseVisualStyleBackColor = true;
        btnSubmitLoginCode.Click += btnSubmitLoginCode_Click;
        // 
        // txtLoginCode
        // 
        txtLoginCode.Location = new Point(52, 60);
        txtLoginCode.Margin = new Padding(3, 2, 3, 2);
        txtLoginCode.Name = "txtLoginCode";
        txtLoginCode.Size = new Size(274, 23);
        txtLoginCode.TabIndex = 2;
        txtLoginCode.Visible = false;
        // 
        // lblLoginCode
        // 
        lblLoginCode.AutoSize = true;
        lblLoginCode.Location = new Point(5, 61);
        lblLoginCode.Name = "lblLoginCode";
        lblLoginCode.Size = new Size(38, 15);
        lblLoginCode.TabIndex = 3;
        lblLoginCode.Text = "Code:";
        lblLoginCode.Visible = false;
        // 
        // btnCreateAccount
        // 
        btnCreateAccount.Location = new Point(296, 140);
        btnCreateAccount.Margin = new Padding(3, 2, 3, 2);
        btnCreateAccount.Name = "btnCreateAccount";
        btnCreateAccount.Size = new Size(126, 22);
        btnCreateAccount.TabIndex = 7;
        btnCreateAccount.Text = "Create Account";
        btnCreateAccount.UseVisualStyleBackColor = true;
        btnCreateAccount.Click += btnCreateAccount_Click;
        // 
        // btnLogin
        // 
        btnLogin.Location = new Point(3, 140);
        btnLogin.Margin = new Padding(3, 2, 3, 2);
        btnLogin.Name = "btnLogin";
        btnLogin.Size = new Size(118, 22);
        btnLogin.TabIndex = 6;
        btnLogin.Text = "Login";
        btnLogin.UseVisualStyleBackColor = true;
        btnLogin.Click += btnLogin_Click;
        // 
        // ctrLoginInPerson
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(grpLoginOneTimeCode);
        Controls.Add(btnCreateAccount);
        Controls.Add(btnLogin);
        Name = "ctrLoginInPerson";
        Size = new Size(427, 169);
        grpLoginOneTimeCode.ResumeLayout(false);
        grpLoginOneTimeCode.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private GroupBox grpLoginOneTimeCode;
    private Button btnSubmitLoginCode;
    private TextBox txtLoginCode;
    private Label lblLoginCode;
    private Button btnCreateAccount;
    private Button btnLogin;
}
