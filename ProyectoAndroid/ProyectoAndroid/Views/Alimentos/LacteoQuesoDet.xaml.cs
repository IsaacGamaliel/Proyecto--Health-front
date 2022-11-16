using ProyectoAndroid.Models;
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
    public partial class LacteoQuesoDet : ContentPage
    {
        public LacteoQuesoDet(object varLQ)
        {
            InitializeComponent();
            vistaDetallada(varLQ);
        }
        public void vistaDetallada(object varLQ)
        {
            try
            {
                ComidaModel vistap = varLQ as ComidaModel;
                Textnombre.Text = vistap.nombreAlimento.ToString();
                TextCal.Text = vistap.calorias.ToString();
                TextP.Text = vistap.proteinas.ToString();
                TextL.Text = vistap.lipidos.ToString();
                TextH.Text = vistap.hidratosCarbono.ToString();
                TexImg.Source = vistap.urlImg.ToString();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }

        }
    }
}