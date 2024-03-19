namespace VotifySystem.Common.Forms;

partial class frmCreateAccount
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        lblFirstName = new Label();
        lblLastName = new Label();
        lblDateOfBirth = new Label();
        lblCountry = new Label();
        dtpDoB = new DateTimePicker();
        txtFirstName = new TextBox();
        txtLastName = new TextBox();
        btnSubmit = new Button();
        cmbCountry = new ComboBox();
        lblCreateAccount = new Label();
        lblAddress = new Label();
        txtAddress = new TextBox();
        cmbVoteMethod = new ComboBox();
        lblVoteMethod = new Label();
        txtEmail = new TextBox();
        lblEmail = new Label();
        txtPassword = new TextBox();
        lblPassword = new Label();
        SuspendLayout();
        // 
        // lblFirstName
        // 
        lblFirstName.AutoSize = true;
        lblFirstName.Location = new Point(79, 152);
        lblFirstName.Name = "lblFirstName";
        lblFirstName.Size = new Size(83, 20);
        lblFirstName.TabIndex = 0;
        lblFirstName.Text = "First Name:";
        // 
        // lblLastName
        // 
        lblLastName.AutoSize = true;
        lblLastName.Location = new Point(79, 191);
        lblLastName.Name = "lblLastName";
        lblLastName.Size = new Size(79, 20);
        lblLastName.TabIndex = 1;
        lblLastName.Text = "Last name:";
        // 
        // lblDateOfBirth
        // 
        lblDateOfBirth.AutoSize = true;
        lblDateOfBirth.Location = new Point(73, 315);
        lblDateOfBirth.Name = "lblDateOfBirth";
        lblDateOfBirth.Size = new Size(94, 20);
        lblDateOfBirth.TabIndex = 2;
        lblDateOfBirth.Text = "Date of Birth";
        // 
        // lblCountry
        // 
        lblCountry.AutoSize = true;
        lblCountry.Location = new Point(95, 384);
        lblCountry.Name = "lblCountry";
        lblCountry.Size = new Size(60, 20);
        lblCountry.TabIndex = 3;
        lblCountry.Text = "Country";
        // 
        // dtpDoB
        // 
        dtpDoB.Location = new Point(163, 307);
        dtpDoB.Margin = new Padding(3, 4, 3, 4);
        dtpDoB.Name = "dtpDoB";
        dtpDoB.Size = new Size(364, 27);
        dtpDoB.TabIndex = 5;
        // 
        // txtFirstName
        // 
        txtFirstName.Location = new Point(162, 148);
        txtFirstName.Margin = new Padding(3, 4, 3, 4);
        txtFirstName.Name = "txtFirstName";
        txtFirstName.Size = new Size(364, 27);
        txtFirstName.TabIndex = 6;
        // 
        // txtLastName
        // 
        txtLastName.Location = new Point(162, 187);
        txtLastName.Margin = new Padding(3, 4, 3, 4);
        txtLastName.Name = "txtLastName";
        txtLastName.Size = new Size(364, 27);
        txtLastName.TabIndex = 7;
        // 
        // btnSubmit
        // 
        btnSubmit.Location = new Point(290, 723);
        btnSubmit.Margin = new Padding(3, 4, 3, 4);
        btnSubmit.Name = "btnSubmit";
        btnSubmit.Size = new Size(237, 31);
        btnSubmit.TabIndex = 8;
        btnSubmit.Text = "Submit";
        btnSubmit.UseVisualStyleBackColor = true;
        btnSubmit.Click += btnSubmit_Click;
        // 
        // cmbCountry
        // 
        cmbCountry.FormattingEnabled = true;
        cmbCountry.Location = new Point(162, 380);
        cmbCountry.Margin = new Padding(3, 4, 3, 4);
        cmbCountry.Name = "cmbCountry";
        cmbCountry.Size = new Size(364, 28);
        cmbCountry.TabIndex = 9;
        // 
        // lblCreateAccount
        // 
        lblCreateAccount.AutoSize = true;
        lblCreateAccount.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblCreateAccount.Location = new Point(178, 47);
        lblCreateAccount.Name = "lblCreateAccount";
        lblCreateAccount.Size = new Size(251, 46);
        lblCreateAccount.TabIndex = 11;
        lblCreateAccount.Text = "Create Account";
        // 
        // lblAddress
        // 
        lblAddress.AutoSize = true;
        lblAddress.Location = new Point(97, 354);
        lblAddress.Name = "lblAddress";
        lblAddress.Size = new Size(62, 20);
        lblAddress.TabIndex = 12;
        lblAddress.Text = "Address";
        // 
        // txtAddress
        // 
        txtAddress.Location = new Point(163, 346);
        txtAddress.Margin = new Padding(3, 4, 3, 4);
        txtAddress.Name = "txtAddress";
        txtAddress.Size = new Size(364, 27);
        txtAddress.TabIndex = 14;
        // 
        // cmbVoteMethod
        // 
        cmbVoteMethod.FormattingEnabled = true;
        cmbVoteMethod.Location = new Point(162, 418);
        cmbVoteMethod.Margin = new Padding(3, 4, 3, 4);
        cmbVoteMethod.Name = "cmbVoteMethod";
        cmbVoteMethod.Size = new Size(364, 28);
        cmbVoteMethod.TabIndex = 16;
        // 
        // lblVoteMethod
        // 
        lblVoteMethod.AutoSize = true;
        lblVoteMethod.Location = new Point(69, 422);
        lblVoteMethod.Name = "lblVoteMethod";
        lblVoteMethod.Size = new Size(95, 20);
        lblVoteMethod.TabIndex = 17;
        lblVoteMethod.Text = "Vote Method";
        // 
        // txtEmail
        // 
        txtEmail.Location = new Point(162, 227);
        txtEmail.Margin = new Padding(3, 4, 3, 4);
        txtEmail.Name = "txtEmail";
        txtEmail.Size = new Size(364, 27);
        txtEmail.TabIndex = 19;
        // 
        // lblEmail
        // 
        lblEmail.AutoSize = true;
        lblEmail.Location = new Point(79, 231);
        lblEmail.Name = "lblEmail";
        lblEmail.Size = new Size(46, 20);
        lblEmail.TabIndex = 18;
        lblEmail.Text = "Email";
        // 
        // txtPassword
        // 
        txtPassword.Location = new Point(162, 262);
        txtPassword.Margin = new Padding(3, 4, 3, 4);
        txtPassword.Name = "txtPassword";
        txtPassword.Size = new Size(364, 27);
        txtPassword.TabIndex = 21;
        // 
        // lblPassword
        // 
        lblPassword.AutoSize = true;
        lblPassword.Location = new Point(79, 266);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(70, 20);
        lblPassword.TabIndex = 20;
        lblPassword.Text = "Password";
        // 
        // frmCreateAccount
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(589, 796);
        Controls.Add(txtPassword);
        Controls.Add(lblPassword);
        Controls.Add(txtEmail);
        Controls.Add(lblEmail);
        Controls.Add(lblVoteMethod);
        Controls.Add(cmbVoteMethod);
        Controls.Add(txtAddress);
        Controls.Add(lblAddress);
        Controls.Add(lblCreateAccount);
        Controls.Add(cmbCountry);
        Controls.Add(btnSubmit);
        Controls.Add(txtLastName);
        Controls.Add(txtFirstName);
        Controls.Add(dtpDoB);
        Controls.Add(lblCountry);
        Controls.Add(lblDateOfBirth);
        Controls.Add(lblLastName);
        Controls.Add(lblFirstName);
        Margin = new Padding(3, 4, 3, 4);
        Name = "frmCreateAccount";
        Text = "frmCreateAccount";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblFirstName;
    private Label lblLastName;
    private Label lblDateOfBirth;
    private Label lblCountry;
    private DateTimePicker dtpDoB;
    private TextBox txtFirstName;
    private TextBox txtLastName;
    private Button btnSubmit;
    private ComboBox cmbCountry;
    private Label lblCreateAccount;
    private Label lblAddress;
    private TextBox txtAddress;
    private ComboBox cmbVoteMethod;
    private Label lblVoteMethod;
    private TextBox txtEmail;
    private Label lblEmail;
    private TextBox txtPassword;
    private Label lblPassword;
}