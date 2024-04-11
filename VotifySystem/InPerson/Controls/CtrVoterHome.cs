using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.Forms;
using VotifySystem.InPerson.Forms;

namespace VotifySystem.Controls;

/// <summary>
/// Control for the Voter home page in person
/// </summary>
public partial class ctrVoterHome : UserControl
{
    private readonly IUserService? _userService;

    public ctrVoterHome()
    {
        InitializeComponent();

        if (DesignMode)
            return;

        _userService = Program.ServiceProvider!.GetService(typeof(IUserService)) as IUserService;
    }

    /// <summary>
    /// Click event for registering to vote
    /// </summary>
    private void btnRegisterToVote_Click(object sender, EventArgs e)
    {
        try
        {
            frmRegisterToVote frm = new();

            //TODO: work out why this doesn't work - ObjectDisposedException on this line on internally called Close() TEMP solution is to wrap in try catch
            frm.Show();
        }
        catch
        {
            return;
        }
    }

    /// <summary>
    /// click event for voting in person
    /// shows the form for voting in person
    /// </summary>
    private void btnVoteInPerson_Click(object sender, EventArgs e)
    {
        try
        {
            frmVote frmVote = new();
            frmVote.ShowDialog();
        }
        catch
        {
            return;
        }
    }

    private void btnLogout_Click(object sender, EventArgs e)
    {
        _userService!.LogOutUser();
    }
}
