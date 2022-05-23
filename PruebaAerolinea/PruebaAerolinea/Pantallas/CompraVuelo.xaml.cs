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
    public partial class CompraVuelo : ContentPage
    {
        VueloConsulta vcr = new VueloConsulta();
        MySQLConn conn = new MySQLConn();

        public CompraVuelo(VueloConsulta vc)
        {
            InitializeComponent();
            vcr = vc;
        }

        private void asientosEntry_Unfocused(object sender, FocusEventArgs e)
        {
            int CostTotal = vcr.Costo * Int32.Parse(asientosEntry.Text);
            costoTotal.Text = CostTotal.ToString();
        }

        private async Task<bool> validarFormulario()
        {
            if (String.IsNullOrWhiteSpace(asientosEntry.Text))
            {
                await this.DisplayAlert("Advertencia", "El campo numero de asientos es obligatorio.", "OK");
                return false;
            }
            else
            {
                if (!asientosEntry.Text.ToCharArray().All(Char.IsDigit))
                {
                    await this.DisplayAlert("Advertencia", "El campo numero de asientos es númerico.", "OK");
                    return false;
                }
            }
            return true;
        }

        private async void Button_Clicked_Pagar(object sender, EventArgs e)
        {
            if (await validarFormulario())
            {
                string error;
                string SQL = "insert into comprareserva (IDVuelos,IDUsuario,NumeroAsientos," +
                    "CostoTotal,BanderaCancelado,BanderaComprado) Values (" + vcr.IDVuelo + ",1," +
                    asientosEntry.Text + "," + costoTotal.Text + ",0,1)";
                if (conn.inActElimDatos(SQL, out error) == true)
                {
                    await DisplayAlert("Mensaje","Se pago correctamente", "OK");
                }
                else
                {
                    await DisplayAlert("Error", error, "OK");
                }
            }
        }
    }
}