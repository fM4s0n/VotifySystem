using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.Classes;
using VotifySystem.Common.DataAccess.Database;
using VotifySystem.Common.Forms;
using VotifySystem.InPerson.Forms;

namespace VotifySystem.Online.Controls;

/// <summary>
/// Online voting home control
/// </summary>
public partial class ctrVoterHomeOnline : UserControl
{
    private IUserService? _userService;
    private IDbService? _dbService;

    public ctrVoterHomeOnline()
    {
        InitializeComponent();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userService"></param>
    /// <param name="dbService"></param>
    public void Init(IUserService userService, IDbService dbService)
    {
        _userService = userService;
        _dbService = dbService;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnGenerateLoginCode_Click(object sender, EventArgs e)
    {
        LoginCode code = _userService!.GenerateLoginCode();

        lblLoginCode.Text = code.Code;

        lblExpiryWarning.Visible = true;
        lblLoginCode.Visible = true;

        _dbService!.InsertEntity(code);
    }

    /// <summary>
    /// 
    /// </summary>
    private void btnRegister_Click(object sender, EventArgs e)
    {
        frmRegisterToVote frm = new(_userService!, _dbService!);
        frm.ShowDialog();
    }

    /// <summary>
    /// 
    /// </summary>
    private void btnVoteOnline_Click(object sender, EventArgs e)
    {
        frmVote frm = new(_userService!, _dbService!);
        frm.ShowDialog();
    }
}
