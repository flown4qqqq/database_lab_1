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
                        ('Кенгуру', 0, 'Австралия'),
                        ('Котята', 0, 'Аргентина'),
                        ('Хорошие ребята', 0, 'Финляндия'),
                        ('Медведи', 0, 'Норвегия'),
                        ('Острова', 0, 'Фиджи'),
                        ('Далеко', 0, 'Бразилия'),
                        ('Мехико', 0, 'Мексика'),
                        ('Пиво', 0, 'Германия'),
                        ('Париж', 0, 'Франция'),
                        ('Машинки', 0, 'Китай')
                    ;
                ", Name, ColId, ColName, ColSum, ColCountry);

                Client.ExecuteQuite(query);
            }
        }
    }
}
