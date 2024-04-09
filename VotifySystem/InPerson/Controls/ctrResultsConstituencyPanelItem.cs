using VotifySystem.Common.BusinessLogic.Helpers;
using VotifySystem.Common.Models;
using VotifySystem.Common.DataAccess.Database;
using VotifySystem.Common.Models.UIClasses;
using VotifySystem.Common.BusinessLogic.Services;

namespace VotifySystem.InPerson.Controls;

/// <summary>
/// Panel item for displaying the results of a constituency in the results view
/// </summary>
public partial class ctrResultsConstituencyPanelItem : UserControl
{
    private readonly ICandidateService? _candidateService;
    private readonly IPartyService? _partyService;

    private readonly List<CandidateDataGridItem>? _gridData = [];
    private readonly Constituency? _constituency;
    private readonly List<Party>? _allParties;
    private List<Candidate>? _candidates;

    public ctrResultsConstituencyPanelItem(Constituency constituency)
    {
        InitializeComponent();

        if (DesignMode)
            return;
        
        _candidateService = Program.ServiceProvider!.GetService(typeof(ICandidateService)) as ICandidateService;
        _partyService = Program.ServiceProvider!.GetService(typeof(IPartyService)) as IPartyService;

        _constituency = constituency;
        _allParties = _partyService!.GetAllParties();

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

        _candidates = _candidateService!.GetCandidatesByElectionId(_constituency!.ElectionId)?
            .Where(ca => ca.ConstituencyId == _constituency.ConstituencyId).ToList() ?? null;

        if (_candidates == null)
        {
            MessageBox.Show("No candidates found for this constituency", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
           
        _candidates = FPTPResultsHelper.OrderCandidatesByVotes(_candidates);

        foreach (Candidate candidate in _candidates)
        {
            int pos = _candidates.IndexOf(candidate) + 1;
            string partyName = _allParties!.First(p => p.PartyId == candidate.PartyId)?.Name ?? string.Empty;

            CandidateDataGridItem item = new(pos, candidate.FullName, partyName, candidate.VotesReceived);
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
