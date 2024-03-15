using VotifySystem.Common.Classes;

namespace VotifySystem.Common.Forms;

/// <summary>
/// Create Account form
/// </summary>
public partial class frmCreateAccount : Form
{
    public frmCreateAccount()
    {
        InitializeComponent();

        if (DesignMode == false)
            return;

        Init();
    }

    private void Init()
    {
        foreach (var t in Enum.GetValues(typeof(VoteMethod)))
        { 
            string a = t.g
        }
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
            Voter newVoter = new(txtFirstName.Text, txtLastName, cmbVoteMethod.SelectedValue, txtAddress, );


            Close();
        }
    }

    /// <summary>
    /// Validate all user input 
    /// </summary>
    /// <returns>True if valid, false if not</returns>
    private bool ValidateUserInput()
    {
        bool success = false;

        return success;
    }
}
