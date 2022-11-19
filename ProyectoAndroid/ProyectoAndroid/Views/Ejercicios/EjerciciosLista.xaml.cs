using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoAndroid.Views.Ejercicios
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EjerciciosLista : ContentPage
    {
        public EjerciciosLista()
        {
            InitializeComponent();
        }

        private async void EventListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item;
            await Navigation.PushAsync(new EjerciciosDet(item));
        }
    }
}