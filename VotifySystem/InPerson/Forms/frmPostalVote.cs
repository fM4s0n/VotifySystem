using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.DataAccess.Database;

namespace VotifySystem.InPerson.Forms;

/// <summary>
/// Form for admins top add postal votes to an election
/// </summary>
public partial class frmPostalVote : Form
{
    private readonly IUserService _userService;
    private readonly IDbService _dbService;

    public frmPostalVote(IUserService userService, IDbService dbService)
    {
        InitializeComponent();

        if (DesignMode)        
            return;
        
        _userService = userService;
        _dbService = dbService;

    }
}
