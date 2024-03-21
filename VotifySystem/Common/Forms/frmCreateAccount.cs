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
    /// Click event for submit button
    /// Validates all user input and creates a new voter  and 
    /// inserts into db if valid
    /// </summary>
    /// <param name="sender">Button</param>
    /// <param name="e">EventArgs</param>
    private void btnSubmit_Click(object sender, EventArgs e)
    {
        if (ValidateAllUserInput())
        {
            // Convert freindly name to enum
            VoteMethod voteMethod = cmbVoteMethod.SelectedValue switch
            {
                "Online" => VoteMethod.Online,
                "Postal" => VoteMethod.Postal,
                _ => VoteMethod.InPerson
            };

            Country country = (Country)cmbCountry.SelectedItem!;

            Voter newVoter = new(txtFirstName.Text, txtLastName.Text, txtEmail.Text, voteMethod, txtAddress.Text, dtpDoB.Value, country);
            newVoter.Password = _userService!.HashPassword(newVoter, txtPassword.Text);

            _dbService!.InsertEntity(newVoter);

            Close();
        }
    }

    /// <summary>
    /// Validate all user input 
    /// </summary>
    /// <returns>True if valid, false if not</returns>
    private bool ValidateAllUserInput()
    {
        return ValidateTextBoxes()
            && ValidateDateOfBirth()
            && ValidateComboBoxes();
    }

    /// <summary>
    /// Validate all textboxes and highlight any that are invalid
    /// </summary>
    /// <returns>True if all input is vlaid</returns>
    private bool ValidateTextBoxes()
    {
        bool success = true;

        TrimAllTextBoxes();

        foreach (TextBox inputBox in new List<TextBox> { txtFirstName, txtLastName, txtAddress, txtEmail, txtPassword })
        {
            if (string.IsNullOrEmpty(inputBox.Text))
            {
                inputBox.BackColor = Color.Red;
                success = false;
            }
            else
            {
                inputBox.BackColor = Color.White;
            }
        }

        return success;
    }

    /// <summary>
    /// validate date of birth and highlight if invalid
    /// </summary>
    /// <returns>true if over 18 otherwise false</returns>
    private bool ValidateDateOfBirth()
    {
        if (dtpDoB.Value > DateTime.Today.AddYears(-18))
        {
            dtpDoB.Value = DateTime.Today.AddYears(-18);
            dtpDoB.BackColor = Color.Red;
            return false;
        }
        else
        {
            dtpDoB.BackColor = Color.White;
            return true;
        }
    }

    /// <summary>
    /// Check if comboboxes have a selected value and highlight if not
    /// </summary>
    /// <returns>True if both have a selected value, false if not</returns>
    private bool ValidateComboBoxes()
    {
        bool success = true;

        foreach (ComboBox dropDown in new List<ComboBox> { cmbCountry, cmbVoteMethod })
        {
            if (string.IsNullOrEmpty(dropDown.SelectedText))
            {
                dropDown.BackColor = Color.Red;
                success = false;
            }
            else
            {
                dropDown.BackColor = Color.White;
            }
        }

        return success;
    }

    /// <summary>
    /// Trims all textboxes
    /// </summary>
    private void TrimAllTextBoxes()
    {
        foreach (TextBox tb in new List<TextBox> { txtFirstName, txtLastName, txtAddress, txtEmail, txtPassword })
        {
            tb.Text = tb.Text.Trim();
        }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        Close();
    }
}
