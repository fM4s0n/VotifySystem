using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.Classes;
using VotifySystem.Common.Classes.Elections;
using VotifySystem.Common.Controls;
using VotifySystem.Common.DataAccess.Database;

namespace VotifySystem.Common.Forms;
public partial class frmVote : Form
{
    private readonly IUserService? _userService;
    private readonly IDbService? _dbService;

    private ElectionVoteMechanism? _electionVoteMechanism;

    private List<Election> _validElections = [];
    private ElectionVoter? _electionVoter;

    /// <summary>
    /// Constructor for the frmVote
    /// </summary>
    public frmVote(IUserService userService, IDbService dbService)
    {
        InitializeComponent();

        if (DesignMode)
            return;

        _userService = userService;
        _dbService = dbService;

        // listen to the vote completed event
        ctrFPTPVote.VoteCompleted += ctrFPTPVote_VoteCompleted;

        Init();
    }

    /// <summary>
    /// 
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
    /// Custom init
    /// </summary>
    private void Init()
    {
        if (_userService.GetCurrentUserLevel() != UserLevel.Voter)
        {
            MessageBox.Show("Only voters may vote in elections", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
        }

        _electionVoter = _dbService!.GetDatabaseContext().ElectionVoters.FirstOrDefault(ev => ev.VoterId == _userService.GetCurrentUser()!.Id);

        if (_electionVoter == null)
        {
            MessageBox.Show("You are not registered to vote in any elections", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
        }

        _validElections = _dbService.GetDatabaseContext().Elections.Where(e => e.EndDate > DateTime.Now && e.ElectionId == _electionVoter!.ElectionId).ToList();

        InitCmbSelectElection();
    }

    /// <summary>
    /// sets the datasource for the cmbSelectElection
    /// </summary>
    private void InitCmbSelectElection()
    {
        cmbSelectElection.DataSource = _validElections;
        cmbSelectElection.DisplayMember = "Description";
        cmbSelectElection.ValueMember = "ElectionId";
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

        Election? election = _validElections.First(e => e.ElectionId == cmbSelectElection.SelectedValue);

        if (election != null)
        {
            switch (election)
            {
                case FirstPastThePostElection _:
                    SetMode(ElectionVoteMechanism.FPTP);
                    break;
                case SingleTransferrableVoteElection _:
                    SetMode(ElectionVoteMechanism.STV);
                    break;
                default:
                    MessageBox.Show("Invalid election type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        switch (electionVoteMechanism)
        {
            case ElectionVoteMechanism.FPTP:
                ctrFPTPVote.Init(_validElections.First(e => e.ElectionId == cmbSelectElection.SelectedValue), _dbService!, _electionVoter!);
                ctrFPTPVote.Visible = true;
                break;
            case ElectionVoteMechanism.STV:
                break;
            default:
                break;
        }
    }
}
