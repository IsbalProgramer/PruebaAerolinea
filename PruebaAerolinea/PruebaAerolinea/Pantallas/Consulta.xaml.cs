using PruebaAerolinea.Clases;
using PruebaAerolinea.Conexion;
using PruebaAerolinea.Pantallas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PruebaAerolinea
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Consulta : ContentPage
    {
        MySQLConn conn = new MySQLConn();        
        public Consulta()
        {
            InitializeComponent();
            lstVuelos.ItemsSource = conn.consultaVuelos();
        }

        private async void lstVuelos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            VueloConsulta vc = (VueloConsulta)e.SelectedItem;
            await Navigation.PushAsync(new CompraVuelo(vc));
        }

        private void refleshButton_Clicked(object sender, EventArgs e)
        {
            List<VueloConsulta> lt = null;
            lstVuelos.ItemsSource = lt;
            lstVuelos.ItemsSource = conn.consultaVuelos();
        }
    }
}