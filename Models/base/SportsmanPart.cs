using System;

namespace dblaba.BaseModels;

public class SportsmanPart
{
    public string Name = null!;
    public string Surname = null!;
    public string Patronymic = null!;

    public string TeamName = null!;
    public string TeamCountry = null!;
    public int Place;
    public double Mark;

    public string FullNameProperty {
        get => Surname + " " + Name + " " + Patronymic;
    }

    public string TeamCountryProperty {
        get => TeamCountry;
        set => TeamCountry = value;
    }

    public string TeamNameProperty {
        get => TeamName;
        set => TeamName = value;
    }

    public int PlaceProperty {
        get => Place;
        set => Place = value;
    }

    public double MarkProperty {
        get => Mark;
        set => Mark = value;
    }
}
