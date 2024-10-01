using System.Collections.Generic;
using Npgsql;
using dblaba.BaseModels;
using System;
using dblaba.Database.Tables;

namespace dblaba.Database
{
    public static class Parser
    {
        public static Dictionary<string, List<string>> Parse(NpgsqlDataReader reader)
        {
            var map = new Dictionary<string, List<string>>();

            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string field = reader.GetName(i).ToString();
                    string? value = reader[field].ToString();

                    if (!map.ContainsKey(field)) {
                        map.Add(field, new());
                    }

                    if (value is not null) {
                        map[field].Add(value);
                    } else {
                        map[field].Add("NULL");
                    }
                }
            }

            return map;
        }

        // Of course, it must not be here. Something (lol) wrong with my database module
        public static List<Competition> JoinCompetitionsParse(NpgsqlDataReader reader) {
            var name = AllTables.TableCompetitionInstance.ColName;
            var date = AllTables.TableCompetitionInstance.ColDate;
            var nameOfSport = AllTables.TableCompetitionTypeInstance.Name + "_" + AllTables.TableCompetitionTypeInstance.ColName;
            var place = AllTables.TableCompetitionInstance.ColPlace;

            var competitions = new List<Competition>();
            var map = Parse(reader);

            foreach (KeyValuePair<string, List<string>> entry in map) {
                var k = entry.Key;
                var value = entry.Value;

                for (int i = 0; i < value.Count; i++) {
                    if (competitions.Count == i) {
                        competitions.Add(new());
                    }

                    if (k == name) {
                        competitions[i].Name = value[i].ToString()!;
                    } else if (k == date) {
                        competitions[i].Date = DateTimeOffset.Parse(value[i].ToString());
                    } else if (k == nameOfSport) {
                        competitions[i].NameOfSport = value[i].ToString()!;
                    } else if (k == place) {
                        competitions[i].Place = value[i].ToString()!;
                    } else {
                        throw new ArgumentException("Wrong parsed join");
                    }
                }
            }

            return competitions;
        }

        public static List<SportsmanPart> JoinParticipationsParse(NpgsqlDataReader reader) {
            var name = AllTables.TableSportsmanInstance.ColName;
            var surname = AllTables.TableSportsmanInstance.ColSurname;
            var patronymic = AllTables.TableSportsmanInstance.ColPatronymic;

            var place = AllTables.TablePatricipationInstance.ColPlace;
            var mark = AllTables.TablePatricipationInstance.ColMark;

            var country = AllTables.TableTeamInstance.ColCountry;
            var nameOfTeam = AllTables.TableTeamInstance.Name + "_" + AllTables.TableTeamInstance.ColName;

            var map = Parse(reader);
            var sportsmen = new List<SportsmanPart>();

            foreach (KeyValuePair<string, List<string>> entry in map) {
                var k = entry.Key;
                var value = entry.Value;

                for (int i = 0; i < value.Count; i++) {
                    if (sportsmen.Count == i) {
                        sportsmen.Add(new());
                    }

                    if (k == name) {
                        sportsmen[i].Name = value[i].ToString()!;
                    } else if (k == surname) {
                        sportsmen[i].Surname = value[i].ToString()!;
                    } else if (k == patronymic) {
                        sportsmen[i].Patronymic = value[i].ToString()!;
                    } else if (k == place) {
                        sportsmen[i].Place = int.Parse(value[i].ToString()!);
                    } else if (k == mark) {
                        sportsmen[i].Mark = double.Parse(value[i].ToString()!);
                    } else if (k == country) {
                        sportsmen[i].TeamCountry = value[i].ToString()!;
                    } else if (k == nameOfTeam) {
                        sportsmen[i].TeamName = value[i].ToString()!;
                    } else {
                        throw new ArgumentException("Wrong parsed join");
                    }
                }
            }

            return sportsmen;
        }
    }
}

