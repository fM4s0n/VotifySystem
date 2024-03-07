using VotifySystem.BusinessLogic.Services;
using VotifySystem.Classes;
using VotifySystem.Forms;

namespace VotifySystem;

public partial class FrmMain : Form
{
    private readonly IUserService _userService;


    private UserLevel _mode;

    public FrmMain(IUserService userService)
    {
        InitializeComponent();

        _userService = userService;

        Init();
    }

    private void Init()
    {
        AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;

        SetMode();

        switch (_mode)
        {

        }
    }

    internal void SetMode()
    {
        _mode = _userService.GetCurrentUser().UserLevel;
    }

    /// <summary>
    /// Handle any unhandled exceptions
    /// </summary>
    private void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
    {
        throw new NotImplementedException();
    }
}
