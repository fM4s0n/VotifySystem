﻿using VotifySystem.Common.Forms;

namespace VotifySystem.Common.Controls.Login;

/// <summary>
/// 
/// </summary>
public partial class ctrLoginInPerson : UserControl
{
    public ctrLoginInPerson()
    {
        InitializeComponent();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void btnSubmitLoginCode_Click(object sender, EventArgs e)
    {
        string loginCode = txtLoginCode.Text.Trim();

        //check db
        bool success = false;

        if (success)
        {

        }
        else
        {

        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnCreateAccount_Click(object sender, EventArgs e)
    {
        frmCreateAccount frmCreateAccount = new();
        frmCreateAccount.ShowDialog();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnLogin_Click(object sender, EventArgs e)
    {
        if (ValidateUserInput() == false)
            return;
    }

    /// <summary>
    /// Validate user input
    /// </summary>
    /// <returns></returns>
    private bool ValidateUserInput()
    {
        bool success = true;

        foreach (TextBox tb in new List<TextBox> { txtLoginCode, txtPassword}) 
        {
            if (string.IsNullOrEmpty(tb.Text))
            {
                tb.BackColor = Color.Red;
                success = false;
            }
        }

        return success;
    }
}
