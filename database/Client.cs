using Npgsql;

namespace dblaba.Database
{
    public static class Client
    {
        private static NpgsqlConnectionStringBuilder connectString = null!;

        public static int ExecuteQuite(string query)
        {
            var connection = new NpgsqlConnection(connectString.ToString());
            connection.Open();
            using var command = new NpgsqlCommand(query, connection);
            return command.ExecuteNonQuery();
        }

        public static NpgsqlDataReader ExecuteReader(string query)
        {
            var connection = new NpgsqlConnection(connectString.ToString());
            connection.Open();
            using var command = new NpgsqlCommand(query, connection);
            command.ExecuteNonQuery();
            return command.ExecuteReader();
        }

        public static void Init()
        {
            var connStrBase = "";
            connStrBase += "Server = localhost;";
            connStrBase += "Port = 5432;";
            connStrBase += "Database = sport;";
            connStrBase += "Username = flown4qqqq;";
            connStrBase += "Password = 123";

            connectString = new NpgsqlConnectionStringBuilder(connStrBase);
        }
    }
}
