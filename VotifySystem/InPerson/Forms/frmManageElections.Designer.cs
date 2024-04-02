namespace VotifySystem.InPerson.Forms;

partial class frmManageElections
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
        flpElections = new FlowLayoutPanel();
        lblManageElections = new Label();
        SuspendLayout();
        // 
        // flpElections
        // 
        flpElections.Location = new Point(12, 75);
        flpElections.Margin = new Padding(3, 4, 3, 4);
        flpElections.Name = "flpElections";
        flpElections.Size = new Size(1058, 684);
        flpElections.TabIndex = 0;
        // 
        // lblManageElections
        // 
        lblManageElections.AutoSize = true;
        lblManageElections.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblManageElections.Location = new Point(326, 9);
        lblManageElections.Name = "lblManageElections";
        lblManageElections.Size = new Size(394, 62);
        lblManageElections.TabIndex = 0;
        lblManageElections.Text = "Manage Elections";
        // 
        // frmManageElections
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1082, 853);
        Controls.Add(lblManageElections);
        Controls.Add(flpElections);
        Margin = new Padding(3, 4, 3, 4);
        Name = "frmManageElections";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Votify | Manage Elections";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private FlowLayoutPanel flpElections;
    private Label lblManageElections;
}