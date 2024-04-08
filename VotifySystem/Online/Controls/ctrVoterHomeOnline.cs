using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.Models;
using VotifySystem.Common.DataAccess.Database;
using VotifySystem.Common.Forms;
using VotifySystem.InPerson.Forms;

namespace VotifySystem.Online.Controls;

/// <summary>
/// Online voting home control
/// </summary>
public partial class ctrVoterHomeOnline : UserControl
{
    private readonly IUserService? _userService;

    public ctrVoterHomeOnline()
    {
        InitializeComponent();

        if (DesignMode)
            return;

        _userService = Program.ServiceProvider!.GetService(typeof(IUserService)) as IUserService;
    }

    /// <summary>
    /// Generates a one-time login code
    /// </summary>
    private void btnGenerateLoginCode_Click(object sender, EventArgs e)
    {
        LoginCode code = _userService!.GenerateLoginCode();

        lblLoginCode.Text = code.Code;

        lblExpiryWarning.Visible = true;
        lblLoginCode.Visible = true;

        _userService!.InsertLoginCode(code);
    }

    private void btnRegister_Click(object sender, EventArgs e)
    {
        frmRegisterToVote frm = new();
        frm.ShowDialog();
    }

    private void btnVoteOnline_Click(object sender, EventArgs e)
    {
        try
        {
            frmVote frm = new();
            frm.ShowDialog();
        }
        catch
        {
            return;
        }
    }

    /// <summary>
    /// Copies the login code to the clipboard
    /// </summary>
    private void btnCopyCode_Click(object sender, EventArgs e) => Clipboard.SetText(lblLoginCode.Text);    
}
