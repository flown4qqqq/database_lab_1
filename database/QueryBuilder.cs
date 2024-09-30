using dblaba.Database.Tables;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

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

        public static void Insert(string tableName, string[] columnNames, string[] args) {
            if (args.Length % columnNames.Length != 0) {
                throw new ArgumentException("ColumnNames.count must be divider of args.length");
            }

            var query = new StringBuilder("INSERT INTO " + tableName + " (");
            int countOfColumns = columnNames.Length;

            for (int i = 0; i < countOfColumns; i++) {
                query.Append(columnNames[i]);

                if (i + 1 != columnNames.Length) {
                    query.Append(", ");
                }
            }

            query.Append(')');
            query.Append('\n');
            query.Append("VALUES");
            query.Append('\n');

            for (int i = 0; i < args.Length; i += countOfColumns) {
                query.Append('(');

                for (int j = i; j < i + countOfColumns; j++) {
                    query.Append(string.Format("'{0}'", args[j]));

                    if (j + 1 != i  + countOfColumns) {
                        query.Append(", ");
                    }
                }

                query.Append(')');
                if (i + countOfColumns != args.Length) {
                    query.Append(",\n");
                }
            }

            query.Append(';');
            Client.ExecuteQuite(query.ToString());
        }

        public static NpgsqlDataReader Select(string tableName, string[] columnNames, Tuple<string, string>? keyValue) {
            var query = new StringBuilder("SELECT ");

            for (int i = 0; i < columnNames.Length; i++) {
                query.Append(columnNames[i]);

                if (i + 1 != columnNames.Length) {
                    query.Append(',');
                }
            }

            query.Append("\nFROM\n");
            query.Append(tableName);

            if (keyValue != null) {
                query.Append('\n');
                var key = keyValue.Item1;
                var value = keyValue.Item2;
                query.Append(string.Format("WHERE {0}.{1} = '{2}'", tableName, key, value));
            }

            query.Append(';');

            var reader = Client.ExecuteReader(query.ToString());
            return reader;
        }
    }
}
