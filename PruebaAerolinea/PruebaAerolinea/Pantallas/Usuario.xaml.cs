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
    public partial class Usuario : ContentPage
    {
        MySQLConn conn = new MySQLConn();

        public Usuario()
        {
            InitializeComponent();
            lstVuelos.ItemsSource = conn.consultaCompraVuelos();
        }

        private void refreshButton_Clicked(object sender, EventArgs e)
        {
            List<CompraConsulta> lt = null;
            lstVuelos.ItemsSource = lt;
            lstVuelos.ItemsSource = conn.consultaCompraVuelos();
        }

        private async void lstVuelos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            CompraConsulta vc = (CompraConsulta)e.SelectedItem;
            await Navigation.PushAsync(new CancelaVuelo(vc));
        }
    }
}