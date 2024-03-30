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
        chkCandidates = new CheckedListBox();
        SuspendLayout();
        // 
        // chkCandidates
        // 
        chkCandidates.CheckOnClick = true;
        chkCandidates.FormattingEnabled = true;
        chkCandidates.Location = new Point(32, 30);
        chkCandidates.Name = "chkCandidates";
        chkCandidates.Size = new Size(365, 382);
        chkCandidates.TabIndex = 0;
        // 
        // ctrFPTPVote
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(chkCandidates);
        Name = "ctrFPTPVote";
        Size = new Size(425, 435);
        ResumeLayout(false);
    }

    #endregion

    private CheckedListBox chkCandidates;
}
