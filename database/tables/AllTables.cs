namespace dblaba.Database.Tables
{
    public static class AllTables {
        public static TableTeams TableTeamInstance;

        public static void Create(bool forced) {
            TableTeamInstance.Create(forced);
        }
    }
}
