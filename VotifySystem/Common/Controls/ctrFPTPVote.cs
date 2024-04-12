using VotifySystem.Common.Models;
using VotifySystem.Common.Models.Elections;
using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.Models.Votes;

namespace VotifySystem.Common.Controls;

/// <summary>
/// Control for voting using the First Past The Post voting system
/// </summary>
public partial class ctrFPTPVote : UserControl
{
    private readonly ICandidateService? _candidateService;
    private readonly IFPTPElectionVoteService? _fptpVoteService;
    private readonly IPartyService? _partyService;

    public delegate void VoteCompletedEventHandler(object sender, EventArgs e);
    public event VoteCompletedEventHandler? VoteCompleted;

    public delegate void VoteCancelledEventHandler(object sender, EventArgs e);
    public event VoteCancelledEventHandler? VoteCancelled;

    private Election? _election;
    private List<Candidate> _candidates = [];
    private List<Party> _parties = [];
    List<ComboBoxCandidate> _comboBoxCandidates = [];

    public ctrFPTPVote()
    {
        InitializeComponent();

        if (DesignMode)
            return;

        _fptpVoteService = Program.ServiceProvider!.GetService(typeof(IFPTPElectionVoteService)) as IFPTPElectionVoteService;
        _candidateService = Program.ServiceProvider!.GetService(typeof(ICandidateService)) as ICandidateService;
        _partyService = Program.ServiceProvider!.GetService(typeof(IPartyService)) as IPartyService;
    }

    public void SetElection(Election election)
    {
        _election = election;
        Init();
    }

    public void Init()
    {
        _candidates = _candidateService!.GetCandidatesByElectionId(_election!.ElectionId)!;
        _parties = _partyService!.GetAllParties()!;

        InitComboBoxDataSource();
    }

    /// <summary>
    /// inits the datasource for the ComboBox and randomises the order
    /// </summary>
    private void InitComboBoxDataSource()
    {
        foreach (Candidate c in _candidates)
        {
            ComboBoxCandidate cbc = new()
            {
                FullName = c.FullName,
                PartyName = _parties.First(p => p.PartyId == c.PartyId).Name,
                CandidateId = c.Id
            };

            _comboBoxCandidates.Add(cbc);
        }

        // randomise the order of the candidates
        Random rnd = new();
        _comboBoxCandidates = _comboBoxCandidates.OrderBy(c => rnd.Next()).ToList();

        cmbSelectCandidate.DataSource = null;
        cmbSelectCandidate.DataSource = _comboBoxCandidates;
        cmbSelectCandidate.SelectedIndex = -1;
    }

    /// <summary>
    /// Submit vote button click event
    /// </summary>
    private void btnSubmitVote_Click(object sender, EventArgs e)
    {
        if (cmbSelectCandidate.SelectedItem == null)
        {
            MessageBox.Show("Please select a candidate", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        ComboBoxCandidate selectedCandidate = (ComboBoxCandidate)cmbSelectCandidate.SelectedItem;
        Candidate candidate = _candidates.First(c => c.Id == selectedCandidate.CandidateId);

        string partyName = _parties.First(p => p.PartyId == candidate.PartyId).Name;
        if (MessageBox.Show($"You have selected {candidate.FullName} - {partyName}. Please confirm you wish to proceed", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
        {
            cmbSelectCandidate.SelectedIndex = -1;
            return;
        }

        FPTPElectionVote? vote = VoteFactory.CreateVote(_election!.ElectionId, ElectionVoteMechanism.FPTP) as FPTPElectionVote;
        vote!.CastVote(candidate.Id);

        _fptpVoteService!.InsertVote(vote);

        OnVoteCompleted();
    }

    /// <summary>
    /// Fire event when the vote is completed
    /// </summary>
    private void OnVoteCompleted()
    {
        Reset();
        VoteCompleted?.Invoke(this, new EventArgs());
    }

    /// <summary>
    /// Fire event when the vote is cancelled
    /// </summary>
    private void OnVoteCancelled()
    {
        Reset();
        VoteCancelled?.Invoke(this, new EventArgs());
    }

    private void btnCancel_Click(object sender, EventArgs e) => OnVoteCancelled();    

    /// <summary>
    /// Reset the control and clear all data
    /// </summary>
    private void Reset()
    {
        cmbSelectCandidate.SelectedIndex = -1;
        cmbSelectCandidate.DataSource = null;
        _comboBoxCandidates.Clear();
        _candidates.Clear();
        _parties.Clear();
    }

    /// <summary>
    /// Class to hold the data for the ComboBox
    /// makes it easier to display the data and get the selected value
    /// </summary>
    internal class ComboBoxCandidate()
    {
        internal string FullName { get; set; } = string.Empty;
        internal string PartyName { get; set; } = string.Empty;
        internal string CandidateId { get; set; } = string.Empty;
        //internal string DisplayText { get { return $"{FullName} - {PartyName}"; } }
        public override string ToString()
        {
            return $"{FullName} - {PartyName}";
        }
    }
}
