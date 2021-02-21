using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Geek_Inside.Models.db
{
    public static class Connection
    {
        public static MySqlConnection Connect()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "website";
            MySqlConnection cn = new MySqlConnection(builder.ToString());
            return cn;
        }
    }
}