using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.OleDb;

namespace Web_Log
{
    public class DB
    {
        static string dbstr;
        static public void setDBPath(string path)
        {
            dbstr = path;
        }
        public static OleDbConnection createConnection()
        {
            OleDbConnection con =
                new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dbstr);
            return con;
        }
    }
}