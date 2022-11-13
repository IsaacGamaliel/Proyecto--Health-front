using ProyectoAndroid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoAndroid.Views.Preguntas
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
    }
}