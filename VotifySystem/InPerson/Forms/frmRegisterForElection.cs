using VotifySystem.Common.BusinessLogic.Services;

namespace VotifySystem.InPerson.Forms;

/// <summary>
/// Form for a voter to register to be able to vote in an Election
/// </summary>
public partial class frmRegisterForElection : Form
{
    IUserService? _userService;
    public frmRegisterForElection(IUserService userService)
    {
        InitializeComponent();

        if (DesignMode)
            return;

        _userService = userService;

        Init();
    }

    private void Init()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnRegister_Click(object sender, EventArgs e)
    {
        if (ValidateInput() == false)
            return;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    private bool ValidateInput()
    {
        bool success = true;
        foreach (ComboBox cmb in new List<ComboBox> { cmbElections, cmbElections })
        {
            if (cmb.SelectedIndex == -1)
            {
                cmb.BackColor = Color.Red;
                success = false;
            }
            else
            {
                cmb.BackColor = Color.White;
            }
        }

        return success;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnCancel_Click(object sender, EventArgs e)
    {

    }
}
