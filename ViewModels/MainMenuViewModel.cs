using System.Collections.ObjectModel;
using ReactiveUI;
using dblaba.Database;
using dblaba.BaseModels;

namespace dblaba.ViewModels;

public class MainMenuViewModel : SubViewModel
{
	public MainMenuViewModel()
	{
        Competitions = new ObservableCollection<Competition>(QueryComposer.JoinCompetitions());
        chosenCompetition = Competitions[0];
	}

	public void CompetitionsForm()
	{
		App.TopWindow.AddView(new CompetitionsViewModel());
	}

    public ObservableCollection<Competition> Competitions { get; }
    Competition chosenCompetition;

	public Competition ChosenCompetition
	{
		get => chosenCompetition;
		set => this.RaiseAndSetIfChanged(ref chosenCompetition, value);
	}    
}
