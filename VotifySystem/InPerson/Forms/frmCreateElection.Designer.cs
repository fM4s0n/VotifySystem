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
        lvwSelectCandidates = new ListView();
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
        comboBox1 = new ComboBox();
        lblCountry = new Label();
        grpCandidates = new GroupBox();
        lblCandidateName = new Label();
        textBox1 = new TextBox();
        lblCandidateConstituency = new Label();
        cmbCandidateConstituency = new ComboBox();
        grpElectionDates.SuspendLayout();
        grpConstituencies.SuspendLayout();
        grpCandidates.SuspendLayout();
        SuspendLayout();
        // 
        // btnCreate
        // 
        btnCreate.Location = new Point(964, 682);
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
        btnCancel.Location = new Point(831, 682);
        btnCancel.Margin = new Padding(3, 2, 3, 2);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(82, 22);
        btnCancel.TabIndex = 1;
        btnCancel.Text = "Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        // 
        // lvwSelectCandidates
        // 
        lvwSelectCandidates.Location = new Point(6, 161);
        lvwSelectCandidates.Margin = new Padding(3, 2, 3, 2);
        lvwSelectCandidates.Name = "lvwSelectCandidates";
        lvwSelectCandidates.Size = new Size(470, 315);
        lvwSelectCandidates.TabIndex = 2;
        lvwSelectCandidates.UseCompatibleStateImageBehavior = false;
        // 
        // lblCandidates
        // 
        lblCandidates.AutoSize = true;
        lblCandidates.Location = new Point(6, 144);
        lblCandidates.Name = "lblCandidates";
        lblCandidates.Size = new Size(69, 15);
        lblCandidates.TabIndex = 3;
        lblCandidates.Text = "Candidates:";
        // 
        // lblElectionTitle
        // 
        lblElectionTitle.AutoSize = true;
        lblElectionTitle.Location = new Point(53, 81);
        lblElectionTitle.Name = "lblElectionTitle";
        lblElectionTitle.Size = new Size(77, 15);
        lblElectionTitle.TabIndex = 4;
        lblElectionTitle.Text = "Election Title:";
        // 
        // txtElectionName
        // 
        txtElectionName.Location = new Point(53, 98);
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
        grpElectionDates.Location = new Point(570, 84);
        grpElectionDates.Margin = new Padding(3, 2, 3, 2);
        grpElectionDates.Name = "grpElectionDates";
        grpElectionDates.Padding = new Padding(3, 2, 3, 2);
        grpElectionDates.Size = new Size(476, 79);
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
        dtpElectionEnd.Location = new Point(120, 52);
        dtpElectionEnd.Margin = new Padding(3, 2, 3, 2);
        dtpElectionEnd.Name = "dtpElectionEnd";
        dtpElectionEnd.Size = new Size(350, 23);
        dtpElectionEnd.TabIndex = 1;
        // 
        // dtpElectionStart
        // 
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
        lvConstituencies.Location = new Point(6, 101);
        lvConstituencies.Margin = new Padding(3, 2, 3, 2);
        lvConstituencies.Name = "lvConstituencies";
        lvConstituencies.Size = new Size(470, 315);
        lvConstituencies.TabIndex = 8;
        lvConstituencies.UseCompatibleStateImageBehavior = false;
        // 
        // cmbVoteMechanism
        // 
        cmbVoteMechanism.FormattingEnabled = true;
        cmbVoteMechanism.Location = new Point(53, 196);
        cmbVoteMechanism.Margin = new Padding(3, 2, 3, 2);
        cmbVoteMechanism.Name = "cmbVoteMechanism";
        cmbVoteMechanism.Size = new Size(397, 23);
        cmbVoteMechanism.TabIndex = 9;
        cmbVoteMechanism.SelectedIndexChanged += cmbVoteMechanism_SelectedIndexChanged;
        // 
        // lblVoteMechanism
        // 
        lblVoteMechanism.AutoSize = true;
        lblVoteMechanism.Location = new Point(53, 179);
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
        grpConstituencies.Location = new Point(53, 256);
        grpConstituencies.Name = "grpConstituencies";
        grpConstituencies.Size = new Size(482, 421);
        grpConstituencies.TabIndex = 12;
        grpConstituencies.TabStop = false;
        grpConstituencies.Text = "Constituencies";
        // 
        // btnAddConstituency
        // 
        btnAddConstituency.Location = new Point(409, 43);
        btnAddConstituency.Name = "btnAddConstituency";
        btnAddConstituency.Size = new Size(67, 23);
        btnAddConstituency.TabIndex = 11;
        btnAddConstituency.Text = "Add";
        btnAddConstituency.UseVisualStyleBackColor = true;
        btnAddConstituency.Click += btnAddConstituency_Click;
        // 
        // lblConstituencies
        // 
        lblConstituencies.AutoSize = true;
        lblConstituencies.Location = new Point(6, 84);
        lblConstituencies.Name = "lblConstituencies";
        lblConstituencies.Size = new Size(85, 15);
        lblConstituencies.TabIndex = 10;
        lblConstituencies.Text = "Constituencies";
        // 
        // txtConstituencyName
        // 
        txtConstituencyName.Location = new Point(6, 43);
        txtConstituencyName.Name = "txtConstituencyName";
        txtConstituencyName.Size = new Size(397, 23);
        txtConstituencyName.TabIndex = 9;
        // 
        // comboBox1
        // 
        comboBox1.FormattingEnabled = true;
        comboBox1.Location = new Point(53, 149);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new Size(397, 23);
        comboBox1.TabIndex = 13;
        // 
        // lblCountry
        // 
        lblCountry.AutoSize = true;
        lblCountry.Location = new Point(53, 131);
        lblCountry.Name = "lblCountry";
        lblCountry.Size = new Size(50, 15);
        lblCountry.TabIndex = 14;
        lblCountry.Text = "Country";
        // 
        // grpCandidates
        // 
        grpCandidates.Controls.Add(cmbCandidateConstituency);
        grpCandidates.Controls.Add(lblCandidateConstituency);
        grpCandidates.Controls.Add(textBox1);
        grpCandidates.Controls.Add(lblCandidateName);
        grpCandidates.Controls.Add(lblCandidates);
        grpCandidates.Controls.Add(lvwSelectCandidates);
        grpCandidates.Location = new Point(564, 196);
        grpCandidates.Name = "grpCandidates";
        grpCandidates.Size = new Size(482, 481);
        grpCandidates.TabIndex = 15;
        grpCandidates.TabStop = false;
        grpCandidates.Text = "Add Candidates";
        // 
        // lblCandidateName
        // 
        lblCandidateName.AutoSize = true;
        lblCandidateName.Location = new Point(11, 30);
        lblCandidateName.Name = "lblCandidateName";
        lblCandidateName.Size = new Size(99, 15);
        lblCandidateName.TabIndex = 4;
        lblCandidateName.Text = "Candidate Name:";
        // 
        // textBox1
        // 
        textBox1.Location = new Point(11, 48);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(465, 23);
        textBox1.TabIndex = 5;
        // 
        // lblCandidateConstituency
        // 
        lblCandidateConstituency.AutoSize = true;
        lblCandidateConstituency.Location = new Point(16, 82);
        lblCandidateConstituency.Name = "lblCandidateConstituency";
        lblCandidateConstituency.Size = new Size(168, 15);
        lblCandidateConstituency.TabIndex = 6;
        lblCandidateConstituency.Text = "Select Candidate Constituency";
        // 
        // cmbCandidateConstituency
        // 
        cmbCandidateConstituency.FormattingEnabled = true;
        cmbCandidateConstituency.Location = new Point(11, 103);
        cmbCandidateConstituency.Name = "cmbCandidateConstituency";
        cmbCandidateConstituency.Size = new Size(465, 23);
        cmbCandidateConstituency.TabIndex = 7;
        // 
        // frmCreateElection
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1080, 715);
        Controls.Add(grpCandidates);
        Controls.Add(lblCountry);
        Controls.Add(comboBox1);
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
    private ListView lvwSelectCandidates;
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
    private ComboBox comboBox1;
    private Label lblCountry;
    private GroupBox grpCandidates;
    private Label lblCandidateName;
    private TextBox textBox1;
    private ComboBox cmbCandidateConstituency;
    private Label lblCandidateConstituency;
}