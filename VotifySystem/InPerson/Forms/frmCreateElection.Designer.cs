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
        lblElectionDescription = new Label();
        txtElectionName = new TextBox();
        grpElectionDates = new GroupBox();
        lblElectionEnd = new Label();
        lblElectionStart = new Label();
        dtpElectionEnd = new DateTimePicker();
        dtpElectionStart = new DateTimePicker();
        lblSelectConstituencies = new Label();
        listView1 = new ListView();
        cmbVoteMechanism = new ComboBox();
        lblVoteMechanism = new Label();
        label1 = new Label();
        grpElectionDates.SuspendLayout();
        SuspendLayout();
        // 
        // btnCreate
        // 
        btnCreate.Location = new Point(691, 912);
        btnCreate.Name = "btnCreate";
        btnCreate.Size = new Size(94, 29);
        btnCreate.TabIndex = 0;
        btnCreate.Text = "Create";
        btnCreate.UseVisualStyleBackColor = true;
        btnCreate.Click += btnCreate_Click;
        // 
        // btnCancel
        // 
        btnCancel.Location = new Point(844, 912);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(94, 29);
        btnCancel.TabIndex = 1;
        btnCancel.Text = "Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        // 
        // lvwSelectCandidates
        // 
        lvwSelectCandidates.Location = new Point(100, 480);
        lvwSelectCandidates.Name = "lvwSelectCandidates";
        lvwSelectCandidates.Size = new Size(453, 169);
        lvwSelectCandidates.TabIndex = 2;
        lvwSelectCandidates.UseCompatibleStateImageBehavior = false;
        // 
        // lblSelectCandidates
        // 
        lblSelectCandidates.AutoSize = true;
        lblSelectCandidates.Location = new Point(100, 457);
        lblSelectCandidates.Name = "lblSelectCandidates";
        lblSelectCandidates.Size = new Size(130, 20);
        lblSelectCandidates.TabIndex = 3;
        lblSelectCandidates.Text = "Select Candidates:";
        // 
        // lblElectionDescription
        // 
        lblElectionDescription.AutoSize = true;
        lblElectionDescription.Location = new Point(100, 114);
        lblElectionDescription.Name = "lblElectionDescription";
        lblElectionDescription.Size = new Size(88, 20);
        lblElectionDescription.TabIndex = 4;
        lblElectionDescription.Text = "Description:";
        // 
        // txtElectionName
        // 
        txtElectionName.Location = new Point(194, 111);
        txtElectionName.Name = "txtElectionName";
        txtElectionName.Size = new Size(359, 27);
        txtElectionName.TabIndex = 5;
        // 
        // grpElectionDates
        // 
        grpElectionDates.Controls.Add(lblElectionEnd);
        grpElectionDates.Controls.Add(lblElectionStart);
        grpElectionDates.Controls.Add(dtpElectionEnd);
        grpElectionDates.Controls.Add(dtpElectionStart);
        grpElectionDates.Location = new Point(100, 171);
        grpElectionDates.Name = "grpElectionDates";
        grpElectionDates.Size = new Size(459, 115);
        grpElectionDates.TabIndex = 6;
        grpElectionDates.TabStop = false;
        grpElectionDates.Text = "Dates";
        // 
        // lblElectionEnd
        // 
        lblElectionEnd.AutoSize = true;
        lblElectionEnd.Location = new Point(6, 85);
        lblElectionEnd.Name = "lblElectionEnd";
        lblElectionEnd.Size = new Size(94, 20);
        lblElectionEnd.TabIndex = 3;
        lblElectionEnd.Text = "Election end:";
        // 
        // lblElectionStart
        // 
        lblElectionStart.AutoSize = true;
        lblElectionStart.Location = new Point(6, 33);
        lblElectionStart.Name = "lblElectionStart";
        lblElectionStart.Size = new Size(98, 20);
        lblElectionStart.TabIndex = 2;
        lblElectionStart.Text = "Election start:";
        // 
        // dtpElectionEnd
        // 
        dtpElectionEnd.Location = new Point(203, 78);
        dtpElectionEnd.Name = "dtpElectionEnd";
        dtpElectionEnd.Size = new Size(250, 27);
        dtpElectionEnd.TabIndex = 1;
        // 
        // dtpElectionStart
        // 
        dtpElectionStart.Location = new Point(203, 26);
        dtpElectionStart.Name = "dtpElectionStart";
        dtpElectionStart.Size = new Size(250, 27);
        dtpElectionStart.TabIndex = 0;
        // 
        // lblSelectConstituencies
        // 
        lblSelectConstituencies.AutoSize = true;
        lblSelectConstituencies.Location = new Point(100, 652);
        lblSelectConstituencies.Name = "lblSelectConstituencies";
        lblSelectConstituencies.Size = new Size(151, 20);
        lblSelectConstituencies.TabIndex = 7;
        lblSelectConstituencies.Text = "Select Constituencies:";
        // 
        // listView1
        // 
        listView1.Location = new Point(97, 675);
        listView1.Name = "listView1";
        listView1.Size = new Size(456, 200);
        listView1.TabIndex = 8;
        listView1.UseCompatibleStateImageBehavior = false;
        // 
        // cmbVoteMechanism
        // 
        cmbVoteMechanism.FormattingEnabled = true;
        cmbVoteMechanism.Location = new Point(106, 366);
        cmbVoteMechanism.Name = "cmbVoteMechanism";
        cmbVoteMechanism.Size = new Size(447, 28);
        cmbVoteMechanism.TabIndex = 9;
        cmbVoteMechanism.SelectedIndexChanged += cmbVoteMechanism_SelectedIndexChanged;
        // 
        // lblVoteMechanism
        // 
        lblVoteMechanism.AutoSize = true;
        lblVoteMechanism.Location = new Point(106, 343);
        lblVoteMechanism.Name = "lblVoteMechanism";
        lblVoteMechanism.Size = new Size(178, 20);
        lblVoteMechanism.TabIndex = 10;
        lblVoteMechanism.Text = "Select Voting Mechanism:";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI", 40F);
        label1.Location = new Point(194, 9);
        label1.Name = "label1";
        label1.Size = new Size(619, 89);
        label1.TabIndex = 11;
        label1.Text = "Create new election";
        // 
        // frmCreateElection
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(982, 953);
        Controls.Add(label1);
        Controls.Add(lblVoteMechanism);
        Controls.Add(cmbVoteMechanism);
        Controls.Add(listView1);
        Controls.Add(lblSelectConstituencies);
        Controls.Add(grpElectionDates);
        Controls.Add(txtElectionName);
        Controls.Add(lblElectionDescription);
        Controls.Add(lblSelectCandidates);
        Controls.Add(lvwSelectCandidates);
        Controls.Add(btnCancel);
        Controls.Add(btnCreate);
        Name = "frmCreateElection";
        Text = "FrmCreateElection";
        grpElectionDates.ResumeLayout(false);
        grpElectionDates.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button btnCreate;
    private Button btnCancel;
    private ListView lvwSelectCandidates;
    private Label lblSelectCandidates;
    private Label lblElectionDescription;
    private TextBox txtElectionName;
    private GroupBox grpElectionDates;
    private Label lblElectionStart;
    private DateTimePicker dtpElectionEnd;
    private DateTimePicker dtpElectionStart;
    private Label lblElectionEnd;
    private Label lblSelectConstituencies;
    private ListView listView1;
    private ComboBox cmbVoteMechanism;
    private Label lblVoteMechanism;
    private Label label1;
}