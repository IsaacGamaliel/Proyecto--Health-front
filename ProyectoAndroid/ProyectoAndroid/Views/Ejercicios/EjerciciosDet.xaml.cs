using ProyectoAndroid.Models;
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
    public partial class EjerciciosDet : ContentPage
    {
        public EjerciciosDet(object varPregunta)
        {
            InitializeComponent();
            vistaDetallada(varPregunta);
        }
        public void vistaDetallada(object varPregunta)
        {
            try
            {
                EjercicioModel vistap = varPregunta as EjercicioModel;
                TxtNombre.Text = vistap.nombreEjercisio.ToString();
                TxtDescrip.Text = vistap.descripcion.ToString();
                TexImg.Source = vistap.urlImg.ToString();
                wb_video.Source = vistap.urlVideo.ToString();
                //TxtResp.Text = vistap.respuesta.ToString();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }

        }

    }
}