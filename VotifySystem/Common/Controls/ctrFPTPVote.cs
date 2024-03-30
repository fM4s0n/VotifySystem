using VotifySystem.Common.Classes.Elections;
using VotifySystem.Common.DataAccess.Database;

namespace VotifySystem.Common.Controls;

/// <summary>
/// Control for voting using the First Past The Post voting system
/// </summary>
public partial class ctrFPTPVote : UserControl
{
    IDbService _dbService;
    Election? _election;

    public ctrFPTPVote()
    {
        InitializeComponent();
    }

    public void SetElection(Election election, IDbService dbService)
    {
        _election = election;
        _dbService = dbService;

    }
}
