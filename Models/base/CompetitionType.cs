using System;
using dblaba.Database;
using dblaba.Database.Tables;

namespace dblaba.BaseModels;

public class CompetitionType
{
    public int? Id;
    public string Name = null!;

    public CompetitionType() {

    }

    public CompetitionType(string name) {
        Name = name;
    }

    public int? IdProperty {
        get => Id;
        set => Id = value;
    }

    public string NameProperty {
        get => Name;
        set => Name = value;
    }

    // I know that it is very awful path to get id, but i have no time :(
    public int GetIdOfSportByName() {
        if (Id == null) {
            var t = AllTables.TableCompetitionTypeInstance;
            var mp = QueryComposer.Select(t.Name, [t.ColId], new(t.ColName, Name));
            Id = int.Parse(mp[t.ColId][0]);
        }

        return Id.Value;
    }
}
