using VotifySystem.Common.Classes;
using VotifySystem.Common.DataAccess.Database;

namespace VotifySystem.InPerson.Controls;

/// <summary>
/// 
/// </summary>
public partial class ctrResultsPartyPanelItem : UserControl
{
    public ctrResultsPartyPanelItem(Party party, int overallElectionPosition,int totalConstituencyWins, int totalElectionVotes )
    {
        InitializeComponent();
    }
}
