using System;
using System.Reactive;
using dblaba.Models;
using dblaba.BaseModels;
using ReactiveUI;

namespace dblaba.ViewModels;

public class NewCompetitionViewModel : SubViewModel
{
    Competition competition;

	public NewCompetitionViewModel()
	{
        competition = new();
	}
	public string Name
	{
		get => competition.Name;
		set => this.RaiseAndSetIfChanged(ref competition.Name, value);
	}

	public DateTimeOffset Date
	{
		get => competition.Date;
		set => this.RaiseAndSetIfChanged(ref competition.Date, value);
	}

	public string NameOfSport
	{
		get => competition.NameOfSport;
		set => this.RaiseAndSetIfChanged(ref competition.NameOfSport, value);
	}

	public string Place
	{
		get => competition.Place;
		set => this.RaiseAndSetIfChanged(ref competition.Place, value);
	}
}
