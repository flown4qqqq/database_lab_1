using dblaba.BaseModels;
using dblaba.Database;
using System.Collections.Generic;

namespace dblaba.Models;

public class SportsmenModel
{
    public List<SportsmanPart> SportsmenInfo { get; }

    public SportsmenModel(string competitionName)
    {
        SportsmenInfo = new(QueryComposer.JoinParticipations(competitionName));
        SportsmenInfo.Sort((x, y) => x.Place.CompareTo(y.Place));
    }
}
