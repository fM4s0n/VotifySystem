namespace VotifySystem.Controls;

partial class ctrVoterHome
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
        btnRegisterToVote = new Button();
        SuspendLayout();
        // 
        // btnRegisterToVote
        // 
        btnRegisterToVote.Location = new Point(214, 215);
        btnRegisterToVote.Name = "btnRegisterToVote";
        btnRegisterToVote.Size = new Size(137, 51);
        btnRegisterToVote.TabIndex = 0;
        btnRegisterToVote.Text = "Register To Vote in an Election";
        btnRegisterToVote.UseVisualStyleBackColor = true;
        btnRegisterToVote.Click += btnRegisterToVote_Click;
        // 
        // CtrVoterHome
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(btnRegisterToVote);
        Name = "CtrVoterHome";
        Size = new Size(1000, 600);
        ResumeLayout(false);
    }

    #endregion

    private Button btnRegisterToVote;
}
