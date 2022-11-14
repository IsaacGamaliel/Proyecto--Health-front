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
    public partial class Carnes : ContentPage
    {
        public Carnes()
        {
            InitializeComponent();
        }

        private async void EventListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item;
            await Navigation.PushAsync(new DetalleCarne(item));
        }
    }
}