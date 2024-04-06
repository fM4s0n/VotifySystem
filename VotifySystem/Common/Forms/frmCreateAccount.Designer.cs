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
        lblDoB = new Label();
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
        btnCancel = new Button();
        lblEn = new Label();
        lblFr = new Label();
        SuspendLayout();
        // 
        // lblFirstName
        // 
        lblFirstName.AutoSize = true;
        lblFirstName.Location = new Point(11, 91);
        lblFirstName.Name = "lblFirstName";
        lblFirstName.Size = new Size(67, 15);
        lblFirstName.TabIndex = 0;
        lblFirstName.Text = "First Name:";
        // 
        // lblLastName
        // 
        lblLastName.AutoSize = true;
        lblLastName.Location = new Point(11, 120);
        lblLastName.Name = "lblLastName";
        lblLastName.Size = new Size(64, 15);
        lblLastName.TabIndex = 0;
        lblLastName.Text = "Last name:";
        // 
        // lblDoB
        // 
        lblDoB.AutoSize = true;
        lblDoB.Location = new Point(11, 210);
        lblDoB.Name = "lblDoB";
        lblDoB.Size = new Size(73, 15);
        lblDoB.TabIndex = 0;
        lblDoB.Text = "Date of Birth";
        // 
        // lblCountry
        // 
        lblCountry.AutoSize = true;
        lblCountry.Location = new Point(10, 268);
        lblCountry.Name = "lblCountry";
        lblCountry.Size = new Size(50, 15);
        lblCountry.TabIndex = 0;
        lblCountry.Text = "Country";
        // 
        // dtpDoB
        // 
        dtpDoB.Location = new Point(127, 205);
        dtpDoB.Name = "dtpDoB";
        dtpDoB.Size = new Size(319, 23);
        dtpDoB.TabIndex = 4;
        // 
        // txtFirstName
        // 
        txtFirstName.Location = new Point(126, 91);
        txtFirstName.Name = "txtFirstName";
        txtFirstName.Size = new Size(319, 23);
        txtFirstName.TabIndex = 0;
        // 
        // txtLastName
        // 
        txtLastName.Location = new Point(126, 120);
        txtLastName.Name = "txtLastName";
        txtLastName.Size = new Size(319, 23);
        txtLastName.TabIndex = 1;
        // 
        // btnSubmit
        // 
        btnSubmit.Location = new Point(242, 347);
        btnSubmit.Name = "btnSubmit";
        btnSubmit.Size = new Size(207, 23);
        btnSubmit.TabIndex = 8;
        btnSubmit.Text = "Submit";
        btnSubmit.UseVisualStyleBackColor = true;
        btnSubmit.Click += btnSubmit_Click;
        // 
        // cmbCountry
        // 
        cmbCountry.FormattingEnabled = true;
        cmbCountry.Location = new Point(126, 265);
        cmbCountry.Name = "cmbCountry";
        cmbCountry.Size = new Size(319, 23);
        cmbCountry.TabIndex = 6;
        // 
        // lblCreateAccount
        // 
        lblCreateAccount.AutoSize = true;
        lblCreateAccount.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblCreateAccount.Location = new Point(69, 9);
        lblCreateAccount.Name = "lblCreateAccount";
        lblCreateAccount.Size = new Size(353, 45);
        lblCreateAccount.TabIndex = 0;
        lblCreateAccount.Text = "Create a Votify Account";
        // 
        // lblAddress
        // 
        lblAddress.AutoSize = true;
        lblAddress.Location = new Point(11, 243);
        lblAddress.Name = "lblAddress";
        lblAddress.Size = new Size(49, 15);
        lblAddress.TabIndex = 0;
        lblAddress.Text = "Address";
        // 
        // txtAddress
        // 
        txtAddress.Location = new Point(127, 235);
        txtAddress.Name = "txtAddress";
        txtAddress.Size = new Size(319, 23);
        txtAddress.TabIndex = 5;
        // 
        // cmbVoteMethod
        // 
        cmbVoteMethod.FormattingEnabled = true;
        cmbVoteMethod.Location = new Point(126, 294);
        cmbVoteMethod.Name = "cmbVoteMethod";
        cmbVoteMethod.Size = new Size(319, 23);
        cmbVoteMethod.TabIndex = 7;
        // 
        // lblVoteMethod
        // 
        lblVoteMethod.AutoSize = true;
        lblVoteMethod.Location = new Point(11, 297);
        lblVoteMethod.Name = "lblVoteMethod";
        lblVoteMethod.Size = new Size(75, 15);
        lblVoteMethod.TabIndex = 0;
        lblVoteMethod.Text = "Vote Method";
        // 
        // txtEmail
        // 
        txtEmail.Location = new Point(126, 150);
        txtEmail.Name = "txtEmail";
        txtEmail.Size = new Size(319, 23);
        txtEmail.TabIndex = 2;
        // 
        // lblEmail
        // 
        lblEmail.AutoSize = true;
        lblEmail.Location = new Point(11, 150);
        lblEmail.Name = "lblEmail";
        lblEmail.Size = new Size(81, 15);
        lblEmail.TabIndex = 0;
        lblEmail.Text = "Email Address";
        // 
        // txtPassword
        // 
        txtPassword.Location = new Point(126, 176);
        txtPassword.Name = "txtPassword";
        txtPassword.Size = new Size(319, 23);
        txtPassword.TabIndex = 3;
        // 
        // lblPassword
        // 
        lblPassword.AutoSize = true;
        lblPassword.Location = new Point(11, 176);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(57, 15);
        lblPassword.TabIndex = 0;
        lblPassword.Text = "Password";
        // 
        // btnCancel
        // 
        btnCancel.Location = new Point(57, 347);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(179, 23);
        btnCancel.TabIndex = 9;
        btnCancel.Text = "Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        // 
        // lblEn
        // 
        lblEn.AutoSize = true;
        lblEn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblEn.Location = new Point(3, 9);
        lblEn.Name = "lblEn";
        lblEn.Size = new Size(22, 15);
        lblEn.TabIndex = 0;
        lblEn.Text = "EN";
        lblEn.Click += lblEn_Click;
        // 
        // lblFr
        // 
        lblFr.AutoSize = true;
        lblFr.Location = new Point(31, 9);
        lblFr.Name = "lblFr";
        lblFr.Size = new Size(20, 15);
        lblFr.TabIndex = 0;
        lblFr.Text = "FR";
        lblFr.Click += lblFr_Click;
        // 
        // frmCreateAccount
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(458, 387);
        Controls.Add(lblFr);
        Controls.Add(lblEn);
        Controls.Add(btnCancel);
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
        Controls.Add(lblDoB);
        Controls.Add(lblLastName);
        Controls.Add(lblFirstName);
        Name = "frmCreateAccount";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Votify | Create Account";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblFirstName;
    private Label lblLastName;
    private Label lblDoB;
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
    private Button btnCancel;
    private Label lblEn;
    private Label lblFr;
}