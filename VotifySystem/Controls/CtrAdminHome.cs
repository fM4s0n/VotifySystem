using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VotifySystem.Forms;

namespace VotifySystem.Controls;
public partial class CtrAdminHome : UserControl
{
    public CtrAdminHome()
    {
        InitializeComponent();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void BtnCreateElection_Click(object sender, EventArgs e)
    {
        FrmCreateElection form = new();
        form.Show();
    }
}
