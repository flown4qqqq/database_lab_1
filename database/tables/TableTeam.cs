using System;
using Npgsql;

namespace dblaba.Database.Tables {
    public class TableTeams : Table {
        public override string tableName { 
            get => "teams";
        }

        private readonly string colId = "id";
        private readonly string colName = "name";
        private readonly string colSum = "sum";
        private readonly string colCountry = "country";

        public override void Create(bool forced) {
            if (IsCreated()) {
                if (forced) {
                    var query = string.Format(@"
                        DROP TABLE {0};
                    ", tableName);

                    Client.ExecuteQuite(query);
                } else {
                    System.Console.WriteLine("TableTeam already exist, so it was not created");
                    return;
                }
            }

            {
                var query = string.Format(@"
                    CREATE TABLE {0}
                    (
                        {1} INTEGER PRIMARY KEY,
                        {2} VARCHAR(50),
                        {3} DECIMAL,
                        {4} VARCHAR(100)
                    );
                ", tableName, colId, colName, colSum, colCountry);

                Client.ExecuteQuite(query);
            }

            {
                var query = string.Format(@"
                    INSERT INTO {0} ({1}, {2}, {3}, {4})
                    VALUES
                        (1, 'Kangaroo', 0, 'Australia'),
                        (3, 'Good guys', 0, 'Finland'),
                        (4, 'Bears', 0, 'Norway'),
                        (5, 'Island', 0, 'Fiji'),
                        (6, 'Far away', 0, 'Brazilia'),
                        (7, 'Mexico', 0, 'Mexico'),
                        (8, 'Bear', 0, 'Germany'),
                        (9, 'Paris', 0, 'France'),
                        (10, 'Cars', 0, 'China')
                    ;
                ", tableName, colId, colName, colSum, colCountry);

                Client.ExecuteQuite(query);
            }
        }
    }
}
