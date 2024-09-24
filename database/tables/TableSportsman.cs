namespace dblaba.Database.Tables {
    public class TableSportsman : Table {
        public override string Name { 
            get => "sportsman";
        }

        public readonly string ColId = "id";
        public readonly string ColSurname = "surname";
        public readonly string ColName = "name";
        public readonly string ColPatronymic = "patronymic";
        public readonly string ColTeamId = "team_id";
        public readonly string ColNumberInTeam = "number_in_team";
        public readonly string ColBirthday = "birthday";

        public readonly string TableTeamName;
        public readonly string TableTeamColId;


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
                        {2} VARCHAR(30),
                        {3} VARCHAR(25),
                        {4} VARCHAR(30),
                        {5} INTEGER,
                        {6} INTEGER,
                        {7} DATE,
                        FOREIGN KEY ({5}) REFERENCES {8} ({9})
                    );
                ", Name, ColId, ColSurname, ColName, ColPatronymic, ColTeamId, ColNumberInTeam, ColBirthday, TableTeamName, TableTeamColId);

                Client.ExecuteQuite(query);
            }

            {
                var query = string.Format(@"
                    INSERT INTO {0} ({2}, {3}, {4}, {5}, {6}, {7})
                    VALUES
                        ('Salomon', 'Oliver', 'Andreevich', 6, 91, '1988-2-6'),
                        ('Birch', 'Fedor', 'Ivanovich', 1, 82, '1995-11-5'),
                        ('Davis', 'Oleg', 'Vitalievich', 7, 98, '1991-2-7'),
                        ('Miller', 'Oliver', 'Semyonovich', 8, 78, '1981-8-25'),
                        ('Pearcy', 'Alice', 'Ivanovich', 8, 26, '1980-11-4'),
                        ('Pearcy', 'Bob', 'Ivanovich', 1, 72, '1987-9-25'),
                        ('Miller', 'John', 'Igorevich', 3, 98, '1981-8-11'),
                        ('Miller', 'John', 'Semyonovich', 4, 83, '1986-1-19'),
                        ('Davis', 'Mila', 'Andreevich', 8, 31, '1998-6-9'),
                        ('Petroshov', 'Oleg', 'Andreevich', 2, 74, '1986-11-4'),
                        ('Salomon', 'Alice', 'Vitalievich', 3, 72, '1984-7-7'),
                        ('Salomon', 'Ava', 'Andreevich', 1, 80, '1986-7-11'),
                        ('Pearcy', 'Alice', 'Ivanovich', 7, 33, '1983-4-7'),
                        ('Birch', 'Fedor', 'Vladimirovich', 5, 32, '1981-3-5'),
                        ('Vance', 'Fedor', 'Ivanovich', 9, 81, '1991-8-4'),
                        ('Petroshov', 'Fedor', 'Vladimirovich', 7, 41, '1981-5-14'),
                        ('Vance', 'Nick', 'Semyonovich', 6, 13, '1994-2-3'),
                        ('Miller', 'Ava', 'Andreevich', 2, 13, '1995-10-12'),
                        ('Vance', 'Oliver', 'Semyonovich', 10, 78, '1987-9-20'),
                        ('Vance', 'Bob', 'Andreevich', 9, 32, '1990-12-24'),
                        ('Salomon', 'Ava', 'Ivanovich', 4, 58, '1996-10-26'),
                        ('Kingsman', 'Ava', 'Vitalievich', 2, 29, '1999-7-26'),
                        ('Salomon', 'Oliver', 'Vitalievich', 5, 36, '1997-1-4'),
                        ('Miller', 'Bob', 'Andreevich', 6, 77, '1992-11-19'),
                        ('Vance', 'Mila', 'Igorevich', 4, 83, '1983-1-2'),
                        ('Petroshov', 'Bob', 'Andreevich', 9, 16, '1986-9-3'),
                        ('Davis', 'John', 'Vladimirovich', 6, 92, '1983-4-14'),
                        ('Pearcy', 'Fedor', 'Vladimirovich', 5, 84, '1990-4-27'),
                        ('Birch', 'Fedor', 'Vitalievich', 10, 86, '1988-5-6'),
                        ('Petroshov', 'Mila', 'Semyonovich', 7, 24, '1991-6-13'),
                        ('Salomon', 'Mila', 'Vitalievich', 5, 38, '1999-2-23'),
                        ('Lavandovich', 'Mila', 'Semyonovich', 10, 53, '1987-1-25'),
                        ('Petroshov', 'Mila', 'Igorevich', 1, 7, '1992-5-4'),
                        ('Pearcy', 'Oliver', 'Vladimirovich', 3, 60, '1993-12-11'),
                        ('Petroshov', 'Oliver', 'Andreevich', 4, 40, '1992-3-19'),
                        ('Pearcy', 'Mila', 'Vitalievich', 3, 73, '1993-10-3'),
                        ('Birch', 'Mila', 'Semyonovich', 8, 15, '1992-5-16'),
                        ('Pearcy', 'Nick', 'Andreevich', 9, 45, '1996-7-17'),
                        ('Lavandovich', 'Oleg', 'Semyonovich', 2, 97, '1980-1-15'),
                        ('Lavandovich', 'Oliver', 'Semyonovich', 10, 77, '1984-12-11')
                    ;
                ", Name, ColId, ColSurname, ColName, ColPatronymic, ColTeamId, ColNumberInTeam, ColBirthday);

                Client.ExecuteQuite(query);
            }
        }

        public TableSportsman(TableTeam tableTeam) {
            TableTeamColId = tableTeam.ColId;
            TableTeamName = tableTeam.Name;
        }
    }
}
