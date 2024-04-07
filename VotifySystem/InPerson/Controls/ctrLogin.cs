using Microsoft.AspNetCore.Identity;
using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.Models;
using VotifySystem.Common.DataAccess.Database;
using VotifySystem.Common.Forms;
using VotifySystem.Controls;

namespace VotifySystem.Common.Controls.Login;

/// <summary>
/// Login control for in person voting
/// </summary>
public partial class ctrLogin : UserControl
{
    private readonly IUserService? _userService;
    private LoginMode _loginMode = LoginMode.InPerson;

    public ctrLogin()
    {
        InitializeComponent();

        if (DesignMode)
            return;

        _userService = Program.ServiceProvider!.GetService(typeof(IUserService)) as IUserService;
    }

    /// <summary>
    /// 
    /// </summary>
    public void Init(LoginMode loginMode)    
    {
        _loginMode = loginMode;

        SetMode();

        // Listen for enter key press on login code textbox
        txtLoginCode.KeyDown += (sender, e) =>
        {
            if (e.KeyCode == Keys.Enter)            
                btnSubmitLoginCode_Click(sender!, e);            
        };

        // Listen for enter key press on password textbox
        txtPassword.KeyDown += (sender, e) =>
        {
            if (e !=null && e.KeyCode == Keys.Enter)            
                btnLogin_Click(sender!, e);            
        };
    }

    /// <summary>
    /// Set mode of the control based on the login mode passed in
    /// Online does not show the login code section
    /// </summary>
    private void SetMode()
    {
        if (_loginMode == LoginMode.InPerson)
        {
            lblLoginCode.Visible = true;
            txtLoginCode.Visible = true;
            btnSubmitLoginCode.Visible = true;
            grpLoginOneTimeCode.Visible = true;
        }
        else
        {
            lblLoginCode.Visible = false;
            txtLoginCode.Visible = false;
            btnSubmitLoginCode.Visible = false;
            grpLoginOneTimeCode.Visible = false;
        }
    }

    /// <summary>
    /// Login using a login code method
    /// </summary>
    public void btnSubmitLoginCode_Click(object sender, EventArgs e)
    {
        string loginCode = txtLoginCode.Text = txtLoginCode.Text.Trim();
        if (ValidateLoginCodeText(loginCode) == false)
            return;

        LoginCode? foundCode = _userService!.GetLoginCodeByCode(loginCode) ?? null;

        if (foundCode == null) 
        {
            MessageBox.Show("Error with login code, please generate a new code and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (foundCode.Valid == false)
        {
            MessageBox.Show("Login code is invalid or expired", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        User? user = _userService!.GetUserById(foundCode.UserId);

        if (user == null)
        {
            MessageBox.Show("User not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        foundCode.Used = true;
        _userService.InsertLoginCode(foundCode);

        _userService!.LogInUser(user, LoginMode.InPerson);
    }

    /// <summary>`
    /// Validates the code input is correct length
    /// </summary>
    /// <returns>True if the length is 6, false if not</returns>
    private bool ValidateLoginCodeText(string loginCode)
    {
        if (loginCode.Length != 6)
        {
            txtLoginCode.BackColor = Color.Red;
            MessageBox.Show("Login code must be 6 characters long", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        txtLoginCode.BackColor = Color.White;
        return true;
    }

    /// <summary>
    /// Show the create account form
    /// </summary>
    private void btnCreateAccount_Click(object sender, EventArgs e)
    {
        frmCreateAccount frmCreateAccount = new(_userService!);
        frmCreateAccount.ShowDialog();
    }

    /// <summary>
    /// Click event for login button
    /// </summary>
    private void btnLogin_Click(object sender, EventArgs e)
    {
        if (ValidateUserInput() == false)
        {
            MessageBox.Show("Please check highlighted fields and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);        
            return;           
        }

        User? attemptedUser = _userService!.GetUserByUsername(txtUsername.Text);

        if (attemptedUser == null)
        {
            MessageBox.Show("Login details not found, please check details and try again or create an account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            ResetControl();
            return;
        }

        if (_loginMode == LoginMode.Online && attemptedUser.UserLevel == UserLevel.Administrator)
        {
            MessageBox.Show("Administrators cannot login in online. Please login in person.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (VerifyUser(attemptedUser) == false)
        {
            MessageBox.Show("Login details not found, please check details and try again or create an account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return; 
        }

        // User is valid, so log in the user
        _userService!.LogInUser(attemptedUser, _loginMode);
    }

    /// <summary>
    /// Verify User password entry
    /// </summary>
    /// <param name="attemptedUser">User matching the username entered</param>
    /// <returns>True if Result is not Failed</returns>
    private bool VerifyUser(User attemptedUser)
    {
        string plainPassword = txtPassword.Text = txtPassword.Text.Trim();

        PasswordVerificationResult result = _userService!.VerifyPassword(plainPassword, attemptedUser);       
        
        return result == PasswordVerificationResult.Success || result == PasswordVerificationResult.SuccessRehashNeeded;
    }

    /// <summary>
    /// Validate user input
    /// </summary>
    /// <returns></returns>
    private bool ValidateUserInput()
    {
        bool success = true;

        foreach (TextBox tb in new List<TextBox> { txtUsername, txtPassword}) 
        {
            tb.Text = tb.Text.Trim();

            if (string.IsNullOrEmpty(tb.Text))
            {
                tb.BackColor = Color.Red;
                success = false;
            }
        }

        return success;
    }

    /// <summary>
    /// rest the control's textboxes
    /// </summary>
    public void ResetControl()
    {
        txtUsername.Text = string.Empty;
        txtPassword.Text = string.Empty;
        txtLoginCode.Text = string.Empty;
    }
}
