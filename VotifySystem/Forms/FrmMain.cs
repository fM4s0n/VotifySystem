using VotifySystem.Forms;

namespace VotifySystem;

public partial class FrmMain : Form
{
    public FrmMain()
    {
        InitializeComponent();

        Init();
    }

    private void Init()
    {
        AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;
    }

    internal void SetMode(Usert)

    /// <summary>
    /// Handle any unhandled exceptions
    /// </summary>
    private void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
    {
        throw new NotImplementedException();
    }

}
