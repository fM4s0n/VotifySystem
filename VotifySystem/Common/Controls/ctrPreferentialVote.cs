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
    private ElectionVoter? _electionVoter;
    private readonly Dictionary<int, string> _candidateIdsAndIndexes = [];

    private PreferentialElectionVote? _vote;

    public ctrPreferentialVote()
    {
        InitializeComponent();

        if (DesignMode)
            return;

        _candidateService = Program.ServiceProvider!.GetService(typeof(ICandidateService)) as ICandidateService;
        _partyService = Program.ServiceProvider!.GetService(typeof(IPartyService)) as IPartyService;
        _voteService = Program.ServiceProvider!.GetService(typeof(IPreferentialVoteService)) as IPreferentialVoteService;

        // listen for visibility change to ensure the control is fully initialised before showing
        VisibleChanged += (sender, e) =>
        {
            if (Visible && _election == null || _electionVoter == null)                
                throw new Exception("Election and ElectionVoter must be set before showing the control");     

            if (Visible == false)            
                Reset();
        };
    }

    private void Init()
    {
        _vote = VoteFactory.CreateVote(_election!.ElectionId, ElectionVoteMechanism.Preferential) as PreferentialElectionVote;

        _candidates = _candidateService!.GetCandidatesByElectionId(_election!.ElectionId)!.Where(c => c.ConstituencyId == _electionVoter!.ConstituencyId).ToList() ?? null;

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
    public void SetElection(PreferentialVoteElection election, ElectionVoter electionVoter)
    {
        _election = election;
        _electionVoter = electionVoter;
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
            if (c is Label)
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
        _voteService!.InsertPreferences(preferences);
        _voteService!.InsertVote(_vote);

        if (ConfirmVoteWithUser(preferences) == false)
            return;

        OnVoteCompleted();
    }

    /// <summary>
    /// Builds a message box to confirm the vote with the user
    /// </summary>
    /// <param name="prefs">Prefernces the user has input</param>
    /// <returns>true if user selects yes, false if not</returns>
    private bool ConfirmVoteWithUser(List<PreferentialVotePreference> prefs)
    {
        string message = "Are you sure you want to submit your vote? Your preferences are:";

        foreach (PreferentialVotePreference p in prefs)
        {
            string candidateName = _candidates!.FirstOrDefault(c => c.Id == p.CandidateId)!.FullName;
            message += $"\nRank: {p.Rank} - Candidate: {candidateName}";
        }

        DialogResult result = MessageBox.Show(message, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes)
            return true;

        return false;
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
