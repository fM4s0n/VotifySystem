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
        // frmPostalVote
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(525, 450);
        Controls.Add(lblPostalVotes);
        Name = "frmPostalVote";
        Text = "frmPostalVote";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblPostalVotes;
}