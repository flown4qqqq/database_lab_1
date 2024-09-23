namespace dblaba.Database.Tables
{
    public static class AllTables {
        public readonly static TableTeam TableTeamInstance;
        public readonly static TableSportsman TableSportsmanInstance;
        public readonly static TableCompetitionType TableCompetitionTypeInstance;
        public readonly static TableCompetition TableCompetitionInstance;
        public readonly static TablePatricipation TablePatricipationInstance;

        public static void Create(bool forced) {
            TableTeamInstance.Create(forced);
            TableSportsmanInstance.Create(forced);
            TableCompetitionTypeInstance.Create(forced);
            TableCompetitionInstance.Create(forced);
            TablePatricipationInstance.Create(forced);
            System.Console.WriteLine("Creating tables has just been completed.");
        }

        static AllTables() {
            TableTeamInstance = new();
            TableSportsmanInstance = new(TableTeamInstance);
            TableCompetitionTypeInstance = new();
            TableCompetitionInstance = new(TableCompetitionTypeInstance);
            TablePatricipationInstance = new(TableSportsmanInstance, TableCompetitionInstance);
        }
    }
}
