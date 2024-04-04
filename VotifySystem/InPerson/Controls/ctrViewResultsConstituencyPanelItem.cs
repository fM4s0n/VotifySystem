using System.Configuration;
using VotifySystem.Common.Classes;
using VotifySystem.Common.Classes.Elections;
using VotifySystem.Common.DataAccess.Database;

namespace VotifySystem.InPerson.Controls;

/// <summary>
/// 
/// </summary>
public partial class ctrViewResultsConstituencyPanelItem : UserControl
{
    private IDbService _dbService;

    private List<CandidateDataGridItem> _gridData = [];
    private readonly Constituency? _constituency;
    private readonly List<Party> _allParties;
    private List<Candidate> _candidates;

    public ctrViewResultsConstituencyPanelItem(IDbService dbService, Constituency constituency)
    {
        InitializeComponent();

        if (DesignMode)
            return;
        
        _dbService = dbService;
        _constituency = constituency;
        _allParties = _dbService.GetDatabaseContext().Parties.ToList();

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

        _candidates = _dbService.GetDatabaseContext().Candidates
            .Where(ca => ca.ElectionId == _constituency!.ElectionId && ca.ConstituencyId == _constituency.ConstituencyId)
            .OrderByDescending(c => c.VotesReceived).ToList();

        foreach (Candidate candidate in _candidates)
        {
            int pos = _candidates.IndexOf(candidate) + 1;
            string partyName = _allParties.First(p => p.PartyId == candidate.PartyId)?.Name ?? string.Empty;

            CandidateDataGridItem item = new(pos, candidate.FullName, partyName, candidate.VotesReceived);
            gridItems.Add(item);
        }

        gridItems = CheckAndFixTies(gridItems);

        _gridData.AddRange(gridItems);
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

    /// <summary>
    /// Checks for any ties in the candidate votes and fixes them by setting the position of the tied candidates to the same position
    /// </summary>
    /// <param name="gridItems">list of candidate grid items</param>
    /// <returns>same list with fixed Position properties</returns>
    private static List<CandidateDataGridItem> CheckAndFixTies(List<CandidateDataGridItem> gridItems)
    {  
        foreach (CandidateDataGridItem item in gridItems)
        {
            List<CandidateDataGridItem> ties = gridItems.Where(gi => gi.Votes == item.Votes).ToList();

            if (ties.Count > 0) 
            {
                // get the position of the first candidate in the tie list
                int tiedPosition  = ties.First().Position;

                foreach (CandidateDataGridItem tie in ties)                
                    gridItems[gridItems.IndexOf(tie)].Position = tiedPosition;                  
            }
        }    

        return gridItems;
    }

    /// <summary>
    /// Class to hold data for the candidate data grid
    /// </summary>
    internal class CandidateDataGridItem(int position, string name, string party, int votes)
    {
        public int Position { get; set; } = position;
        public string Name { get; set; } = name;
        public string Party { get; set; } = party;
        public int Votes { get; set; } = votes;
    }
}
