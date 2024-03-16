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
        label1 = new Label();
        txtAddress = new TextBox();
        txtPostCode = new TextBox();
        cmbVoteMethod = new ComboBox();
        lblVoteMethod = new Label();
        SuspendLayout();
        // 
        // lblFirstName
        // 
        lblFirstName.AutoSize = true;
        lblFirstName.Location = new Point(69, 114);
        lblFirstName.Name = "lblFirstName";
        lblFirstName.Size = new Size(67, 15);
        lblFirstName.TabIndex = 0;
        lblFirstName.Text = "First Name:";
        // 
        // lblLastName
        // 
        lblLastName.AutoSize = true;
        lblLastName.Location = new Point(69, 143);
        lblLastName.Name = "lblLastName";
        lblLastName.Size = new Size(64, 15);
        lblLastName.TabIndex = 1;
        lblLastName.Text = "Last name:";
        // 
        // lblDateOfBirth
        // 
        lblDateOfBirth.AutoSize = true;
        lblDateOfBirth.Location = new Point(63, 175);
        lblDateOfBirth.Name = "lblDateOfBirth";
        lblDateOfBirth.Size = new Size(73, 15);
        lblDateOfBirth.TabIndex = 2;
        lblDateOfBirth.Text = "Date of Birth";
        // 
        // lblCountry
        // 
        lblCountry.AutoSize = true;
        lblCountry.Location = new Point(83, 260);
        lblCountry.Name = "lblCountry";
        lblCountry.Size = new Size(50, 15);
        lblCountry.TabIndex = 3;
        lblCountry.Text = "Country";
        // 
        // dtpDoB
        // 
        dtpDoB.Location = new Point(142, 169);
        dtpDoB.Name = "dtpDoB";
        dtpDoB.Size = new Size(319, 23);
        dtpDoB.TabIndex = 5;
        // 
        // txtFirstName
        // 
        txtFirstName.Location = new Point(142, 111);
        txtFirstName.Name = "txtFirstName";
        txtFirstName.Size = new Size(319, 23);
        txtFirstName.TabIndex = 6;
        // 
        // txtLastName
        // 
        txtLastName.Location = new Point(142, 140);
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
        cmbCountry.Location = new Point(142, 257);
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
        lblCreateAccount.Size = new Size(197, 37);
        lblCreateAccount.TabIndex = 11;
        lblCreateAccount.Text = "Create Account";
        // 
        // lblAddress
        // 
        lblAddress.AutoSize = true;
        lblAddress.Location = new Point(84, 204);
        lblAddress.Name = "lblAddress";
        lblAddress.Size = new Size(49, 15);
        lblAddress.TabIndex = 12;
        lblAddress.Text = "Address";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(72, 231);
        label1.Name = "label1";
        label1.Size = new Size(61, 15);
        label1.TabIndex = 13;
        label1.Text = "Post Code";
        // 
        // txtAddress
        // 
        txtAddress.Location = new Point(142, 198);
        txtAddress.Name = "txtAddress";
        txtAddress.Size = new Size(319, 23);
        txtAddress.TabIndex = 14;
        // 
        // txtPostCode
        // 
        txtPostCode.Location = new Point(142, 228);
        txtPostCode.Name = "txtPostCode";
        txtPostCode.Size = new Size(319, 23);
        txtPostCode.TabIndex = 15;
        // 
        // cmbVoteMethod
        // 
        cmbVoteMethod.FormattingEnabled = true;
        cmbVoteMethod.Location = new Point(142, 286);
        cmbVoteMethod.Name = "cmbVoteMethod";
        cmbVoteMethod.Size = new Size(319, 23);
        cmbVoteMethod.TabIndex = 16;
        // 
        // lblVoteMethod
        // 
        lblVoteMethod.AutoSize = true;
        lblVoteMethod.Location = new Point(60, 289);
        lblVoteMethod.Name = "lblVoteMethod";
        lblVoteMethod.Size = new Size(75, 15);
        lblVoteMethod.TabIndex = 17;
        lblVoteMethod.Text = "Vote Method";
        // 
        // frmCreateAccount
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(515, 597);
        Controls.Add(lblVoteMethod);
        Controls.Add(cmbVoteMethod);
        Controls.Add(txtPostCode);
        Controls.Add(txtAddress);
        Controls.Add(label1);
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
    private Label label1;
    private TextBox txtAddress;
    private TextBox txtPostCode;
    private ComboBox cmbVoteMethod;
    private Label lblVoteMethod;
}