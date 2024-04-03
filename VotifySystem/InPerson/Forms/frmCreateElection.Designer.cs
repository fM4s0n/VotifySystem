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
        lblFormTitle = new Label();
        grpConstituencies = new GroupBox();
        btnRemoveConstituency = new Button();
        btnAddConstituency = new Button();
        lblConstituencies = new Label();
        txtConstituencyName = new TextBox();
        cmbCountry = new ComboBox();
        lblCountry = new Label();
        grpCandidates = new GroupBox();
        txtCandidateLastName = new TextBox();
        lblCandidateLastName = new Label();
        btnRemoveCandidate = new Button();
        btnAddCandidate = new Button();
        cmbCandidateParty = new ComboBox();
        lblParty = new Label();
        cmbCandidateConstituency = new ComboBox();
        lblCandidateConstituency = new Label();
        txtCandidateFirstName = new TextBox();
        lblCandidateFirstName = new Label();
        btnReset = new Button();
        grpElectionDetails = new GroupBox();
        btnInitialiseElection = new Button();
        grpElectionDates.SuspendLayout();
        grpConstituencies.SuspendLayout();
        grpCandidates.SuspendLayout();
        grpElectionDetails.SuspendLayout();
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
        btnCancel.Location = new Point(812, 832);
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
        lvCandidates.Enabled = false;
        lvCandidates.GridLines = true;
        lvCandidates.Location = new Point(11, 253);
        lvCandidates.Margin = new Padding(3, 2, 3, 2);
        lvCandidates.MultiSelect = false;
        lvCandidates.Name = "lvCandidates";
        lvCandidates.Size = new Size(460, 354);
        lvCandidates.TabIndex = 2;
        lvCandidates.UseCompatibleStateImageBehavior = false;
        // 
        // lblCandidates
        // 
        lblCandidates.AutoSize = true;
        lblCandidates.Location = new Point(10, 236);
        lblCandidates.Name = "lblCandidates";
        lblCandidates.Size = new Size(69, 15);
        lblCandidates.TabIndex = 3;
        lblCandidates.Text = "Candidates:";
        // 
        // lblElectionTitle
        // 
        lblElectionTitle.AutoSize = true;
        lblElectionTitle.Location = new Point(6, 20);
        lblElectionTitle.Name = "lblElectionTitle";
        lblElectionTitle.Size = new Size(77, 15);
        lblElectionTitle.TabIndex = 4;
        lblElectionTitle.Text = "Election Title:";
        // 
        // txtElectionName
        // 
        txtElectionName.Location = new Point(6, 37);
        txtElectionName.Margin = new Padding(3, 2, 3, 2);
        txtElectionName.Name = "txtElectionName";
        txtElectionName.Size = new Size(470, 23);
        txtElectionName.TabIndex = 1;
        // 
        // grpElectionDates
        // 
        grpElectionDates.Controls.Add(lblElectionEnd);
        grpElectionDates.Controls.Add(lblElectionStart);
        grpElectionDates.Controls.Add(dtpElectionEnd);
        grpElectionDates.Controls.Add(dtpElectionStart);
        grpElectionDates.Location = new Point(564, 62);
        grpElectionDates.Margin = new Padding(3, 2, 3, 2);
        grpElectionDates.Name = "grpElectionDates";
        grpElectionDates.Padding = new Padding(3, 2, 3, 2);
        grpElectionDates.Size = new Size(482, 92);
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
        dtpElectionEnd.CustomFormat = "dd/MM/yyyy HH:mm:ss";
        dtpElectionEnd.Format = DateTimePickerFormat.Custom;
        dtpElectionEnd.Location = new Point(120, 52);
        dtpElectionEnd.Margin = new Padding(3, 2, 3, 2);
        dtpElectionEnd.Name = "dtpElectionEnd";
        dtpElectionEnd.Size = new Size(350, 23);
        dtpElectionEnd.TabIndex = 6;
        // 
        // dtpElectionStart
        // 
        dtpElectionStart.CustomFormat = "dd/MM/yyyy HH:mm:ss";
        dtpElectionStart.Format = DateTimePickerFormat.Custom;
        dtpElectionStart.Location = new Point(120, 20);
        dtpElectionStart.Margin = new Padding(3, 2, 3, 2);
        dtpElectionStart.Name = "dtpElectionStart";
        dtpElectionStart.Size = new Size(350, 23);
        dtpElectionStart.TabIndex = 5;
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
        lvConstituencies.Enabled = false;
        lvConstituencies.GridLines = true;
        lvConstituencies.Location = new Point(5, 119);
        lvConstituencies.Margin = new Padding(3, 2, 3, 2);
        lvConstituencies.MultiSelect = false;
        lvConstituencies.Name = "lvConstituencies";
        lvConstituencies.Size = new Size(470, 401);
        lvConstituencies.TabIndex = 8;
        lvConstituencies.UseCompatibleStateImageBehavior = false;
        // 
        // cmbVoteMechanism
        // 
        cmbVoteMechanism.FormattingEnabled = true;
        cmbVoteMechanism.Location = new Point(6, 134);
        cmbVoteMechanism.Margin = new Padding(3, 2, 3, 2);
        cmbVoteMechanism.Name = "cmbVoteMechanism";
        cmbVoteMechanism.Size = new Size(470, 23);
        cmbVoteMechanism.TabIndex = 3;
        cmbVoteMechanism.SelectedIndexChanged += cmbVoteMechanism_SelectedIndexChanged;
        // 
        // lblVoteMechanism
        // 
        lblVoteMechanism.AutoSize = true;
        lblVoteMechanism.Location = new Point(6, 117);
        lblVoteMechanism.Name = "lblVoteMechanism";
        lblVoteMechanism.Size = new Size(143, 15);
        lblVoteMechanism.TabIndex = 10;
        lblVoteMechanism.Text = "Select Voting Mechanism:";
        // 
        // lblFormTitle
        // 
        lblFormTitle.AutoSize = true;
        lblFormTitle.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblFormTitle.Location = new Point(344, 9);
        lblFormTitle.Name = "lblFormTitle";
        lblFormTitle.Size = new Size(344, 50);
        lblFormTitle.TabIndex = 11;
        lblFormTitle.Text = "Create new election";
        // 
        // grpConstituencies
        // 
        grpConstituencies.Controls.Add(btnRemoveConstituency);
        grpConstituencies.Controls.Add(btnAddConstituency);
        grpConstituencies.Controls.Add(lblConstituencies);
        grpConstituencies.Controls.Add(txtConstituencyName);
        grpConstituencies.Controls.Add(lblAddConstituencies);
        grpConstituencies.Controls.Add(lvConstituencies);
        grpConstituencies.Location = new Point(59, 255);
        grpConstituencies.Name = "grpConstituencies";
        grpConstituencies.Size = new Size(482, 554);
        grpConstituencies.TabIndex = 12;
        grpConstituencies.TabStop = false;
        grpConstituencies.Text = "Constituencies";
        // 
        // btnRemoveConstituency
        // 
        btnRemoveConstituency.Enabled = false;
        btnRemoveConstituency.Location = new Point(295, 525);
        btnRemoveConstituency.Name = "btnRemoveConstituency";
        btnRemoveConstituency.Size = new Size(180, 23);
        btnRemoveConstituency.TabIndex = 12;
        btnRemoveConstituency.Text = "Remove Selected Constituency";
        btnRemoveConstituency.UseVisualStyleBackColor = true;
        btnRemoveConstituency.Click += btnRemoveConstituency_Click;
        // 
        // btnAddConstituency
        // 
        btnAddConstituency.Enabled = false;
        btnAddConstituency.Location = new Point(344, 72);
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
        lblConstituencies.Location = new Point(6, 102);
        lblConstituencies.Name = "lblConstituencies";
        lblConstituencies.Size = new Size(85, 15);
        lblConstituencies.TabIndex = 10;
        lblConstituencies.Text = "Constituencies";
        // 
        // txtConstituencyName
        // 
        txtConstituencyName.Enabled = false;
        txtConstituencyName.Location = new Point(6, 43);
        txtConstituencyName.Name = "txtConstituencyName";
        txtConstituencyName.Size = new Size(469, 23);
        txtConstituencyName.TabIndex = 4;
        // 
        // cmbCountry
        // 
        cmbCountry.FormattingEnabled = true;
        cmbCountry.Location = new Point(6, 87);
        cmbCountry.Name = "cmbCountry";
        cmbCountry.Size = new Size(470, 23);
        cmbCountry.TabIndex = 2;
        cmbCountry.SelectedIndexChanged += cmbCountry_SelectedIndexChanged;
        // 
        // lblCountry
        // 
        lblCountry.AutoSize = true;
        lblCountry.Location = new Point(6, 69);
        lblCountry.Name = "lblCountry";
        lblCountry.Size = new Size(50, 15);
        lblCountry.TabIndex = 14;
        lblCountry.Text = "Country";
        // 
        // grpCandidates
        // 
        grpCandidates.Controls.Add(txtCandidateLastName);
        grpCandidates.Controls.Add(lblCandidateLastName);
        grpCandidates.Controls.Add(btnRemoveCandidate);
        grpCandidates.Controls.Add(btnAddCandidate);
        grpCandidates.Controls.Add(cmbCandidateParty);
        grpCandidates.Controls.Add(lblParty);
        grpCandidates.Controls.Add(cmbCandidateConstituency);
        grpCandidates.Controls.Add(lblCandidateConstituency);
        grpCandidates.Controls.Add(txtCandidateFirstName);
        grpCandidates.Controls.Add(lblCandidateFirstName);
        grpCandidates.Controls.Add(lblCandidates);
        grpCandidates.Controls.Add(lvCandidates);
        grpCandidates.Location = new Point(564, 159);
        grpCandidates.Name = "grpCandidates";
        grpCandidates.Size = new Size(482, 650);
        grpCandidates.TabIndex = 15;
        grpCandidates.TabStop = false;
        grpCandidates.Text = "Add Candidates";
        // 
        // txtCandidateLastName
        // 
        txtCandidateLastName.Enabled = false;
        txtCandidateLastName.Location = new Point(6, 87);
        txtCandidateLastName.Name = "txtCandidateLastName";
        txtCandidateLastName.Size = new Size(465, 23);
        txtCandidateLastName.TabIndex = 8;
        // 
        // lblCandidateLastName
        // 
        lblCandidateLastName.AutoSize = true;
        lblCandidateLastName.Location = new Point(6, 69);
        lblCandidateLastName.Name = "lblCandidateLastName";
        lblCandidateLastName.Size = new Size(123, 15);
        lblCandidateLastName.TabIndex = 14;
        lblCandidateLastName.Text = "Candidate Last Name:";
        // 
        // btnRemoveCandidate
        // 
        btnRemoveCandidate.Enabled = false;
        btnRemoveCandidate.Location = new Point(306, 612);
        btnRemoveCandidate.Name = "btnRemoveCandidate";
        btnRemoveCandidate.Size = new Size(170, 23);
        btnRemoveCandidate.TabIndex = 13;
        btnRemoveCandidate.Text = "Remove Selected Candidate";
        btnRemoveCandidate.UseVisualStyleBackColor = true;
        btnRemoveCandidate.Click += btnRemoveCandidate_Click;
        // 
        // btnAddCandidate
        // 
        btnAddCandidate.BackColor = SystemColors.Control;
        btnAddCandidate.Enabled = false;
        btnAddCandidate.Location = new Point(351, 214);
        btnAddCandidate.Name = "btnAddCandidate";
        btnAddCandidate.Size = new Size(120, 23);
        btnAddCandidate.TabIndex = 11;
        btnAddCandidate.Text = "Add Candidate";
        btnAddCandidate.UseVisualStyleBackColor = false;
        btnAddCandidate.Click += cmbAddCandidate_Click;
        // 
        // cmbCandidateParty
        // 
        cmbCandidateParty.Enabled = false;
        cmbCandidateParty.FormattingEnabled = true;
        cmbCandidateParty.Location = new Point(6, 185);
        cmbCandidateParty.Name = "cmbCandidateParty";
        cmbCandidateParty.Size = new Size(465, 23);
        cmbCandidateParty.TabIndex = 10;
        // 
        // lblParty
        // 
        lblParty.AutoSize = true;
        lblParty.Location = new Point(6, 167);
        lblParty.Name = "lblParty";
        lblParty.Size = new Size(71, 15);
        lblParty.TabIndex = 8;
        lblParty.Text = "Select Party:";
        // 
        // cmbCandidateConstituency
        // 
        cmbCandidateConstituency.Enabled = false;
        cmbCandidateConstituency.FormattingEnabled = true;
        cmbCandidateConstituency.Location = new Point(5, 137);
        cmbCandidateConstituency.Name = "cmbCandidateConstituency";
        cmbCandidateConstituency.Size = new Size(470, 23);
        cmbCandidateConstituency.TabIndex = 9;
        // 
        // lblCandidateConstituency
        // 
        lblCandidateConstituency.AutoSize = true;
        lblCandidateConstituency.Location = new Point(6, 119);
        lblCandidateConstituency.Name = "lblCandidateConstituency";
        lblCandidateConstituency.Size = new Size(168, 15);
        lblCandidateConstituency.TabIndex = 6;
        lblCandidateConstituency.Text = "Select Candidate Constituency";
        // 
        // txtCandidateFirstName
        // 
        txtCandidateFirstName.Enabled = false;
        txtCandidateFirstName.Location = new Point(6, 37);
        txtCandidateFirstName.Name = "txtCandidateFirstName";
        txtCandidateFirstName.Size = new Size(465, 23);
        txtCandidateFirstName.TabIndex = 7;
        // 
        // lblCandidateFirstName
        // 
        lblCandidateFirstName.AutoSize = true;
        lblCandidateFirstName.Location = new Point(6, 19);
        lblCandidateFirstName.Name = "lblCandidateFirstName";
        lblCandidateFirstName.Size = new Size(124, 15);
        lblCandidateFirstName.TabIndex = 4;
        lblCandidateFirstName.Text = "Candidate First Name:";
        // 
        // btnReset
        // 
        btnReset.Location = new Point(900, 832);
        btnReset.Name = "btnReset";
        btnReset.Size = new Size(75, 23);
        btnReset.TabIndex = 16;
        btnReset.Text = "Reset form";
        btnReset.UseVisualStyleBackColor = true;
        btnReset.Click += btnReset_Click;
        // 
        // grpElectionDetails
        // 
        grpElectionDetails.Controls.Add(btnInitialiseElection);
        grpElectionDetails.Controls.Add(cmbVoteMechanism);
        grpElectionDetails.Controls.Add(lblVoteMechanism);
        grpElectionDetails.Controls.Add(cmbCountry);
        grpElectionDetails.Controls.Add(lblCountry);
        grpElectionDetails.Controls.Add(txtElectionName);
        grpElectionDetails.Controls.Add(lblElectionTitle);
        grpElectionDetails.Location = new Point(59, 62);
        grpElectionDetails.Name = "grpElectionDetails";
        grpElectionDetails.Size = new Size(482, 190);
        grpElectionDetails.TabIndex = 17;
        grpElectionDetails.TabStop = false;
        grpElectionDetails.Text = "Election Details";
        // 
        // btnInitialiseElection
        // 
        btnInitialiseElection.Location = new Point(344, 164);
        btnInitialiseElection.Name = "btnInitialiseElection";
        btnInitialiseElection.Size = new Size(132, 23);
        btnInitialiseElection.TabIndex = 15;
        btnInitialiseElection.Text = "Initialise Election";
        btnInitialiseElection.UseVisualStyleBackColor = true;
        btnInitialiseElection.Click += btnInitialiseElection_Click;
        // 
        // frmCreateElection
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1080, 865);
        Controls.Add(grpElectionDetails);
        Controls.Add(btnReset);
        Controls.Add(grpCandidates);
        Controls.Add(grpConstituencies);
        Controls.Add(lblFormTitle);
        Controls.Add(grpElectionDates);
        Controls.Add(btnCancel);
        Controls.Add(btnCreate);
        Margin = new Padding(3, 2, 3, 2);
        Name = "frmCreateElection";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "FrmCreateElection";
        grpElectionDates.ResumeLayout(false);
        grpElectionDates.PerformLayout();
        grpConstituencies.ResumeLayout(false);
        grpConstituencies.PerformLayout();
        grpCandidates.ResumeLayout(false);
        grpCandidates.PerformLayout();
        grpElectionDetails.ResumeLayout(false);
        grpElectionDetails.PerformLayout();
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
    private Label lblFormTitle;
    private GroupBox grpConstituencies;
    private Button btnAddConstituency;
    private Label lblConstituencies;
    private TextBox txtConstituencyName;
    private ComboBox cmbCountry;
    private Label lblCountry;
    private GroupBox grpCandidates;
    private Label lblCandidateFirstName;
    private TextBox txtCandidateFirstName;
    private ComboBox cmbCandidateConstituency;
    private Label lblCandidateConstituency;
    private Label lblParty;
    private ComboBox cmbCandidateParty;
    private Button btnAddCandidate;
    private Button btnReset;
    private Button btnRemoveConstituency;
    private Button btnRemoveCandidate;
    private TextBox txtCandidateLastName;
    private Label lblCandidateLastName;
    private GroupBox grpElectionDetails;
    private Button btnInitialiseElection;
}