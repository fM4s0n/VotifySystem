using VotifySystem.Common.BusinessLogic.Helpers;
using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.Models;
using VotifySystem.Common.Models.Elections;
using VotifySystem.Common.DataAccess.Database;

namespace VotifySystem.InPerson.Forms;

/// <summary>
/// Form for admins to add postal votes to candidates in an election
/// </summary>
public partial class frmPostalVote : Form
{
    private readonly IUserService? _userService;
    private readonly IElectionService? _electionService;
    private readonly ICandidateService? _candidateService;
    private readonly IFPTPVoteService? _fptpVoteService;

    private List<Election>? _elections = [];
    private List<Candidate>? _candidates = [];

    public frmPostalVote()
    {
        InitializeComponent();

        if (DesignMode)
            return;

        _userService = Program.ServiceProvider!.GetService(typeof(IUserService)) as IUserService;
        _electionService = Program.ServiceProvider!.GetService(typeof(IElectionService)) as IElectionService;
        _candidateService = Program.ServiceProvider!.GetService(typeof(ICandidateService)) as ICandidateService;
        _fptpVoteService = Program.ServiceProvider!.GetService(typeof(IFPTPVoteService)) as IFPTPVoteService;

        Init();
    }

    private void Init()
    {
        if (_userService!.GetCurrentUserLevel() != UserLevel.Administrator)
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

        if (cmbCountry.SelectedItem is Country selectedCountry)
        {
            _elections = _electionService!.GetElectionsByCountry(selectedCountry);

            if (_elections == null || _elections.Count == 0)
            {
                MessageBox.Show("No elections found for this country", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Filter out elections that are not in progress
            _elections = _elections.Where(e => e.GetElectionStatus() == ElectionStatus.InProgress).ToList();
        }
        else
        {
            cmbCountry.SelectedIndex = -1;
            MessageBox.Show("Error selecting Country, please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        InitElectionComboBox();

        cmbCountry.Enabled = false;
        cmbElection.Enabled = true;
    }

    /// <summary>
    /// Loads candidates based on value selected in Election combo box 
    /// </summary>
    private void cmbElection_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbElection.SelectedIndex == -1)
            return;

        if (cmbElection.SelectedItem is Election selectedElection)
            _candidates = _candidateService!.GetCandidatesByElectionId(selectedElection.ElectionId);

        InitCandidateComboBox();

        cmbElection.Enabled = false;
        cmbCandidate.Enabled = true;
    }

    private void InitElectionComboBox()
    {
        cmbElection.SelectedIndexChanged -= cmbElection_SelectedIndexChanged;
        cmbElection.DataSource = null;
        cmbElection.DisplayMember = "Description";
        cmbElection.ValueMember = "ElectionId";
        cmbElection.DataSource = _elections;
        cmbElection.SelectedIndex = -1;
        cmbElection.SelectedIndexChanged += cmbElection_SelectedIndexChanged;
    }

    private void InitCandidateComboBox()
    {
        cmbCandidate.SelectedIndexChanged -= cmbCandidate_SelectedIndexChanged;
        cmbCandidate.DataSource = null;
        cmbCandidate.DisplayMember = "FullName";
        cmbCandidate.ValueMember = "Id";
        cmbCandidate.DataSource = _candidates;
        cmbCandidate.SelectedIndex = -1;
        cmbCandidate.SelectedIndexChanged += cmbCandidate_SelectedIndexChanged;
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
        _elections!.Clear();
        _candidates!.Clear();
        cmbCountry.SelectedIndex = -1;
        cmbElection.DataSource = null;
        cmbElection.SelectedIndex = -1;
        cmbCandidate.SelectedIndex = -1;
        cmbCandidate.DataSource = null;
        txtVotesToAdd.Text = string.Empty;
    }

    private void btnSubmit_Click(object sender, EventArgs e)
    {
        if (cmbCandidate.SelectedIndex == -1)
        {
            MessageBox.Show("Please select a candidate", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        Candidate? candidate = _candidates!.FirstOrDefault(c => c.Id == cmbCandidate.SelectedValue.ToString()) ?? null;

        if (candidate == null)
        {
            cmbCandidate.SelectedIndex = -1;
            InitCandidateComboBox();
            return;
        }

        if (ValidateVoteInput())
        {
            int votesToAdd = int.Parse(txtVotesToAdd.Text);

            if (candidate.ElectionVoteMechanism == ElectionVoteMechanism.FPTP)
            {
                for (int i = 0; i < votesToAdd; i++)
                {
                    FPTPElectionVote? vote = VoteFactory.CreateVote(candidate.ElectionId, candidate.ElectionVoteMechanism) as FPTPElectionVote;
                    _fptpVoteService!.InsertVote(vote!);
                }
            }

            //TODO: Add other vote mechanisms here

            MessageBox.Show($"{txtVotesToAdd.Text} votes added for {candidate.FullName}", "Votes added", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

    private void cmbCandidate_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbCandidate.SelectedIndex == -1)
            return;

        btnSubmit.Enabled = true;
        txtVotesToAdd.Enabled = true;
    }
}
