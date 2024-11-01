﻿namespace VotifySystem.InPerson.Forms;

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
        cmbDisplayOrder = new ComboBox();
        lblSortOrder = new Label();
        SuspendLayout();
        // 
        // flpElections
        // 
        flpElections.AutoScroll = true;
        flpElections.FlowDirection = FlowDirection.TopDown;
        flpElections.Location = new Point(10, 95);
        flpElections.Name = "flpElections";
        flpElections.Size = new Size(875, 535);
        flpElections.TabIndex = 0;
        // 
        // lblManageElections
        // 
        lblManageElections.AutoSize = true;
        lblManageElections.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblManageElections.Location = new Point(285, 7);
        lblManageElections.Name = "lblManageElections";
        lblManageElections.Size = new Size(310, 50);
        lblManageElections.TabIndex = 0;
        lblManageElections.Text = "Manage Elections";
        // 
        // cmbDisplayOrder
        // 
        cmbDisplayOrder.FormattingEnabled = true;
        cmbDisplayOrder.Location = new Point(702, 56);
        cmbDisplayOrder.Name = "cmbDisplayOrder";
        cmbDisplayOrder.Size = new Size(180, 23);
        cmbDisplayOrder.TabIndex = 1;
        cmbDisplayOrder.SelectedIndexChanged += cmbDisplayOrder_SelectedIndexChanged;
        // 
        // lblSortOrder
        // 
        lblSortOrder.AutoSize = true;
        lblSortOrder.Location = new Point(708, 37);
        lblSortOrder.Name = "lblSortOrder";
        lblSortOrder.Size = new Size(96, 15);
        lblSortOrder.TabIndex = 2;
        lblSortOrder.Text = "Select Sort order:";
        // 
        // frmManageElections
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(894, 641);
        Controls.Add(lblSortOrder);
        Controls.Add(cmbDisplayOrder);
        Controls.Add(lblManageElections);
        Controls.Add(flpElections);
        Name = "frmManageElections";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Votify | Manage Elections";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private FlowLayoutPanel flpElections;
    private Label lblManageElections;
    private ComboBox cmbDisplayOrder;
    private Label lblSortOrder;
}