using dblaba.Database.Tables;
using Npgsql;

namespace dblaba.Database
{
    public static class QueryBuilder
    {
        public static bool IsTableCreated(string tableName)
        {
            var query = string.Format(@"
                SELECT * FROM information_schema.tables WHERE table_name = '{0}' AND table_schema = 'public';
            ", tableName);

            var reader = Client.ExecuteReader(query);
            return reader != null && reader.HasRows;
        }

        public static NpgsqlDataReader JoinCompetitions()
        {
            var tableName = AllTables.TableCompetitionInstance.Name;
            var tableTypeName = AllTables.TableCompetitionTypeInstance.Name;

            var name = AllTables.TableCompetitionInstance.ColName;
            var date = AllTables.TableCompetitionInstance.ColDate;
            var nameOfSport = AllTables.TableCompetitionTypeInstance.ColName;
            var place = AllTables.TableCompetitionInstance.ColPlace;

            var idFK = AllTables.TableCompetitionInstance.ColTypeId;
            var idPK = AllTables.TableCompetitionTypeInstance.ColId;

            var query = string.Format(@"
                SELECT {4}.{0}, {4}.{1}, {5}.{2} as {5}_{2}, {4}.{3} 
                FROM (
                    {4}
                    LEFT JOIN
                    {5}
                    ON {4}.{6} = {5}.{7}
                );
            ",
                name,
                date,
                nameOfSport,
                place,
                tableName,
                tableTypeName,
                idFK,
                idPK
            );

            var reader = Client.ExecuteReader(query);
            return reader;
        }

        public static void Init(bool flagCreateNotForced, bool flagCreateForced)
        {
            Client.Init();

            if (flagCreateNotForced || flagCreateForced) {
                AllTables.Create(flagCreateForced);
            }
        }
    }
}
