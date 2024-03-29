using System.Xml.Linq;
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
    private List<Candidate> _candidates = [];
    private List<Constituency> _constituencies = [];
    private List<Party> _parties = [];

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

    //Override show metho

    /// <summary>
    /// Custom init
    /// </summary>
    private void Init()
    {     
        if (_parties.Count == 0)
        {
            MessageBox.Show("There are no parties in the system. Please add a party before creating an election", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
        }

        ResetDatePickers();

        InitCandidateComboBoxes();

        foreach (ElectionVoteMechanism voteMechanism in Enum.GetValues(typeof(ElectionVoteMechanism)))
            cmbVoteMechanism.Items.Add(voteMechanism.ToString());

        lvCandidates.View = View.Details;
        lvCandidates.Columns.Add("Name");
        lvCandidates.Columns.Add("Party");
        lvCandidates.Columns.Add("Constituency");
    }

    /// <summary>
    /// Resets & inits the comboBoxes in add candidates section
    /// </summary>
    private void InitCandidateComboBoxes()
    {
        cmbCandidateParty.Items.Clear();
        cmbCandidateParty.DisplayMember = "Text";
        cmbCandidateParty.ValueMember = "Value";
        foreach (Party party in _parties)        
            cmbCandidateParty.Items.Add(new { Text = party.Name, Value = party.PartyId });        

        cmbCandidateConstituency.Items.Clear();
        cmbCandidateConstituency.DisplayMember = "Text";
        cmbCandidateConstituency.ValueMember = "Value";
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
    /// 
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

        _newElection = ElectionFactory.CreateElection(_currentVoteMechanism);
        cmbVoteMechanism.Enabled = false;
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

        Constituency constituencyToAdd = new(txtConstituencyName.Text, _newElection!.ElectionId);
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

        lvConstituencies.Items.Add(txtConstituencyName.Text);

        txtConstituencyName.Text = string.Empty;
    }

    /// <summary>
    /// Adds a candidate to the election as long they are valid and not already in the list
    /// </summary>
    private void cmbAddCandidate_Click(object sender, EventArgs e)
    {
        if (ValidateCandidateName() == false ||
            ValidateCandidateParty() == false || 
            ValidateCandidateConstituency() == false)
            return;

        string constituencyId = _constituencies.First(c => c.ConstituencyId == cmbCandidateConstituency.SelectedValue!.ToString()).ConstituencyId;
        string partyId = cmbCandidateParty.SelectedValue!.ToString()!;

        Candidate candidateToAdd = new (txtCandidateFirstName.Text, txtCandidateLastName.Text, constituencyId, partyId);

        ListViewItem item = new(candidateToAdd.FullName);
        item.SubItems.Add(candidateToAdd.PartyId).Tag = "PartyId"; // index 0
        item.SubItems.Add(constituencyId).Tag = "ConstituencyId"; // index 1
        
        lvCandidates.Items.Add(item);

        _dbService!.InsertEntity(candidateToAdd);
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
        ResetGlobals();
    }

    /// <summary>
    /// Clear every control on the form
    /// </summary>
    private void ClearAllControls()
    {
        foreach (TextBox tb in new List<TextBox> { txtCandidateFirstName, txtCandidateLastName, txtConstituencyName, txtElectionName})
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
        _parties.Clear();
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
        cmbCandidateConstituency.Items.Clear();

        foreach (Constituency co in _constituencies.OrderBy(c => c.ConstituencyName).ToList())
        {
            cmbCandidateConstituency.Items.Add(new { Text = co.ConstituencyName, Value = co.ConstituencyId });
        }
    }
}
