namespace dblaba.Database.Tables {
    public class TableCompetitionType : Table {
        public override string Name { 
            get => "competition_type";
        }

        public readonly string ColId = "id";
        public readonly string ColName = "name";
        public readonly string ColDescription = "description";

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
                        {2} VARCHAR(100),
                        {3} TEXT
                    );
                ", Name, ColId, ColName, ColDescription);

                Client.ExecuteQuite(query);
            }

            {
                var query = string.Format(@"
                    INSERT INTO {0} ({1}, {2}, {3})
                    VALUES
                        (1, 'football', 'very good description'),
                        (2, 'handball', 'awesome description'),
                        (3, 'golf', 'beatiful description')
                    ;
                ", Name, ColId, ColName, ColDescription);

                Client.ExecuteQuite(query);
            }
        }
    }
}
