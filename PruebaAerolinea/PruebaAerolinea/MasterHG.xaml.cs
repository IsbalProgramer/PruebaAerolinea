using PruebaAerolinea.Clases;
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
                new MenuHG{ page = new Consulta(), menuTitulo = "Consultas", menuDetail = "Consulte vuelos disponibles"}
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
                listMenu.Unfocus();
            }
        }
    }
}