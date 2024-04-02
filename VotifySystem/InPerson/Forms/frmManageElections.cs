using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.DataAccess.Database;

namespace VotifySystem.InPerson.Forms;

/// <summary>
/// 
/// </summary>
public partial class frmManageElections : Form
{
    private readonly IDbService? _dbService;
    private readonly IUserService? _userService;

    public frmManageElections(IDbService dbService, IUserService userService)
    {
        InitializeComponent();

        if (DesignMode) 
            return;

        _dbService = dbService;
        _userService = userService;
    }


}
