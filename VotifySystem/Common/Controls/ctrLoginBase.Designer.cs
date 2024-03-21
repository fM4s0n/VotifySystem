namespace VotifySystem.Controls;

partial class ctrLoginBase
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
        ctrLoginInPerson = new Common.Controls.Login.ctrLoginInPerson();
        SuspendLayout();
        // 
        // ctrLoginInPerson
        // 
        ctrLoginInPerson.Location = new Point(235, 84);
        ctrLoginInPerson.Margin = new Padding(3, 5, 3, 5);
        ctrLoginInPerson.Name = "ctrLoginInPerson";
        ctrLoginInPerson.Size = new Size(506, 414);
        ctrLoginInPerson.TabIndex = 0;
        // 
        // ctrLoginBase
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(ctrLoginInPerson);
        Name = "ctrLoginBase";
        Size = new Size(1000, 600);
        ResumeLayout(false);
    }

    #endregion

    private Common.Controls.Login.ctrLoginInPerson ctrLoginInPerson;
}
