using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaAerolinea.Clases;
using PruebaAerolinea.Conexion;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PruebaAerolinea.Pantallas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ControlVuelos : ContentPage
    {
        MySQLConn conn = new MySQLConn();
        public ControlVuelos()
        {
            InitializeComponent();
            
            startDatePicker.MinimumDate = DateTime.Today;
            aerolineasCombo.DataSource = conn.consultaAerolinea();
            aerolineasCombo.DisplayMemberPath = "nombreAerolinea";
            origenCombo.DataSource = conn.consultaDestinos();
            origenCombo.DisplayMemberPath = "nombreDestino";
            destinoCombo.DataSource = conn.consultaDestinos();
            destinoCombo.DisplayMemberPath = "nombreDestino";
        }

        private async Task<bool> validarFormulario() 
        {
            if (String.IsNullOrWhiteSpace(aerolineasCombo.Text)) 
            {
                await this.DisplayAlert("Advertencia", "El campo del aerolinea es obligatorio.", "OK");
                return false;
            }

            if (String.IsNullOrWhiteSpace(origenCombo.Text))
            {
                await this.DisplayAlert("Advertencia", "El campo del Origen es obligatorio.", "OK");
                return false;
            }

            if (startDatePicker.Date > endDatePicker.Date) 
            {
                await this.DisplayAlert("Advertencia", "No debe de haber diferencias de fechas menores a la de salida", "OK");
                return false;
            }

            if (startTimePicker.Time >= endTimePicker.Time) 
            {
                await this.DisplayAlert("Advertencia", "No debe de haber diferencias de horas iguales o menores a la de salida", "OK");
                return false;
            }

            if (String.IsNullOrWhiteSpace(asientosEntry.Text))
            {
                await this.DisplayAlert("Advertencia", "El campo de Asientos es obligatorio.", "OK");
                return false;
            }
            else
            {
                if (!asientosEntry.Text.ToCharArray().All(Char.IsDigit))
                {
                    await this.DisplayAlert("Advertencia", "El campo del Asientos es númerico.", "OK");
                    return false;
                }
            }

            if (String.IsNullOrWhiteSpace(costEntry.Text))
            {
                await this.DisplayAlert("Advertencia", "El campo del Costo es obligatorio.", "OK");
                return false;
            }
            else 
            {
                if (!costEntry.Text.ToCharArray().All(Char.IsDigit)) 
                {
                    await this.DisplayAlert("Advertencia", "El campo del Costo es obligatorio.", "OK");
                    return false;
                }
            }
            return true;
        }

        private async void Button_Clicked_Guardar(object sender, EventArgs e)
        {
            if (await validarFormulario())
            {
                string error;
                Aerolinea al = (Aerolinea)aerolineasCombo.SelectedItem;
                Destino oring = (Destino)origenCombo.SelectedItem;
                Destino final = (Destino)destinoCombo.SelectedItem;
                Vuelo vuelo = new Vuelo();
                vuelo.IDAerolinea = al.IDAeroLinea;
                vuelo.IDOrigen = oring.IDDestino;
                vuelo.IdDestino = final.IDDestino;
                vuelo.FechaSalida = startDatePicker.Date.ToString("yyyy-MM-dd");
                vuelo.HoraSalida = startTimePicker.Time.ToString();
                vuelo.FechaLlegada = endDatePicker.Date.ToString("yyyy-MM-dd");
                vuelo.HoraLlegada = endTimePicker.Time.ToString();
                vuelo.Asiento = Int32.Parse(asientosEntry.Text);
                vuelo.CostoAsiento = Int32.Parse(costEntry.Text);

                String SQL = "insert into Vuelos (IDAeroLinea,IDOrigen,IdDestino,FechaSalida,HoraSalida," +
                                "FechaLlegada,HoraLlegada,Asientos,CostoPorAsiento,BanderaVueloRealizado) values ("+ 
                                vuelo.IDAerolinea+","+vuelo.IDOrigen+","+vuelo.IdDestino+",'"+ 
                                vuelo.FechaSalida+"','"+vuelo.HoraSalida+"','" +vuelo.FechaLlegada+"','"+
                                vuelo.HoraLlegada+"',"+vuelo.Asiento+","+vuelo.CostoAsiento+",0)";

                if (conn.inActElimDatos(SQL,out error) == true)
                {
                    await DisplayAlert("Exito", "El vuelo se registro con éxito", "OK");
                    aerolineasCombo.Clear();
                    origenCombo.Clear();
                    destinoCombo.Clear();
                    asientosEntry.Text = "";
                    costEntry.Text = "";
                }
                else 
                {
                    await DisplayAlert("Error", error, "OK");
                }                
            }
            
        }

       
    }
}