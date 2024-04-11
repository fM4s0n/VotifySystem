using VotifySystem.Common.BusinessLogic.Services;
using VotifySystem.Common.Models.Elections;
using VotifySystem.Common.Models.UI;
using VotifySystem.InPerson.Controls;

namespace VotifySystem.InPerson.Forms;

/// <summary>
/// Form to view all elections and manage their details or view results
/// </summary>
public partial class frmManageElections : Form
{
    private List<Election>? _elections;
    private readonly IElectionService? _electionService;

    private IManageElectionSortStrategy? _sortStrategy;

    public frmManageElections()
    {
        InitializeComponent();

        if (DesignMode)
            return;

        IServiceProvider serviceProvider = Program.ServiceProvider!;

        _electionService = Program.ServiceProvider!.GetService(typeof(IElectionService)) as IElectionService;

        Init();
    }

    private void Init()
    {
        // Populate ComboBox with display order options
        cmbDisplayOrder.Items.Add("Alphabetical Order");
        cmbDisplayOrder.Items.Add("Chronological Order");
        cmbDisplayOrder.Items.Add("By Status");

        // Set default selection
        cmbDisplayOrder.SelectedIndex = -1;
    }

    /// <summary>
    /// Load the elections based on the selected display order
    /// </summary>
    private void LoadElections()
    {
        if (cmbDisplayOrder.SelectedIndex == -1)        
            return;        

        // load all election that are ongoing, future and completed within last month
        _elections = _electionService!.GetAllElections()?
            .Where(e => e.EndDate >= DateTime.Now.AddMonths(-1))
            .ToList();

        if (_elections == null || _elections.Count == 0)
        {
            MessageBox.Show("No elections found", "No Elections", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        _sortStrategy!.Sort(_elections);

        // Clear existing controls
        flpElections.Controls.Clear();

        for (int i = 0; i < _elections.Count; i++)
        {
            ctrManageElectionPanelItem epi = new(_elections[i], i);
            flpElections.Controls.Add(epi);
        }
    }

    private void cmbDisplayOrder_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Determine the selected strategy
        _sortStrategy = cmbDisplayOrder.SelectedItem switch
        {
            "Alphabetical Order" => new SortByAlphabeticalOrderStrategy(),
            "Chronological Order" => new SortByStartDateStrategy(),
            _ => throw new NotImplementedException()
        };


        if (_sortStrategy != null)
            LoadElections();
    }
}


/// <summary>
/// Strategy to sort elections by alphabetical order
/// </summary>
public class SortByAlphabeticalOrderStrategy : IManageElectionSortStrategy
{
    public void Sort(List<Election> elections)
    {
        elections.Sort((e1, e2) => string.Compare(e1.Description, e2.Description));
    }
}

/// <summary>
/// Strategy to sort elections by start date
/// </summary>
public class SortByStartDateStrategy : IManageElectionSortStrategy
{
    public void Sort(List<Election> elections)
    {
        elections.Sort((e1, e2) => e1.StartDate.CompareTo(e2.StartDate));
    }
}

/// <summary>
/// Sort strategy interface for viewing elections in
/// Manage Elections form
/// </summary>
public interface IManageElectionSortStrategy
{
    void Sort(List<Election> elections);
}
