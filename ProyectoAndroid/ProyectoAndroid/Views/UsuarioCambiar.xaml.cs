using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoAndroid.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsuarioCambiar : ContentPage
    {
        public UsuarioCambiar()
        {
            InitializeComponent();
            carga();
        }

        private void carga()
        {
            GeneroP.Items.Add("Masculino");
            GeneroP.Items.Add("Femenino");

        }

        private void btnEdi_Clicked(object sender, EventArgs e)
        {
            TxtNombre.IsEnabled = true;
            TxtApellidos.IsEnabled = true;
            TxtNickName.IsEnabled = true;
            TxtCorreo.IsEnabled = true;
            TxtContrseña.IsEnabled = true;
            pkFecha.IsEnabled = true;

            GeneroP.IsVisible = true;
            frameG.IsVisible = false;

            btnEdi.IsVisible = false;
            btnGua.IsVisible = true;
            SFtxtGeneroP.IsVisible = false;


        }
    }
}