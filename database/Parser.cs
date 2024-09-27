using System.Collections.Generic;
using Npgsql;
using dblaba.BaseModels;
using System;
using dblaba.Database.Tables;

namespace dblaba.Database
{
    public static class Parser
    {
        private static Dictionary<string, List<string>> Parse(NpgsqlDataReader reader)
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
    }
}

