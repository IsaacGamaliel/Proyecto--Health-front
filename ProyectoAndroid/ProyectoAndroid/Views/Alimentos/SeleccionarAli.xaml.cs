using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoAndroid.Views.Alimentos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SeleccionarAli : ContentPage
    {
        public SeleccionarAli()
        {
            InitializeComponent();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Carnes());
        }
    }
}