using Plugin.Toast;
using ProyectoAndroid.Views.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamUIDemo.Animations;

namespace ProyectoAndroid.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaLogin : ContentPage
    {
        public PaginaLogin()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Task.Run(async () =>
            {
                await ViewAnimations.FadeAnimY(Logo);
                await ViewAnimations.FadeAnimY(EmailPancake);
                await ViewAnimations.FadeAnimY(PassPancake);
                await ViewAnimations.FadeAnimY(LoginButton);

            });
        }
        

        private void Registro(object sender, EventArgs e)
        {
            Application.Current.MainPage = new PaginaRegistro();
            
            
        }

        //private async void LoginButton_Clicked(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrWhiteSpace(correo.Text))
        //    {
        //        await DisplayAlert("Advertencia", "El campo del correo es obligatorio", "Ok");
        //        return;
        //    }
            
        //    if(string.IsNullOrWhiteSpace(contraseña.Text))
        //    {
        //        await DisplayAlert("Advertencia", "El campo del contraseña es obligatorio", "Ok");
        //        return;
        //    }

           
            
        //}
    }
}