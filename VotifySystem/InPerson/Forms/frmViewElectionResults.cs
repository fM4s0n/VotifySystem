﻿using VotifySystem.Common.BusinessLogic.Helpers;
using VotifySystem.Common.Models;
using VotifySystem.Common.Models.Elections;
using VotifySystem.Common.Models.UIClasses;
using VotifySystem.Common.DataAccess.Database;
using VotifySystem.InPerson.Controls;
using VotifySystem.Common.BusinessLogic.Services;

namespace VotifySystem.InPerson.Forms;

/// <summary>
/// form to view the results of an election
/// </summary>
public partial class frmViewElectionResults : Form
{
    private readonly IDbService? _dbService;
    private readonly ICandidateService? _candidateService;

    private readonly Election? _election;
    private List<Candidate>? _candidates;
    private List<Constituency>? _electionConstituencies;

    public frmViewElectionResults(Election election)
    {
        InitializeComponent();

        if (DesignMode)
            return;

        _dbService = Program.ServiceProvider!.GetService(typeof(IDbService)) as IDbService;
        _candidateService = Program.ServiceProvider!.GetService(typeof(ICandidateService)) as ICandidateService;

        _election = election;       
        
        Init();
    }

    private void Init()
    {
        _candidates = _candidateService!.GetCandidatesByElectionId(_election!.ElectionId);
        _electionConstituencies = _dbService!.GetDatabaseContext().Constituencies.Where(c => c.ElectionId == _election!.ElectionId).ToList();

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
            ctrResultsConstituencyPanelItem item = new(constituency);

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

        List<GenericTieFixCheckItem> tieCheckList = [];

        int partyPosition = 1;
        foreach (Party party in partyConstituencyWins.Keys)
        {            
            tieCheckList.Add(new GenericTieFixCheckItem(party.PartyId, partyPosition, partyConstituencyWins[party].Count)); 
            partyPosition++;
        }

        List<GenericTieFixCheckItem> fixedTieCheckList = FPTPResultsHelper.GenericCheckAndFixTies(tieCheckList);

        foreach (Party p in partyConstituencyWins.Keys)
        {
            int totalVotes = partyTotalVotes[p];
            int totalConstituencyWins = partyConstituencyWins[p].Count;

            // don't add 1 as was done before doing tie check
            int position = fixedTieCheckList.First(t => t.Key == p.PartyId).Position;

            ctrResultsPartyPanelItem item = new(p, position, totalConstituencyWins, totalVotes);

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
