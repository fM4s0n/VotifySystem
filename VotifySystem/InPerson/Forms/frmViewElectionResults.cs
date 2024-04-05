using VotifySystem.Common.BusinessLogic.Helpers;
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
    private readonly List<Candidate>? _candidates;
    private readonly List<Constituency>? _electionConstituencies;

    public frmViewElectionResults(IDbService dbService, Election election)
    {
        InitializeComponent();

        if (DesignMode)
            return;

        _dbService = dbService;
        _election = election;        
        
        _candidates = _dbService.GetDatabaseContext().Candidates.Where(c => c.ElectionId == _election.ElectionId).ToList();
        _electionConstituencies = _dbService!.GetDatabaseContext().Constituencies.Where(c => c.ElectionId == _election!.ElectionId).ToList();

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
            flpResults.Controls.Clear();

            switch (mode)
            {
                case ViewElectionFormMode.Constituency:
                    SetConstituencyView();
                    break;
                case ViewElectionFormMode.Election:
                    SetElectionView();
                    break;
            }
        }
    }

    private void SetConstituencyView()
    {
        foreach (Constituency constituency in _electionConstituencies!)
        {
            ctrResultsConstituencyPanelItem item = new(_dbService!, constituency);

            flpResults.Controls.Add(item);
        }
    }

    private void SetElectionView()
    {
        List<string> candidatePartyIds = _candidates!.Select(c => c.PartyId).Distinct().ToList();
        List<Party> electionParties = _dbService!.GetDatabaseContext().Parties.Where(p => candidatePartyIds.Contains(p.PartyId)).ToList();

        // Calculate total votes per party
        Dictionary<Party, int> partyTotalVotes = FPTPResultsHelper.CalculateTotalVotesPerParty(electionParties, _candidates!);
        
        // Calculate Constituency wins per party
        Dictionary<Party, List<Constituency>> partyConstituencyWins = FPTPResultsHelper.CalculatePartyConstituencyWinsForElection(electionParties, _candidates!, _electionConstituencies!);

        foreach (Party party in electionParties)
        {
            int totalVotes = partyTotalVotes[party];
            int totalConstituencyWins = partyConstituencyWins[party].Count;

            int position = electionParties.IndexOf(party) + 1;

            List<Candidate>? partyCandidates = _candidates!.Where(c => c.PartyId == party.PartyId).ToList();

            ctrResultsPartyPanelItem item = new(party, position, totalConstituencyWins, totalVotes);

            flpResults.Controls.Add(item);
        }
    }

    /// <summary>
    /// enum to represent the different view modes for the election results form
    /// </summary>
    internal enum ViewElectionFormMode
    {
        Constituency,
        Election
    }
}
