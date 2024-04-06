using VotifySystem.Common.BusinessLogic.Helpers;
using VotifySystem.Common.Classes;

namespace VotifySystem.InPerson.Controls;

/// <summary>
/// control for displaying the results of a party, election wide in the results view
/// </summary>
public partial class ctrResultsPartyPanelItem : UserControl
{
    public ctrResultsPartyPanelItem(Party party, int overallElectionPosition, int totalConstituencyWins, int totalElectionVotes )
    {
        InitializeComponent();

        if (DesignMode)
            return;

        lblPartyName.Text = party.Name;
        lblConstituenciesWonValue.Text = totalConstituencyWins.ToString();
        lblOverallPositionValue.Text = FPTPResultsHelper.AddOrdinal(overallElectionPosition);
        lblTotalVotesValue.Text = totalElectionVotes.ToString();
    }
}
