using ProyectoAndroid.Views.UsuariosM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoAndroid.Views.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuShell : Shell
    {
        public MenuShell()
        {
            InitializeComponent();
        }

        private async void btnCerrar_Clicked(object sender, EventArgs e)
        {
            bool respuesta = await Application.Current.MainPage.DisplayAlert("Mensaje", "Esta Seguro que quieres Cerrar Sesión", "Si", "No");


            if (respuesta == true)
            {
                Application.Current.Properties.Remove("jsonUsuario");
                await Application.Current.SavePropertiesAsync();
                Application.Current.MainPage = new PaginaLogin();
            }
        }
    }
}