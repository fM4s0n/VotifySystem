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
    }

    /// <summary>
    /// Custom init
    /// </summary>
    /// <param name="userService">User service</param>
    /// <param name="dbService">dbService</param>
    internal void Init(IUserService userService, IDbService dbService)
    {
        _userService = userService;
        _dbService = dbService;
    }

    /// <summary>
    /// Click event for registering to vote
    /// </summary>
    private void btnRegisterToVote_Click(object sender, EventArgs e)
    {
        frmRegisterToVote frmRegisterToVote = new(_userService!, _dbService!);
        frmRegisterToVote.ShowDialog();
    }

    /// <summary>
    /// click event for voting in person
    /// shows the form for voting in person
    /// </summary>
    private void btnVoteInPerson_Click(object sender, EventArgs e)
    {
        frmVote frmVote = new(_userService!, _dbService!);
        frmVote.ShowDialog();
    }
}
