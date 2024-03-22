using VotifySystem.Common.BusinessLogic.Services;
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
    private List<ElectionCandidate> electionCandidates;

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
        dtpElectionStart.Value = DateTime.Now;
        dtpElectionEnd.Value = DateTime.Now.AddMonths(1);

        foreach (ElectionVoteMechanism voteMechanism in Enum.GetValues(typeof(ElectionVoteMechanism)))
            cmbVoteMechanism.Items.Add(voteMechanism.ToString());

        foreach ()
    }

    /// <summary>
    /// Click event for the create button
    /// Validates all fields and creates the election
    /// </summary>
    private void btnCreate_Click(object sender, EventArgs e)
    {
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
    /// 
    /// </summary>
    private void ValidateAllFields()
    {
        if (string.IsNullOrEmpty(txtElectionName.Text))
        {

        }

        if (dtpElectionStart.Value > dtpElectionEnd.Value)
        {
            MessageBox.Show("The start date must be before the end date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
    }

    /// <summary>
    /// Adds a constituency to the election
    /// </summary>
    private void btnAddConstituency_Click(object sender, EventArgs e)
    {
        txtConstituencyName.Text = txtConstituencyName.Text.Trim();

        if (string.IsNullOrEmpty(txtConstituencyName.Text))
        {
            MessageBox.Show("Please enter a constituency name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        lvConstituencies.Items.Add(txtConstituencyName.Text);
        txtConstituencyName.Text = string.Empty;
    }
}
