using System.Xml.Serialization;
using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.Models;
using VotifySystem.Common.Models.Elections;
using VotifySystem.Common.Models.Votes;

namespace VotifySystem.Common.Controls;

/// <summary>
/// 
/// </summary>
public partial class ctrPreferentialVote : UserControl
{
    private readonly ICandidateService? _candidateService;
    private readonly IPartyService? _partyService;
    private readonly IPreferentialVoteService? _voteService;

    public delegate void VoteCompletedEventHandler(object sender, EventArgs e);
    public event VoteCompletedEventHandler? VoteCompleted;

    public delegate void VoteCancelledEventHandler(object sender, EventArgs e);
    public event VoteCancelledEventHandler? VoteCancelled;

    private PreferentialVoteElection? _election;
    private List<Candidate>? _candidates;
    private Dictionary<int, string>? _candidateIdsAndIndexes;

    private PreferentialElectionVote _vote;

    public ctrPreferentialVote()
    {
        InitializeComponent();

        if (DesignMode)
            return;

        _candidateService = Program.ServiceProvider!.GetService(typeof(ICandidateService)) as ICandidateService;
        _partyService = Program.ServiceProvider!.GetService(typeof(IPartyService)) as IPartyService;
    }

    private void Init()
    {
        _vote = VoteFactory.CreateVote(_election!.ElectionId, ElectionVoteMechanism.Preferential) as PreferentialElectionVote;

        _candidates = _candidateService!.GetCandidatesByElectionId(_election!.ElectionId);

        if (_candidates == null || _candidates.Count == 0)
        {
            MessageBox.Show("No candidates found for this election", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        InitFlpCandidateOptions();
    }

    /// <summary>
    /// Initialises the flow layout panel for the candidate options
    /// </summary>
    private void InitFlpCandidateOptions()
    {
        flpCandidateOptions.Controls.Clear();

        foreach (Candidate c in _candidates!)
        {
            string? partyName = _partyService!.GetPartyById(c.PartyId)!.Name ?? "Unknown";
            Label label = new()
            {
                Text = $"{c.FullName} - {partyName}",
                Width = flpCandidateOptions.Width / 2
            };

            flpCandidateOptions.Controls.Add(label);

            // add candidateId and index of the control in the flp to dictionary
            _candidateIdsAndIndexes!.Add(flpCandidateOptions.Controls.IndexOf(label), c.Id);

            NumericUpDown numericUpDown = new()
            {
                Minimum = 0,
                Maximum = _candidates.Count,
                Value = 1
            };

            flpCandidateOptions.Controls.Add(numericUpDown);
        }
    }

    /// <summary>
    /// Sets the election for the control
    /// </summary>
    /// <param name="election">Election of type PreferentialVoteElection</param>
    public void SetElection(PreferentialVoteElection election)
    {
        _election = election;
        Init();
    }

    private void OnVoteCompleted()
    {
        Reset();
        VoteCompleted?.Invoke(this, new EventArgs());
    }

    private void OnVoteCancelled()
    {
        Reset();
        VoteCancelled?.Invoke(this, new EventArgs());
    }

    private void Reset()
    {
        flpCandidateOptions.Controls.Clear();
        _candidates = null;
        _election = null;
    }

    private void btnSubmit_Click(object sender, EventArgs e)
    {
        if (ValidateNumericUpDowns() == false)
            return;

        List<PreferentialVotePreference> preferences = [];

        foreach (Control c in flpCandidateOptions.Controls)
        {
            if (c is Label label)
            {
                // get candidateId dictionary value
                string candidateId = _candidateIdsAndIndexes![flpCandidateOptions.Controls.IndexOf(c)];

                // get value from numeric up down
                int indexOfValue = flpCandidateOptions.Controls.IndexOf(c) + 1;
                int rank = (int)((NumericUpDown)flpCandidateOptions.Controls[indexOfValue]).Value;

                preferences.Add(CreatePreference(rank, candidateId)); 
            }
        }

        // cast vote and insert into db
        _vote!.CastVote(preferences);
        _voteService!.InsertVote(_vote);

        OnVoteCompleted();
    }

    /// <summary>
    /// Creates a preference object
    /// </summary>
    /// <param name="rank">rank of the preference</param>
    /// <param name="candidateId">CandidateId</param>
    /// <returns>New preference</returns>
    private PreferentialVotePreference CreatePreference(int rank, string candidateId)
    {
        string electionId = _election!.ElectionId;
        string voteId = _vote!.VoteId;       

        return new PreferentialVotePreference(electionId, voteId, rank, candidateId);
    }

    private bool ValidateNumericUpDowns()
    {
        List<int> values = [];

        foreach (Control c in flpCandidateOptions.Controls)
        {
            if (c is NumericUpDown numericUpDown)            
                values.Add((int)numericUpDown.Value);            
        }

        // check for duplicates
        if (values.Distinct().Count() != values.Count)
        {
            MessageBox.Show("Please ensure all ranks are unique", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        return true;
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        OnVoteCancelled();
    }
}
