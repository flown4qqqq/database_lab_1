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
                        ('Соломон', 'Оливер', 'Андреевич', 6, 91, '1988-2-6'),
                        ('Береза', 'Федор', 'Иванович', 1, 82, '1995-11-5'),
                        ('Дэвис', 'Олег', 'Витальевич', 7, 98, '1991-2-7'),
                        ('Миллер', 'Оливер', 'Семенович', 8, 78, '1981-8-25'),
                        ('Пирси', 'Алиса', 'Иванович', 8, 26, '1980-11-4'),
                        ('Пирси', 'Боб', 'Иванович', 1, 72, '1987-9-25'),
                        ('Миллер', 'Джон', 'Игоревич', 3, 98, '1981-8-11'),
                        ('Миллер', 'Джон', 'Семенович', 4, 83, '1986-1-19'),
                        ('Дэвис', 'Мила', 'Андреевич', 8, 31, '1998-6-9'),
                        ('Петрошов', 'Олег', 'Андреевич', 2, 74, '1986-11-4'),
                        ('Соломон', 'Алиса', 'Витальевич', 3, 72, '1984-7-7'),
                        ('Соломон', 'Ава', 'Андреевич', 1, 80, '1986-7-11'),
                        ('Пирси', 'Алиса', 'Иванович', 7, 33, '1983-4-7'),
                        ('Береза', 'Федор', 'Владимирович', 5, 32, '1981-3-5'),
                        ('Вэнс', 'Федор', 'Иванович', 9, 81, '1991-8-4'),
                        ('Петрошов', 'Федор', 'Владимирович', 7, 41, '1981-5-14'),
                        ('Вэнс', 'Ник', 'Семенович', 6, 13, '1994-2-3'),
                        ('Миллер', 'Ава', 'Андреевич', 2, 13, '1995-10-12'),
                        ('Вэнс', 'Оливер', 'Семенович', 10, 78, '1987-9-20'),
                        ('Вэнс', 'Боб', 'Андреевич', 9, 32, '1990-12-24'),
                        ('Соломон', 'Ава', 'Иванович', 4, 58, '1996-10-26'),
                        ('Кингсман', 'Ава', 'Витальевич', 2, 29, '1999-7-26'),
                        ('Соломон', 'Оливер', 'Витальевич', 5, 36, '1997-1-4'),
                        ('Миллер', 'Боб', 'Андреевич', 6, 77, '1992-11-19'),
                        ('Вэнс', 'Мила', 'Игоревич', 4, 83, '1983-1-2'),
                        ('Петрошов', 'Боб', 'Андреевич', 9, 16, '1986-9-3'),
                        ('Дэвис', 'Джон', 'Владимирович', 6, 92, '1983-4-14'),
                        ('Пирси', 'Федор', 'Владимирович', 5, 84, '1990-4-27'),
                        ('Береза', 'Федор', 'Витальевич', 10, 86, '1988-5-6'),
                        ('Петрошов', 'Мила', 'Семенович', 7, 24, '1991-6-13'),
                        ('Соломон', 'Мила', 'Витальевич', 5, 38, '1999-2-23'),
                        ('Лавандович', 'Мила', 'Семенович', 10, 53, '1987-1-25'),
                        ('Петрошов', 'Мила', 'Игоревич', 1, 7, '1992-5-4'),
                        ('Пирси', 'Оливер', 'Владимирович', 3, 60, '1993-12-11'),
                        ('Петрошов', 'Оливер', 'Андреевич', 4, 40, '1992-3-19'),
                        ('Пирси', 'Мила', 'Витальевич', 3, 73, '1993-10-3'),
                        ('Береза', 'Мила', 'Семенович', 8, 15, '1992-5-16'),
                        ('Пирси', 'Ник', 'Андреевич', 9, 45, '1996-7-17'),
                        ('Лавандович', 'Олег', 'Семенович', 2, 97, '1980-1-15'),
                        ('Лавандович', 'Оливер', 'Семенович', 10, 77, '1984-12-11')
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
