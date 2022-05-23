using PruebaAerolinea.Conexion;
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
    public partial class Detail : ContentPage
    {
        public Detail()
        {
            InitializeComponent();
        }

        //void OnButtonClicked(object sender, EventArgs args)
        //{
        //    string error;
        //    MySQLConn conn = new MySQLConn();
        //    if (conn.TryConnection(out error))
        //    {
        //        label.Text = "Conexion Exitosa";                
        //    }
        //    else
        //    {
        //        label.Text = error;
        //    }
        //}
    }
}