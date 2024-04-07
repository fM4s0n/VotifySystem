using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.DataAccess.Database;
using VotifySystem.Common.Forms;
using VotifySystem.InPerson.Forms;

namespace VotifySystem.Controls;

/// <summary>
/// Control for the Voter home page in person
/// </summary>
public partial class ctrVoterHome : UserControl
{
    private IUserService? _userService;
    private IDbService? _dbService;

    public ctrVoterHome()
    {
        InitializeComponent();

        if (DesignMode)
            return;

        _userService = Program.ServiceProvider!.GetService(typeof(IUserService)) as IUserService;
        _dbService = Program.ServiceProvider!.GetService(typeof(IDbService)) as IDbService;
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
}
