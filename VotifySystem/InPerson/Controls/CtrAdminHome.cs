﻿using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.DataAccess.Database;
using VotifySystem.Forms;
using VotifySystem.InPerson.Forms;

namespace VotifySystem.Controls;

/// <summary>
/// Home page for admin user
/// </summary>
public partial class ctrAdminHome : UserControl
{
    private IUserService? _userService;
    private IDbService? _dbService;

    public ctrAdminHome()
    {
        InitializeComponent();

        if (DesignMode)
            return;

        _userService = Program.ServiceProvider!.GetService(typeof(IUserService)) as IUserService;
        _dbService = Program.ServiceProvider!.GetService(typeof(IDbService)) as IDbService;
    }

    /// <summary>
    /// Show Create Election Form
    /// </summary>
    private void btnCreateElection_Click(object sender, EventArgs e)
    {
        frmCreateElection form = new();
        form.Show();
    }

    /// <summary>
    /// Show Manage Election Form
    /// </summary>
    private void btnManageElection_Click(object sender, EventArgs e)
    {
        try
        {
            frmManageElections form = new();
            form.Show();
        }
        catch
        {
            return;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void btnLogOut_Click(object sender, EventArgs e)
    {
        _userService!.LogOutUser();
    }

    /// <summary>
    /// Click event for Manage Parties button
    /// Launch Manage Parties form
    /// </summary>
    private void btnManageParties_Click(object sender, EventArgs e)
    {
        frmManageParties form = new(_dbService!);
        form.ShowDialog();
    }

    /// <summary>
    /// launches the postal vote form
    /// </summary>
    private void btnPostalVote_Click(object sender, EventArgs e)
    {
        frmPostalVote frm = new();
        frm.ShowDialog();
    }
}
