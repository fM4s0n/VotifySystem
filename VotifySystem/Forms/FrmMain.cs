using VotifySystem.Classes;
using VotifySystem.Forms;

namespace VotifySystem;

public partial class FrmMain : Form
{
    private UserLevel _mode;

    public FrmMain()
    {
        InitializeComponent();

        Init();
    }

    private void Init()
    {
        AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;
    }

    internal void SetMode(UserLevel userLevel)
    {
        _mode = userLevel;
    }

    /// <summary>
    /// Handle any unhandled exceptions
    /// </summary>
    private void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
    {
        throw new NotImplementedException();
    }
}
