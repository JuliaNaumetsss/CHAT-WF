// -----------------------------------------------------------------------
// <copyright file="SqLiteBackend.cs" company="xsDevelopment">
//   Attribution-NonCommercial-ShareAlike 3.0 Unported (CC BY-NC-SA 3.0)
//   All Rights Reserved - See License.txt for more details
// </copyright>
// -----------------------------------------------------------------------
namespace serverExample.Backends
{
    using System;
    using System.Data;
    using Information;
    using System.Data.SQLite;

    public class SQLiteBackend : IBackend
    {
        public string GetBackendName()
        {
            return "SQLite";
        }

        public class ConnectionString
        {
            /// <param name="dataSource">The SQLite Datasource To Use (e.g. mydatabase.db)</param>
            /// <param name="password">The password to the SQLite Datasource (if exists)</param>
            /// <param name="pooling">Whether or not to use connection pooling</param>
            /// <param name="maxpoolsize">The Maximum size of the connection pool</param>
            public ConnectionString(string dataSource, string password, bool pooling, int maxpoolsize)
            {
                DataSource = dataSource;
                Password = Password;
                Pooling = pooling;
                MaxPoolSize = maxpoolsize;
            }

            public string Version
            {
                get { return "3"; }
            }

            public string DataSource { get; private set; }
            public string Password { get; private set; }
            public bool Pooling { get; private set; }
            public int MaxPoolSize { get; private set; }

            public string Generate()
            {
                return 
                    string.Format("Data Source={0};Version={1};Password={2};Pooling={3};Max Pool Size={4};",
                                  DataSource,
                                  Version,
                                  Password,
                                  Pooling,
                                  MaxPoolSize);
            }
        }

        private string SQLiteConnectionString { get; set; }

        public SQLiteBackend(ConnectionString connectionString)
        {
            SQLiteConnectionString = connectionString.Generate();
        }
        private SQLiteConnection GetConnection()
        {
            var connection = new SQLiteConnection(SQLiteConnectionString);
            connection.Open();
            return connection;
        }
        public User GetUser(string email)
        {
            using (var connection = GetConnection())
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * from users where email = @email LIMIT 1";
                command.Parameters.Add(new SQLiteParameter("@email", email));
                return GetUser(command);
            }
        }
        public User GetUser(int userId)
        {
            using (var connection = GetConnection())
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * from users where id = @id LIMIT 1";
                command.Parameters.Add(new SQLiteParameter("@id", userId));
                return GetUser(command);
            }
        }
        private User GetUser(SQLiteCommand recvCommand)
        {
            using (var command = recvCommand)
            {
                using (var reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                        return new User
                                   {
                                       Exists = false
                                   };
                    while (reader.Read())
                    {
                        var userid = Convert.ToInt32(reader["id"].ToString());
                        var useremail = reader["email"].ToString();
                        var userbanned = reader["banned"].ToString().ToLower() == "true";
                        var username = reader["nickname"].ToString();
                        var userpassword = reader["password"].ToString();
                        var preuserrole = reader["role"].ToString();
                        var userrole =
                            (User.UserRole)
                            Enum.Parse(
                                typeof (User.UserRole),
                                preuserrole,
                                true);
                        return new User
                                   {
                                       Exists = true,
                                       Id = userid,
                                       Banned = userbanned,
                                       Nickname = username,
                                       Email = useremail,
                                       Password = userpassword,
                                       Role = userrole
                                   };
                    }

                    //This should never happen..
                    return new User
                               {
                                   Exists = false
                               };
                }
            }
        }

        public void CreateUser(string email, string password, string nickname, User.UserRole role)
        {
            using (var connection = GetConnection())
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO users (nickname, email, password, role, banned) VALUES(@nickname, @email, @password, @role, @banned)";
                command.Parameters.Add(new SQLiteParameter("@email", email));
                command.Parameters.Add(new SQLiteParameter("@nickname", nickname));
                command.Parameters.Add(new SQLiteParameter("@password", password));
                command.Parameters.Add(new SQLiteParameter("@banned", "false"));
                command.Parameters.Add(new SQLiteParameter("@role", role.ToString()));
                command.ExecuteNonQuery();
            }
        }

        public void UpdateUserNickname(int userId, string newNickname)
        {
            using (var connection = GetConnection())
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "UPDATE users set nickname = @nickname where id = @userId";
                command.Parameters.Add(new SQLiteParameter("@userId", userId));
                command.Parameters.Add(new SQLiteParameter("@nickname", newNickname));
                command.ExecuteNonQuery();
            }
        }
        public void UpdateUserPassword(int userId, string newPassword)
        {
            using (var connection = GetConnection())
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "UPDATE users set password = @pass where id = @userId";
                command.Parameters.Add(new SQLiteParameter("@userId", userId));
                command.Parameters.Add(new SQLiteParameter("@pass", newPassword));
                command.ExecuteNonQuery();
            }
        }
        public void UpdateUserRole(int userId, User.UserRole userRole)
        {
            using (var connection = GetConnection())
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "UPDATE users set role = @role where id = @userId";
                command.Parameters.Add(new SQLiteParameter("@userId", userId));
                command.Parameters.Add(new SQLiteParameter("@role", userRole.ToString()));
                command.ExecuteNonQuery();
            }
        }
        public void UpdateUserBanned(int userId, bool banned)
        {
            using (var connection = GetConnection())
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "UPDATE users set banned = @ban where id = @userId";
                command.Parameters.Add(new SQLiteParameter("@userId", userId));
                command.Parameters.Add(new SQLiteParameter("@ban", banned.ToString()));
                command.ExecuteNonQuery();
            }
        }
    }
}