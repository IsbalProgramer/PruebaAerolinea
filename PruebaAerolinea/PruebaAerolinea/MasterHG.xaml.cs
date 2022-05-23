using PruebaAerolinea.Clases;
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
    public partial class MasterHG : ContentPage
    {
        public MasterHG()
        {
            InitializeComponent();

            List<MenuHG> mn = new List<MenuHG>
            {
                new MenuHG{ page = new ControlVuelos(), menuTitulo = "Control Vuelos", menuDetail = "Inserte y modifique los vuelos"},
                new MenuHG{ page = new Consulta(), menuTitulo = "Consultas", menuDetail = "Compre vuelos disponibles"},
                new MenuHG{ page= new Usuario(), menuTitulo = "Usuario", menuDetail = "Cancele vuelos pagados"}
            };
            listMenu.ItemsSource = mn;
        }

        private async void listMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var men = e.SelectedItem as MenuHG;
            if (men != null) 
            {
                App.MasterDet.IsPresented = false;
                App.MasterDet.Detail.Navigation.PushAsync(men.page);
                List<MenuHG> mn = null;
                listMenu.ItemsSource = mn;
                mn = new List<MenuHG>
                {
                    new MenuHG{ page = new ControlVuelos(), menuTitulo = "Control Vuelos", menuDetail = "Inserte y modifique los vuelos"},
                    new MenuHG{ page = new Consulta(), menuTitulo = "Consultas", menuDetail = "Consulte y compre los vuelos disponibles"},
                    new MenuHG{ page= new Usuario(), menuTitulo = "Usuario", menuDetail = "Consulte y cancele todos los vuelos pagados"}
                };
                listMenu.ItemsSource = mn;
            }
        }
    }
}