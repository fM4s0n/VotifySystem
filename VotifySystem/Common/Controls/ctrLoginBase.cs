﻿using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.Classes;

namespace VotifySystem.Controls;
public partial class ctrLoginBase : UserControl
{
    private IUserService _userService;
    private LoginMode _loginMode;

    public ctrLoginBase() 
    { 
        InitializeComponent();
    }

    /// <summary>
    /// Constructor for Login Control
    /// </summary>
    /// <param name="userService">Singleton User Service</param>
    public ctrLoginBase(IUserService userService, LoginMode loginMode)
    {
        InitializeComponent();

        _userService = userService;
        _loginMode = loginMode;

        if (_loginMode == LoginMode.InPerson)
        {
            ctrLoginInPerson.Visible = true;
            //lblLoginCode.Visible = true;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    private void LoginUser(User user)
    {
        _userService.SetCurrentUser(user);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnCreateAccount_Click(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnLogin_Click(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnSubmitLoginCode_Click(object sender, EventArgs e)
    {
        // check db or something
    }
}

/// <summary>
/// Mode to control which version of the control to show
/// </summary>
public enum LoginMode
{
    InPerson,
    Online
}