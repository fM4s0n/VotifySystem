using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Forms;

namespace VotifySystem.Controls;

/// <summary>
/// 
/// </summary>
public partial class CtrAdminHome : UserControl
{
    readonly IUserService? _userService;

    public CtrAdminHome(IUserService userService)
    {
        InitializeComponent();
        _userService = userService;
    }

    /// <summary>
    /// Show Create Election Form
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void BtnCreateElection_Click(object sender, EventArgs e)
    {
        frmCreateElection form = new(_userService!);
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
