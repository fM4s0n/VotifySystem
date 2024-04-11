using VotifySystem.Common.BusinessLogic.Services;

namespace VotifySystem.Controls;
public partial class ctrLoginBase : UserControl
{
    private readonly IUserService? _userService;

    public ctrLoginBase() 
    { 
        InitializeComponent();

        if (DesignMode)
            return;

        _userService = Program.ServiceProvider!.GetService(typeof(IUserService)) as IUserService;

        _userService!.LogInEvent += UserService_LogInEvent;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userService"></param>
    /// <param name="loginMode"></param>
    public void Init(LoginMode loginMode)   
    {
        ctrLogin.Init(loginMode);
        ctrLogin.Visible = true;       
    }

    /// <summary>
    /// Log in event
    /// hides ctrLogin control
    /// </summary>
    private void UserService_LogInEvent(object sender, EventArgs e)
    {
        ctrLogin.ResetControl();
        ctrLogin.Visible = false;
    }
}

/// <summary>
/// Mode to control which version of the control to show
/// </summary>
public enum LoginMode
{
    InPerson,
    Online
}