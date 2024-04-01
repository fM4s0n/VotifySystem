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
        lblFirstName.Location = new Point(69, 133);
        lblFirstName.Name = "lblFirstName";
        lblFirstName.Size = new Size(67, 15);
        lblFirstName.TabIndex = 0;
        lblFirstName.Text = "First Name:";
        // 
        // lblLastName
        // 
        lblLastName.AutoSize = true;
        lblLastName.Location = new Point(69, 162);
        lblLastName.Name = "lblLastName";
        lblLastName.Size = new Size(64, 15);
        lblLastName.TabIndex = 1;
        lblLastName.Text = "Last name:";
        // 
        // lblDoB
        // 
        lblDoB.AutoSize = true;
        lblDoB.Location = new Point(64, 255);
        lblDoB.Name = "lblDoB";
        lblDoB.Size = new Size(73, 15);
        lblDoB.TabIndex = 2;
        lblDoB.Text = "Date of Birth";
        // 
        // lblCountry
        // 
        lblCountry.AutoSize = true;
        lblCountry.Location = new Point(83, 307);
        lblCountry.Name = "lblCountry";
        lblCountry.Size = new Size(50, 15);
        lblCountry.TabIndex = 3;
        lblCountry.Text = "Country";
        // 
        // dtpDoB
        // 
        dtpDoB.Location = new Point(143, 249);
        dtpDoB.Name = "dtpDoB";
        dtpDoB.Size = new Size(319, 23);
        dtpDoB.TabIndex = 5;
        // 
        // txtFirstName
        // 
        txtFirstName.Location = new Point(142, 130);
        txtFirstName.Name = "txtFirstName";
        txtFirstName.Size = new Size(319, 23);
        txtFirstName.TabIndex = 6;
        // 
        // txtLastName
        // 
        txtLastName.Location = new Point(142, 159);
        txtLastName.Name = "txtLastName";
        txtLastName.Size = new Size(319, 23);
        txtLastName.TabIndex = 7;
        // 
        // btnSubmit
        // 
        btnSubmit.Location = new Point(254, 542);
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
        cmbCountry.Location = new Point(142, 304);
        cmbCountry.Name = "cmbCountry";
        cmbCountry.Size = new Size(319, 23);
        cmbCountry.TabIndex = 9;
        // 
        // lblCreateAccount
        // 
        lblCreateAccount.AutoSize = true;
        lblCreateAccount.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblCreateAccount.Location = new Point(156, 35);
        lblCreateAccount.Name = "lblCreateAccount";
        lblCreateAccount.Size = new Size(293, 37);
        lblCreateAccount.TabIndex = 11;
        lblCreateAccount.Text = "Create a Votify Account";
        // 
        // lblAddress
        // 
        lblAddress.AutoSize = true;
        lblAddress.Location = new Point(85, 285);
        lblAddress.Name = "lblAddress";
        lblAddress.Size = new Size(49, 15);
        lblAddress.TabIndex = 12;
        lblAddress.Text = "Address";
        // 
        // txtAddress
        // 
        txtAddress.Location = new Point(143, 279);
        txtAddress.Name = "txtAddress";
        txtAddress.Size = new Size(319, 23);
        txtAddress.TabIndex = 14;
        // 
        // cmbVoteMethod
        // 
        cmbVoteMethod.FormattingEnabled = true;
        cmbVoteMethod.Location = new Point(142, 333);
        cmbVoteMethod.Name = "cmbVoteMethod";
        cmbVoteMethod.Size = new Size(319, 23);
        cmbVoteMethod.TabIndex = 16;
        // 
        // lblVoteMethod
        // 
        lblVoteMethod.AutoSize = true;
        lblVoteMethod.Location = new Point(60, 335);
        lblVoteMethod.Name = "lblVoteMethod";
        lblVoteMethod.Size = new Size(75, 15);
        lblVoteMethod.TabIndex = 17;
        lblVoteMethod.Text = "Vote Method";
        // 
        // txtEmail
        // 
        txtEmail.Location = new Point(142, 189);
        txtEmail.Name = "txtEmail";
        txtEmail.Size = new Size(319, 23);
        txtEmail.TabIndex = 19;
        // 
        // lblEmail
        // 
        lblEmail.AutoSize = true;
        lblEmail.Location = new Point(69, 192);
        lblEmail.Name = "lblEmail";
        lblEmail.Size = new Size(81, 15);
        lblEmail.TabIndex = 18;
        lblEmail.Text = "Email Address";
        // 
        // txtPassword
        // 
        txtPassword.Location = new Point(142, 215);
        txtPassword.Name = "txtPassword";
        txtPassword.Size = new Size(319, 23);
        txtPassword.TabIndex = 21;
        // 
        // lblPassword
        // 
        lblPassword.AutoSize = true;
        lblPassword.Location = new Point(69, 219);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(57, 15);
        lblPassword.TabIndex = 20;
        lblPassword.Text = "Password";
        // 
        // btnCancel
        // 
        btnCancel.Location = new Point(69, 542);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(179, 23);
        btnCancel.TabIndex = 22;
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
        lblEn.TabIndex = 23;
        lblEn.Text = "EN";
        lblEn.Click += lblEn_Click;
        // 
        // lblFr
        // 
        lblFr.AutoSize = true;
        lblFr.Location = new Point(31, 9);
        lblFr.Name = "lblFr";
        lblFr.Size = new Size(20, 15);
        lblFr.TabIndex = 24;
        lblFr.Text = "FR";
        lblFr.Click += lblFr_Click;
        // 
        // frmCreateAccount
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(515, 597);
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
        Text = "frmCreateAccount";
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