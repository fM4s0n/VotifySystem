﻿using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.Classes;
using VotifySystem.Common.Classes.Elections;
using VotifySystem.Common.DataAccess.Database;

namespace VotifySystem.InPerson.Forms;

/// <summary>
/// Form for registering to vote
/// Creates a new ElectionVoter object
/// </summary>
public partial class frmRegisterToVote : Form
{
    private readonly IUserService? _userService;
    private readonly IDbService? _dbService;

    private List<Election> _elections = [];
    private List<Constituency> _constituencies = [];
    private Voter? _voter;

    public frmRegisterToVote(IUserService userService, IDbService dbService)
    {
        InitializeComponent();

        if (DesignMode)
            return;

        _userService = userService;
        _dbService = dbService;

        Init();
    }

    /// <summary>
    /// Custom init
    /// </summary>
    private void Init()
    {
        if (_userService!.GetCurrentUserLevel() != UserLevel.Voter)
        {
            MessageBox.Show("You must be a voter to register to vote.", "Not a voter", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Close();
        }

        _voter = (Voter)_userService!.GetCurrentUser()!;

        _elections = _dbService!.GetDatabaseContext().Elections.Where(e => e.StartDate > DateTime.Now && e.Country == _voter.Country).ToList();
        _constituencies = _dbService!.GetDatabaseContext().Constituencies.Where(c => c.Country == _voter.Country).ToList();

        if (_elections.Count == 0)
        {
            MessageBox.Show("No elections available to register for.", "No elections", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Close();
        }

        ResetCmbElections();
        ResetCmbConstituencies();
    }

    /// <summary>
    /// Resets the combo box for elections with refreshed data
    /// </summary>
    private void ResetCmbElections()
    {
        cmbElections.DataSource = null;
        cmbElections.DisplayMember = "Description";
        cmbElections.ValueMember = "ElectionId";
        cmbElections.DataSource = _elections;
    }

    /// <summary>
    /// 
    /// </summary>
    private void ResetCmbConstituencies()
    {
        cmbConstituencies.DataSource = null;
        cmbConstituencies.DisplayMember = "Name";
        cmbConstituencies.ValueMember = "ConstituencyId";
        cmbConstituencies.DataSource = _constituencies;
    }

    /// <summary>
    /// Click event for registering to vote
    /// Created new ElectionVoter object
    /// </summary>
    private void btnRegister_Click(object sender, EventArgs e)
    {
        if (cmbElections.SelectedIndex == -1)
        {
            MessageBox.Show("Please select an election to register for.", "No election selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        string electionId = cmbElections.SelectedValue!.ToString()!;
        string voterId = _userService!.GetCurrentUser()!.Id;
        string constituencyId = cmbConstituencies.SelectedValue!.ToString()!;

        ElectionVoter electionVoter = new(electionId, voterId, constituencyId);

        _dbService!.InsertEntity(electionVoter);

        string electionDescription = _elections.First(e => e.ElectionId == electionId).Description;
        MessageBox.Show($"Successfully registered for {electionDescription}.", "Successfully Registered", MessageBoxButtons.OK, MessageBoxIcon.Information);
        Close();
    }
}