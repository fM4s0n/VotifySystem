namespace VotifySystem.InPerson.Controls;

partial class ctrResultsPartyPanelItem
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
        lblPartyName = new Label();
        lblConstituenciesWon = new Label();
        lblConstituenciesWonValue = new Label();
        lblOverallPosition = new Label();
        lblOverallPositionValue = new Label();
        lblTotalVotesValue = new Label();
        lblTotalVotes = new Label();
        SuspendLayout();
        // 
        // lblPartyName
        // 
        lblPartyName.AutoSize = true;
        lblPartyName.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblPartyName.Location = new Point(3, 0);
        lblPartyName.Name = "lblPartyName";
        lblPartyName.Size = new Size(484, 32);
        lblPartyName.TabIndex = 1;
        lblPartyName.Text = "This is a very long description for testing";
        // 
        // lblConstituenciesWon
        // 
        lblConstituenciesWon.AutoSize = true;
        lblConstituenciesWon.Font = new Font("Segoe UI", 15.75F);
        lblConstituenciesWon.Location = new Point(0, 66);
        lblConstituenciesWon.Name = "lblConstituenciesWon";
        lblConstituenciesWon.Size = new Size(202, 30);
        lblConstituenciesWon.TabIndex = 2;
        lblConstituenciesWon.Text = "Constituencies Won:";
        // 
        // lblConstituenciesWonValue
        // 
        lblConstituenciesWonValue.AutoSize = true;
        lblConstituenciesWonValue.Font = new Font("Segoe UI", 15.75F);
        lblConstituenciesWonValue.Location = new Point(208, 66);
        lblConstituenciesWonValue.Name = "lblConstituenciesWonValue";
        lblConstituenciesWonValue.Size = new Size(24, 30);
        lblConstituenciesWonValue.TabIndex = 3;
        lblConstituenciesWonValue.Text = "0";
        // 
        // lblOverallPosition
        // 
        lblOverallPosition.AutoSize = true;
        lblOverallPosition.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblOverallPosition.Location = new Point(3, 36);
        lblOverallPosition.Name = "lblOverallPosition";
        lblOverallPosition.Size = new Size(162, 30);
        lblOverallPosition.TabIndex = 4;
        lblOverallPosition.Text = "Overall Position:";
        // 
        // lblOverallPositionValue
        // 
        lblOverallPositionValue.AutoSize = true;
        lblOverallPositionValue.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblOverallPositionValue.Location = new Point(171, 36);
        lblOverallPositionValue.Name = "lblOverallPositionValue";
        lblOverallPositionValue.Size = new Size(24, 30);
        lblOverallPositionValue.TabIndex = 5;
        lblOverallPositionValue.Text = "0";
        // 
        // lblTotalVotesValue
        // 
        lblTotalVotesValue.AutoSize = true;
        lblTotalVotesValue.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblTotalVotesValue.Location = new Point(411, 66);
        lblTotalVotesValue.Name = "lblTotalVotesValue";
        lblTotalVotesValue.Size = new Size(24, 30);
        lblTotalVotesValue.TabIndex = 7;
        lblTotalVotesValue.Text = "0";
        // 
        // lblTotalVotes
        // 
        lblTotalVotes.AutoSize = true;
        lblTotalVotes.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblTotalVotes.Location = new Point(286, 66);
        lblTotalVotes.Name = "lblTotalVotes";
        lblTotalVotes.Size = new Size(119, 30);
        lblTotalVotes.TabIndex = 6;
        lblTotalVotes.Text = "Total Votes:";
        // 
        // ctrResultsPartyPanelItem
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(lblTotalVotesValue);
        Controls.Add(lblTotalVotes);
        Controls.Add(lblOverallPositionValue);
        Controls.Add(lblOverallPosition);
        Controls.Add(lblConstituenciesWonValue);
        Controls.Add(lblConstituenciesWon);
        Controls.Add(lblPartyName);
        Name = "ctrResultsPartyPanelItem";
        Size = new Size(540, 100);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblPartyName;
    private Label lblConstituenciesWon;
    private Label lblConstituenciesWonValue;
    private Label lblOverallPosition;
    private Label lblOverallPositionValue;
    private Label lblTotalVotesValue;
    private Label lblTotalVotes;
}
