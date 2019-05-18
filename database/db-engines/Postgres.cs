using System;
using System.Collections.Generic;
using Npgsql;

namespace Nom.database
{
    public class Postgres : DbInterface
    {

        private string _engine;
        string DbInterface.Engine
        {
            get { return _engine; } 
            set { _engine = value; }
        }
        
        private string _host;
        string DbInterface.Host
        {
            get { return _host; }
            set { _host = value;  }
        }
        
        private string _database;
        string DbInterface.Database
        {
            get { return _database; }
            set
            {
                _database = value;
                use(_database);
            }
        }
        
        private string _user;
        string DbInterface.User
        {
            get { return _user; }
            set { _user = value;  }
        }

        private string _password;
        string DbInterface.Password
        {
            get { return _password; }
            set { _password = value;  }
        }
        
        private int _port;
        int DbInterface.Port
        {
            get { return _port; }
            set { _port = value;  }
        }
        
        public NpgsqlConnection Conn;
        NpgsqlConnection DbInterface.Conn
        {
            get { return Conn; }
            set { Conn = value; }
        }
        
        // Constructor
        public Postgres(string database, string host, string user, string password, int port)
        {
            _engine = "Postgres";
            _host = host;
            _database = database;
            _user = user;
            _password = password;
            _port = port;
            
            connect();
        }
        
        public void connect()
        {
            var connStr = new NpgsqlConnectionStringBuilder();
            connStr.Host = _host;
            connStr.Username = _user;
            connStr.Password = _password;
            connStr.Database = _database;
            connStr.Port = _port;
            Conn = new NpgsqlConnection(connStr.ConnectionString);
            Conn.Open();
        }

        public void disconnect()
        {
            Conn.Close();
        }

        public void use(string database)
        {
            Conn.ChangeDatabase(database);   
        }

        public Dictionary<string, dynamic> select(string sql)
        {

            var command = Conn.CreateCommand();
            command.CommandText = sql;
            command.Prepare();
            var result = command.ExecuteReader();

            while (result.Read())
            {
                Console.Write("{0}\t{1} \n", result[0], result[1]);
            }

            return new Dictionary<string, dynamic>();
        }

        public void insert(string sql)
        {
            try
            {
                var command = Conn.CreateCommand();

                command.CommandText = sql;
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (NpgsqlException e)
            {
                Console.WriteLine(e.ToString());   
            }
        }

        public void update(string sql)
        {
            
        }
        
        public void delete(string sql)
        {

        }

    }
}