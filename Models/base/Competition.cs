using System;

namespace dblaba.BaseModels;

public class Competition
{
    public int Id;
    public string Name = null!;
    public DateTimeOffset Date;
    public string NameOfSport = null!;

    public string Place = null!;

    public int IdProperty {
        get => Id;
        set => Id = value;
    }

    public string NameProperty {
        get => Name;
        set => Name = value;
    }

    public DateTimeOffset DateProperty {
        get => Date;
        set => Date = value;
    }

    public string DateProperty_Parsed {
        get {
            return DateProperty.ToString().Split(" ")[0];
        }
    }

    public string NameOfSportProperty {
        get => NameOfSport;
        set => NameOfSport = value;
    }

    public string PlaceProperty {
        get => Place;
        set => Place = value;
    }

    // I know that it is very awful path to get id, but i have no time :(
    public int GetIdOfSportByName() {
        return new CompetitionType(NameOfSport).GetIdOfSportByName();
    }
}
