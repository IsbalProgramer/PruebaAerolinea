using PruebaAerolinea.Clases;
using PruebaAerolinea.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PruebaAerolinea
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            string error;
            MySQLConn conn = new MySQLConn();
            if (conn.TryConnection(out error))
            {
                label.Text = "Conexion Exitosa";
            }
            else 
            {
                label.Text = error;
            }
        }
    }
}
