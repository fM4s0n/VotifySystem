using VotifySystem.Common.BusinessLogic.Helpers;
using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.Models;
using VotifySystem.Common.Models.Elections;
using VotifySystem.Common.DataAccess.Database;

namespace VotifySystem.InPerson.Forms;

/// <summary>
/// Form to view and add parties to a country
/// </summary>
public partial class frmManageParties : Form
{
    private readonly IDbService? _dbService;
    private readonly IElectionService? _electionService;

    List<Party> _parties = [];

    public frmManageParties(IDbService dbService)
    {
        InitializeComponent();

        if (DesignMode)
            return;

        _dbService = Program.ServiceProvider!.GetService(typeof(IDbService)) as IDbService;
        _electionService = Program.ServiceProvider!.GetService(typeof(IElectionService)) as IElectionService;

        Init();
    }

    /// <summary>
    /// Custom init
    /// </summary>
    private void Init()
    {
        foreach (Country c in Enum.GetValues(typeof(Country)))
            cmbCountry.Items.Add(c);

        InitListView();
    }

    private void InitListView()
    {
        lvParties.View = View.Details;
        lvParties.Columns.Add("Party", lvParties.Width - 2);
        lvParties.GridLines = true;
    }

    /// <summary>
    /// Deletes the party from the db and refreshes the list view and _parties
    /// </summary>
    private void btnRemoveParty_Click(object sender, EventArgs e)
    {
        if (lvParties.SelectedItems.Count == 0)
            return;

        // Multiselect disabled so able to hardcode lvParties.SelectedItems[0]
        Party partyToDelete = _parties.First(p => p.Name == lvParties.SelectedItems[0].Text);

        if (ValidatePartyDeletion(partyToDelete) == false)
            return;

        lvParties.Items.Remove(lvParties.SelectedItems[0]);
        _parties.Remove(partyToDelete);

        _dbService!.DeleteEntity(partyToDelete);
    }

    /// <summary>
    /// validate the party can be deleted
    /// </summary>
    /// <param name="partyToDelete"></param>
    /// <returns>True if passed validation checks, false if not</returns>
    private bool ValidatePartyDeletion(Party partyToDelete)
    {
        // Get candidates whose partyId is the same as partyToDelete
        List<Candidate>? candidates = _dbService!.GetDatabaseContext().Candidates
            .Where(c => c.PartyId == partyToDelete.PartyId).ToList();

        // Get elections that are either ongoing or planned for future who contain candidates impacted by partyToDelete
        List<Election>? elections = _electionService!.GetAllElections()?
            .Where(e => e.EndDate > DateTime.Now && candidates.Select(c => c.ElectionId)
                    .Contains(e.ElectionId)).ToList();

        if (elections?.Count > 0)
        {
            MessageBox.Show($"Warning - this party is has {candidates} candidates associated with this Party. These candidates are not part of {elections.Count} ongoing or planned elections. Deleteing this party will also delete these candidates. The deletion will not be performed.", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            return false;
        }
        else if ((elections == null || elections.Count == 0) && (candidates == null || candidates.Count > 0))
        {
            DialogResult dr = MessageBox.Show($"Warning - this party is has {candidates} candidates associated with this Party. These candidates are not part of any ongoing or planned elections. Deleteing this party will also delete these candidates. Do you wish to continue", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            
            if (dr != DialogResult.OK)
                return false;
        }
        else
        {
            if (MessageBox.Show($"Warning, this will permanently delete {partyToDelete.Name} from the database. Do you wish to proceed?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                return false;
        }

        return true;
    }

    /// <summary>
    /// selects the country and fills out the list with any relevant parties
    /// </summary>
    private void btnGo_Click(object sender, EventArgs e)
    {
        if (cmbCountry.SelectedIndex == -1)
        {
            MessageBox.Show("Please select a country", "Select a country", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        grpAddParty.Visible = true;
        txtPartyName.Visible = true;
        btnAddParty.Visible = true;

        grpParties.Visible = true;
        lvParties.Visible = true;
        btnRemoveParty.Visible = true;

        RefreshParties();
    }

    /// <summary>
    /// Refresh the party list and the ListView
    /// </summary>
    private void RefreshParties()
    {
        lvParties.Items.Clear();
        _parties.Clear();

        if (cmbCountry.SelectedItem != null && cmbCountry.SelectedItem is Country selectedCountry)        
            _parties = _dbService!.GetDatabaseContext().Parties.Where(p => p.Country == selectedCountry).OrderBy(p => p.Name).ToList();

        foreach (Party p in _parties)        
            lvParties.Items.Add(p.Name);
    }

    /// <summary>
    /// Add a party to the selected country
    /// </summary>
    private void btnAddParty_Click(object sender, EventArgs e)
    {
        // Check the party name is not empty and is a valid Country
        if (cmbCountry.SelectedItem != null 
            && cmbCountry.SelectedItem is Country selectedCountry 
            && string.IsNullOrWhiteSpace(txtPartyName.Text) == false)
        {
            txtPartyName.Text = txtPartyName.Text.Trim();

            Party party = new(txtPartyName.Text, selectedCountry);
            _parties.Add(party);

            _dbService!.InsertEntity(party);

            RefreshParties();
            txtPartyName.Clear();
        }
    }

    /// <summary>
    /// Close the form
    /// </summary>
    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }
}
