using dblaba.BaseModels;
using dblaba.Models;
using System.Collections.Generic;
using ReactiveUI;
using System.Reactive;
using System;
using dblaba.Database;
using dblaba.Database.Tables;
using Avalonia.Data;

namespace dblaba.ViewModels;

public class NewSportsmanViewModel : SubViewModel
{
    SportsmanPart SportsmanInfo;
    SportsmanPart ChosenSportsman;
    List<SportsmanPart> Sportsmen = null!;
	public ReactiveCommand<Unit, SportsmanPart> Add { get; }
    Competition ChosenCompetition;

    private void initSportsmen() {
        var map = QueryComposer.Select(
            AllTables.TableSportsmanInstance.Name,
            [
                AllTables.TableSportsmanInstance.ColId, 
                AllTables.TableSportsmanInstance.ColName, 
                AllTables.TableSportsmanInstance.ColSurname,
                AllTables.TableSportsmanInstance.ColPatronymic
            ]
        );

        var name = AllTables.TableSportsmanInstance.ColName;
        var surname = AllTables.TableSportsmanInstance.ColSurname;
        var patronymic = AllTables.TableSportsmanInstance.ColPatronymic;
        var id = AllTables.TableSportsmanInstance.ColId;
        Sportsmen = new();

        foreach (KeyValuePair<string, List<string>> entry in map) {
            var k = entry.Key;
            var value = entry.Value;

            for (int i = 0; i < value.Count; i++) {
                if (Sportsmen.Count == i) {
                    Sportsmen.Add(new());
                }

                if (k == name) {
                    Sportsmen[i].Name = value[i];
                } else if (k == surname) {
                    Sportsmen[i].Surname = value[i];
                } else if (k == patronymic) {
                    Sportsmen[i].Patronymic = value[i];
                } else if (k == id) {
                    Sportsmen[i].IdSportsman = int.Parse(value[i]);
                } else {
                    throw new ArgumentException("Wrong parsed join");
                }
            }
        }

        Sportsmen.Sort((x, y) =>
            {
                int a = String.Compare(x.Surname, y.Surname);
                if (a != 0) {
                    return a;
                }

                int b = String.Compare(x.Name, y.Name);

                if (b != 0) {
                    return b;
                }

                return String.Compare(x.Patronymic, y.Patronymic);
            }
        );
    }

    public NewSportsmanViewModel(Competition chosenCompetition)
    {
        initSportsmen();

        SportsmanInfo = new SportsmanPart();
        ChosenCompetition = chosenCompetition;
        ChosenSportsman = Sportsmen[0];

        var isValidData = this.WhenAnyValue(
            a => a.Place,
            a => a.Mark,
            (_place, _mark) => {
                return
                    int.Parse(_place) > 0 && 0 <= double.Parse(_mark) && double.Parse(_mark) <= 1;
            }
        );
        
        Add = ReactiveCommand.Create(
            () => SportsmanInfo,
            isValidData
        );

        Add.Subscribe(
            _ => {
                SportsmanInfo.IdSportsman = ChosenSportsman.IdSportsman;
                QueryComposer.Insert(
                    AllTables.TablePatricipationInstance.Name,
                    [
                        AllTables.TablePatricipationInstance.ColCompetitionId,
                        AllTables.TablePatricipationInstance.ColPlace,
                        AllTables.TablePatricipationInstance.ColMark,
                        AllTables.TablePatricipationInstance.ColSportsmanId
                    ],
                    [
                        ChosenCompetition.Id.ToString(), SportsmanInfo.Place.ToString(), SportsmanInfo.Mark.ToString(), SportsmanInfo.IdSportsman.ToString()                        
                    ]
                );

				App.TopWindow.RemoveTopView();
            }
        );
    }

    public List<SportsmanPart> SportsmenProperty {
        get => Sportsmen;
    }

    public string Place {
        get => SportsmanInfo.Place.ToString();
		set {
            bool can = int.TryParse(value, out int newValue);

            if (!can || newValue < 1) {
                throw new DataValidationException("Введите число, начиная с 1");
            }

            this.RaiseAndSetIfChanged(ref SportsmanInfo.Place, newValue);
        }
    }

    public string Mark {
        get => SportsmanInfo.Mark.ToString();
		set {
            bool can = double.TryParse(value, out double newValue);

            if (!can || newValue < 0 || newValue > 1) {
                throw new DataValidationException("Введите число от 0 до 1 с точкой между целой и дробной частями");
            }

            this.RaiseAndSetIfChanged(ref SportsmanInfo.Mark, newValue);
        }
    }

    public SportsmanPart ChosenSportsmanProperty {
        get => ChosenSportsman;
    }

    public string CompetitionName {
        get => ChosenCompetition.Name;
    }

    public string CompetitionPlace {
        get => ChosenCompetition.Place;
    }

    public string CompetitionDate {
        get => ChosenCompetition.DateProperty_Parsed;
    }

    public string NameOfSport {
        get => ChosenCompetition.NameOfSport;
    }
}
