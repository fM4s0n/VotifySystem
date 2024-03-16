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
        btnOnline.Location = new Point(446, 201);
        btnOnline.Margin = new Padding(3, 2, 3, 2);
        btnOnline.Name = "btnOnline";
        btnOnline.Size = new Size(82, 22);
        btnOnline.TabIndex = 3;
        btnOnline.Text = "Online";
        btnOnline.UseVisualStyleBackColor = true;
        btnOnline.Click += btnOnline_Click;
        // 
        // btnInPerson
        // 
        btnInPerson.Location = new Point(222, 201);
        btnInPerson.Margin = new Padding(3, 2, 3, 2);
        btnInPerson.Name = "btnInPerson";
        btnInPerson.Size = new Size(116, 22);
        btnInPerson.TabIndex = 2;
        btnInPerson.Text = "In person";
        btnInPerson.UseVisualStyleBackColor = true;
        btnInPerson.Click += btnInPerson_Click;
        // 
        // ctrMainDefault
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(btnOnline);
        Controls.Add(btnInPerson);
        Name = "ctrMainDefault";
        Size = new Size(750, 425);
        ResumeLayout(false);
    }

    #endregion

    private Button btnOnline;
    private Button btnInPerson;
}
