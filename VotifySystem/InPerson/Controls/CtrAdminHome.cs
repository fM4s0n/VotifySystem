using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.DataAccess.Database;
using VotifySystem.Forms;
using VotifySystem.InPerson.Forms;

namespace VotifySystem.Controls;

/// <summary>
/// Home page for admin user
/// </summary>
public partial class ctrAdminHome : UserControl
{
    private IUserService? _userService;
    private IDbService? _dbService;

    public ctrAdminHome()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Init the control with the required services
    /// </summary>
    /// <param name="userService"></param>
    /// <param name="dbService"></param>
    public void Init(IUserService userService, IDbService dbService)
    {
        _userService = userService;
        _dbService = dbService;
    }

    /// <summary>
    /// Show Create Election Form
    /// </summary>
    private void BtnCreateElection_Click(object sender, EventArgs e)
    {
        frmCreateElection form = new(_userService!, _dbService!);
        form.Show();
    }

    /// <summary>
    /// Show Manage Election Form
    /// </summary>
    private void btnManageElection_Click(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// 
    /// </summary>
    private void btnLogOut_Click(object sender, EventArgs e)
    {
        _userService!.LogOutUser();
    }

    /// <summary>
    /// Click event for Manage Parties button
    /// Launch Manage Parties form
    /// </summary>
    private void btnManageParties_Click(object sender, EventArgs e)
    {
        frmManageParties form = new(_userService!, _dbService!);
        form.ShowDialog();
    }

    /// <summary>
    /// launches the postal vote form
    /// </summary>
    private void btnPostalVote_Click(object sender, EventArgs e)
    {

    }
}
