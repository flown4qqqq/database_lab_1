using System.Collections.Generic;
using dblaba.BaseModels;

namespace dblaba.Database
{
    public static class QueryComposer
    {
        public static void Init(bool flagCreateNotForced, bool flagCreateForced)
        {
            QueryBuilder.Init(flagCreateNotForced, flagCreateForced);
        }

        public static List<Competition> JoinCompetitions()
        {
            return Parser.JoinCompetitionsParse(QueryBuilder.JoinCompetitions());
        }
    }
}

