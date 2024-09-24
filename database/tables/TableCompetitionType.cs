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
                        {1} SERIAL PRIMARY KEY,
                        {2} VARCHAR(100),
                        {3} TEXT
                    );
                ", Name, ColId, ColName, ColDescription);

                Client.ExecuteQuite(query);
            }

            {
                var query = string.Format(@"
                    INSERT INTO {0} ({2}, {3})
                    VALUES
                        ('football', 'very good description'),
                        ('handball', 'awesome description'),
                        ('golf', 'beatiful description')
                    ;
                ", Name, ColId, ColName, ColDescription);

                Client.ExecuteQuite(query);
            }
        }
    }
}
