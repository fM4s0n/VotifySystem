using VotifySystem.Common.BusinessLogic.Helpers;
using VotifySystem.Common.Models;
using VotifySystem.Common.DataAccess.Database;
using VotifySystem.Common.Models.UIClasses;

namespace VotifySystem.InPerson.Controls;

/// <summary>
/// Panel item for displaying the results of a constituency in the results view
/// </summary>
public partial class ctrResultsConstituencyPanelItem : UserControl
{
    private readonly IDbService? _dbService;

    private readonly List<CandidateDataGridItem>? _gridData = [];
    private readonly Constituency? _constituency;
    private readonly List<Party>? _allParties;
    private List<Candidate>? _candidates;

    public ctrResultsConstituencyPanelItem(Constituency constituency)
    {
        InitializeComponent();

        if (DesignMode)
            return;
        
        _dbService = Program.ServiceProvider!.GetService(typeof(IDbService)) as IDbService;
        _constituency = constituency;
        _allParties = _dbService!.GetDatabaseContext().Parties.ToList();

        InitUI();

        InitDataSource();

        InitDataGrid();
    }

    private void InitUI()
    {
        lblConstituencyName.Text = _constituency!.ConstituencyName;
    }

    private void InitDataSource()
    {
        List<CandidateDataGridItem> gridItems = [];

        _candidates = _dbService!.GetDatabaseContext().Candidates
            .Where(ca => ca.ElectionId == _constituency!.ElectionId && ca.ConstituencyId == _constituency.ConstituencyId).ToList();
           
        _candidates = FPTPResultsHelper.OrderCandidatesByVotes(_candidates);

        foreach (Candidate candidate in _candidates)
        {
            int pos = _candidates.IndexOf(candidate) + 1;
            string partyName = _allParties!.First(p => p.PartyId == candidate.PartyId)?.Name ?? string.Empty;

            CandidateDataGridItem item = new(pos, candidate.FullName, partyName, candidate.GetVotesReceived());
            gridItems.Add(item);
        }

        gridItems = FPTPResultsHelper.CheckAndFixTies(gridItems);

        _gridData!.AddRange(gridItems);
    }

    private void InitDataGrid()
    { 
        dgvCandidates.AutoGenerateColumns = false;
        dgvCandidates.Columns.Add(new DataGridViewTextBoxColumn { Name = "Position", DataPropertyName = "Position" });
        dgvCandidates.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", DataPropertyName = "Name", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
        dgvCandidates.Columns.Add(new DataGridViewTextBoxColumn { Name = "Party", DataPropertyName = "Party" });
        dgvCandidates.Columns.Add(new DataGridViewTextBoxColumn { Name = "Votes", DataPropertyName = "Votes" });

        dgvCandidates.DataSource = _gridData;
    }  
}
