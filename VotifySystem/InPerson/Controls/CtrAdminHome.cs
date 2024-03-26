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
    private readonly IUserService? _userService;
    private readonly IDbService? _dbService;

    public ctrAdminHome(IUserService userService, IDbService dbService)
    {
        InitializeComponent();

        if (DesignMode)
            return;

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
    /// Launmch Manage Parties form
    /// </summary>
    private void btnManageParties_Click(object sender, EventArgs e)
    {
        frmManageParties form = new(_userService!, _dbService!);
    }
}
