using System.Collections.Generic;
using dblaba.BaseModels;
using dblaba.Database.Tables;
using System;

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

        public static List<SportsmanPart> JoinParticipations(string competitionName)
        {
            return Parser.JoinParticipationsParse(QueryBuilder.JoinParticipations(competitionName));
        }

        public static void Insert(string tableName, string[] columnNames, string[] args) {
            QueryBuilder.Insert(tableName, columnNames, args);
        }

        public static Dictionary<string, List<string>> Select(string tableName, string[] columnNames, Tuple<string, string>? keyValue = null) {
            return Parser.Parse(QueryBuilder.Select(tableName, columnNames, keyValue));
        }
    }
}
