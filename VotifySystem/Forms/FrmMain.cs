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

    /// <summary>
    /// Handle any unhandled excptions
    /// </summary>
    private void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
    {
        throw new NotImplementedException();
    }
}
