﻿using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.Models;
using VotifySystem.Common.Models.Elections;
using VotifySystem.Common.Controls;
using VotifySystem.Common.DataAccess.Database;

namespace VotifySystem.Common.Forms;
public partial class frmVote : Form
{
    private readonly IUserService? _userService;
    private readonly IElectionService? _electionService;
    private readonly IElectionVoterService? _electionVoterService;

    // TODO: Implement ElectionVoteMechanism for STV
    // private readonly ElectionVoteMechanism? _electionVoteMechanism;

    private List<Election>? _validElections = [];

    // electionVoter is to get the specific ElectionVoter object based on the selected election
    private ElectionVoter? _electionVoter;

    // electionVoters is to get all possible elections the user can vote in
    private List<ElectionVoter>? _electionVoters = [];

    /// <summary>
    /// Constructor for the frmVote
    /// </summary>
    public frmVote()
    {
        InitializeComponent();

        if (DesignMode)
            return;

        _userService = Program.ServiceProvider!.GetService(typeof(IUserService)) as IUserService;
        _electionService = Program.ServiceProvider!.GetService(typeof(IElectionService)) as IElectionService;
        _electionVoterService = Program.ServiceProvider!.GetService(typeof(IElectionVoterService)) as IElectionVoterService;

        Init();
    }

    /// <summary>
    /// Custom init
    /// </summary>
    private void Init()
    {
        if (_userService!.GetCurrentUserLevel() != UserLevel.Voter)
        {
            MessageBox.Show("Only voters may vote in elections", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
            return;
        }

        GetElectionVoters();

        if (_electionVoters!.Count == 0)
        {
            MessageBox.Show("You are not registered to vote in any elections", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
            return;
        }

        List<string> validElectionIds = _electionVoters.Select(ev => ev.ElectionId).ToList();

        _validElections = _electionService!.GetAllElections();
        CheckElectionCount();

        _validElections = _validElections!.Where(e => validElectionIds.Contains(e.ElectionId)).ToList();
        CheckElectionCount();

        _validElections = _validElections.Where(e => e.GetElectionStatus() == ElectionStatus.InProgress).ToList();
        CheckElectionCount();

        InitCmbSelectElection();

        // listen to the vote completed/cancelled events
        // TODO: refactor to be a form close event
        // pass through bool if vote was completed or cancelled
        if (ctrFPTPVote != null)
        {
            ctrFPTPVote.VoteCompleted += ctrFPTPVote_VoteCompleted;
            ctrFPTPVote.VoteCancelled += ctrFPTPVote_VoteCancelled;
        }

        if (ctrPreferentialVote != null)
        {
            ctrPreferentialVote.VoteCompleted += ctrPreferentialVote_VoteCompleted;
            ctrPreferentialVote.VoteCancelled += ctrPreferentialVote_VoteCancelled;
        }
    }

    private void CheckElectionCount()
    {
        if (_validElections == null || _validElections.Count == 0)
        {
            MessageBox.Show("There are no elections to vote in currently, please retry once an election has commenced.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
            return;
        }
    }

    private void GetElectionVoters()
    {
        _electionVoters = _electionVoterService!.GetElectionVotersByVoterId(_userService!.GetCurrentUser()!.Id) ?? null;

        if (_electionVoters == null)
        {
            MessageBox.Show("Error loading elections, please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
            return;
        }

        _electionVoters = _electionVoters.Where(ev => ev.HasVoted == false).ToList();
    }

    /// <summary>
    /// Vote completed event handler
    /// closes the form after updating the db to record the voter has voted in the election
    /// </summary>
    private void ctrFPTPVote_VoteCompleted(object sender, EventArgs e)
    {
        ctrFPTPVote.Visible = false;
        UpdateElectionVoter();
        Close();
    }

    private void ctrFPTPVote_VoteCancelled(object sender, EventArgs e)
    {
        ctrFPTPVote.Visible = false;
        Close();
    }

    /// <summary>
    /// Handles the vote completed event for the preferential vote control
    /// </summary>
    private void ctrPreferentialVote_VoteCompleted(object sender, EventArgs e)
    {
        ctrPreferentialVote.Visible = false;
        UpdateElectionVoter();
        Close();
    }

    private void ctrPreferentialVote_VoteCancelled(object sender, EventArgs e)
    {
        ctrPreferentialVote.Visible = false;
        Close();
    }

    /// <summary>
    /// Updates the election voter to show that the user has voted
    /// </summary>
    private void UpdateElectionVoter()
    {
        _electionVoter!.HasVoted = true;
        _electionVoterService!.UpdateElectionVoter(_electionVoter);
    }

    /// <summary>
    /// sets the datasource for the cmbSelectElection
    /// </summary>
    private void InitCmbSelectElection()
    {
        cmbSelectElection.DataSource = null;
        cmbSelectElection.DisplayMember = "Description";
        cmbSelectElection.ValueMember = "ElectionId";
        cmbSelectElection.DataSource = _validElections;
        cmbSelectElection.SelectedIndex = -1;
    }

    /// <summary>
    /// Click event for the go button
    /// validates the election shows relevant control in tlpVoteControl
    /// </summary>
    private void btnGo_Click(object sender, EventArgs e)
    {
        if (cmbSelectElection.SelectedIndex == -1)
        {
            MessageBox.Show("Please select an election", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        Election election;
        if (cmbSelectElection.SelectedValue is string electionId)
        {
            election = _validElections!.First(e => e.ElectionId == electionId);
        }
        else
        {
            MessageBox.Show("Error Loading Election, please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            cmbSelectElection.SelectedIndex = -1;
            return;
        }
        
        if (election != null)
        {
            lblElectionName.Text = election.Description;
            lblElectionName.Visible = true;

            // set the election voter based on the selected election
            _electionVoter = _electionVoters!.First(ev => ev.ElectionId == election.ElectionId);

            switch (election)
            {
                case FirstPastThePostElection _:
                    SetMode(ElectionVoteMechanism.FPTP);
                    break;
                case SingleTransferrableVoteElection _:
                    SetMode(ElectionVoteMechanism.STV);
                    break;
                case PreferentialVoteElection _:
                    SetMode(ElectionVoteMechanism.Preferential);
                    break;
                default:
                    break;
            }
        }
    }

    /// <summary>
    /// Sets the current mode of the form
    /// </summary>
    /// <param name="electionVoteMechanism">Mode to set the form to</param>
    private void SetMode(ElectionVoteMechanism electionVoteMechanism)
    {
        if (cmbSelectElection.SelectedIndex != -1 && cmbSelectElection.SelectedValue is string)
        {
            pnlVoteControl.Controls.Clear();

            switch (electionVoteMechanism)
            {
                case ElectionVoteMechanism.FPTP:
                    pnlVoteControl.Controls.Add(ctrFPTPVote);
                    ctrFPTPVote.SetElection(_validElections!.First(e => e.ElectionId == cmbSelectElection.SelectedValue.ToString()));
                    ctrFPTPVote.Visible = true;
                    break;
                case ElectionVoteMechanism.STV:
                    throw new NotImplementedException();
                case ElectionVoteMechanism.Preferential:
                    pnlVoteControl.Controls.Add(ctrPreferentialVote);
                    ctrPreferentialVote.SetElection(_validElections!.First(e => e.ElectionId == cmbSelectElection.SelectedValue.ToString()) as PreferentialVoteElection, _electionVoter!);
                    ctrPreferentialVote.Visible = true;
                    break;
                default:
                    break;
            }
        }
    }
}
