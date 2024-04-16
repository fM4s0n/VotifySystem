using VotifySystem.Common.BusinessLogic.Helpers;
using VotifySystem.Common.Models;
using VotifySystem.Common.DataAccess.Database;
using VotifySystem.Common.Models.UI;
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

    /// <summary>
    /// Inits the data sourve for the data grid
    /// </summary>
    private void InitDataSource()
    {
        List<CandidateDataGridItem> gridItems = [];
        List<GenericTieFixCheckItem> tieFixCheckItems = [];

        // get all candidates for this constituency
        _candidates = _candidateService!.GetCandidatesByElectionId(_constituency!.ElectionId)?
            .Where(ca => ca.ConstituencyId == _constituency.ConstituencyId).ToList() ?? null;

        if (_candidates == null)
        {
            MessageBox.Show("No candidates found for this constituency", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
           
        // order the candidates by votes
        _candidates = FPTPResultsHelper.OrderCandidatesByVotes(_candidates);

        // create the grid items and tie fix items
        foreach (Candidate candidate in _candidates)
        {
            int pos = _candidates.IndexOf(candidate) + 1;
            string partyName = _allParties!.First(p => p.PartyId == candidate.PartyId)?.Name ?? string.Empty;

            GenericTieFixCheckItem tfi = new(candidate.Id, pos, candidate.VotesReceived);
            tieFixCheckItems.Add(tfi);

            CandidateDataGridItem item = new(candidate.Id, pos, candidate.FullName, partyName, candidate.VotesReceived);
            gridItems.Add(item);
        }

        // fix any ties
        tieFixCheckItems = FPTPResultsHelper.GenericCheckAndFixTies(tieFixCheckItems);
        
        // update the positions in the grid items
        foreach (GenericTieFixCheckItem tfi in tieFixCheckItems)
        {
            CandidateDataGridItem item = gridItems.First(gi => gi.CandidateId == tfi.Key);
            item.Position = tfi.Position;
        }

        _gridData!.AddRange(gridItems);
    }

    private void InitDataGrid()
    { 
        dgvCandidates.AutoGenerateColumns = false;
        dgvCandidates.Columns.Add(new DataGridViewTextBoxColumn { Name = "Position", DataPropertyName = "Position" });
        dgvCandidates.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", DataPropertyName = "Name", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
        dgvCandidates.Columns.Add(new DataGridViewTextBoxColumn { Name = "Party", DataPropertyName = "PartyName" });
        dgvCandidates.Columns.Add(new DataGridViewTextBoxColumn { Name = "Votes", DataPropertyName = "Votes" });

        dgvCandidates.DataSource = _gridData;
    }  
}
