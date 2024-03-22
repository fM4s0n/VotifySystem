using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.DataAccess.Database;
using VotifySystem.Forms;

namespace VotifySystem.Controls;

/// <summary>
/// 
/// </summary>
public partial class CtrAdminHome : UserControl
{
    private readonly IUserService? _userService;
    private readonly IDbService? _dbService;

    public CtrAdminHome(IUserService userService, IDbService dbService)
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
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void BtnCreateElection_Click(object sender, EventArgs e)
    {
        frmCreateElection form = new(_userService!, _dbService!);
        form.Show();
    }

    /// <summary>
    /// Show Manage Election Form
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnManageElection_Click(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnLogOut_Click(object sender, EventArgs e)
    {
        _userService!.LogOutUser();
    }
}
