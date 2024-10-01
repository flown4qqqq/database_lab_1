using dblaba.BaseModels;
using dblaba.Models;
using System.Collections.Generic;

namespace dblaba.ViewModels;

public class CompetitionsViewModel : SubViewModel
{
    public CompetitionsModel Model;
	public List<Competition> Competitions { get => Model.Competitions; }

	public CompetitionsViewModel()
    {
        Model = new();
    }

    public void AddCompetition()
    {
		NewCompetitionViewModel newCompetition = new(Competitions);
        App.TopWindow.AddView(newCompetition);
    }

    public void OpenListOfSportsmen(int index)
    {
        SportsmenViewModel sportsmenInCompetition = new(Competitions[index]);
		App.TopWindow.AddView(sportsmenInCompetition);
    }
}
