using System;
using Nom.database;

namespace Nom
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbConn = new DbConn("pgsql","nom", "localhost", "sa", "sa", 32768).Conn;
            
            //dbConn.insert("insert into api.test (value) values ('blah blah')");

            var results = dbConn.@select("select id, value from api.test");
            
            Console.Write(results);
            
            dbConn.disconnect();
        }
    }
}
