using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoAndroid.Models;
using ProyectoAndroid.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoAndroid.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PreguntaDetallada : ContentPage
    {
        public PreguntaDetallada(object varPregunta)
        {
            InitializeComponent();
            vistaDetallada(varPregunta);
        }
        public void vistaDetallada(object varPregunta)
        {
            try
            {
                PreguntasModel vistap = varPregunta as PreguntasModel;
                TxtidPregunta.Text = vistap._id.ToString();
                TxtDescrip.Text = vistap.descripcion.ToString();
                Txtid.Text = vistap.idUsuario.ToString();
                TxtTitulo.Text = vistap.titulo.ToString();
                TxtResp.Text = vistap.respuesta.ToString();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }

        }

        //public async void Button_Clicked(object sender, EventArgs e)
        //{
        //    //Bug
        //    //await Navigation.PushAsync(new Preguntas());
        //    //await Navigation.PushModalAsync(new NavigationPage(new Preguntas()));
        //}
    }
}