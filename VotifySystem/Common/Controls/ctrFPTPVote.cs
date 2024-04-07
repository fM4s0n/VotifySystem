﻿using VotifySystem.Common.Models;
using VotifySystem.Common.Models.Elections;
using VotifySystem.Common.DataAccess.Database;
using static VotifySystem.Common.Controls.ctrFPTPVote;
using VotifySystem.Common.BusinessLogic.Services;

namespace VotifySystem.Common.Controls;

/// <summary>
/// Control for voting using the First Past The Post voting system
/// </summary>
public partial class ctrFPTPVote : UserControl
{
    private readonly IDbService? _dbService;
    private readonly IFPTPVoteService? _fptpVoteService;

    private readonly Election? _election;
    private List<Candidate> _candidates = [];
    private List<Party> _parties = [];
    List<ComboBoxCandidate> _comboBoxCandidates = [];

    public delegate void VoteCompletedEventHandler(object sender, EventArgs e);
    public event VoteCompletedEventHandler? VoteCompleted;

    public ctrFPTPVote(Election election)
    {
        InitializeComponent();

        if (DesignMode) 
            return;

        _election = election;

        _dbService = Program.ServiceProvider!.GetService(typeof(IDbService)) as IDbService;
        _fptpVoteService = Program.ServiceProvider!.GetService(typeof(IFPTPVoteService)) as IFPTPVoteService;

        Init();
    }

    public void Init()
    {
        _candidates = _dbService!.GetDatabaseContext().Candidates.Where(c => c.ElectionId == _election!.ElectionId).ToList();
        _parties = _dbService.GetDatabaseContext().Parties.ToList();

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

        _fptpVoteService!.InsertFPTPVote(vote);

        OnVoteCompleted();
    }

    /// <summary>
    /// Event to fire when the vote is completed
    /// </summary>
    private void OnVoteCompleted()
    {
        Reset();
        VoteCompleted?.Invoke(this, new EventArgs());
    }

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
