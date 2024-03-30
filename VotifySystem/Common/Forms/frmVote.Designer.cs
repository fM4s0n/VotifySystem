namespace VotifySystem.Common.Forms;

partial class frmVote
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
        lblElectionName = new Label();
        grpSelectElection = new GroupBox();
        btnGo = new Button();
        cmbSelectElection = new ComboBox();
        pnlVoteControl = new Panel();
        ctrFPTPVote = new Controls.ctrFPTPVote();
        grpSelectElection.SuspendLayout();
        pnlVoteControl.SuspendLayout();
        SuspendLayout();
        // 
        // lblElectionName
        // 
        lblElectionName.AutoSize = true;
        lblElectionName.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblElectionName.Location = new Point(105, 9);
        lblElectionName.Name = "lblElectionName";
        lblElectionName.Size = new Size(212, 37);
        lblElectionName.TabIndex = 0;
        lblElectionName.Text = "lblElectionName";
        lblElectionName.Visible = false;
        // 
        // grpSelectElection
        // 
        grpSelectElection.Controls.Add(btnGo);
        grpSelectElection.Controls.Add(cmbSelectElection);
        grpSelectElection.Location = new Point(12, 61);
        grpSelectElection.Name = "grpSelectElection";
        grpSelectElection.Size = new Size(439, 100);
        grpSelectElection.TabIndex = 1;
        grpSelectElection.TabStop = false;
        grpSelectElection.Text = "Select Election";
        // 
        // btnGo
        // 
        btnGo.Location = new Point(338, 61);
        btnGo.Name = "btnGo";
        btnGo.Size = new Size(75, 23);
        btnGo.TabIndex = 1;
        btnGo.Text = "Go";
        btnGo.UseVisualStyleBackColor = true;
        btnGo.Click += btnGo_Click;
        // 
        // cmbSelectElection
        // 
        cmbSelectElection.FormattingEnabled = true;
        cmbSelectElection.Location = new Point(6, 34);
        cmbSelectElection.Name = "cmbSelectElection";
        cmbSelectElection.Size = new Size(407, 23);
        cmbSelectElection.TabIndex = 0;
        // 
        // pnlVoteControl
        // 
        pnlVoteControl.Controls.Add(ctrFPTPVote);
        pnlVoteControl.Location = new Point(12, 167);
        pnlVoteControl.Name = "pnlVoteControl";
        pnlVoteControl.Size = new Size(439, 438);
        pnlVoteControl.TabIndex = 2;
        // 
        // ctrFPTPVote
        // 
        ctrFPTPVote.Location = new Point(6, 10);
        ctrFPTPVote.Name = "ctrFPTPVote";
        ctrFPTPVote.Size = new Size(425, 113);
        ctrFPTPVote.TabIndex = 0;
        // 
        // frmVote
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(463, 649);
        Controls.Add(pnlVoteControl);
        Controls.Add(grpSelectElection);
        Controls.Add(lblElectionName);
        Name = "frmVote";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "frmVote";
        grpSelectElection.ResumeLayout(false);
        pnlVoteControl.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblElectionName;
    private GroupBox grpSelectElection;
    private Button btnGo;
    private ComboBox cmbSelectElection;
    private Panel pnlVoteControl;
    private Controls.ctrFPTPVote ctrFPTPVote;
}