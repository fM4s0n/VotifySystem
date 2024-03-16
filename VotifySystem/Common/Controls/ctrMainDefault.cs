namespace VotifySystem.Common.Controls;

/// <summary>
/// 
/// </summary>
public partial class ctrMainDefault : UserControl
{
    public ctrMainDefault()
    {
        InitializeComponent();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnInPerson_Click(object sender, EventArgs e)
    {
        frmMain.GetInstance().ShowInPersonLogin();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnOnline_Click(object sender, EventArgs e)
    {
        frmMain.GetInstance().ShowOnlineLogin();
    }
}
