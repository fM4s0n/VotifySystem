namespace VotifySystem.InPerson.Forms;

partial class frmViewElectionResults
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
        lblViewresults = new Label();
        flpResults = new FlowLayoutPanel();
        cmbViewMode = new ComboBox();
        label1 = new Label();
        btnSelectViewModeGo = new Button();
        SuspendLayout();
        // 
        // lblViewresults
        // 
        lblViewresults.AutoSize = true;
        lblViewresults.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblViewresults.Location = new Point(326, 9);
        lblViewresults.Name = "lblViewresults";
        lblViewresults.Size = new Size(497, 50);
        lblViewresults.TabIndex = 1;
        lblViewresults.Text = "View Results - Election Name";
        // 
        // flpResults
        // 
        flpResults.AutoScroll = true;
        flpResults.Location = new Point(12, 116);
        flpResults.Name = "flpResults";
        flpResults.Size = new Size(1100, 633);
        flpResults.TabIndex = 2;
        // 
        // cmbViewMode
        // 
        cmbViewMode.FormattingEnabled = true;
        cmbViewMode.Location = new Point(749, 89);
        cmbViewMode.Name = "cmbViewMode";
        cmbViewMode.Size = new Size(281, 23);
        cmbViewMode.TabIndex = 3;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(749, 71);
        label1.Name = "label1";
        label1.Size = new Size(100, 15);
        label1.TabIndex = 4;
        label1.Text = "Select View mode";
        // 
        // btnSelectViewModeGo
        // 
        btnSelectViewModeGo.Location = new Point(1036, 88);
        btnSelectViewModeGo.Name = "btnSelectViewModeGo";
        btnSelectViewModeGo.Size = new Size(75, 23);
        btnSelectViewModeGo.TabIndex = 5;
        btnSelectViewModeGo.Text = "Go";
        btnSelectViewModeGo.UseVisualStyleBackColor = true;
        btnSelectViewModeGo.Click += btnSelectViewModeGo_Click;
        // 
        // frmViewElectionResults
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1123, 761);
        Controls.Add(btnSelectViewModeGo);
        Controls.Add(label1);
        Controls.Add(cmbViewMode);
        Controls.Add(flpResults);
        Controls.Add(lblViewresults);
        Name = "frmViewElectionResults";
        Text = "Votify | View Results";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblViewresults;
    private FlowLayoutPanel flpResults;
    private ComboBox cmbViewMode;
    private Label label1;
    private Button btnSelectViewModeGo;
}