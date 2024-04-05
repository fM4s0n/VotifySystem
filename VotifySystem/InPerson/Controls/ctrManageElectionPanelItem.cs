﻿using VotifySystem.Common.BusinessLogic.Helpers;
using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.Classes.Elections;
using VotifySystem.Common.DataAccess.Database;
using VotifySystem.Forms;
using VotifySystem.InPerson.Forms;
using static VotifySystem.Forms.frmCreateElection;

namespace VotifySystem.InPerson.Controls;

/// <summary>
/// 
/// </summary>
public partial class ctrManageElectionPanelItem : UserControl
{
    private readonly IDbService? _dbService;
    private readonly IUserService? _userService;
    private readonly int _index;
    private readonly Election? _election;

    public ctrManageElectionPanelItem(Election election, IDbService dbService, IUserService userService, int index)
    {
        InitializeComponent();

        if (DesignMode)
            return;

        _election = election;
        _dbService = dbService;
        _userService = userService;
        _index = index;

        if (_election != null)
            InitUI();
        else
            throw new ArgumentNullException(nameof(election)); // TODO: wrap call in try catch
    }

    private void InitUI()
    {
        lblElectionDescription.Text = _election!.Description;
        lblElectionCountry.Text = LocalisationHelper.GetCountryName(_election.Country);
        lblRegisteredCandidatesValue.Text =_dbService!.GetDatabaseContext().Candidates.Where(c => c.ElectionId == _election.ElectionId).ToList().Count.ToString();
        lblTotalConstituenciesValue.Text = _dbService!.GetDatabaseContext().Constituencies.Where(c => c.ElectionId == _election.ElectionId).ToList().Count.ToString();
        lblRegisteredVotersValue.Text = _dbService!.GetDatabaseContext().ElectionVoters.Where(v => v.ElectionId == _election.ElectionId).ToList().Count.ToString();
        btnViewResults.Enabled = _election.GetElectionStatus() == ElectionStatus.Completed;
        SetStatusLabel();
        SetDateInfoLabel();

        // Alternate row colour
        if (int.IsEvenInteger(_index))        
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
            frmViewElectionResults frm = new(_dbService!, _election!);
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

            frmCreateElection frm = new(_userService!, _dbService!, _election!, createMode);
            frm.ShowDialog();
        }
        catch
        {
            return;
        }
    }
}