using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace ProyectoAndroid.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaRegistro : ContentPage
    {
        public PaginaRegistro()
        {
            InitializeComponent();
            pkGenero.Items.Add("Masculino");
            pkGenero.Items.Add("Femenino");
        }

        private async void RegistroButton_Clicked (object sender, EventArgs e)
        {
            //Validación Nombre
            if (string.IsNullOrWhiteSpace(Nombre.Text))
            {
                await DisplayAlert("Advertencia", "El campo del correo es obligatorio", "Ok");
                return;
            }
            //Validación Apellido
            if (string.IsNullOrWhiteSpace(Apellido.Text))
            {
                await DisplayAlert("Advertencia", "El campo del contraseña es obligatorio", "Ok");
                return;
            }
            //Validación Apodo
            if (string.IsNullOrWhiteSpace(NickName.Text))
            {
                await DisplayAlert("Advertencia", "El campo del contraseña es obligatorio", "Ok");
                return;
            }
            //Validación Correo
            if (string.IsNullOrWhiteSpace(correo.Text))
            {
                await DisplayAlert("Advertencia", "El campo del contraseña es obligatorio", "Ok");
                return;
            }
            //Validación contraseña
            if (string.IsNullOrWhiteSpace(contraseña.Text))
            {
                await DisplayAlert("Advertencia", "El campo del contraseña es obligatorio", "Ok");
                return;
            }

            //Validación Confirmación de contraseña
            if (string.IsNullOrWhiteSpace(ConfirmarContra.Text))
            {
                await DisplayAlert("Advertencia", "El campo del contraseña es obligatorio", "Ok");
                return;
            }
            //Validación de genero
            if (pkGenero.SelectedIndex == -1)
            {
                await DisplayAlert("Error", "Seleccine su género", "OK");
                return;
            }

            

           


        }
    }
}