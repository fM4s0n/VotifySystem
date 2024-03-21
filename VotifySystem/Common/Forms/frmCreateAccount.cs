using VotifySystem.Common.BusinessLogic.Helpers;
using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.Classes;
using VotifySystem.Common.DataAccess.Database;

namespace VotifySystem.Common.Forms;

/// <summary>
/// Create Account form for voter to create an account
/// </summary>
internal partial class frmCreateAccount : Form
{
    private IUserService? _userService;
    private IDbService? _dbService;

    internal frmCreateAccount(IUserService userService, IDbService dbService)
    {
        InitializeComponent();

        if (DesignMode)
            return;

        _userService = userService;
        _dbService = dbService;

        Init();
    }

    /// <summary>
    /// Custom init method
    /// </summary>
    private void Init()
    {
        foreach (VoteMethod vm in Enum.GetValues(typeof(VoteMethod)))
            cmbVoteMethod.Items.Add(VoterHelper.VoteMethodFriendlyNames[vm.ToString()]);

        foreach (Country c in Enum.GetValues(typeof(Country)))
            cmbCountry.Items.Add(c);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnSubmit_Click(object sender, EventArgs e)
    {
        if (ValidateUserInput())
        {
            VoteMethod voteMethod = cmbVoteMethod.SelectedValue switch
            {
                "Online" => VoteMethod.Online,
                "Postal" => VoteMethod.Postal,
                _ => VoteMethod.InPerson
            };            

            Voter newVoter = new(txtFirstName.Text, txtLastName.Text, txtEmail.Text, voteMethod, txtAddress.Text, dtpDoB.Value);
            newVoter.Password = _userService.HashPassword(newVoter, txtPassword.Text);

            _dbService.InsertEntity(newVoter);

            Close();
        }
    }

    /// <summary>
    /// Validate all user input 
    /// </summary>
    /// <returns>True if valid, false if not</returns>
    private bool ValidateUserInput()
    {
        foreach (TextBox inputBox in new List<TextBox> { txtFirstName, txtLastName, txtAddress })
        {
            bool success = true;
            if (string.IsNullOrEmpty(inputBox.Text))
            {
                inputBox.BackColor = Color.Red;
                success = false;
            }
            else
            {
                inputBox.BackColor = Color.White;
            }

            if (success == false)
                return success;
        }

        if (dtpDoB.Value > DateTime.Today.AddYears(-18))
        {
            dtpDoB.Value = DateTime.Today.AddYears(-18);
            dtpDoB.BackColor = Color.Red;
        }
        else
        {
            dtpDoB.BackColor = Color.White;
        }

        foreach (ComboBox dropDown in new List<ComboBox> { cmbCountry, cmbVoteMethod })
        {
            if (string.IsNullOrEmpty(dropDown.SelectedText))
            {
                dropDown.BackColor = Color.Red;
            }
            else
            {
                dropDown.BackColor = Color.White;
            }
        }

        return true;
    }
}
