namespace VotifySystem.InPerson.Forms;

partial class frmPostalVote
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
        lblPostalVotes = new Label();
        cmbElection = new ComboBox();
        cmbCandidate = new ComboBox();
        lblSelectCandidate = new Label();
        lblSelectElection = new Label();
        lblSelectCountry = new Label();
        cmbCountry = new ComboBox();
        txtVotesToAdd = new TextBox();
        lblAddVotes = new Label();
        btnSubmit = new Button();
        btnReset = new Button();
        btnCancel = new Button();
        SuspendLayout();
        // 
        // lblPostalVotes
        // 
        lblPostalVotes.AutoSize = true;
        lblPostalVotes.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblPostalVotes.Location = new Point(93, 9);
        lblPostalVotes.Name = "lblPostalVotes";
        lblPostalVotes.Size = new Size(329, 47);
        lblPostalVotes.TabIndex = 0;
        lblPostalVotes.Text = "Submit Postal Votes";
        // 
        // cmbElection
        // 
        cmbElection.Enabled = false;
        cmbElection.FormattingEnabled = true;
        cmbElection.Location = new Point(66, 144);
        cmbElection.Name = "cmbElection";
        cmbElection.Size = new Size(371, 23);
        cmbElection.TabIndex = 2;
        cmbElection.SelectedIndexChanged += cmbElection_SelectedIndexChanged;
        // 
        // cmbCandidate
        // 
        cmbCandidate.Enabled = false;
        cmbCandidate.FormattingEnabled = true;
        cmbCandidate.Location = new Point(66, 203);
        cmbCandidate.Name = "cmbCandidate";
        cmbCandidate.Size = new Size(371, 23);
        cmbCandidate.TabIndex = 3;
        // 
        // lblSelectCandidate
        // 
        lblSelectCandidate.AutoSize = true;
        lblSelectCandidate.Location = new Point(66, 185);
        lblSelectCandidate.Name = "lblSelectCandidate";
        lblSelectCandidate.Size = new Size(98, 15);
        lblSelectCandidate.TabIndex = 3;
        lblSelectCandidate.Text = "Select Candidate:";
        // 
        // lblSelectElection
        // 
        lblSelectElection.AutoSize = true;
        lblSelectElection.Location = new Point(66, 126);
        lblSelectElection.Name = "lblSelectElection";
        lblSelectElection.Size = new Size(86, 15);
        lblSelectElection.TabIndex = 4;
        lblSelectElection.Text = "Select Election:";
        // 
        // lblSelectCountry
        // 
        lblSelectCountry.AutoSize = true;
        lblSelectCountry.Location = new Point(69, 70);
        lblSelectCountry.Name = "lblSelectCountry";
        lblSelectCountry.Size = new Size(87, 15);
        lblSelectCountry.TabIndex = 5;
        lblSelectCountry.Text = "Select Country:";
        // 
        // cmbCountry
        // 
        cmbCountry.FormattingEnabled = true;
        cmbCountry.Location = new Point(66, 88);
        cmbCountry.Name = "cmbCountry";
        cmbCountry.Size = new Size(371, 23);
        cmbCountry.TabIndex = 1;
        cmbCountry.SelectedIndexChanged += cmbCountry_SelectedIndexChanged;
        // 
        // txtVotesToAdd
        // 
        txtVotesToAdd.Enabled = false;
        txtVotesToAdd.Location = new Point(66, 272);
        txtVotesToAdd.Name = "txtVotesToAdd";
        txtVotesToAdd.Size = new Size(371, 23);
        txtVotesToAdd.TabIndex = 6;
        // 
        // lblAddVotes
        // 
        lblAddVotes.AutoSize = true;
        lblAddVotes.Location = new Point(69, 254);
        lblAddVotes.Name = "lblAddVotes";
        lblAddVotes.Size = new Size(140, 15);
        lblAddVotes.TabIndex = 7;
        lblAddVotes.Text = "Enter Postal Votes to add:";
        // 
        // btnSubmit
        // 
        btnSubmit.Location = new Point(362, 323);
        btnSubmit.Name = "btnSubmit";
        btnSubmit.Size = new Size(75, 23);
        btnSubmit.TabIndex = 8;
        btnSubmit.Text = "Submit";
        btnSubmit.UseVisualStyleBackColor = true;
        btnSubmit.Click += btnSubmit_Click;
        // 
        // btnReset
        // 
        btnReset.Location = new Point(264, 323);
        btnReset.Name = "btnReset";
        btnReset.Size = new Size(75, 23);
        btnReset.TabIndex = 9;
        btnReset.Text = "Reset Form";
        btnReset.UseVisualStyleBackColor = true;
        btnReset.Click += btnReset_Click;
        // 
        // btnCancel
        // 
        btnCancel.Location = new Point(69, 323);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(75, 23);
        btnCancel.TabIndex = 10;
        btnCancel.Text = "Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        // 
        // frmPostalVote
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(490, 378);
        Controls.Add(btnCancel);
        Controls.Add(btnReset);
        Controls.Add(btnSubmit);
        Controls.Add(lblAddVotes);
        Controls.Add(txtVotesToAdd);
        Controls.Add(cmbCountry);
        Controls.Add(lblSelectCountry);
        Controls.Add(lblSelectElection);
        Controls.Add(lblSelectCandidate);
        Controls.Add(cmbCandidate);
        Controls.Add(cmbElection);
        Controls.Add(lblPostalVotes);
        Name = "frmPostalVote";
        Text = "frmPostalVote";
        StartPosition = FormStartPosition.CenterScreen;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblPostalVotes;
    private ComboBox cmbElection;
    private ComboBox cmbCandidate;
    private Label lblSelectCandidate;
    private Label lblSelectElection;
    private Label lblSelectCountry;
    private ComboBox cmbCountry;
    private TextBox txtVotesToAdd;
    private Label lblAddVotes;
    private Button btnSubmit;
    private Button btnReset;
    private Button btnCancel;
}