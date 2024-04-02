using VotifySystem.Common.BusinessLogic.Helpers;
using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.Classes.Elections;
using VotifySystem.Common.DataAccess.Database;
using VotifySystem.Forms;
using VotifySystem.InPerson.Forms;

namespace VotifySystem.InPerson.Controls;

/// <summary>
/// 
/// </summary>
public partial class ctrManageElectionPanelItem : UserControl
{
    private IDbService? _dbService;
    private IUserService? _userService;

    private Election? _election;

    public ctrManageElectionPanelItem(Election election, IDbService dbService, IUserService userService)
    {
        InitializeComponent();

        if (DesignMode)
            return;

        _election = election;
        _dbService = dbService;
        _userService = userService;

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
    }

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
            frmViewElectionResults frm = new(_election!, _dbService!, _userService!);
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
            frmCreateElection frm = new(_userService!, _dbService!, _election!, false);
            frm.ShowDialog();
        }
        catch
        {
            return;
        }
    }
}
