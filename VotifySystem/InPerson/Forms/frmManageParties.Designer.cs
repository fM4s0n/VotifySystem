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
        listView1 = new ListView();
        grpAddParty = new GroupBox();
        btnAddParty = new Button();
        textBox1 = new TextBox();
        lblManageParties = new Label();
        cmbCountry = new ComboBox();
        lblSelectCountry = new Label();
        btnRemoveParty = new Button();
        btnViewParties = new Button();
        grpAddParty.SuspendLayout();
        SuspendLayout();
        // 
        // listView1
        // 
        listView1.Location = new Point(403, 103);
        listView1.Name = "listView1";
        listView1.Size = new Size(385, 303);
        listView1.TabIndex = 0;
        listView1.UseCompatibleStateImageBehavior = false;
        listView1.Visible = false;
        // 
        // grpAddParty
        // 
        grpAddParty.Controls.Add(btnAddParty);
        grpAddParty.Controls.Add(textBox1);
        grpAddParty.Location = new Point(12, 205);
        grpAddParty.Name = "grpAddParty";
        grpAddParty.Size = new Size(370, 98);
        grpAddParty.TabIndex = 1;
        grpAddParty.TabStop = false;
        grpAddParty.Text = "Add New Party";
        grpAddParty.Visible = false;
        // 
        // btnAddParty
        // 
        btnAddParty.Location = new Point(289, 64);
        btnAddParty.Name = "btnAddParty";
        btnAddParty.Size = new Size(75, 23);
        btnAddParty.TabIndex = 1;
        btnAddParty.Text = "Add Party";
        btnAddParty.UseVisualStyleBackColor = true;
        // 
        // textBox1
        // 
        textBox1.Location = new Point(6, 35);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(358, 23);
        textBox1.TabIndex = 0;
        // 
        // lblManageParties
        // 
        lblManageParties.AutoSize = true;
        lblManageParties.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblManageParties.Location = new Point(236, 9);
        lblManageParties.Name = "lblManageParties";
        lblManageParties.Size = new Size(274, 50);
        lblManageParties.TabIndex = 0;
        lblManageParties.Text = "Manage Parties";
        // 
        // cmbCountry
        // 
        cmbCountry.FormattingEnabled = true;
        cmbCountry.Location = new Point(12, 103);
        cmbCountry.Name = "cmbCountry";
        cmbCountry.Size = new Size(370, 23);
        cmbCountry.TabIndex = 2;
        // 
        // lblSelectCountry
        // 
        lblSelectCountry.AutoSize = true;
        lblSelectCountry.Location = new Point(12, 85);
        lblSelectCountry.Name = "lblSelectCountry";
        lblSelectCountry.Size = new Size(84, 15);
        lblSelectCountry.TabIndex = 3;
        lblSelectCountry.Text = "Select Country";
        // 
        // btnRemoveParty
        // 
        btnRemoveParty.Location = new Point(632, 416);
        btnRemoveParty.Name = "btnRemoveParty";
        btnRemoveParty.Size = new Size(156, 23);
        btnRemoveParty.TabIndex = 4;
        btnRemoveParty.Text = "Remove Selected Party";
        btnRemoveParty.UseVisualStyleBackColor = true;
        btnRemoveParty.Visible = false;
        btnRemoveParty.Click += btnRemoveParty_Click;
        // 
        // btnViewParties
        // 
        btnViewParties.Location = new Point(277, 132);
        btnViewParties.Name = "btnViewParties";
        btnViewParties.Size = new Size(105, 23);
        btnViewParties.TabIndex = 2;
        btnViewParties.Text = "Go";
        btnViewParties.UseVisualStyleBackColor = true;
        // 
        // frmManageParties
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(btnViewParties);
        Controls.Add(btnRemoveParty);
        Controls.Add(lblSelectCountry);
        Controls.Add(cmbCountry);
        Controls.Add(lblManageParties);
        Controls.Add(grpAddParty);
        Controls.Add(listView1);
        Name = "frmManageParties";
        Text = "frmCreateParty";
        grpAddParty.ResumeLayout(false);
        grpAddParty.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private ListView listView1;
    private GroupBox grpAddParty;
    private Label lblManageParties;
    private Button btnAddParty;
    private TextBox textBox1;
    private ComboBox cmbCountry;
    private Label lblSelectCountry;
    private Button btnRemoveParty;
    private Button btnViewParties;
}