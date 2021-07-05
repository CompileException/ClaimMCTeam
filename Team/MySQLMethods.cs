using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClaimMCTeam.Team
{
    class MySQLMethods
    {
        //database stuff
        public const String SERVER = "localhost";
        public const String DATABASE = "teamdatabase";
        public const String UID = "root";
        public const String PASSWORD = "";
        private static MySqlConnection dbConn;

        public static bool connected;

        // User class stuff
        public String Group { get; private set; }
        public String Username { get; private set; }
        public String Password { get; private set; }
        public String Registerdate { get; private set; }
        public String Money { get; private set; }

        private MySQLMethods(String group, String username, String password, String money, String rd)
        {
            Group = group;
            Username = username;
            Password = password;
            Money = money;
            Registerdate = rd;
        }

        public static void InitializeDB()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = SERVER;
            builder.UserID = UID;
            builder.Password = PASSWORD;
            builder.Database = DATABASE;

            String connString = builder.ToString();

            builder = null;

            Console.WriteLine(connString);

            dbConn = new MySqlConnection(connString);

            connected = true;

            Application.ApplicationExit += (sender, args) =>
            {
                if (dbConn != null)
                {
                    dbConn.Dispose();
                    dbConn = null;
                }
            };

            if (dbConn == null)
            {
                connected = false;
            }
        }

        public static List<MySQLMethods> GetUsers()
        {

            List<MySQLMethods> users = new List<MySQLMethods>();

            String query = "SELECT * FROM users WHERE externalip= '" + Dns.GetHostName() + "'";

            MySqlCommand cmd = new MySqlCommand(query, dbConn);

            dbConn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                String username = reader["name"].ToString();
                String uuid = reader["uuid"].ToString();
                String isBanned = reader["isBanned"].ToString();
                String banreason = reader["banreason"].ToString();
                String bantime = reader["bantime"].ToString();

                MySQLMethods u = new MySQLMethods(username, uuid, isBanned, banreason, bantime);

                users.Add(u);
            }

            reader.Close();

            dbConn.Close();

            return users;
        }

        public static void InsertPCData(String externalip)
        {
            String query = string.Format("INSERT INTO users SET externalip= '" + externalip + "'");

            MySqlCommand cmd = new MySqlCommand(query, dbConn);

            dbConn.Open();

            cmd.ExecuteNonQuery();

            dbConn.Close();
        }
    }
}
