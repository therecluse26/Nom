using System.Collections.Generic;

namespace Nom.database
{
    public interface DbInterface
    {
        string Engine { get; set; }
        string Host { get; set; }
        string User { get; set; }
        string Password { get; set; }
        string Database { get; set; }
        int Port { get; set; }
        Npgsql.NpgsqlConnection Conn { get; set; }
        
        void connect();
        void disconnect();

        Dictionary<string, dynamic> select(string sql);
        void insert(string sql);
        void update(string sql);
        void delete(string guid);

        /*void createTable(string sql);
        void alterTable(string sql);*/

    }
}