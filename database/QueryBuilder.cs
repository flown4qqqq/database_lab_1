using dblaba.Database.Tables;

namespace dblaba.Database
{
    public static class QueryBuilder
    {
        public static bool IsTableCreated(string tableName) {
            var query = string.Format(@"
                SELECT * FROM information_schema.tables WHERE table_name = '{0}' AND table_schema = 'public';
            ", tableName);

            var reader = Client.ExecuteReader(query);
            return reader != null && reader.HasRows;
        }

        public static void Init(bool flagCreateNotForced, bool flagCreateForced) {
            Client.Init();

            if (flagCreateNotForced || flagCreateForced) {
                AllTables.Create(flagCreateForced);
            }
        }
    }
}
