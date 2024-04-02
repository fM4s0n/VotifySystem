using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.Classes.Elections;
using VotifySystem.Common.DataAccess.Database;
using VotifySystem.InPerson.Controls;

namespace VotifySystem.InPerson.Forms;

/// <summary>
/// 
/// </summary>
public partial class frmManageElections : Form
{
    private readonly IDbService? _dbService;
    private readonly IUserService? _userService;
    private List<Election>? _elections;

    public frmManageElections(IUserService userService, IDbService dbService)
    {
        InitializeComponent();

        if (DesignMode) 
            return;

        _dbService = dbService;
        _userService = userService;

        Load += frmManageElections_Load;
    }

    private void frmManageElections_Load(object? sender, EventArgs e)
    {
        // load all election that are ongoing, future and completed within last month
        _elections = _dbService!.GetDatabaseContext().Elections
            .Where(e => e.EndDate >= DateTime.Now.AddMonths(-1))
            .ToList();

        if (_elections.Count == 0)
        {
            MessageBox.Show("No elections found", "No Elections", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        foreach (Election election in _elections)
        {
            ctrManageElectionPanelItem epi = new (election, _dbService, _userService!);
            flpElections.Controls.Add(epi);
        }
    }
}
