using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VotifySystem.Common.Forms;
public partial class frmCreateAccount : Form
{
    public frmCreateAccount()
    {
        InitializeComponent();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnSubmit_Click(object sender, EventArgs e)
    {
        ValidateUserInput();
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
