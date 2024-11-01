﻿using VotifySystem.Common.BusinessLogic.Helpers;
using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.Models.Elections;
using VotifySystem.Forms;
using VotifySystem.InPerson.Forms;
using static VotifySystem.Forms.frmCreateElection;

namespace VotifySystem.InPerson.Controls;

/// <summary>
/// 
/// </summary>
public partial class ctrManageElectionPanelItem : UserControl
{
    private readonly ICandidateService? _candidateService;
    private readonly IConstituencyService? _constituencyService;
    private readonly IElectionVoterService? _electionVoterService;

    private readonly int _listIndex;
    private readonly Election? _election;

    public ctrManageElectionPanelItem(Election election, int index)
    {
        InitializeComponent();

        if (DesignMode)
            return;

        _candidateService = Program.ServiceProvider!.GetService(typeof(ICandidateService)) as ICandidateService;
        _constituencyService = Program.ServiceProvider!.GetService(typeof(IConstituencyService)) as IConstituencyService;
        _electionVoterService = Program.ServiceProvider!.GetService(typeof(IElectionVoterService)) as IElectionVoterService;

        _listIndex = index;
        _election = election;

        InitUI();
    }

    private void InitUI()
    {
        lblElectionDescription.Text = _election!.Description;
        lblElectionCountry.Text = LocalisationHelper.GetCountryName(_election.Country);
        lblRegisteredCandidatesValue.Text = _candidateService!.GetCandidatesByElectionId(_election!.ElectionId)?.Count.ToString() ?? "0";
        lblTotalConstituenciesValue.Text = _constituencyService!.GetConstituenciesByElectionId(_election.ElectionId)?.Count.ToString() ?? "0";
        lblRegisteredVotersValue.Text = _electionVoterService!.GetElectionVotersByElectionId(_election.ElectionId)?.Count.ToString() ?? "0";
        btnViewResults.Enabled = _election.GetElectionStatus() == ElectionStatus.Completed;
        SetStatusLabel();
        SetDateInfoLabel();

        // Alternate row colour
        if (int.IsEvenInteger(_listIndex))        
            BackColor = Color.WhiteSmoke;        
    }

    /// <summary>
    /// sets the date info label based on the election status
    /// displays the number of days until the election starts, ends or ended
    /// changes colour of the label based on the status also
    /// </summary>
    private void SetDateInfoLabel()
    {
        int days;
        switch (_election!.GetElectionStatus())
        {
            case ElectionStatus.NotStarted:
                days = (_election.StartDate - DateTime.Now).Days;
                lblDateInfo.ForeColor = Color.Red;
                lblDateInfo.Text = $"Election starts in {days} days";
                break;
            case ElectionStatus.InProgress:
                days = (_election.EndDate - DateTime.Now).Days;
                lblDateInfo.ForeColor = Color.Green;
                lblDateInfo.Text = $"Election ends in {days} days";
                break;
            case ElectionStatus.Completed:
                days = (DateTime.Now - _election.EndDate).Days;
                lblDateInfo.ForeColor = Color.Black;
                lblDateInfo.Text = $"Election ended {days} days ago";
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Set lblStatus text based on the election status
    /// </summary>
    private void SetStatusLabel()
    {
        lblStatus.Text = _election!.GetElectionStatus() switch
        {
            ElectionStatus.NotStarted => "Not Started",
            ElectionStatus.InProgress => "In Progress",
            ElectionStatus.Completed => "Completed",
            _ => "Unknown",
        };
    }

    private void btnViewResults_Click(object sender, EventArgs e)
    {
        try
        {
            frmViewElectionResults frm = new(_election!);
            frm.ShowDialog();
        }
        catch
        {
            return;
        }
    }

    private void btnElectionDetails_Click(object sender, EventArgs e)
    {
        try
        {
            CreateElectionFormMode createMode = CreateElectionFormMode.View;

            if (_election!.GetElectionStatus() == ElectionStatus.NotStarted)            
                createMode = CreateElectionFormMode.Edit;            

            frmCreateElection frm = new(_election!, createMode);
            frm.ShowDialog();
        }
        catch
        {
            return;
        }
    }
}
