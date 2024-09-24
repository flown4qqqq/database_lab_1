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
                        {1} SERIAL PRIMARY KEY,
                        {2} VARCHAR(50),
                        {3} DECIMAL,
                        {4} VARCHAR(100)
                    );
                ", Name, ColId, ColName, ColSum, ColCountry);

                Client.ExecuteQuite(query);
            }

            {
                var query = string.Format(@"
                    INSERT INTO {0} ({2}, {3}, {4})
                    VALUES
                        ('Kangaroo', 0, 'Australia'),
                        ('Kittens', 0, 'Argentina'),
                        ('Good guys', 0, 'Finland'),
                        ('Bears', 0, 'Norway'),
                        ('Island', 0, 'Fiji'),
                        ('Far away', 0, 'Brazilia'),
                        ('Mexico', 0, 'Mexico'),
                        ('Bear', 0, 'Germany'),
                        ('Paris', 0, 'France'),
                        ('Cars', 0, 'China')
                    ;
                ", Name, ColId, ColName, ColSum, ColCountry);

                Client.ExecuteQuite(query);
            }
        }
    }
}
