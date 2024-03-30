namespace VotifySystem.InPerson.Forms;

partial class frmManageParties
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
        lvParties = new ListView();
        grpAddParty = new GroupBox();
        btnAddParty = new Button();
        txtPartyName = new TextBox();
        lblManageParties = new Label();
        cmbCountry = new ComboBox();
        btnRemoveParty = new Button();
        btnGo = new Button();
        grpSelectCountry = new GroupBox();
        grpParties = new GroupBox();
        btnClose = new Button();
        grpAddParty.SuspendLayout();
        grpSelectCountry.SuspendLayout();
        grpParties.SuspendLayout();
        SuspendLayout();
        // 
        // lvParties
        // 
        lvParties.GridLines = true;
        lvParties.Location = new Point(6, 22);
        lvParties.MultiSelect = false;
        lvParties.Name = "lvParties";
        lvParties.Size = new Size(358, 343);
        lvParties.TabIndex = 0;
        lvParties.UseCompatibleStateImageBehavior = false;
        // 
        // grpAddParty
        // 
        grpAddParty.Controls.Add(btnAddParty);
        grpAddParty.Controls.Add(txtPartyName);
        grpAddParty.Location = new Point(12, 174);
        grpAddParty.Name = "grpAddParty";
        grpAddParty.Size = new Size(370, 98);
        grpAddParty.TabIndex = 1;
        grpAddParty.TabStop = false;
        grpAddParty.Text = "Add New Party";
        grpAddParty.Visible = false;
        // 
        // btnAddParty
        // 
        btnAddParty.Enabled = false;
        btnAddParty.Location = new Point(289, 64);
        btnAddParty.Name = "btnAddParty";
        btnAddParty.Size = new Size(75, 23);
        btnAddParty.TabIndex = 1;
        btnAddParty.Text = "Add Party";
        btnAddParty.UseVisualStyleBackColor = true;
        btnAddParty.Click += btnAddParty_Click;
        // 
        // txtPartyName
        // 
        txtPartyName.Enabled = false;
        txtPartyName.Location = new Point(6, 35);
        txtPartyName.Name = "txtPartyName";
        txtPartyName.Size = new Size(358, 23);
        txtPartyName.TabIndex = 0;
        // 
        // lblManageParties
        // 
        lblManageParties.AutoSize = true;
        lblManageParties.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblManageParties.Location = new Point(45, 9);
        lblManageParties.Name = "lblManageParties";
        lblManageParties.Size = new Size(274, 50);
        lblManageParties.TabIndex = 0;
        lblManageParties.Text = "Manage Parties";
        // 
        // cmbCountry
        // 
        cmbCountry.FormattingEnabled = true;
        cmbCountry.Location = new Point(6, 22);
        cmbCountry.Name = "cmbCountry";
        cmbCountry.Size = new Size(358, 23);
        cmbCountry.TabIndex = 2;
        // 
        // btnRemoveParty
        // 
        btnRemoveParty.Location = new Point(223, 371);
        btnRemoveParty.Name = "btnRemoveParty";
        btnRemoveParty.Size = new Size(141, 23);
        btnRemoveParty.TabIndex = 4;
        btnRemoveParty.Text = "Remove Selected Party";
        btnRemoveParty.UseVisualStyleBackColor = true;
        btnRemoveParty.Visible = false;
        btnRemoveParty.Click += btnRemoveParty_Click;
        // 
        // btnGo
        // 
        btnGo.Location = new Point(289, 51);
        btnGo.Name = "btnGo";
        btnGo.Size = new Size(75, 23);
        btnGo.TabIndex = 2;
        btnGo.Text = "Go";
        btnGo.UseVisualStyleBackColor = true;
        btnGo.Click += btnGo_Click;
        // 
        // grpSelectCountry
        // 
        grpSelectCountry.Controls.Add(btnGo);
        grpSelectCountry.Controls.Add(cmbCountry);
        grpSelectCountry.Location = new Point(12, 71);
        grpSelectCountry.Name = "grpSelectCountry";
        grpSelectCountry.Size = new Size(370, 83);
        grpSelectCountry.TabIndex = 5;
        grpSelectCountry.TabStop = false;
        grpSelectCountry.Text = "Select Country";
        // 
        // grpParties
        // 
        grpParties.Controls.Add(btnRemoveParty);
        grpParties.Controls.Add(lvParties);
        grpParties.Location = new Point(12, 278);
        grpParties.Name = "grpParties";
        grpParties.Size = new Size(370, 400);
        grpParties.TabIndex = 6;
        grpParties.TabStop = false;
        grpParties.Text = "Parties";
        // 
        // btnClose
        // 
        btnClose.Location = new Point(247, 695);
        btnClose.Name = "btnClose";
        btnClose.Size = new Size(141, 23);
        btnClose.TabIndex = 7;
        btnClose.Text = "Save and Close";
        btnClose.UseVisualStyleBackColor = true;
        btnClose.Click += btnClose_Click;
        // 
        // frmManageParties
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(400, 730);
        Controls.Add(btnClose);
        Controls.Add(grpParties);
        Controls.Add(grpSelectCountry);
        Controls.Add(lblManageParties);
        Controls.Add(grpAddParty);
        Name = "frmManageParties";
        Text = "frmCreateParty";
        StartPosition = FormStartPosition.CenterScreen;
        grpAddParty.ResumeLayout(false);
        grpAddParty.PerformLayout();
        grpSelectCountry.ResumeLayout(false);
        grpParties.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private ListView lvParties;
    private GroupBox grpAddParty;
    private Label lblManageParties;
    private Button btnAddParty;
    private TextBox txtPartyName;
    private ComboBox cmbCountry;
    private Button btnRemoveParty;
    private Button btnGo;
    private GroupBox grpSelectCountry;
    private GroupBox grpParties;
    private Button btnClose;
}