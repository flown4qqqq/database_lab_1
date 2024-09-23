using System;
using System.Data.Common;
using Npgsql;

namespace dblaba.Database
{
    public static class Client
    {
        private static NpgsqlConnectionStringBuilder connectString;
        private static NpgsqlConnection connection;

        private static void reopenConnection()
        {
            if (connection.FullState != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
        }

        public static int ExecuteQuite(string query)
        {
            reopenConnection();
            using var command = new NpgsqlCommand(query, connection);
            return command.ExecuteNonQuery();
        }

        public static NpgsqlDataReader ExecuteWithResult(string query)
        {
            reopenConnection();
            using var command = new NpgsqlCommand(query, connection);
            command.ExecuteNonQuery();
            return command.ExecuteReader();
        }

        // private static void CreateTables() {
        //     using (var conn = GetConnection())
        //     {
        //         conn.Open();
        //         tables.TableTeam.Create(conn);
        //     }

        //     System.Console.WriteLine("TABLES CREATED");
        // }

        public static void Init()
        {
            var connStrBase = "";
            connStrBase += "Server = localhost;";
            connStrBase += "Port = 5432;";
            connStrBase += "Database = sport;";
            connStrBase += "Username = flown4qqqq;";
            connStrBase += "Password = 123";

            connectString = new NpgsqlConnectionStringBuilder(connStrBase);
            connection = new NpgsqlConnection(connectString.ToString());
            connection.Open();
        }
    }
}
