using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.Classes;
using VotifySystem.Common.DataAccess.Database;

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

    public void Init(IUserService userService, IDbService dbService)
    {
        _userService = userService;
        _dbService = dbService;
    }

    private void btnGenerateLoginCode_Click(object sender, EventArgs e)
    {
        LoginCode code = _userService!.GenerateLoginCode();

        lblLoginCode.Text = code.Code;

        lblExpiryWarning.Visible = true;
        lblLoginCode.Visible = true;

        _dbService!.InsertEntity(code);
    }
}
