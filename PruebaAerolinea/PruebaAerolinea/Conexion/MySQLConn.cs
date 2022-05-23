using MySqlConnector;
using PruebaAerolinea.Clases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;


namespace PruebaAerolinea.Conexion
{
    public class MySQLConn
    {
        MySqlConnection myConnectionString = new MySqlConnection();
       

        public bool TryConnection(out string Error)
        {
            myConnectionString.ConnectionString = "Server=192.168.1.164;Database=aerolinea;Uid=PRUEBAS;Pwd=Pru3b4$Kaiba123;";
            try
            {
                myConnectionString.Open();
                Error = "";
                return true;
            }
            catch (Exception ex)
            {
                Error = ex.ToString();
                return false;
            }
        }

        private string rutaConexion() 
        {
            String ruta = "Server=192.168.1.164;Database=aerolinea;Uid=PRUEBAS;Pwd=Pru3b4$Kaiba123;";
            return ruta;
        }

        public ObservableCollection<Aerolinea> consultaAerolinea() 
        {
           myConnectionString.ConnectionString = rutaConexion();
            try
            {
                myConnectionString.Open();
                var command = myConnectionString.CreateCommand();
                command.CommandText = "select * from aerolinea";
                var reader = command.ExecuteReader();
                var list = new ObservableCollection<Aerolinea>();
                while (reader.Read()) 
                {
                    list.Add(new Aerolinea
                    {
                        IDAeroLinea = (int)reader.GetInt64("IDAeroLinea"),
                        nombreAerolinea = reader.GetString("nombreAerolinea")
                    });
                }
                myConnectionString.Close();
                return list;

            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }

        public List<VueloConsulta> consultaVuelos() 
        {
            myConnectionString.ConnectionString = rutaConexion();
            try 
            {
                myConnectionString.Open();
                var command = myConnectionString.CreateCommand();
                command.CommandText = "select v.IDVuelos AS IDVuelo, ae.nombreAerolinea AS Aerolinea, orig.nombreDestino AS Origen, dest.nombreDestino AS Destino, " +
                    "CONCAT(v.FechaSalida,' ', v.HoraSalida) AS FechaHoraSalida, CONCAT(v.FechaLlegada,' ', v.HoraLlegada) AS FechaHoraLlegada, v.Asientos as Asientos, v.CostoPorAsiento as Costo " +
                    "from Vuelos v inner join aerolinea ae ON v.IDAeroLinea = ae.IDAeroLinea inner join Destinos orig on v.IDOrigen = orig.IDDestino " +
                    "inner join Destinos dest ON v.IdDestino = dest.IDDestino where v.BanderaVueloRealizado = 0 and v.Asientos > 0;";
                var reader = command.ExecuteReader();
                var list = new List<VueloConsulta>();
                while (reader.Read())
                {
                    list.Add(new VueloConsulta
                    {
                        IDVuelo = (int)reader.GetInt64("IDVuelo"),
                        Aerolinea = reader.GetString("Aerolinea"),
                        Origen = reader.GetString("Origen"),
                        Destino = reader.GetString("Destino"),
                        FechaHoraSalida = reader.GetString("FechaHoraSalida"),
                        FechaHoraLlegada = reader.GetString("FechaHoraLlegada"),
                        Asientos = (int)reader.GetInt64("Asientos"),
                        Costo = (int)reader.GetInt64("Costo")
                    }); 
                }
                myConnectionString.Close();
                return list;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }

        public ObservableCollection<Destino> consultaDestinos()
        {
            myConnectionString.ConnectionString = rutaConexion();
            try
            {
                myConnectionString.Open();
                var command = myConnectionString.CreateCommand();
                command.CommandText = "select * from Destinos";
                var reader = command.ExecuteReader();
                var list = new ObservableCollection<Destino>();
                while (reader.Read())
                {
                    list.Add(new Destino
                    {
                        IDDestino = (int)reader.GetInt64("IDDestino"),
                        nombreDestino = reader.GetString("nombreDestino")
                    });
                }
                myConnectionString.Close();
                return list;

            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }

        public Boolean inActElimDatos(String SQL,out string Error) 
        {
            myConnectionString.ConnectionString = rutaConexion();
            try
            {
                myConnectionString.Open();
                var command = myConnectionString.CreateCommand();
                command.CommandText = SQL;
                command.ExecuteReader();
                myConnectionString.Close();
                Error = "";
                return true;
            }
            catch (Exception ex) 
            {
                Error = ex.ToString();
                return false;
            }
        }
    }
}
