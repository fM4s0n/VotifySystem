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

        if (DesignMode)
            return;
    }

    /// <summary>
    /// Custom init - must be before the control is shown
    /// TODO - overload the show method to pass in the services
    /// </summary>
    public void Init(IUserService userService, IDbService dbService)
    {
        _userService = userService;
        _dbService = dbService;
    }

    /// <summary>
    /// Generates a one-time login code
    /// </summary>
    private void btnGenerateLoginCode_Click(object sender, EventArgs e)
    {
        LoginCode code = _userService!.GenerateLoginCode();

        lblLoginCode.Text = code.Code;

        lblExpiryWarning.Visible = true;
        lblLoginCode.Visible = true;

        _dbService!.InsertEntity(code);
    }

    private void btnRegister_Click(object sender, EventArgs e)
    {
        frmRegisterToVote frm = new(_userService!, _dbService!);
        frm.ShowDialog();
    }

    private void btnVoteOnline_Click(object sender, EventArgs e)
    {
        try
        {
            frmVote frm = new(_userService!, _dbService!);
            frm.ShowDialog();
        } catch 
        { 
            return; 
        }
    }
}
