using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.Classes;
using VotifySystem.Common.Classes.Elections;
using VotifySystem.Common.DataAccess.Database;
using VotifySystem.InPerson.Controls;

namespace VotifySystem.InPerson.Forms;

/// <summary>
/// form to view the results of an election
/// </summary>
public partial class frmViewElectionResults : Form
{
    private readonly IDbService? _dbService;
    private readonly Election? _election;
    private readonly List<Constituency> _electionConstituencies;

    public frmViewElectionResults(IDbService dbService, Election election)
    {
        InitializeComponent();

        if (DesignMode)
            return;

        _dbService = dbService;

        _election = election;
        _electionConstituencies = _dbService.GetDatabaseContext().Constituencies.Where(c => c.ElectionId == _election!.ElectionId).ToList();
        Init();
    }

    private void Init()
    {
        foreach (ViewElectionFormMode mode in Enum.GetValues(typeof(ViewElectionFormMode)))                   
            cmbViewMode.Items.Add(mode);

        cmbViewMode.SelectedIndex = -1;
    }

    private void btnSelectViewModeGo_Click(object sender, EventArgs e)
    {
        if (cmbViewMode.SelectedIndex == -1)
            return;

        if (cmbViewMode.SelectedItem is ViewElectionFormMode mode)
        {
            switch (mode)
            {
                case ViewElectionFormMode.Constituency:
                    SetConstituencyView();
                    break;
                case ViewElectionFormMode.Election:

                    break;
            }
        }
    }

    private void SetConstituencyView()
    {
        flpResults.Controls.Clear();
        foreach (Constituency constituency in _electionConstituencies)
        {
            ctrResultsConstituencyPanelItem item = new(_dbService!, constituency);

            flpResults.Controls.Add(item);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    internal enum ViewElectionFormMode
    {
        Constituency,
        Election,
    }
}
