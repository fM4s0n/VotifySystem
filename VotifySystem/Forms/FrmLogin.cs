
using VotifySystem.BusinessLogic.Services;

namespace VotifySystem.Forms
{
    public partial class FrmLogin : Form
    {
        IUserService _userService;

        public FrmLogin(IUserService userService)
        {
            InitializeComponent();

            _userService = userService;
        }
    }
}
