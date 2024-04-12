namespace VotifySystem.Common.Controls;

partial class ctrFPTPVote
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        btnSubmitVote = new Button();
        cmbSelectCandidate = new ComboBox();
        lblSelectCandidate = new Label();
        btnCancel = new Button();
        SuspendLayout();
        // 
        // btnSubmitVote
        // 
        btnSubmitVote.Location = new Point(329, 65);
        btnSubmitVote.Name = "btnSubmitVote";
        btnSubmitVote.Size = new Size(75, 23);
        btnSubmitVote.TabIndex = 1;
        btnSubmitVote.Text = "Submit Vote";
        btnSubmitVote.UseVisualStyleBackColor = true;
        btnSubmitVote.Click += btnSubmitVote_Click;
        // 
        // cmbSelectCandidate
        // 
        cmbSelectCandidate.FormattingEnabled = true;
        cmbSelectCandidate.Location = new Point(18, 36);
        cmbSelectCandidate.Name = "cmbSelectCandidate";
        cmbSelectCandidate.Size = new Size(386, 23);
        cmbSelectCandidate.TabIndex = 2;
        // 
        // lblSelectCandidate
        // 
        lblSelectCandidate.AutoSize = true;
        lblSelectCandidate.Location = new Point(18, 18);
        lblSelectCandidate.Name = "lblSelectCandidate";
        lblSelectCandidate.Size = new Size(123, 15);
        lblSelectCandidate.TabIndex = 3;
        lblSelectCandidate.Text = "Select One Candidate:";
        // 
        // btnCancel
        // 
        btnCancel.Location = new Point(18, 65);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(75, 23);
        btnCancel.TabIndex = 4;
        btnCancel.Text = "Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        // 
        // ctrFPTPVote
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(btnCancel);
        Controls.Add(lblSelectCandidate);
        Controls.Add(cmbSelectCandidate);
        Controls.Add(btnSubmitVote);
        Name = "ctrFPTPVote";
        Size = new Size(425, 113);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private Button btnSubmitVote;
    private ComboBox cmbSelectCandidate;
    private Label lblSelectCandidate;
    private Button btnCancel;
}
