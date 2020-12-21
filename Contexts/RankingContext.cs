using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edux.Contexts
{
    public class RankingContext
    {
        SqlConnection con = new SqlConnection();

        public RankingContext()
        {
            con.ConnectionString = @"Data Source = LAB107801\SQLEXPRESS3; Initial Catalog= Edux; User Id=sa; Password=sa132";
        }

        public SqlConnection Conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }

            return con;
        }

        public void Desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
