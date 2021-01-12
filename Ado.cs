using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace gestion_clients
{
    class Ado
    {
        //Déclaration des objets sql
        public SqlConnection con = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public SqlDataReader dr;
        public DataTable dt = new DataTable();

        //Déclaration de la methode connecter
        /*public void connecter()
        {
            if(con.State == ConnectionState.Closed || con.State == ConnectionState.Broken)
            {
                con.ConnectionString = @"Data Source = DESKTOP - QUDI77S\MSSQLSERVER01; Initial Catalog = gestion_clt; Integrated Security = True";
                con.Open();
            }
        }*/

        //Déclaration de la methode connecter
        public void deconnecter()
        {
            if (con.State == ConnectionState.Open)
            {            
                con.Close();
            }
        }
    }
}
