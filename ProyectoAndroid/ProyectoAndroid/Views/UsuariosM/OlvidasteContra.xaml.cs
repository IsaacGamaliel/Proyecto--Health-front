using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoAndroid.Views.UsuariosM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OlvidasteContra : ContentPage
    {
        public OlvidasteContra()
        {
            InitializeComponent();
        }
        private void Cancelar_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new PaginaLogin();
        }
    }
}