using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.Models;
using VotifySystem.Common.Models.Elections;
using VotifySystem.Common.Controls;
using VotifySystem.Common.DataAccess.Database;

namespace VotifySystem.Common.Forms;
public partial class frmVote : Form
{
    private readonly IUserService? _userService;
    private readonly IDbService? _dbService;
    private readonly IElectionService? _electionService;

    // TODO: Implement ElectionVoteMechanism for STV
    // private readonly ElectionVoteMechanism? _electionVoteMechanism;

    private List<Election>? _validElections = [];

    // electionVoter is to get the specific ElectionVoter object based on the selected election
    private ElectionVoter? _electionVoter;

    // electionVoters is to get all possible elections the user can vote in
    private List<ElectionVoter> _electionVoters = [];

    /// <summary>
    /// Constructor for the frmVote
    /// </summary>
    public frmVote()
    {
        InitializeComponent();

        if (DesignMode)
            return;

        _userService = Program.ServiceProvider!.GetService(typeof(IUserService)) as IUserService;
        _dbService = Program.ServiceProvider!.GetService(typeof(IDbService)) as IDbService;
        _electionService = Program.ServiceProvider!.GetService(typeof(IElectionService)) as IElectionService;

        Init();
    }

    /// <summary>
    /// Custom init
    /// </summary>
    private void Init()
    {
        if (_userService!.GetCurrentUserLevel() != UserLevel.Voter)
        {
            MessageBox.Show("Only voters may vote in elections", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
            return;
        }

        GetElectionVoters();

        if (_electionVoters.Count == 0)
        {
            MessageBox.Show("You are not registered to vote in any elections", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
            return;
        }

        List<string> validElectionIds = _electionVoters.Select(ev => ev.ElectionId).ToList();

        _validElections = _electionService!.GetAllElections();
        CheckElectionCount();

        _validElections = _validElections!.Where(e => validElectionIds.Contains(e.ElectionId)).ToList();
        CheckElectionCount();

        _validElections = _validElections
            .Where(e => e.GetElectionStatus() == ElectionStatus.InProgress).ToList();
        CheckElectionCount();

        InitCmbSelectElection();

        // listen to the vote completed event
        ctrFPTPVote.VoteCompleted += ctrFPTPVote_VoteCompleted;
    }

    private void CheckElectionCount()
    {
        if (_validElections == null || _validElections.Count == 0)
        {
            MessageBox.Show("There are no elections to vote in currently, please retry once an election has commenced.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
            return;
        }
    }

    private void GetElectionVoters()
    {
        _electionVoters = _dbService!.GetDatabaseContext().ElectionVoters
            .Where(ev => ev.VoterId == _userService.GetCurrentUser()!.Id).ToList();

        _electionVoters = _electionVoters.Where(ev => ev.HasVoted == false).ToList();
    }

    /// <summary>
    /// Vote completed event handler
    /// closes the form after updating the db to record the voter has voted in the election
    /// </summary>
    private void ctrFPTPVote_VoteCompleted(object sender, EventArgs e)
    {
        ctrFPTPVote.Visible = false;

        // update the election voter to show that the user has voted
        _electionVoter!.HasVoted = true;
        _dbService!.UpdateEntity(_electionVoter);

        Close();
    }

    /// <summary>
    /// sets the datasource for the cmbSelectElection
    /// </summary>
    private void InitCmbSelectElection()
    {
        cmbSelectElection.DataSource = null;
        cmbSelectElection.DisplayMember = "Description";
        cmbSelectElection.ValueMember = "ElectionId";
        cmbSelectElection.DataSource = _validElections;
        cmbSelectElection.SelectedIndex = -1;
    }

    /// <summary>
    /// Click event for the go button
    /// validates the election shows relevant control in tlpVoteControl
    /// </summary>
    private void btnGo_Click(object sender, EventArgs e)
    {
        if (cmbSelectElection.SelectedIndex == -1)
        {
            MessageBox.Show("Please select an election", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        Election election;
        if (cmbSelectElection.SelectedValue is string electionId)
        {
            election = _validElections.First(e => e.ElectionId == electionId);
        }
        else
        {
            MessageBox.Show("Error Loading Election, please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            cmbSelectElection.SelectedIndex = -1;
            return;
        }
        
        if (election != null)
        {
            lblElectionName.Text = election.Description;
            lblElectionName.Visible = true;

            // set the election voter based on the selected election
            _electionVoter = _electionVoters.First(ev => ev.ElectionId == election.ElectionId);

            switch (election)
            {
                case FirstPastThePostElection _:
                    SetMode(ElectionVoteMechanism.FPTP);
                    break;
                case SingleTransferrableVoteElection _:
                    SetMode(ElectionVoteMechanism.STV);
                    break;
                default:
                    break;
            }
        }
    }

    /// <summary>
    /// Sets the current mode of the form
    /// </summary>
    /// <param name="electionVoteMechanism">Mode to set the form to</param>
    private void SetMode(ElectionVoteMechanism electionVoteMechanism)
    {
        if (cmbSelectElection.SelectedIndex != -1 && cmbSelectElection.SelectedValue is string electionId)
        {
            switch (electionVoteMechanism)
            {
                case ElectionVoteMechanism.FPTP:
                    ctrFPTPVote.Init(_validElections.First(e => e.ElectionId == electionId), _dbService!);
                    ctrFPTPVote.Visible = true;
                    break;
                case ElectionVoteMechanism.STV:
                    break;
                default:
                    break;
            }
        }
    }
}
