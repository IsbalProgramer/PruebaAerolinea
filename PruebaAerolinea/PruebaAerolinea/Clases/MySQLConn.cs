using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;


namespace PruebaAerolinea.Clases
{
    public class MySQLConn
    {

        

        public bool TryConnection(out string Error) 
        {
            var myConnectionString = new MySqlConnection();
            myConnectionString.ConnectionString = "Server=192.168.1.164;Database=aerolinea;Uid=root;Pwd=R00tKaiba123;";
            try
            {
                myConnectionString.Open();
                Error = "";
                return true;
            }
            catch(Exception ex)
            {
                Error = ex.ToString();
                return false;
            }
        }
    }
}
