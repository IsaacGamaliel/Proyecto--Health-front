using ProyectoAndroid.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoAndroid.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Preguntas : ContentPage
    {
        ApiRest apiRest = new ApiRest();
        public string _id { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public string idUsuario { get; set; }
        public string respuesta { get; set; }
        public Preguntas()
        {
            InitializeComponent();
        }

        private async void EventListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item;
            await Navigation.PushAsync(new PreguntaDetallada(item));
        }

        public async void Button_Clicked(object sender, EventArgs e)
        {
            //Application.Current.MainPage = new CrearPreguntas();
            await Navigation.PushAsync(new CrearPreguntas());
        }
    }
    
}