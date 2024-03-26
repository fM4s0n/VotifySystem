using System.Windows.Forms;

namespace VotifySystem.Forms;

partial class frmCreateElection
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
        btnCreate = new Button();
        btnCancel = new Button();
        lvCandidates = new ListView();
        lblCandidates = new Label();
        lblElectionTitle = new Label();
        txtElectionName = new TextBox();
        grpElectionDates = new GroupBox();
        lblElectionEnd = new Label();
        lblElectionStart = new Label();
        dtpElectionEnd = new DateTimePicker();
        dtpElectionStart = new DateTimePicker();
        lblAddConstituencies = new Label();
        lvConstituencies = new ListView();
        cmbVoteMechanism = new ComboBox();
        lblVoteMechanism = new Label();
        label1 = new Label();
        grpConstituencies = new GroupBox();
        btnAddConstituency = new Button();
        lblConstituencies = new Label();
        txtConstituencyName = new TextBox();
        cmbCountry = new ComboBox();
        lblCountry = new Label();
        grpCandidates = new GroupBox();
        cmbAddCandidate = new Button();
        cmbParty = new ComboBox();
        lblParty = new Label();
        cmbCandidateConstituency = new ComboBox();
        lblCandidateConstituency = new Label();
        txtCandidateName = new TextBox();
        lblCandidateName = new Label();
        grpElectionDates.SuspendLayout();
        grpConstituencies.SuspendLayout();
        grpCandidates.SuspendLayout();
        SuspendLayout();
        // 
        // btnCreate
        // 
        btnCreate.Location = new Point(981, 832);
        btnCreate.Margin = new Padding(3, 2, 3, 2);
        btnCreate.Name = "btnCreate";
        btnCreate.Size = new Size(82, 22);
        btnCreate.TabIndex = 0;
        btnCreate.Text = "Create";
        btnCreate.UseVisualStyleBackColor = true;
        btnCreate.Click += btnCreate_Click;
        // 
        // btnCancel
        // 
        btnCancel.Location = new Point(848, 832);
        btnCancel.Margin = new Padding(3, 2, 3, 2);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(82, 22);
        btnCancel.TabIndex = 1;
        btnCancel.Text = "Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        // 
        // lvCandidates
        // 
        lvCandidates.Location = new Point(11, 218);
        lvCandidates.Margin = new Padding(3, 2, 3, 2);
        lvCandidates.Name = "lvCandidates";
        lvCandidates.Size = new Size(470, 315);
        lvCandidates.TabIndex = 2;
        lvCandidates.UseCompatibleStateImageBehavior = false;
        // 
        // lblCandidates
        // 
        lblCandidates.AutoSize = true;
        lblCandidates.Location = new Point(11, 201);
        lblCandidates.Name = "lblCandidates";
        lblCandidates.Size = new Size(69, 15);
        lblCandidates.TabIndex = 3;
        lblCandidates.Text = "Candidates:";
        // 
        // lblElectionTitle
        // 
        lblElectionTitle.AutoSize = true;
        lblElectionTitle.Location = new Point(59, 114);
        lblElectionTitle.Name = "lblElectionTitle";
        lblElectionTitle.Size = new Size(77, 15);
        lblElectionTitle.TabIndex = 4;
        lblElectionTitle.Text = "Election Title:";
        // 
        // txtElectionName
        // 
        txtElectionName.Location = new Point(59, 131);
        txtElectionName.Margin = new Padding(3, 2, 3, 2);
        txtElectionName.Name = "txtElectionName";
        txtElectionName.Size = new Size(397, 23);
        txtElectionName.TabIndex = 5;
        // 
        // grpElectionDates
        // 
        grpElectionDates.Controls.Add(lblElectionEnd);
        grpElectionDates.Controls.Add(lblElectionStart);
        grpElectionDates.Controls.Add(dtpElectionEnd);
        grpElectionDates.Controls.Add(dtpElectionStart);
        grpElectionDates.Location = new Point(564, 114);
        grpElectionDates.Margin = new Padding(3, 2, 3, 2);
        grpElectionDates.Name = "grpElectionDates";
        grpElectionDates.Padding = new Padding(3, 2, 3, 2);
        grpElectionDates.Size = new Size(482, 79);
        grpElectionDates.TabIndex = 6;
        grpElectionDates.TabStop = false;
        grpElectionDates.Text = "Election Date:";
        // 
        // lblElectionEnd
        // 
        lblElectionEnd.AutoSize = true;
        lblElectionEnd.Location = new Point(5, 58);
        lblElectionEnd.Name = "lblElectionEnd";
        lblElectionEnd.Size = new Size(75, 15);
        lblElectionEnd.TabIndex = 3;
        lblElectionEnd.Text = "Election end:";
        // 
        // lblElectionStart
        // 
        lblElectionStart.AutoSize = true;
        lblElectionStart.Location = new Point(5, 25);
        lblElectionStart.Name = "lblElectionStart";
        lblElectionStart.Size = new Size(78, 15);
        lblElectionStart.TabIndex = 2;
        lblElectionStart.Text = "Election start:";
        // 
        // dtpElectionEnd
        // 
        dtpElectionEnd.CustomFormat = "dd/MM/yyyy hh:mm:ss";
        dtpElectionEnd.Format = DateTimePickerFormat.Custom;
        dtpElectionEnd.Location = new Point(120, 52);
        dtpElectionEnd.Margin = new Padding(3, 2, 3, 2);
        dtpElectionEnd.Name = "dtpElectionEnd";
        dtpElectionEnd.Size = new Size(350, 23);
        dtpElectionEnd.TabIndex = 1;
        // 
        // dtpElectionStart
        // 
        dtpElectionStart.Format = DateTimePickerFormat.Custom;
        dtpElectionStart.CustomFormat = "dd/MM/yyyy hh:mm:ss";
        dtpElectionStart.Location = new Point(120, 20);
        dtpElectionStart.Margin = new Padding(3, 2, 3, 2);
        dtpElectionStart.Name = "dtpElectionStart";
        dtpElectionStart.Size = new Size(350, 23);
        dtpElectionStart.TabIndex = 0;
        // 
        // lblAddConstituencies
        // 
        lblAddConstituencies.AutoSize = true;
        lblAddConstituencies.Location = new Point(6, 25);
        lblAddConstituencies.Name = "lblAddConstituencies";
        lblAddConstituencies.Size = new Size(113, 15);
        lblAddConstituencies.TabIndex = 7;
        lblAddConstituencies.Text = "Add Constituencies:";
        // 
        // lvConstituencies
        // 
        lvConstituencies.Location = new Point(5, 126);
        lvConstituencies.Margin = new Padding(3, 2, 3, 2);
        lvConstituencies.Name = "lvConstituencies";
        lvConstituencies.Size = new Size(470, 358);
        lvConstituencies.TabIndex = 8;
        lvConstituencies.UseCompatibleStateImageBehavior = false;
        // 
        // cmbVoteMechanism
        // 
        cmbVoteMechanism.FormattingEnabled = true;
        cmbVoteMechanism.Location = new Point(59, 229);
        cmbVoteMechanism.Margin = new Padding(3, 2, 3, 2);
        cmbVoteMechanism.Name = "cmbVoteMechanism";
        cmbVoteMechanism.Size = new Size(397, 23);
        cmbVoteMechanism.TabIndex = 9;
        cmbVoteMechanism.SelectedIndexChanged += cmbVoteMechanism_SelectedIndexChanged;
        // 
        // lblVoteMechanism
        // 
        lblVoteMechanism.AutoSize = true;
        lblVoteMechanism.Location = new Point(59, 212);
        lblVoteMechanism.Name = "lblVoteMechanism";
        lblVoteMechanism.Size = new Size(143, 15);
        lblVoteMechanism.TabIndex = 10;
        lblVoteMechanism.Text = "Select Voting Mechanism:";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        label1.Location = new Point(344, 9);
        label1.Name = "label1";
        label1.Size = new Size(344, 50);
        label1.TabIndex = 11;
        label1.Text = "Create new election";
        // 
        // grpConstituencies
        // 
        grpConstituencies.Controls.Add(btnAddConstituency);
        grpConstituencies.Controls.Add(lblConstituencies);
        grpConstituencies.Controls.Add(txtConstituencyName);
        grpConstituencies.Controls.Add(lblAddConstituencies);
        grpConstituencies.Controls.Add(lvConstituencies);
        grpConstituencies.Location = new Point(59, 278);
        grpConstituencies.Name = "grpConstituencies";
        grpConstituencies.Size = new Size(482, 495);
        grpConstituencies.TabIndex = 12;
        grpConstituencies.TabStop = false;
        grpConstituencies.Text = "Constituencies";
        // 
        // btnAddConstituency
        // 
        btnAddConstituency.Location = new Point(344, 79);
        btnAddConstituency.Name = "btnAddConstituency";
        btnAddConstituency.Size = new Size(131, 23);
        btnAddConstituency.TabIndex = 11;
        btnAddConstituency.Text = "Add Constituency";
        btnAddConstituency.UseVisualStyleBackColor = true;
        btnAddConstituency.Click += btnAddConstituency_Click;
        // 
        // lblConstituencies
        // 
        lblConstituencies.AutoSize = true;
        lblConstituencies.Location = new Point(6, 109);
        lblConstituencies.Name = "lblConstituencies";
        lblConstituencies.Size = new Size(85, 15);
        lblConstituencies.TabIndex = 10;
        lblConstituencies.Text = "Constituencies";
        // 
        // txtConstituencyName
        // 
        txtConstituencyName.Location = new Point(6, 43);
        txtConstituencyName.Name = "txtConstituencyName";
        txtConstituencyName.Size = new Size(469, 23);
        txtConstituencyName.TabIndex = 9;
        // 
        // cmbCountry
        // 
        cmbCountry.FormattingEnabled = true;
        cmbCountry.Location = new Point(59, 182);
        cmbCountry.Name = "cmbCountry";
        cmbCountry.Size = new Size(397, 23);
        cmbCountry.TabIndex = 13;
        // 
        // lblCountry
        // 
        lblCountry.AutoSize = true;
        lblCountry.Location = new Point(59, 164);
        lblCountry.Name = "lblCountry";
        lblCountry.Size = new Size(50, 15);
        lblCountry.TabIndex = 14;
        lblCountry.Text = "Country";
        // 
        // grpCandidates
        // 
        grpCandidates.Controls.Add(cmbAddCandidate);
        grpCandidates.Controls.Add(cmbParty);
        grpCandidates.Controls.Add(lblParty);
        grpCandidates.Controls.Add(cmbCandidateConstituency);
        grpCandidates.Controls.Add(lblCandidateConstituency);
        grpCandidates.Controls.Add(txtCandidateName);
        grpCandidates.Controls.Add(lblCandidateName);
        grpCandidates.Controls.Add(lblCandidates);
        grpCandidates.Controls.Add(lvCandidates);
        grpCandidates.Location = new Point(564, 229);
        grpCandidates.Name = "grpCandidates";
        grpCandidates.Size = new Size(482, 544);
        grpCandidates.TabIndex = 15;
        grpCandidates.TabStop = false;
        grpCandidates.Text = "Add Candidates";
        // 
        // cmbAddCandidate
        // 
        cmbAddCandidate.Location = new Point(350, 190);
        cmbAddCandidate.Name = "cmbAddCandidate";
        cmbAddCandidate.Size = new Size(126, 23);
        cmbAddCandidate.TabIndex = 12;
        cmbAddCandidate.Text = "Add Candidate";
        cmbAddCandidate.UseVisualStyleBackColor = true;
        cmbAddCandidate.Click += cmbAddCandidate_Click;
        // 
        // cmbParty
        // 
        cmbParty.FormattingEnabled = true;
        cmbParty.Location = new Point(6, 152);
        cmbParty.Name = "cmbParty";
        cmbParty.Size = new Size(465, 23);
        cmbParty.TabIndex = 9;
        // 
        // lblParty
        // 
        lblParty.AutoSize = true;
        lblParty.Location = new Point(11, 134);
        lblParty.Name = "lblParty";
        lblParty.Size = new Size(71, 15);
        lblParty.TabIndex = 8;
        lblParty.Text = "Select Party:";
        // 
        // cmbCandidateConstituency
        // 
        cmbCandidateConstituency.FormattingEnabled = true;
        cmbCandidateConstituency.Location = new Point(6, 92);
        cmbCandidateConstituency.Name = "cmbCandidateConstituency";
        cmbCandidateConstituency.Size = new Size(465, 23);
        cmbCandidateConstituency.TabIndex = 7;
        // 
        // lblCandidateConstituency
        // 
        lblCandidateConstituency.AutoSize = true;
        lblCandidateConstituency.Location = new Point(11, 70);
        lblCandidateConstituency.Name = "lblCandidateConstituency";
        lblCandidateConstituency.Size = new Size(168, 15);
        lblCandidateConstituency.TabIndex = 6;
        lblCandidateConstituency.Text = "Select Candidate Constituency";
        // 
        // txtCandidateName
        // 
        txtCandidateName.Location = new Point(6, 37);
        txtCandidateName.Name = "txtCandidateName";
        txtCandidateName.Size = new Size(465, 23);
        txtCandidateName.TabIndex = 5;
        // 
        // lblCandidateName
        // 
        lblCandidateName.AutoSize = true;
        lblCandidateName.Location = new Point(6, 19);
        lblCandidateName.Name = "lblCandidateName";
        lblCandidateName.Size = new Size(99, 15);
        lblCandidateName.TabIndex = 4;
        lblCandidateName.Text = "Candidate Name:";
        // 
        // frmCreateElection
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1080, 865);
        Controls.Add(grpCandidates);
        Controls.Add(lblCountry);
        Controls.Add(cmbCountry);
        Controls.Add(grpConstituencies);
        Controls.Add(label1);
        Controls.Add(lblVoteMechanism);
        Controls.Add(cmbVoteMechanism);
        Controls.Add(grpElectionDates);
        Controls.Add(txtElectionName);
        Controls.Add(lblElectionTitle);
        Controls.Add(btnCancel);
        Controls.Add(btnCreate);
        Margin = new Padding(3, 2, 3, 2);
        Name = "frmCreateElection";
        Text = "FrmCreateElection";
        grpElectionDates.ResumeLayout(false);
        grpElectionDates.PerformLayout();
        grpConstituencies.ResumeLayout(false);
        grpConstituencies.PerformLayout();
        grpCandidates.ResumeLayout(false);
        grpCandidates.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button btnCreate;
    private Button btnCancel;
    private ListView lvCandidates;
    private Label lblCandidates;
    private Label lblElectionTitle;
    private TextBox txtElectionName;
    private GroupBox grpElectionDates;
    private Label lblElectionStart;
    private DateTimePicker dtpElectionEnd;
    private DateTimePicker dtpElectionStart;
    private Label lblElectionEnd;
    private Label lblAddConstituencies;
    private ListView lvConstituencies;
    private ComboBox cmbVoteMechanism;
    private Label lblVoteMechanism;
    private Label label1;
    private GroupBox grpConstituencies;
    private Button btnAddConstituency;
    private Label lblConstituencies;
    private TextBox txtConstituencyName;
    private ComboBox cmbCountry;
    private Label lblCountry;
    private GroupBox grpCandidates;
    private Label lblCandidateName;
    private TextBox txtCandidateName;
    private ComboBox cmbCandidateConstituency;
    private Label lblCandidateConstituency;
    private Label lblParty;
    private ComboBox cmbParty;
    private Button cmbAddCandidate;
}