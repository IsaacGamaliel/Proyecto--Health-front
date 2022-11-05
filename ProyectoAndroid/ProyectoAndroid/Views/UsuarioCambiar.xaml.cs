using Newtonsoft.Json;
using ProyectoAndroid.Models;
using ProyectoAndroid.Services;
using ProyectoAndroid.Views.Menu;
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
        ApiRest apiRest = new ApiRest();
        public string _id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string nickName { get; set; }
        public string email { get; set; }
        public string fechaNacimiento { get; set; }
        public string genero { get; set; }
        public string password { get; set; }

        public string idUsuario { get; set; }

        public UsuarioCambiar()
        {
            InitializeComponent();
            consultaU();
            
        }

        private void btnEdi_Clicked(object sender, EventArgs e)
        {
            //Se desabilitan botenes y se habilitan campos para editar
            TxtNombre.IsEnabled = true;
            TxtApellidos.IsEnabled = true;
            TxtNickName.IsEnabled = true;
            TxtCorreo.IsEnabled = true;
            pkFecha.IsEnabled = true;
           


            btnEdi.IsVisible = false;
            btnGua.IsVisible = true;
            btnCancelar.IsVisible = true;
        }

        private void btnCancelar_Clicked(object sender, EventArgs e)
        {
            //Application.Current.MainPage.Navigation.PushModalAsync(new UsuarioCambiar());
            Application.Current.MainPage = new MenuShell();
            //Application.Current.MainPage = new UsuarioCambiar();
        }

        public async void consultaU()
        {
            
            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(Application.Current.Properties["jsonUsuario"].ToString());
            idUsuario = $"{usuario._id}";

            var response = await apiRest.ConsultaUsuario(idUsuario);
            Usuario consultaget = JsonConvert.DeserializeObject<Usuario>(response);

            Txtid.Text = consultaget._id.ToString();
            TxtG.Text = consultaget.genero;
            TxtNombre.Text = consultaget.nombre;
            TxtApellidos.Text = consultaget.apellido;
            TxtNickName.Text = consultaget.nickName;
            TxtCorreo.Text = consultaget.email;
            pkFecha.Text = consultaget.fechaNacimiento;
        }
    }
}