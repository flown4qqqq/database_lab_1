namespace dblaba.Database.Tables {
    public class TablePatricipation : Table {
        public override string Name { 
            get => "patricipation";
        }

        public readonly string ColId = "id";
        public readonly string ColCompetitionId = "competition_id";
        public readonly string ColSportsmanId = "sportsman_id";
        public readonly string ColPlace = "place";
        public readonly string ColMark = "mark";
        public readonly string TableCompetitionName;
        public readonly string TableCompetitionColId;
        public readonly string TableSportsmanName;
        public readonly string TableSportsmanColId;

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
                        {2} INTEGER,
                        {3} INTEGER,
                        {4} INTEGER,
                        {5} DECIMAL,
                        FOREIGN KEY ({2}) REFERENCES {6} ({7}),
                        FOREIGN KEY ({3}) REFERENCES {8} ({9})
                    );
                ", Name, ColId, ColCompetitionId, ColSportsmanId, ColPlace, ColMark, TableCompetitionName, TableCompetitionColId, TableSportsmanName, TableSportsmanColId);

                Client.ExecuteQuite(query);
            }

            {
                var query = string.Format(@"
                    INSERT INTO {0} ({1}, {2}, {3}, {4}, {5})
                        VALUES
                        (10, 1, 17, 11, 0.01889003783777237956),
                        (30, 1, 19, 10, 0.26270057110088014635),
                        (12, 1, 38, 9, 0.4238552050795080924),
                        (14, 1, 30, 8, 0.44401744495556950422),
                        (9, 1, 19, 7, 0.48056158028899597604),
                        (18, 1, 11, 6, 0.52562615813360516405),
                        (13, 1, 36, 5, 0.5632684295038474239),
                        (7, 1, 29, 4, 0.66680256667590366945),
                        (35, 1, 4, 3, 0.9023294209587932944),
                        (1, 1, 38, 2, 0.94267996571380543715),
                        (8, 1, 31, 1, 0.9606100890458682336),
                        (15, 2, 22, 5, 0.14912461176005012768),
                        (5, 2, 5, 4, 0.15879805776552905),
                        (2, 2, 33, 3, 0.7707430865692511422),
                        (49, 2, 14, 2, 0.91832413270433995193),
                        (38, 2, 19, 1, 0.97317410869795789504),
                        (42, 3, 5, 14, 0.01602044480861267525),
                        (60, 3, 34, 13, 0.037147414137784680173),
                        (19, 3, 17, 12, 0.037395121796164625684),
                        (32, 3, 22, 11, 0.075735441265123760433),
                        (58, 3, 19, 10, 0.12094533791680548103),
                        (45, 3, 32, 9, 0.12478163486453404273),
                        (23, 3, 1, 8, 0.13843111013057123457),
                        (6, 3, 33, 7, 0.16170324216619506067),
                        (11, 3, 27, 6, 0.22451844312519282998),
                        (41, 3, 25, 5, 0.32712354199062428802),
                        (33, 3, 30, 4, 0.35683572850066743937),
                        (57, 3, 24, 3, 0.4726570460796361209),
                        (40, 3, 39, 2, 0.7308638043987869095),
                        (34, 3, 7, 1, 0.79363558955530424477),
                        (43, 4, 39, 9, 0.15574261006140801705),
                        (29, 4, 38, 8, 0.21041312457556117269),
                        (39, 4, 33, 7, 0.23496269707565223617),
                        (28, 4, 39, 6, 0.33437032244585911163),
                        (20, 4, 35, 5, 0.653600050238795177),
                        (36, 4, 19, 4, 0.69599463324596269717),
                        (51, 4, 8, 3, 0.8019823902904787028),
                        (21, 4, 23, 2, 0.922461374535396081),
                        (3, 4, 38, 1, 0.9870870488633863761),
                        (24, 5, 17, 12, 0.065854439997456981134),
                        (55, 5, 25, 11, 0.14665008949316440182),
                        (56, 5, 15, 10, 0.1871393918954349219),
                        (37, 5, 37, 9, 0.23116546545701070387),
                        (25, 5, 29, 8, 0.2771327369923381949),
                        (50, 5, 18, 7, 0.46912637650953262767),
                        (17, 5, 9, 6, 0.50704219795575069916),
                        (26, 5, 30, 5, 0.60662383193153511995),
                        (44, 5, 9, 4, 0.8153131949660220414),
                        (52, 5, 37, 3, 0.90719405751068449197),
                        (4, 5, 21, 2, 0.96029778627128794724),
                        (47, 5, 14, 1, 0.96202230445286687397),
                        (22, 6, 28, 9, 0.048968609659415163016),
                        (31, 6, 7, 8, 0.09824395888814530958),
                        (27, 6, 1, 7, 0.113548877042925963623),
                        (16, 6, 4, 6, 0.11979590912738684269),
                        (54, 6, 2, 5, 0.23673154337448055554),
                        (48, 6, 39, 4, 0.43970116461662582774),
                        (59, 6, 11, 3, 0.5423301936652261283),
                        (53, 6, 27, 2, 0.6368024146745155706),
                        (46, 6, 25, 1, 0.9209288558558200066)
                    ;
                ", Name, ColId, ColCompetitionId, ColSportsmanId, ColPlace, ColMark);

                Client.ExecuteQuite(query);
            }
        }

        public TablePatricipation (TableSportsman tableSportsman, TableCompetition tableCompetition) {
            TableCompetitionName = tableCompetition.Name;
            TableCompetitionColId = tableCompetition.ColId;
            TableSportsmanName = tableSportsman.Name;
            TableSportsmanColId = tableSportsman.ColId;
        }
    }
}
