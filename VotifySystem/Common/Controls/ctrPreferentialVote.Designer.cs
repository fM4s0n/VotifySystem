namespace VotifySystem.Common.Controls;

partial class ctrPreferentialVote
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
        flpCandidateOptions = new FlowLayoutPanel();
        btnSubmit = new Button();
        btnCancel = new Button();
        lblVoterAdvice = new Label();
        SuspendLayout();
        // 
        // flpCandidateOptions
        // 
        flpCandidateOptions.AutoScroll = true;
        flpCandidateOptions.Location = new Point(3, 19);
        flpCandidateOptions.Name = "flpCandidateOptions";
        flpCandidateOptions.Size = new Size(419, 349);
        flpCandidateOptions.TabIndex = 0;
        // 
        // btnSubmit
        // 
        btnSubmit.Location = new Point(347, 374);
        btnSubmit.Name = "btnSubmit";
        btnSubmit.Size = new Size(75, 23);
        btnSubmit.TabIndex = 1;
        btnSubmit.Text = "Submit";
        btnSubmit.UseVisualStyleBackColor = true;
        btnSubmit.Click += btnSubmit_Click;
        // 
        // btnCancel
        // 
        btnCancel.Location = new Point(3, 374);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(75, 23);
        btnCancel.TabIndex = 2;
        btnCancel.Text = "Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        // 
        // lblVoterAdvice
        // 
        lblVoterAdvice.AutoSize = true;
        lblVoterAdvice.Location = new Point(3, 1);
        lblVoterAdvice.Name = "lblVoterAdvice";
        lblVoterAdvice.Size = new Size(291, 15);
        lblVoterAdvice.TabIndex = 0;
        lblVoterAdvice.Text = "Rank candidates: 1 for top choice, 0 for no preference.";
        // 
        // ctrPreferentialVote
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(lblVoterAdvice);
        Controls.Add(btnCancel);
        Controls.Add(btnSubmit);
        Controls.Add(flpCandidateOptions);
        Name = "ctrPreferentialVote";
        Size = new Size(425, 400);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private FlowLayoutPanel flpCandidateOptions;
    private Button btnSubmit;
    private Button btnCancel;
    private Label lblVoterAdvice;
}
