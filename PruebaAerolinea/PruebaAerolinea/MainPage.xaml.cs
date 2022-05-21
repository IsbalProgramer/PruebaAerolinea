﻿using PruebaAerolinea.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PruebaAerolinea
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.Master = new MasterHG();
            this.Detail = new NavigationPage(new Detail());
            App.MasterDet = this;

        }

        /*void OnButtonClicked(object sender, EventArgs args)
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
        }*/
    }
}
