using PruebaAerolinea.Clases;
using PruebaAerolinea.Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PruebaAerolinea.Pantallas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CancelaVuelo : ContentPage
    {
        CompraConsulta ccr = new CompraConsulta();
        MySQLConn conn = new MySQLConn();
        public CancelaVuelo(CompraConsulta cc)
        {
            InitializeComponent();
            ccr = cc;
            lblAerolinea.Text = cc.Aerolinea;
            lblOrigen.Text = cc.Origen;
            lblDestino.Text = cc.Destino;
            lblFechaHoraSalida.Text = cc.FechaHoraSalida;
            lblFechaHoraDestino.Text = cc.FechaHoraLlegada;
            lblAsientosComprados.Text = cc.AsientosComprados.ToString();
            lblCostoTotal.Text = cc.Costo.ToString();
        }

        private async void Button_Clicked_Cancelar(object sender, EventArgs e)
        {
            string error;
            string SQL = "update comprareserva set BanderaComprado = 0, BanderaCancelado = 1 where IDVuelos="+ccr.IDVuelo;
            if (conn.inActElimDatos(SQL, out error) == true) 
            {
                await DisplayAlert("Mensaje", "Se cancelo correctamente", "OK");
            }
            else
            {
                await DisplayAlert("Error", error, "OK");
            }

        }
    }
}