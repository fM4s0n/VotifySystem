using VotifySystem.Common.BusinessLogic.Helpers;
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

        Init();
    }

    /// <summary>
    /// Custom init
    /// </summary>
    private void Init()
    {
        foreach (Country c in Enum.GetValues(typeof(Country))) 
            cmbCountry.Items.Add(c);
    }

    /// <summary>
    /// 
    /// </summary>
    private void btnRemoveParty_Click(object sender, EventArgs e)
    {

    }
}
