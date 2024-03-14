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
        dateTimePicker1 = new DateTimePicker();
        textBox1 = new TextBox();
        textBox2 = new TextBox();
        btnSubmit = new Button();
        cmbCountry = new ComboBox();
        cmbConstituency = new ComboBox();
        lblCreateAccount = new Label();
        lblAddress = new Label();
        label1 = new Label();
        textBox3 = new TextBox();
        textBox4 = new TextBox();
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
        lblCountry.Location = new Point(83, 265);
        lblCountry.Name = "lblCountry";
        lblCountry.Size = new Size(50, 15);
        lblCountry.TabIndex = 3;
        lblCountry.Text = "Country";
        // 
        // lblConstituency
        // 
        lblConstituency.AutoSize = true;
        lblConstituency.Location = new Point(63, 289);
        lblConstituency.Name = "lblConstituency";
        lblConstituency.Size = new Size(77, 15);
        lblConstituency.TabIndex = 4;
        lblConstituency.Text = "Constituency";
        // 
        // dateTimePicker1
        // 
        dateTimePicker1.Location = new Point(142, 169);
        dateTimePicker1.Name = "dateTimePicker1";
        dateTimePicker1.Size = new Size(319, 23);
        dateTimePicker1.TabIndex = 5;
        // 
        // textBox1
        // 
        textBox1.Location = new Point(142, 111);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(319, 23);
        textBox1.TabIndex = 6;
        // 
        // textBox2
        // 
        textBox2.Location = new Point(142, 140);
        textBox2.Name = "textBox2";
        textBox2.Size = new Size(319, 23);
        textBox2.TabIndex = 7;
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
        // cmbConstituency
        // 
        cmbConstituency.Enabled = false;
        cmbConstituency.FormattingEnabled = true;
        cmbConstituency.Location = new Point(142, 286);
        cmbConstituency.Name = "cmbConstituency";
        cmbConstituency.Size = new Size(319, 23);
        cmbConstituency.TabIndex = 10;
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
        // textBox3
        // 
        textBox3.Location = new Point(142, 198);
        textBox3.Name = "textBox3";
        textBox3.Size = new Size(319, 23);
        textBox3.TabIndex = 14;
        // 
        // textBox4
        // 
        textBox4.Location = new Point(142, 228);
        textBox4.Name = "textBox4";
        textBox4.Size = new Size(319, 23);
        textBox4.TabIndex = 15;
        // 
        // frmCreateAccount
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(515, 597);
        Controls.Add(textBox4);
        Controls.Add(textBox3);
        Controls.Add(label1);
        Controls.Add(lblAddress);
        Controls.Add(lblCreateAccount);
        Controls.Add(cmbConstituency);
        Controls.Add(cmbCountry);
        Controls.Add(btnSubmit);
        Controls.Add(textBox2);
        Controls.Add(textBox1);
        Controls.Add(dateTimePicker1);
        Controls.Add(lblConstituency);
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
    private Label lblConstituency;
    private DateTimePicker dateTimePicker1;
    private TextBox textBox1;
    private TextBox textBox2;
    private Button btnSubmit;
    private ComboBox cmbCountry;
    private ComboBox cmbConstituency;
    private Label lblCreateAccount;
    private Label lblAddress;
    private Label label1;
    private TextBox textBox3;
    private TextBox textBox4;
}