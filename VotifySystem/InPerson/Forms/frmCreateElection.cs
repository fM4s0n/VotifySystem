﻿using VotifySystem.Common.BusinessLogic.Helpers;
using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.Classes;
using VotifySystem.Common.Classes.Elections;
using VotifySystem.Common.DataAccess.Database;

namespace VotifySystem.Forms;

/// <summary>
/// Form for an admin to create an election
/// </summary>>
public partial class frmCreateElection : Form
{
    private readonly IUserService? _userService;
    private readonly IDbService? _dbService;

    private ElectionVoteMechanism _currentVoteMechanism;
    private List<Candidate> _candidates = [];
    private List<Constituency> _constituencies = [];
    private List<Party> _parties = [];

    public frmCreateElection(IUserService userService, IDbService dbService)
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
        // pre-set dates
        dtpElectionStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 0, 0);
        dtpElectionEnd.Value = new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(1).Month, DateTime.Now.Day, 21, 0, 0);

        _parties = _dbService!.GetDatabaseContext().Parties.ToList();

        if (_parties.Count == 0)
        {
            MessageBox.Show("There are no parties in the system. Please add a party before creating an election", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
        }

        foreach (ElectionVoteMechanism voteMechanism in Enum.GetValues(typeof(ElectionVoteMechanism)))
            cmbVoteMechanism.Items.Add(voteMechanism.ToString());

        foreach (Party party in _parties)
            cmbParty.Items.Add(party.Name);

        lvCandidates.View = View.Details;
        lvCandidates.Columns.Add("Name");
        lvCandidates.Columns.Add("Party");
        lvCandidates.Columns.Add("Constituency");
    }

    /// <summary>
    /// Click event for the create button
    /// Validates all fields and creates the election
    /// </summary>
    private void btnCreate_Click(object sender, EventArgs e)
    {
        if (ValidateElection() == false)
            return;

        Election election = ElectionFactory.CreateElection(_currentVoteMechanism, txtElectionName.Text, dtpElectionStart.Value, dtpElectionEnd.Value, _userService!.GetCurrentUser()!);

        _dbService!.InsertEntity(election);
    }

    /// <summary>
    /// 
    /// </summary>
    private void btnCancel_Click(object sender, EventArgs e)
    {
        Close();
    }

    /// <summary>
    /// 
    /// </summary>
    private void cmbVoteMechanism_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Enum.TryParse(typeof(ElectionVoteMechanism), cmbVoteMechanism.SelectedItem!.ToString(), out object result))
        {
            _currentVoteMechanism = (ElectionVoteMechanism)result;
        }
    }

    /// <summary>
    /// Validates all fields on the form
    /// </summary>
    /// <returns>True if every field is valid, false if not</returns>
    private bool ValidateElection()
    {
        if (ValidateElectionTitle() &&
            ValidateComboBoxes() &&
            ValidateListViews() &&
            ValidateDates())
            return true;

        return false;
    }

    /// <summary>
    /// Validate the dates are in the future and the start date is before the end date
    /// </summary>
    /// <returns>true if all checks pass false if not</returns>
    private bool ValidateDates()
    {
        if (dtpElectionStart.Value < DateTime.Now)
        {
            MessageBox.Show("The start date must be in the future", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        if (dtpElectionStart.Value >= dtpElectionEnd.Value)
        {
            MessageBox.Show("The start date must be before the end date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private bool ValidateElectionTitle()
    {
        if (string.IsNullOrWhiteSpace(txtElectionName.Text))
        {
            txtElectionName.BackColor = Color.Red;
            return false;
        }

        txtElectionName.BackColor = Color.White;
        return true;
    }

    /// <summary>
    /// Validates all comboboxes on the form have a value
    /// </summary>
    /// <returns></returns>
    private bool ValidateComboBoxes()
    {
        bool success = true;
        foreach (ComboBox comboBox in new List<ComboBox> { cmbCountry, cmbVoteMechanism })
        {
            if (comboBox.SelectedIndex == -1)
            {
                comboBox.BackColor = Color.Red;
                success = false;
            }
        }

        return success;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private bool ValidateListViews()
    {
        bool success = true;
        foreach (ListView listView in new List<ListView> { lvConstituencies, lvCandidates })
        {
            if (listView.Items.Count == 0)
            {
                listView.BackColor = Color.Red;
                success = false;
            }
        }

        return success;
    }

    /// <summary>
    /// Adds a constituency to the election
    /// </summary>
    private void btnAddConstituency_Click(object sender, EventArgs e)
    {
        txtConstituencyName.Text = txtConstituencyName.Text.Trim();

        if (string.IsNullOrWhiteSpace(txtConstituencyName.Text))
        {
            MessageBox.Show("Please enter a constituency name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtConstituencyName.BackColor = Color.Red;
            return;
        }
        else
        {
            txtConstituencyName.BackColor = Color.White;
        }

        lvConstituencies.Items.Add(txtConstituencyName.Text);
        txtConstituencyName.Text = string.Empty;
    }

    /// <summary>
    /// Adds a candidate to the election as long they are valid and not already in the list
    /// </summary>
    private void cmbAddCandidate_Click(object sender, EventArgs e)
    {
        if (ValidateCandidateName() == false ||
            ValidateCandidateParty() == false)
        {
            //TODO
        }

        string constituencyId;
        string partyId;

        Candidate candidateToAdd = new Candidate(txtCandidateFirstName.Text, txtCandidateLastName.Text, constituencyId, partyId);

        ListViewItem item = new(candidateToAdd.FullName);
        item.SubItems.Add(candidateToAdd.PartyId);
        item.SubItems.Add(constituencyId);
        
        lvCandidates.Items.Add(item);

        _dbService!.InsertEntity(candidateToAdd);
    }

    private bool ValidateCandidateName()
    {
        if (string.IsNullOrWhiteSpace(txtCandidateFirstName.Text))
        {
            MessageBox.Show("Please enter a candidate name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtCandidateFirstName.BackColor = Color.Red;
            return false;
        }
        else
        {
            txtCandidateFirstName.BackColor = Color.White;
            return true;
        }
    }

    /// <summary>
    /// Validates the candidate party combobox
    /// </summary>
    /// <returns>True if a value is seleected false if not</returns>
    private bool ValidateCandidateParty()
    {
        if (cmbParty.SelectedIndex == -1)
        {
            MessageBox.Show("Please select a party", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            cmbParty.BackColor = Color.Red;
            return false;
        }
        else
        {
            cmbParty.BackColor = Color.White;
            return true;
        }
    }

    /// <summary>
    /// Loads parties based on the selected country
    /// </summary>
    private void cmbCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbCountry.SelectedIndex != -1 && cmbCountry.SelectedItem is Country selectedCountry)
        {
            _parties = _parties.Where(p => p.Country == selectedCountry).ToList();
        }

        // Disable the comboBox so the country cant be changed as we now load in the parties based on country
        // User must reset the form and start again if they wish to change the country
        cmbCountry.Enabled = false;
    }

    /// <summary>
    /// Reset the form by clearing all the controls
    /// </summary>
    private void btnReset_Click(object sender, EventArgs e)
    {
        ClearAllControls();
    }

    /// <summary>
    /// Clear every control on the form
    /// </summary>
    private void ClearAllControls()
    {
        //TODO
    }

    /// <summary>
    /// 
    /// </summary>
    private void btnRemoveCandidate_Click(object sender, EventArgs e)
    {
        Candidate candidateToDelete = _candidates.FirstOrDefault(c => c.)
    }

    /// <summary>
    /// 
    /// </summary>
    private void btnRemoveConstituency_Click(object sender, EventArgs e)
    {

    }
}
