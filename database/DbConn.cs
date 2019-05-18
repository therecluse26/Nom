using System;

namespace Nom.database
{
    public class DbConn 
    {

        public DbInterface Conn;
        
        // Constructor
        public DbConn(string engine, string database, string host, string user, string password, int port)
        {
            Conn = spawnEngine(engine, database, host, user, password, port);
        }


        public DbInterface spawnEngine(string engine, string database, string host, string user, string password, int port)
        {
            if (engine == "pgsql")
            {
                return new Postgres(database, host, user, password, port);

            }

            return new Postgres(database, host, user, password, port);
        }
        
    }
}