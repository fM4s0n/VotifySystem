namespace VotifySystem.InPerson.Forms;

partial class frmRegisterForElection
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
        cmbElections = new ComboBox();
        lblSelectElection = new Label();
        cmbConstituencies = new ComboBox();
        lblSelectConstituency = new Label();
        lblRegisterForElection = new Label();
        btnRegister = new Button();
        btnCancel = new Button();
        SuspendLayout();
        // 
        // cmbElections
        // 
        cmbElections.FormattingEnabled = true;
        cmbElections.Location = new Point(156, 95);
        cmbElections.Name = "cmbElections";
        cmbElections.Size = new Size(287, 23);
        cmbElections.TabIndex = 0;
        // 
        // lblSelectElection
        // 
        lblSelectElection.AutoSize = true;
        lblSelectElection.Location = new Point(36, 98);
        lblSelectElection.Name = "lblSelectElection";
        lblSelectElection.Size = new Size(86, 15);
        lblSelectElection.TabIndex = 1;
        lblSelectElection.Text = "Select Election:";
        // 
        // cmbConstituencies
        // 
        cmbConstituencies.FormattingEnabled = true;
        cmbConstituencies.Location = new Point(156, 138);
        cmbConstituencies.Name = "cmbConstituencies";
        cmbConstituencies.Size = new Size(287, 23);
        cmbConstituencies.TabIndex = 2;
        // 
        // lblSelectConstituency
        // 
        lblSelectConstituency.AutoSize = true;
        lblSelectConstituency.Location = new Point(36, 141);
        lblSelectConstituency.Name = "lblSelectConstituency";
        lblSelectConstituency.Size = new Size(114, 15);
        lblSelectConstituency.TabIndex = 3;
        lblSelectConstituency.Text = "Select Constituency:";
        // 
        // lblRegisterForElection
        // 
        lblRegisterForElection.AutoSize = true;
        lblRegisterForElection.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblRegisterForElection.Location = new Point(95, 18);
        lblRegisterForElection.Name = "lblRegisterForElection";
        lblRegisterForElection.Size = new Size(289, 37);
        lblRegisterForElection.TabIndex = 4;
        lblRegisterForElection.Text = "Register for an Election";
        // 
        // btnRegister
        // 
        btnRegister.Location = new Point(391, 219);
        btnRegister.Name = "btnRegister";
        btnRegister.Size = new Size(75, 23);
        btnRegister.TabIndex = 5;
        btnRegister.Text = "Register";
        btnRegister.UseVisualStyleBackColor = true;
        btnRegister.Click += btnRegister_Click;
        // 
        // btnCancel
        // 
        btnCancel.Location = new Point(12, 219);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(75, 23);
        btnCancel.TabIndex = 6;
        btnCancel.Text = "Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        // 
        // frmRegisterForElection
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(478, 254);
        Controls.Add(btnCancel);
        Controls.Add(btnRegister);
        Controls.Add(lblRegisterForElection);
        Controls.Add(lblSelectConstituency);
        Controls.Add(cmbConstituencies);
        Controls.Add(lblSelectElection);
        Controls.Add(cmbElections);
        Name = "frmRegisterForElection";
        Text = "frmRegisterForElection";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private ComboBox cmbElections;
    private Label lblSelectElection;
    private ComboBox cmbConstituencies;
    private Label lblSelectConstituency;
    private Label lblRegisterForElection;
    private Button btnRegister;
    private Button btnCancel;
}