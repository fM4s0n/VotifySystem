namespace VotifySystem.InPerson.Forms;

partial class frmRegisterToVote
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
        lblRegisterToVote = new Label();
        cmbElections = new ComboBox();
        lblSelectElection = new Label();
        btnRegister = new Button();
        lblSelectConstituency = new Label();
        cmbConstituencies = new ComboBox();
        SuspendLayout();
        // 
        // lblRegisterToVote
        // 
        lblRegisterToVote.AutoSize = true;
        lblRegisterToVote.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblRegisterToVote.Location = new Point(32, 9);
        lblRegisterToVote.Name = "lblRegisterToVote";
        lblRegisterToVote.Size = new Size(251, 45);
        lblRegisterToVote.TabIndex = 0;
        lblRegisterToVote.Text = "Register To Vote";
        // 
        // cmbElections
        // 
        cmbElections.FormattingEnabled = true;
        cmbElections.Location = new Point(32, 98);
        cmbElections.Name = "cmbElections";
        cmbElections.Size = new Size(265, 23);
        cmbElections.TabIndex = 1;
        cmbElections.SelectedIndexChanged += cmbElections_SelectedIndexChanged;
        // 
        // lblSelectElection
        // 
        lblSelectElection.AutoSize = true;
        lblSelectElection.Location = new Point(32, 80);
        lblSelectElection.Name = "lblSelectElection";
        lblSelectElection.Size = new Size(83, 15);
        lblSelectElection.TabIndex = 2;
        lblSelectElection.Text = "Select Election";
        // 
        // btnRegister
        // 
        btnRegister.Location = new Point(222, 185);
        btnRegister.Name = "btnRegister";
        btnRegister.Size = new Size(75, 23);
        btnRegister.TabIndex = 3;
        btnRegister.Text = "Register";
        btnRegister.UseVisualStyleBackColor = true;
        btnRegister.Click += btnRegister_Click;
        // 
        // lblSelectConstituency
        // 
        lblSelectConstituency.AutoSize = true;
        lblSelectConstituency.Location = new Point(32, 129);
        lblSelectConstituency.Name = "lblSelectConstituency";
        lblSelectConstituency.Size = new Size(136, 15);
        lblSelectConstituency.TabIndex = 4;
        lblSelectConstituency.Text = "Select your constituency";
        // 
        // cmbConstituencies
        // 
        cmbConstituencies.FormattingEnabled = true;
        cmbConstituencies.Location = new Point(32, 147);
        cmbConstituencies.Name = "cmbConstituencies";
        cmbConstituencies.Size = new Size(265, 23);
        cmbConstituencies.TabIndex = 5;
        // 
        // frmRegisterToVote
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(320, 231);
        Controls.Add(cmbConstituencies);
        Controls.Add(lblSelectConstituency);
        Controls.Add(btnRegister);
        Controls.Add(lblSelectElection);
        Controls.Add(cmbElections);
        Controls.Add(lblRegisterToVote);
        Name = "frmRegisterToVote";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Votify | Register To Vote";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblRegisterToVote;
    private ComboBox cmbElections;
    private Label lblSelectElection;
    private Button btnRegister;
    private Label lblSelectConstituency;
    private ComboBox cmbConstituencies;
}