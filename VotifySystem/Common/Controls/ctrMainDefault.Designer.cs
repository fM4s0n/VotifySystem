namespace VotifySystem.Common.Controls;

partial class ctrMainDefault
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
        btnOnline = new Button();
        btnInPerson = new Button();
        SuspendLayout();
        // 
        // btnOnline
        // 
        btnOnline.Location = new Point(510, 268);
        btnOnline.Name = "btnOnline";
        btnOnline.Size = new Size(94, 29);
        btnOnline.TabIndex = 3;
        btnOnline.Text = "Online";
        btnOnline.UseVisualStyleBackColor = true;
        btnOnline.Click += btnOnline_Click;
        // 
        // btnInPerson
        // 
        btnInPerson.Location = new Point(254, 268);
        btnInPerson.Name = "btnInPerson";
        btnInPerson.Size = new Size(133, 29);
        btnInPerson.TabIndex = 2;
        btnInPerson.Text = "In person";
        btnInPerson.UseVisualStyleBackColor = true;
        btnInPerson.Click += btnInPerson_Click;
        // 
        // ctrMainDefault
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(btnOnline);
        Controls.Add(btnInPerson);
        Margin = new Padding(3, 4, 3, 4);
        Name = "ctrMainDefault";
        Size = new Size(857, 567);
        ResumeLayout(false);
    }

    #endregion

    private Button btnOnline;
    private Button btnInPerson;
}
