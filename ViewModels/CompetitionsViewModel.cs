using System.Collections.ObjectModel;
using dblaba.DataModel;
using dblaba.Database;

namespace dblaba.ViewModels;

public class CompetitionsViewModel : SubViewModel
{
	public ObservableCollection<Competition> Competitions { get; } = null!;

	public CompetitionsViewModel()
	{   
        var x = QueryComposer.JoinCompetitions();
		Competitions = new ObservableCollection<Competition>(QueryComposer.JoinCompetitions());
	}
}
