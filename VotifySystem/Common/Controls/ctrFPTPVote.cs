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
    ElectionVoter? _electionVoter;

    public ctrFPTPVote()
    {
        InitializeComponent();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="election"></param>
    /// <param name="dbService"></param>
    /// <param name="electionVoter"></param>
    public void Init(Election election, IDbService dbService, ElectionVoter electionVoter)
    {
        _election = election;
        _dbService = dbService;
        _electionVoter = electionVoter;
    }
}
