namespace VotifySystem.InPerson.Controls;

partial class ctrManageElectionPanelItem
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
        lblElectionDescription = new Label();
        btnViewResults = new Button();
        btnElectionDetails = new Button();
        lblStatus = new Label();
        lblRegisteredCandidates = new Label();
        label1 = new Label();
        label2 = new Label();
        lblRegisteredCandidatesValue = new Label();
        lblTotalConstituenciesValue = new Label();
        lblRegisteredVotersValue = new Label();
        lblElectionCountry = new Label();
        SuspendLayout();
        // 
        // lblElectionDescription
        // 
        lblElectionDescription.AutoSize = true;
        lblElectionDescription.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblElectionDescription.Location = new Point(3, 0);
        lblElectionDescription.Name = "lblElectionDescription";
        lblElectionDescription.Size = new Size(665, 37);
        lblElectionDescription.TabIndex = 0;
        lblElectionDescription.Text = "This is a very long description for testing purposes";
        // 
        // btnViewResults
        // 
        btnViewResults.Location = new Point(698, 95);
        btnViewResults.Name = "btnViewResults";
        btnViewResults.Size = new Size(158, 23);
        btnViewResults.TabIndex = 1;
        btnViewResults.Text = "View Election Results";
        btnViewResults.UseVisualStyleBackColor = true;
        btnViewResults.Click += btnViewResults_Click;
        // 
        // btnElectionDetails
        // 
        btnElectionDetails.Location = new Point(698, 66);
        btnElectionDetails.Name = "btnElectionDetails";
        btnElectionDetails.Size = new Size(158, 23);
        btnElectionDetails.TabIndex = 2;
        btnElectionDetails.Text = "Manage Election Details";
        btnElectionDetails.UseVisualStyleBackColor = true;
        btnElectionDetails.Click += btnElectionDetails_Click;
        // 
        // lblStatus
        // 
        lblStatus.AutoSize = true;
        lblStatus.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblStatus.Location = new Point(-1, 86);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(164, 30);
        lblStatus.TabIndex = 3;
        lblStatus.Text = "lblElectionStatus";
        // 
        // lblRegisteredCandidates
        // 
        lblRegisteredCandidates.AutoSize = true;
        lblRegisteredCandidates.Location = new Point(323, 50);
        lblRegisteredCandidates.Name = "lblRegisteredCandidates";
        lblRegisteredCandidates.Size = new Size(127, 15);
        lblRegisteredCandidates.TabIndex = 4;
        lblRegisteredCandidates.Text = "Registered Candidates:";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(323, 75);
        label1.Name = "label1";
        label1.Size = new Size(116, 15);
        label1.TabIndex = 5;
        label1.Text = "Total Constituencies:";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(323, 100);
        label2.Name = "label2";
        label2.Size = new Size(100, 15);
        label2.TabIndex = 6;
        label2.Text = "Registered Voters:";
        // 
        // lblRegisteredCandidatesValue
        // 
        lblRegisteredCandidatesValue.AutoSize = true;
        lblRegisteredCandidatesValue.Location = new Point(456, 50);
        lblRegisteredCandidatesValue.Name = "lblRegisteredCandidatesValue";
        lblRegisteredCandidatesValue.Size = new Size(162, 15);
        lblRegisteredCandidatesValue.TabIndex = 7;
        lblRegisteredCandidatesValue.Text = "lblRegisteredCandidatesValue";
        // 
        // lblTotalConstituenciesValue
        // 
        lblTotalConstituenciesValue.AutoSize = true;
        lblTotalConstituenciesValue.Location = new Point(456, 75);
        lblTotalConstituenciesValue.Name = "lblTotalConstituenciesValue";
        lblTotalConstituenciesValue.Size = new Size(151, 15);
        lblTotalConstituenciesValue.TabIndex = 8;
        lblTotalConstituenciesValue.Text = "lblTotalConstituenciesValue";
        // 
        // lblRegisteredVotersValue
        // 
        lblRegisteredVotersValue.AutoSize = true;
        lblRegisteredVotersValue.Location = new Point(456, 100);
        lblRegisteredVotersValue.Name = "lblRegisteredVotersValue";
        lblRegisteredVotersValue.Size = new Size(135, 15);
        lblRegisteredVotersValue.TabIndex = 9;
        lblRegisteredVotersValue.Text = "lblRegisteredVotersValue";
        // 
        // lblElectionCountry
        // 
        lblElectionCountry.AutoSize = true;
        lblElectionCountry.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblElectionCountry.Location = new Point(2, 50);
        lblElectionCountry.Name = "lblElectionCountry";
        lblElectionCountry.Size = new Size(181, 30);
        lblElectionCountry.TabIndex = 10;
        lblElectionCountry.Text = "lblElectionCountry";
        // 
        // ctrManageElectionPanelItem
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(lblElectionCountry);
        Controls.Add(lblRegisteredVotersValue);
        Controls.Add(lblTotalConstituenciesValue);
        Controls.Add(lblRegisteredCandidatesValue);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(lblRegisteredCandidates);
        Controls.Add(lblStatus);
        Controls.Add(btnElectionDetails);
        Controls.Add(btnViewResults);
        Controls.Add(lblElectionDescription);
        Name = "ctrManageElectionPanelItem";
        Size = new Size(860, 121);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblElectionDescription;
    private Button btnViewResults;
    private Button btnElectionDetails;
    private Label lblStatus;
    private Label lblRegisteredCandidates;
    private Label label1;
    private Label label2;
    private Label lblRegisteredCandidatesValue;
    private Label lblTotalConstituenciesValue;
    private Label lblRegisteredVotersValue;
    private Label lblElectionCountry;
}
