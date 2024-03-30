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
        btnVoteInPerson = new Button();
        SuspendLayout();
        // 
        // btnRegisterToVote
        // 
        btnRegisterToVote.Location = new Point(242, 193);
        btnRegisterToVote.Margin = new Padding(3, 2, 3, 2);
        btnRegisterToVote.Name = "btnRegisterToVote";
        btnRegisterToVote.Size = new Size(120, 38);
        btnRegisterToVote.TabIndex = 0;
        btnRegisterToVote.Text = "Register To Vote in an Election";
        btnRegisterToVote.UseVisualStyleBackColor = true;
        btnRegisterToVote.Click += btnRegisterToVote_Click;
        // 
        // btnVoteInPerson
        // 
        btnVoteInPerson.Location = new Point(485, 193);
        btnVoteInPerson.Margin = new Padding(3, 2, 3, 2);
        btnVoteInPerson.Name = "btnVoteInPerson";
        btnVoteInPerson.Size = new Size(120, 38);
        btnVoteInPerson.TabIndex = 1;
        btnVoteInPerson.Text = "Vote";
        btnVoteInPerson.UseVisualStyleBackColor = true;
        btnVoteInPerson.Click += btnVoteInPerson_Click;
        // 
        // ctrVoterHome
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(btnVoteInPerson);
        Controls.Add(btnRegisterToVote);
        Margin = new Padding(3, 2, 3, 2);
        Name = "ctrVoterHome";
        Size = new Size(875, 450);
        ResumeLayout(false);
    }

    #endregion

    private Button btnRegisterToVote;
    private Button btnVoteInPerson;
}
