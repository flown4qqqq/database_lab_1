using System;
using System.Reactive;
using dblaba.Models;
using dblaba.BaseModels;
using ReactiveUI;
using Avalonia.Animation.Easings;
using System.Collections.Generic;
using dblaba.Database;
using dblaba.Database.Tables;

namespace dblaba.ViewModels;

public class NewCompetitionViewModel : SubViewModel
{
    Competition competition;
    public List<CompetitionType> CompetitionTypes { get; set; }
    CompetitionType chosenCompetition;

	public NewCompetitionViewModel(List<Competition> competitions)
	{
        var t = AllTables.TableCompetitionTypeInstance;

        var list = QueryComposer.Select(t.Name, [t.ColName])[t.ColName];
        CompetitionTypes = new();

        for (int i = 0; i < list.Count; i++) {
            CompetitionTypes.Add(new CompetitionType(list[i]));
        }

        chosenCompetition = CompetitionTypes[0];
        competition = new();

        var isValidData = this.WhenAnyValue(
            a => a.Name,
            a => a.Date,
            a => a.Place,
            a => a.ChosenCompetitionType,
            (_name, _date, _place, _chosenCompetition) => {
                return
                    !string.IsNullOrEmpty(_name)
                    &&
                    _date.Year >= 1950
                    &&
                    !string.IsNullOrEmpty(_place);
            }
        );

        Add = ReactiveCommand.Create(
			() => competition,
            isValidData
		);

        Add.Subscribe(
            _ => {
                competition.NameOfSport = ChosenCompetitionType.Name;
                competitions.Add(competition);
                var idOfSportByName = ChosenCompetitionType.GetIdOfSportByName();
                var t = AllTables.TableCompetitionInstance;
                QueryComposer.Insert(
                    t.Name,
                    [t.ColName, t.ColDate, t.ColTypeId, t.ColPlace],
                    [Name, Date.ToString(), idOfSportByName.ToString(), Place]
                );

				App.TopWindow.RemoveTopView();
            }
        );
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

	public string Place
	{
		get => competition.Place;
		set => this.RaiseAndSetIfChanged(ref competition.Place, value);
	}

    public CompetitionType ChosenCompetitionType
    {
        get => chosenCompetition;
        set => this.RaiseAndSetIfChanged(ref chosenCompetition, value);
    }

	public ReactiveCommand<Unit, Competition> Add { get; }
}
