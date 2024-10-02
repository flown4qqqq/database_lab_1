using dblaba.BaseModels;
using dblaba.Models;
using System.Collections.Generic;

namespace dblaba.ViewModels;

public class SportsmenViewModel : SubViewModel
{
    public SportsmenModel Model;
	public List<SportsmanPart> SportsmenInfo { get => Model.SportsmenInfo; }

    public Competition ChosenCompetition;
    public SportsmenViewModel(Competition chosenCompetition)
    {
        ChosenCompetition = chosenCompetition;
        Model = new(ChosenCompetition.Name);
    }

    public string CompetitionName {
        get => ChosenCompetition.Name;
    }

    public void AddSportsman() {
		NewSportsmanViewModel newSportsman = new(ChosenCompetition);
        App.TopWindow.AddView(newSportsman);
    }
}
