namespace dblaba.Database.Tables {
    public class TableTeam : Table {
        public override string Name { 
            get => "team";
        }

        public readonly string ColId = "id";
        public readonly string ColName = "name";
        public readonly string ColSum = "sum";
        public readonly string ColCountry = "country";

        public override void Create(bool forced) {
            var proccesResult = ProcessDrop(forced);

            if (proccesResult == ProcessResult.Break) {
                return;
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
                ", Name, ColId, ColName, ColSum, ColCountry);

                Client.ExecuteQuite(query);
            }

            {
                var query = string.Format(@"
                    INSERT INTO {0} ({1}, {2}, {3}, {4})
                    VALUES
                        (1, 'Kangaroo', 0, 'Australia'),
                        (2, 'Kittens', 0, 'Argentina'),
                        (3, 'Good guys', 0, 'Finland'),
                        (4, 'Bears', 0, 'Norway'),
                        (5, 'Island', 0, 'Fiji'),
                        (6, 'Far away', 0, 'Brazilia'),
                        (7, 'Mexico', 0, 'Mexico'),
                        (8, 'Bear', 0, 'Germany'),
                        (9, 'Paris', 0, 'France'),
                        (10, 'Cars', 0, 'China')
                    ;
                ", Name, ColId, ColName, ColSum, ColCountry);

                Client.ExecuteQuite(query);
            }
        }
    }
}
