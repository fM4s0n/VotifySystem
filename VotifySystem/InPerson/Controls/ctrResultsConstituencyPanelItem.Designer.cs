namespace VotifySystem.InPerson.Controls;

partial class ctrResultsConstituencyPanelItem
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
        lblConstituencyName = new Label();
        dgvCandidates = new DataGridView();
        ((System.ComponentModel.ISupportInitialize)dgvCandidates).BeginInit();
        SuspendLayout();
        // 
        // lblConstituencyName
        // 
        lblConstituencyName.AutoSize = true;
        lblConstituencyName.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblConstituencyName.Location = new Point(0, 0);
        lblConstituencyName.Name = "lblConstituencyName";
        lblConstituencyName.Size = new Size(484, 32);
        lblConstituencyName.TabIndex = 0;
        lblConstituencyName.Text = "This is a very long description for testing";
        // 
        // dgvCandidates
        // 
        dgvCandidates.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        dgvCandidates.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        dgvCandidates.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvCandidates.Location = new Point(3, 35);
        dgvCandidates.Name = "dgvCandidates";
        dgvCandidates.Size = new Size(524, 182);
        dgvCandidates.TabIndex = 1;
        // 
        // ctrViewResultsConstituencyPanelItem
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(dgvCandidates);
        Controls.Add(lblConstituencyName);
        Name = "ctrViewResultsConstituencyPanelItem";
        Size = new Size(539, 220);
        ((System.ComponentModel.ISupportInitialize)dgvCandidates).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblConstituencyName;
    private DataGridView dgvCandidates;
}
