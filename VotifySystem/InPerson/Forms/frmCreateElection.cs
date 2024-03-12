using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.Classes.Elections;

namespace VotifySystem.Forms;

/// <summary>
/// 
/// </summary>
public partial class frmCreateElection : Form
{
    IUserService? _userService;
    ElectionVoteMechanism _currentVoteMechanism;

    public frmCreateElection(IUserService userService)
    {
        InitializeComponent();
        _userService = userService;

        foreach (ElectionVoteMechanism voteMechanism in Enum.GetValues(typeof(ElectionVoteMechanism)))
            cmbVoteMechanism.Items.Add(voteMechanism.ToString());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnCreate_Click(object sender, EventArgs e)
    {
        Election? election = ElectionFactory.CreateElection(_currentVoteMechanism, txtElectionName.Text, dtpElectionStart.Value, dtpElectionEnd.Value, _userService.GetCurrentUser());       
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnCancel_Click(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void cmbVoteMechanism_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Enum.TryParse(typeof(ElectionVoteMechanism), cmbVoteMechanism.SelectedItem.ToString(), out object result))
        {
            _currentVoteMechanism = (ElectionVoteMechanism)result;
        }
    }
}
