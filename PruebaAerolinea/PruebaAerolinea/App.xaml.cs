using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PruebaAerolinea
{
    public partial class App : Application
    {
        public static MasterDetailPage MasterDet { get; set; }

        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjQyODM1QDMyMzAyZTMxMmUzMGJxUHZWWGtmL3lmYzJoYkxSTTRkZlZkYkZVUS9BQlRhR3B5Vk5oRjc5alk9");

            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
