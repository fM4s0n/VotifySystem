﻿using Microsoft.AspNetCore.Identity;
using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.Classes;
using VotifySystem.Common.DataAccess.Database;
using VotifySystem.Common.Forms;

namespace VotifySystem.Common.Controls.Login;

/// <summary>
/// Login control for in person voting
/// </summary>
public partial class ctrLoginInPerson : UserControl
{
    private IUserService? _userService;
    private IDbService? _dbService;

    public ctrLoginInPerson()
    {
        InitializeComponent();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userService"></param>
    /// <param name="dbService"></param>
    public void Init(IUserService userService, IDbService dbService)
    {
        _userService = userService;
        _dbService = dbService;

        //_userService.LogInEvent += UserService_LogInEvent;
    }

    /// <summary>
    /// Event handler for when a user logs in
    /// </summary>
    /// <param name="sender">UserService</param>
    /// <param name="e">EventArgs</param>
    //private void UserService_LogInEvent(object sender, EventArgs e)
    //{
    //    UserLevel userLevel = _userService!.GetCurrentUserLevel();

    //    if (userLevel == UserLevel.Voter)
    //    {
    //        //show ctrVoterHome
    //    }
    //    else if (userLevel == UserLevel.Administrator)
    //    {
    //        //TODO show ctrAdminHome
    //    }
    //}

    /// <summary>
    /// Login using a login code method
    /// </summary>
    public void btnSubmitLoginCode_Click(object sender, EventArgs e)
    {
        // Validate input
        if (string.IsNullOrWhiteSpace(txtLoginCode.Text))
        {
            txtLoginCode.BackColor = Color.Red;
            return;
        }
        else
        {
            txtLoginCode.BackColor = Color.White;
        }

        string loginCode = txtLoginCode.Text.Trim();

        //check db
        bool success = false;

        if (success)
        {
            //TODO
        }
        else
        {

        }
    }

    /// <summary>
    /// Show the create account form
    /// </summary>
    private void btnCreateAccount_Click(object sender, EventArgs e)
    {
        frmCreateAccount frmCreateAccount = new(_userService!, _dbService!);
        frmCreateAccount.ShowDialog();
    }

    /// <summary>
    /// Click event for login button
    /// </summary>
    /// <param name="sender">btnLogin</param>
    /// <param name="e">EventArgs</param>
    private void btnLogin_Click(object sender, EventArgs e)
    {
        if (ValidateUserInput() == false)
        {
            MessageBox.Show("Please check highlighted fields and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);        
            return;           
        }

        User attemptedUser = _dbService!.GetDatabaseContext().Users.First(u => u.Username == txtUsername.Text);

        if (attemptedUser == null)
        {
            MessageBox.Show("Login details not found, please check detials and try again or create an account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (VerifyUser(attemptedUser) == false)
        {
            MessageBox.Show("Login details not found, please check detials and try again or create an account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return; 
        }

        // User is valid, so log in the user
        _userService!.LogInUser(attemptedUser);
    }

    /// <summary>
    /// Verify User password entry
    /// </summary>
    /// <param name="attemptedUser">User matching the username entered</param>
    /// <returns>True if Result is not Failed</returns>
    private bool VerifyUser(User attemptedUser)
    {
        string plainPassword = txtPassword.Text = txtPassword.Text.Trim();
        string hashedPassword = _userService!.HashPassword(attemptedUser, plainPassword);

        return _userService!.VerifyPassword(hashedPassword, plainPassword, attemptedUser) != PasswordVerificationResult.Failed;
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
