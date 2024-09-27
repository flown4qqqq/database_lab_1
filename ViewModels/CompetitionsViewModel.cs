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
        Model = new CompetitionsModel();
	}

    public void AddCompetition() {
		NewCompetitionViewModel newCompetition = new();
        App.TopWindow.AddView(newCompetition);
    }
}
