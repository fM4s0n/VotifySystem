namespace VotifySystem.Controls;

partial class CtrAdminHome
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
        BtnCreateElection = new Button();
        SuspendLayout();
        // 
        // BtnCreateElection
        // 
        BtnCreateElection.Location = new Point(236, 143);
        BtnCreateElection.Name = "BtnCreateElection";
        BtnCreateElection.Size = new Size(75, 23);
        BtnCreateElection.TabIndex = 1;
        BtnCreateElection.Text = "Create New Election";
        BtnCreateElection.UseVisualStyleBackColor = true;
        BtnCreateElection.Click += BtnCreateElection_Click;
        // 
        // CtrAdminHome
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(BtnCreateElection);
        Name = "CtrAdminHome";
        Size = new Size(547, 308);
        ResumeLayout(false);
    }

    #endregion

    private Button BtnCreateElection;
}
