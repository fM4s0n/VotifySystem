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
        lblSelectCandidates = new Label();
        lblElectionTitle = new Label();
        txtElectionName = new TextBox();
        grpElectionDates = new GroupBox();
        lblElectionEnd = new Label();
        lblElectionStart = new Label();
        dtpElectionEnd = new DateTimePicker();
        dtpElectionStart = new DateTimePicker();
        lblAddConstituencies = new Label();
        listView1 = new ListView();
        cmbVoteMechanism = new ComboBox();
        lblVoteMechanism = new Label();
        label1 = new Label();
        grpConstituencies = new GroupBox();
        btnAddConstituency = new Button();
        lblConstituencies = new Label();
        txtConstituencyName = new TextBox();
        comboBox1 = new ComboBox();
        label2 = new Label();
        grpElectionDates.SuspendLayout();
        grpConstituencies.SuspendLayout();
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
        lvwSelectCandidates.Location = new Point(649, 256);
        lvwSelectCandidates.Margin = new Padding(3, 2, 3, 2);
        lvwSelectCandidates.Name = "lvwSelectCandidates";
        lvwSelectCandidates.Size = new Size(397, 128);
        lvwSelectCandidates.TabIndex = 2;
        lvwSelectCandidates.UseCompatibleStateImageBehavior = false;
        // 
        // lblSelectCandidates
        // 
        lblSelectCandidates.AutoSize = true;
        lblSelectCandidates.Location = new Point(649, 239);
        lblSelectCandidates.Name = "lblSelectCandidates";
        lblSelectCandidates.Size = new Size(103, 15);
        lblSelectCandidates.TabIndex = 3;
        lblSelectCandidates.Text = "Select Candidates:";
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
        grpElectionDates.Location = new Point(589, 84);
        grpElectionDates.Margin = new Padding(3, 2, 3, 2);
        grpElectionDates.Name = "grpElectionDates";
        grpElectionDates.Padding = new Padding(3, 2, 3, 2);
        grpElectionDates.Size = new Size(402, 95);
        grpElectionDates.TabIndex = 6;
        grpElectionDates.TabStop = false;
        grpElectionDates.Text = "Election Date:";
        // 
        // lblElectionEnd
        // 
        lblElectionEnd.AutoSize = true;
        lblElectionEnd.Location = new Point(5, 72);
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
        dtpElectionEnd.Location = new Point(120, 66);
        dtpElectionEnd.Margin = new Padding(3, 2, 3, 2);
        dtpElectionEnd.Name = "dtpElectionEnd";
        dtpElectionEnd.Size = new Size(277, 23);
        dtpElectionEnd.TabIndex = 1;
        // 
        // dtpElectionStart
        // 
        dtpElectionStart.Location = new Point(120, 20);
        dtpElectionStart.Margin = new Padding(3, 2, 3, 2);
        dtpElectionStart.Name = "dtpElectionStart";
        dtpElectionStart.Size = new Size(277, 23);
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
        // listView1
        // 
        listView1.Location = new Point(6, 101);
        listView1.Margin = new Padding(3, 2, 3, 2);
        listView1.Name = "listView1";
        listView1.Size = new Size(470, 232);
        listView1.TabIndex = 8;
        listView1.UseCompatibleStateImageBehavior = false;
        // 
        // cmbVoteMechanism
        // 
        cmbVoteMechanism.FormattingEnabled = true;
        cmbVoteMechanism.Location = new Point(53, 153);
        cmbVoteMechanism.Margin = new Padding(3, 2, 3, 2);
        cmbVoteMechanism.Name = "cmbVoteMechanism";
        cmbVoteMechanism.Size = new Size(397, 23);
        cmbVoteMechanism.TabIndex = 9;
        cmbVoteMechanism.SelectedIndexChanged += cmbVoteMechanism_SelectedIndexChanged;
        // 
        // lblVoteMechanism
        // 
        lblVoteMechanism.AutoSize = true;
        lblVoteMechanism.Location = new Point(53, 136);
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
        grpConstituencies.Controls.Add(listView1);
        grpConstituencies.Location = new Point(53, 301);
        grpConstituencies.Name = "grpConstituencies";
        grpConstituencies.Size = new Size(482, 337);
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
        comboBox1.Location = new Point(53, 211);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new Size(397, 23);
        comboBox1.TabIndex = 13;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(59, 193);
        label2.Name = "label2";
        label2.Size = new Size(38, 15);
        label2.TabIndex = 14;
        label2.Text = "label2";
        // 
        // frmCreateElection
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1080, 715);
        Controls.Add(label2);
        Controls.Add(comboBox1);
        Controls.Add(grpConstituencies);
        Controls.Add(label1);
        Controls.Add(lblVoteMechanism);
        Controls.Add(cmbVoteMechanism);
        Controls.Add(grpElectionDates);
        Controls.Add(txtElectionName);
        Controls.Add(lblElectionTitle);
        Controls.Add(lblSelectCandidates);
        Controls.Add(lvwSelectCandidates);
        Controls.Add(btnCancel);
        Controls.Add(btnCreate);
        Margin = new Padding(3, 2, 3, 2);
        Name = "frmCreateElection";
        Text = "FrmCreateElection";
        grpElectionDates.ResumeLayout(false);
        grpElectionDates.PerformLayout();
        grpConstituencies.ResumeLayout(false);
        grpConstituencies.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button btnCreate;
    private Button btnCancel;
    private ListView lvwSelectCandidates;
    private Label lblSelectCandidates;
    private Label lblElectionTitle;
    private TextBox txtElectionName;
    private GroupBox grpElectionDates;
    private Label lblElectionStart;
    private DateTimePicker dtpElectionEnd;
    private DateTimePicker dtpElectionStart;
    private Label lblElectionEnd;
    private Label lblAddConstituencies;
    private ListView listView1;
    private ComboBox cmbVoteMechanism;
    private Label lblVoteMechanism;
    private Label label1;
    private GroupBox grpConstituencies;
    private Button btnAddConstituency;
    private Label lblConstituencies;
    private TextBox txtConstituencyName;
    private ComboBox comboBox1;
    private Label label2;
}