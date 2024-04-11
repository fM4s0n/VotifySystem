using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.Models;
using VotifySystem.Common.Models.Elections;
using VotifySystem.Common.DataAccess.Database;

namespace VotifySystem.InPerson.Forms;

/// <summary>
/// Form for registering to vote
/// Creates a new ElectionVoter object
/// </summary>
public partial class frmRegisterToVote : Form
{
    private readonly IUserService? _userService;
    private readonly IElectionService? _electionService;
    private readonly IConstituencyService? _constituencyService;
    private readonly IElectionVoterService? _electionVoterService;

    private List<Election>? _elections = [];
    private List<Constituency>? _constituencies = [];
    private Voter? _voter;
    private List<ElectionVoter>? _electionVoters = [];

    public frmRegisterToVote()
    {
        InitializeComponent();

        if (DesignMode)
            return;

        _userService = Program.ServiceProvider!.GetService(typeof(IUserService)) as IUserService;
        _electionService = Program.ServiceProvider!.GetService(typeof(IElectionService)) as IElectionService;
        _constituencyService = Program.ServiceProvider!.GetService(typeof(IConstituencyService)) as IConstituencyService;
        _electionVoterService = Program.ServiceProvider!.GetService(typeof(IElectionVoterService)) as IElectionVoterService;

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
            return;
        }

        _voter = (Voter)_userService!.GetCurrentUser()!;

        _elections = _electionService!.GetElectionsByCountry(_voter.Country);

        if (_elections == null || _elections.Count == 0)
        {
            if (MessageBox.Show("No elections available to register for.", "No elections", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Close();
                return;
            }
        }

        _elections = _elections!.Where(e => e.GetElectionStatus() != ElectionStatus.Completed).ToList();

        _electionVoters = _electionVoterService!.GetElectionVotersByVoterId(_voter.Id);

        // Remove elections that the voter has already registered for
        if (_electionVoters != null && _electionVoters.Count > 0)
        {
            foreach (ElectionVoter ev in _electionVoters)
            {
                Election election = _elections.First(e => e.ElectionId == ev.ElectionId);
                _elections.Remove(election);
            }
        }

        if (_elections.Count == 0)
        {
            if (MessageBox.Show("No elections available to register for.", "No elections", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Close();
                return;
            }
        }

        ResetCmbElections();
    }

    /// <summary>
    /// Resets the combo box for elections with refreshed data
    /// </summary>
    private void ResetCmbElections()
    {
        cmbElections.SelectedIndexChanged -= cmbElections_SelectedIndexChanged;
        cmbElections.DataSource = null;
        cmbElections.DisplayMember = "Description";
        cmbElections.ValueMember = "ElectionId";
        cmbElections.DataSource = _elections;
        cmbElections.SelectedIndex = -1;
        cmbElections.SelectedIndexChanged += cmbElections_SelectedIndexChanged;
    }

    /// <summary>
    /// Inits / resets the combo box for constituencies with refreshed data
    /// </summary>
    private void ResetCmbConstituencies()
    {
        if (ResetConstituencyDataSource()==false)
            return;

        cmbConstituencies.DataSource = null;
        cmbConstituencies.DisplayMember = "ConstituencyName";
        cmbConstituencies.ValueMember = "ConstituencyId";
        cmbConstituencies.DataSource = _constituencies;
        cmbConstituencies.SelectedIndex = -1;
    }

    /// <summary>
    /// Resets the constituency data source based on the selected election
    /// </summary>
    private bool ResetConstituencyDataSource()
    {
        if (cmbElections.SelectedIndex == -1)
            return false;

        string electionId = cmbElections.SelectedValue!.ToString()!;
        _constituencies = _constituencyService!.GetConstituenciesByElectionId(electionId);

        if (_constituencies != null && cmbElections.SelectedIndex != -1)
            _constituencies = _constituencies.Where(c => c.ElectionId == cmbElections.SelectedValue!.ToString()!).ToList();

        return true;
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

        _electionVoterService!.InsertElectionVoter(electionVoter);

        string electionDescription = _elections!.First(e => e.ElectionId == electionId).Description;
        MessageBox.Show($"Successfully registered for {electionDescription}.", "Successfully Registered", MessageBoxButtons.OK, MessageBoxIcon.Information);
        Close();
        return;
    }

    private void cmbElections_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbElections.SelectedIndex == -1)
            return;

        ResetCmbConstituencies();
    }
}
