using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.DataAccess.Database;

namespace VotifySystem.InPerson.Forms;

/// <summary>
/// Form to view and add parties to a country
/// </summary>
public partial class frmManageParties : Form
{
    IUserService? _userService;
    IDbService? _dbService;

    public frmManageParties(IUserService userService, IDbService dbService)
    {
        InitializeComponent();

        if (DesignMode)
            return;

        _userService = userService;
        _dbService = dbService;
    }

    private void frmManageParties_Load(object sender, EventArgs e)
    {
        iL
    }
}
