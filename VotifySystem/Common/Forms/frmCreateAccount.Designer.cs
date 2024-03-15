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
        lblConstituency = new Label();
        dtpDoB = new DateTimePicker();
        txtFirstName = new TextBox();
        txtLastName = new TextBox();
        btnSubmit = new Button();
        cmbCountry = new ComboBox();
        cmbConstituency = new ComboBox();
        lblCreateAccount = new Label();
        lblAddress = new Label();
        label1 = new Label();
        txtAddress = new TextBox();
        txtpostCode = new TextBox();
        cmbVoteMethod = new ComboBox();
        lblVoteMethod = new Label();
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
        lblDateOfBirth.Location = new Point(72, 233);
        lblDateOfBirth.Name = "lblDateOfBirth";
        lblDateOfBirth.Size = new Size(94, 20);
        lblDateOfBirth.TabIndex = 2;
        lblDateOfBirth.Text = "Date of Birth";
        // 
        // lblCountry
        // 
        lblCountry.AutoSize = true;
        lblCountry.Location = new Point(95, 353);
        lblCountry.Name = "lblCountry";
        lblCountry.Size = new Size(60, 20);
        lblCountry.TabIndex = 3;
        lblCountry.Text = "Country";
        // 
        // lblConstituency
        // 
        lblConstituency.AutoSize = true;
        lblConstituency.Location = new Point(72, 385);
        lblConstituency.Name = "lblConstituency";
        lblConstituency.Size = new Size(93, 20);
        lblConstituency.TabIndex = 4;
        lblConstituency.Text = "Constituency";
        // 
        // dtpDoB
        // 
        dtpDoB.Location = new Point(162, 225);
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
        cmbCountry.Location = new Point(162, 343);
        cmbCountry.Margin = new Padding(3, 4, 3, 4);
        cmbCountry.Name = "cmbCountry";
        cmbCountry.Size = new Size(364, 28);
        cmbCountry.TabIndex = 9;
        // 
        // cmbConstituency
        // 
        cmbConstituency.Enabled = false;
        cmbConstituency.FormattingEnabled = true;
        cmbConstituency.Location = new Point(162, 381);
        cmbConstituency.Margin = new Padding(3, 4, 3, 4);
        cmbConstituency.Name = "cmbConstituency";
        cmbConstituency.Size = new Size(364, 28);
        cmbConstituency.TabIndex = 10;
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
        lblAddress.Location = new Point(96, 272);
        lblAddress.Name = "lblAddress";
        lblAddress.Size = new Size(62, 20);
        lblAddress.TabIndex = 12;
        lblAddress.Text = "Address";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(82, 308);
        label1.Name = "label1";
        label1.Size = new Size(75, 20);
        label1.TabIndex = 13;
        label1.Text = "Post Code";
        // 
        // txtAddress
        // 
        txtAddress.Location = new Point(162, 264);
        txtAddress.Margin = new Padding(3, 4, 3, 4);
        txtAddress.Name = "txtAddress";
        txtAddress.Size = new Size(364, 27);
        txtAddress.TabIndex = 14;
        // 
        // txtpostCode
        // 
        txtpostCode.Location = new Point(162, 304);
        txtpostCode.Margin = new Padding(3, 4, 3, 4);
        txtpostCode.Name = "txtpostCode";
        txtpostCode.Size = new Size(364, 27);
        txtpostCode.TabIndex = 15;
        // 
        // cmbVoteMethod
        // 
        cmbVoteMethod.Enabled = false;
        cmbVoteMethod.FormattingEnabled = true;
        cmbVoteMethod.Location = new Point(163, 417);
        cmbVoteMethod.Margin = new Padding(3, 4, 3, 4);
        cmbVoteMethod.Name = "cmbVoteMethod";
        cmbVoteMethod.Size = new Size(364, 28);
        cmbVoteMethod.TabIndex = 16;
        // 
        // lblVoteMethod
        // 
        lblVoteMethod.AutoSize = true;
        lblVoteMethod.Location = new Point(26, 459);
        lblVoteMethod.Name = "lblVoteMethod";
        lblVoteMethod.Size = new Size(95, 20);
        lblVoteMethod.TabIndex = 17;
        lblVoteMethod.Text = "Vote Method";
        // 
        // frmCreateAccount
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(589, 796);
        Controls.Add(lblVoteMethod);
        Controls.Add(cmbVoteMethod);
        Controls.Add(txtpostCode);
        Controls.Add(txtAddress);
        Controls.Add(label1);
        Controls.Add(lblAddress);
        Controls.Add(lblCreateAccount);
        Controls.Add(cmbConstituency);
        Controls.Add(cmbCountry);
        Controls.Add(btnSubmit);
        Controls.Add(txtLastName);
        Controls.Add(txtFirstName);
        Controls.Add(dtpDoB);
        Controls.Add(lblConstituency);
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
    private Label lblConstituency;
    private DateTimePicker dtpDoB;
    private TextBox txtFirstName;
    private TextBox txtLastName;
    private Button btnSubmit;
    private ComboBox cmbCountry;
    private ComboBox cmbConstituency;
    private Label lblCreateAccount;
    private Label lblAddress;
    private Label label1;
    private TextBox txtAddress;
    private TextBox txtpostCode;
    private ComboBox cmbVoteMethod;
    private Label lblVoteMethod;
}