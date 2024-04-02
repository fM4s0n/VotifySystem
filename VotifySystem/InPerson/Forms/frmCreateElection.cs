using VotifySystem.Common.BusinessLogic.Helpers;
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

    private Election? _newElection;
    private ElectionVoteMechanism _currentVoteMechanism = ElectionVoteMechanism.FPTP;
    private readonly List<Candidate> _candidates = [];
    private readonly List<Constituency> _constituencies = [];
    private List<Party> _allParties = [];

    public frmCreateElection(IUserService userService, IDbService dbService)
    {
        InitializeComponent();

        if (DesignMode)
            return;

        //Listen to form.show event
        this.Load += (sender, e) => { Init(); };

        _userService = userService;
        _dbService = dbService;
    }


    /// <summary>
    /// Custom init
    /// </summary>
    private void Init()
    {
        _allParties = _dbService!.GetDatabaseContext().Parties.ToList();

        if (_allParties.Count == 0)
        {
            MessageBox.Show("There are no parties in the system. Please add a party before creating an election", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
        }

        ResetDatePickers();

        foreach (ElectionVoteMechanism voteMechanism in Enum.GetValues(typeof(ElectionVoteMechanism)))
            cmbVoteMechanism.Items.Add(voteMechanism.ToString());

        foreach (Country country in Enum.GetValues(typeof(Country)))
            cmbCountry.Items.Add(country);

        InitLvCandidates();
        InitLvConstituencies();
    }

    /// <summary>
    /// Inits the lvCandidates ListView
    /// </summary>
    private void InitLvCandidates()
    {
        lvCandidates.View = View.Details;
        lvCandidates.Columns.Add("Name", lvCandidates.Width / 3, HorizontalAlignment.Left);
        lvCandidates.Columns.Add("Party", lvCandidates.Width / 3, HorizontalAlignment.Left);
        lvCandidates.Columns.Add("Constituency", lvCandidates.Width / 3, HorizontalAlignment.Left);      
    }

    private void InitLvConstituencies()
    {
        lvConstituencies.View = View.Details;
        lvConstituencies.Columns.Add("Constituency Name", lvConstituencies.Width);
    }

    /// <summary>
    /// Resets & inits the comboBoxes in add candidates section
    /// </summary>
    private void InitCandidateComboBoxes()
    {
        if (cmbCountry.SelectedItem == null)
            return;

        cmbCandidateParty.DisplayMember = "Name";
        cmbCandidateParty.ValueMember = "PartyId";
        cmbCandidateParty.DataSource = _allParties.Where(p => p.Country == (Country)cmbCountry.SelectedItem).ToList();

        RefreshCmbCandidateConstituency();
    }

    /// <summary>
    /// reset the date pickers to standard value
    /// </summary>
    private void ResetDatePickers()
    {
        dtpElectionStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 0, 0);
        dtpElectionEnd.Value = new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(1).Month, DateTime.Now.Day, 21, 0, 0);
    }

    /// <summary>
    /// Click event for the create button
    /// Validates all fields and creates the election
    /// </summary>
    private void btnCreate_Click(object sender, EventArgs e)
    {
        if (ValidateElection() == false)
            return;

        _newElection!.StartDate = dtpElectionStart.Value;
        _newElection.EndDate = dtpElectionEnd.Value;
        _newElection.Description = txtElectionName.Text;
        _newElection.ElectionAdministratorId = _userService!.GetCurrentUser()!.Id;

        _dbService!.InsertEntity(_newElection);

        //insert all candidates
        foreach (Candidate candidate in _candidates)
        {
            _dbService.InsertEntity(candidate);
        }

        //insert all constituencies
        foreach (Constituency constituency in _constituencies)
        {
            _dbService.InsertEntity(constituency);
        }
    }

    /// <summary>
    /// Close the form
    /// </summary>
    private void btnCancel_Click(object sender, EventArgs e)
    {
        Close();
    }

    /// <summary>
    /// selects the vote mechanism
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
    /// Validates the election title text box
    /// </summary>
    /// <returns>true if it is not nullOrWhiteSpace, false if it is</returns>
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
    /// Validates all ComboBoxes on the form have a value
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
    /// Validates that the listViews have items in them
    /// </summary>
    /// <returns>True if all ListViews have at least 1 item in them, false if not</returns>
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

        Constituency constituencyToAdd = new(txtConstituencyName.Text, _newElection!.ElectionId, (Country)cmbCountry.SelectedItem!);
        AddConstituency(constituencyToAdd);
    }

    /// <summary>
    /// Add a new constituency to _constituencies, lvConstituencies and cmbCandidateConstituency
    /// </summary>
    /// <param name="constituency">Constituency to be added</param>
    private void AddConstituency(Constituency constituency)
    {
        _constituencies.Add(constituency);

        ListViewItem lvi = new(constituency.ConstituencyName);
        lvi.SubItems.Add(constituency.ConstituencyId);// 0 index
        lvi.SubItems.Add(constituency.ElectionId); // 1 index

        lvConstituencies.Items.Add(lvi);

        txtConstituencyName.Text = string.Empty;

        RefreshCmbCandidateConstituency();
    }

    /// <summary>
    /// Adds a candidate to the election as long they are valid and not already in the list
    /// </summary>
    private void cmbAddCandidate_Click(object sender, EventArgs e)
    {
        if (IsValidCandidate() == false)
            return;

        string constituencyId = GetSelectedConstituencyId();
        string partyId = GetSelectedPartyId();

        Candidate candidateToAdd = CreateCandidate(constituencyId, partyId);

        AddCandidateToListView(candidateToAdd);

        _dbService!.InsertEntity(candidateToAdd);

        // TODO: Add error message if candidate already exists

        // TODO: add column to lvConstituencies to show the number of candidates in each constituency
    }

    /// <summary>
    /// Validates candidate to be added to the election
    /// </summary>
    /// <returns>True if name, party and constituency are all valid, false if not</returns>
    private bool IsValidCandidate()
    {
        return ValidateCandidateName() && ValidateCandidateParty() && ValidateCandidateConstituency();
    }

    /// <summary>
    /// Gets the selected constituencyId from cmbCandidateConstituency
    /// </summary>
    /// <returns>string of constituencyId of the selected constituency</returns>
    private string GetSelectedConstituencyId()
    {
        return _constituencies.First(c => c.ConstituencyId == cmbCandidateConstituency.SelectedValue.ToString()).ConstituencyId;
    }

    /// <summary>
    /// gets the selected partyId from cmbCandidateParty
    /// </summary>
    /// <returns>string of partyId of selected party</returns>
    private string GetSelectedPartyId()
    {
        return cmbCandidateParty.SelectedValue!.ToString()!;
    }

    /// <summary>
    /// Creates a new candidate object
    /// </summary>
    /// <param name="constituencyId">constituencyId</param>
    /// <param name="partyId">PartyId</param>
    /// <returns>New Candidate object</returns>
    private Candidate CreateCandidate(string constituencyId, string partyId)
    {
        return new Candidate(txtCandidateFirstName.Text, txtCandidateLastName.Text, constituencyId, partyId, _newElection!.ElectionId);
    }

    /// <summary>
    /// Adds a candidate to the lvCandidates ListView
    /// </summary>
    /// <param name="candidate">candidate to be added</param>
    private void AddCandidateToListView(Candidate candidate)
    {
        string partyName = _allParties.First(p => p.PartyId == candidate.PartyId).Name;
        string constituencyName = _constituencies.First(c => c.ConstituencyId == candidate.ConstituencyId).ConstituencyName;

        ListViewItem item = new(candidate.FullName);
        item.SubItems.Add(partyName); // index 0
        item.SubItems[0].Tag = candidate.PartyId;
        item.SubItems.Add(constituencyName); // index 1
        item.SubItems[1].Tag = candidate.ConstituencyId;

        lvCandidates.Items.Add(item);
    }

    /// <summary>
    /// Validates a constituency has been selected
    /// </summary>
    /// <returns>True if an index is not -1, false if it is -1</returns>
    private bool ValidateCandidateConstituency()
    {
        return cmbCandidateConstituency.SelectedIndex != -1;
    }

    /// <summary>
    /// Validates the candidate name text boxes
    /// </summary>
    /// <returns>true if both name textboxes hare not nullOrWhiteSpace, false if not</returns>
    private bool ValidateCandidateName()
    {
        bool success = true;

        foreach (TextBox tb in new List<TextBox> { txtCandidateFirstName, txtCandidateLastName })
        {
            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                MessageBox.Show("Please enter a candidate name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb.BackColor = Color.Red;
                success = false;
            }
            else
            {
                tb.BackColor = Color.White;
            }
        }

        return success;
    }

    /// <summary>
    /// Validates the candidate party ComboBox
    /// </summary>
    /// <returns>True if a value is selected false if not</returns>
    private bool ValidateCandidateParty()
    {
        if (cmbCandidateParty.SelectedIndex == -1)
        {
            MessageBox.Show("Please select a party", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            cmbCandidateParty.BackColor = Color.Red;
            return false;
        }
        else
        {
            cmbCandidateParty.BackColor = Color.White;
            return true;
        }
    }

    /// <summary>
    /// Loads parties into cmbCandidateParty based on the selected country
    /// </summary>
    private void cmbCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        cmbCandidateParty.Items.Clear();

        if (cmbCountry.SelectedIndex != -1 && cmbCountry.SelectedItem is Country selectedCountry)
        {
            foreach (Party p in _allParties.Where(p => p.Country == selectedCountry).ToList())
            {
                cmbCandidateParty.Items.Add(new { Text = p.Name, Value = p.PartyId });
            }
        }

    }

    /// <summary>
    /// Reset the form by clearing all the controls
    /// </summary>
    private void btnReset_Click(object sender, EventArgs e)
    {
        ClearAllControls();
        ResetGlobals();
    }

    /// <summary>
    /// Clear every control on the form
    /// </summary>
    private void ClearAllControls()
    {
        foreach (TextBox tb in new List<TextBox> { txtCandidateFirstName, txtCandidateLastName, txtConstituencyName, txtElectionName })
            tb.Clear();

        foreach (ComboBox cb in new List<ComboBox> { cmbCandidateParty, cmbCandidateConstituency, cmbCountry, cmbVoteMechanism })
            cb.SelectedIndex = -1;

        ResetDatePickers();

        lvCandidates.Items.Clear();
        lvConstituencies.Items.Clear();
    }

    /// <summary>
    /// Reset global variables 
    /// </summary>
    private void ResetGlobals()
    {
        _allParties.Clear();
        _candidates.Clear();
        _constituencies.Clear();
        _currentVoteMechanism = ElectionVoteMechanism.FPTP;
    }

    /// <summary>
    /// remove selected candidate from lvCandidates
    /// </summary>
    private void btnRemoveCandidate_Click(object sender, EventArgs e)
    {
        Candidate candidateToDelete = _candidates.First(c => c.Id == lvCandidates.SelectedItems[0].SubItems[1].Text);

        if (candidateToDelete != null)
        {
            _candidates.Remove(candidateToDelete);
            lvCandidates.Items.Remove(lvCandidates.SelectedItems[0]);
        }
    }

    /// <summary>
    /// Remove selected constituency
    /// </summary>
    private void btnRemoveConstituency_Click(object sender, EventArgs e)
    {
        Constituency constituencyToDelete = _constituencies.First(c => c.ConstituencyId == lvConstituencies.SelectedItems[0].SubItems[1].Text);

        if (constituencyToDelete != null)
        {
            _constituencies.Remove(constituencyToDelete);
            lvConstituencies.Items.Remove(lvConstituencies.SelectedItems[0]);
            RefreshCmbCandidateConstituency();
        }
        else
        {
            MessageBox.Show("Error removing constituency, please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// refreshes the data in cmbCandidateConstituency
    /// </summary>
    private void RefreshCmbCandidateConstituency()
    {
        cmbCandidateConstituency.DataSource = null;
        cmbCandidateConstituency.DisplayMember = "ConstituencyName";
        cmbCandidateConstituency.ValueMember = "ConstituencyId";
        cmbCandidateConstituency.DataSource = _constituencies;
    }

    /// <summary>
    /// Initialises the election after validating the election details section
    /// </summary>
    private void btnInitialiseElection_Click(object sender, EventArgs e)
    {
        if (ValidateComboBoxes() == false)
        {
            // TODO: Add error message
            return;
        }

        _newElection = ElectionFactory.CreateElection(_currentVoteMechanism, (Country)cmbCountry.SelectedItem!);

        _newElection!.StartDate = dtpElectionStart.Value;
        _newElection.EndDate = dtpElectionEnd.Value;
        _newElection.Description = txtElectionName.Text;
        _newElection.ElectionAdministratorId = _userService!.GetCurrentUser()!.Id;

        InitCandidateComboBoxes();

        DisableElectionDetailsComboBoxes();
        EnableFullForm();
    }

    /// <summary>
    /// Enable rest of the form after the election details have been set
    /// </summary>
    private void EnableFullForm()
    {
        txtConstituencyName.Enabled = true;
        btnAddConstituency.Enabled = true;
        lvConstituencies.Enabled = true;
        btnRemoveConstituency.Enabled = true;
        txtCandidateFirstName.Enabled = true;
        txtCandidateLastName.Enabled = true;
        cmbCandidateConstituency.Enabled = true;
        cmbCandidateParty.Enabled = true;
        btnAddCandidate.Enabled = true;
        lvCandidates.Enabled = true;
        btnRemoveCandidate.Enabled = true;
    }

    /// <summary>
    /// Disable the election details comboBoxes
    /// </summary>
    private void DisableElectionDetailsComboBoxes()
    {
        cmbCountry.Enabled = false;
        cmbVoteMechanism.Enabled = false;
    }
}
