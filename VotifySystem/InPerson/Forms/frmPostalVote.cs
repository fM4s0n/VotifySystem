using VotifySystem.Common.BusinessLogic.Helpers;
using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.Classes;
using VotifySystem.Common.Classes.Elections;
using VotifySystem.Common.DataAccess.Database;

namespace VotifySystem.InPerson.Forms;

/// <summary>
/// Form for admins to add postal votes to candidates in an election
/// </summary>
public partial class frmPostalVote : Form
{
    private readonly IUserService _userService;
    private readonly IDbService _dbService;

    private List<Election> _elections = [];
    private List<Candidate> _candidates = [];

    public frmPostalVote(IUserService userService, IDbService dbService)
    {
        InitializeComponent();

        if (DesignMode)
            return;

        _userService = userService;
        _dbService = dbService;

        Init();
    }

    private void Init()
    {
        if (_userService.GetCurrentUserLevel() != UserLevel.Administrator)
        {
            MessageBox.Show("You do not have permission to access this page");
            Close();
        }

        foreach (Country country in Enum.GetValues(typeof(Country)))
            cmbCountry.Items.Add(country);
    }

    /// <summary>
    /// loads elections into cmbElection based on country selected
    /// </summary>
    private void cmbCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbCountry.SelectedIndex == -1)
            return;

        _elections = _dbService!.GetDatabaseContext().Elections.Where(e => e.Country == (Country)cmbCountry.SelectedItem).ToList();

        if (_elections.Count == 0)
        {
            MessageBox.Show("No elections found for this country", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Close();
        }

        InitElectionComboBox();

        cmbCountry.Enabled = false;
    }

    /// <summary>
    /// Loads candidates based on value selected in Election combo box 
    /// </summary>
    private void cmbElection_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbElection.SelectedIndex == -1)
            return;

        _candidates = _dbService!.GetDatabaseContext().Candidates.Where(c => c.ElectionId == cmbElection.SelectedValue.ToString()).ToList();

        InitCandidateComboBox();

        cmbElection.Enabled = false;
    }

    private void InitElectionComboBox()
    {
        cmbElection.DataSource = null;
        cmbElection.DisplayMember = "Description";
        cmbElection.ValueMember = "ElectionId";
        cmbElection.DataSource = _elections;
    }

    private void InitCandidateComboBox()
    {
        cmbCandidate.DataSource = null;
        cmbCandidate.DisplayMember = "FullName";
        cmbCandidate.ValueMember = "Id";
        cmbCandidate.DataSource = _candidates;
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void btnReset_Click(object sender, EventArgs e)
    {
        ResetForm();
    }

    private void ResetForm()
    {
        _elections.Clear();
        _candidates.Clear();
        cmbCountry.SelectedIndex = -1;
        cmbElection.DataSource = null;
        cmbElection.SelectedIndex = -1;
        cmbCandidate.SelectedIndex = -1;
        cmbCandidate.DataSource = null;
        txtVotesToAdd.Text = string.Empty;
    }

    /// <summary>
    /// 
    /// </summary>
    private void btnSubmit_Click(object sender, EventArgs e)
    {
        if (cmbCandidate.SelectedIndex != -1)
        {
            MessageBox.Show("Please select a candidate", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        Candidate candidate = _candidates.First(c => c.Id == cmbCandidate.SelectedValue.ToString());

        if (candidate == null) 
        {
            cmbCandidate.SelectedIndex = -1;
            InitCandidateComboBox();
            return;
        }

        if (ValidateVoteInput())
        {
            candidate.AddVotes(int.Parse(cmbCandidate.Text));
            _dbService.UpdateEntity(candidate);

            MessageBox.Show($"{cmbCandidate.Text} votes added for {candidate.FullName}", "Votes added", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
    }

    /// <summary>
    /// Validates the vote input text is not nullOrWhiteSpace and is a number over 0
    /// </summary>
    /// <returns></returns>
    private bool ValidateVoteInput()
    {        
        txtVotesToAdd.Text = txtVotesToAdd.Text.Trim();

        if (string.IsNullOrWhiteSpace(txtVotesToAdd.Text))
        {
            MessageBox.Show("Please enter number of votes to add", "Add votes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtVotesToAdd.BackColor = Color.Red;
            return false;
        }

        if (int.TryParse(txtVotesToAdd.Text, out int result))
        {
            if (result > 0)
                return true;

            return false;
        }
        else
        {
            MessageBox.Show("Please enter a number", "Add votes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
    }
}
