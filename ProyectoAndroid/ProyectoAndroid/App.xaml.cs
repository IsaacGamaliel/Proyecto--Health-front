using ProyectoAndroid.Views;
using ProyectoAndroid.Views.Menu;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoAndroid
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //Se comenta codigo para cuando la sesion quede activa

            //if (Application.Current.Properties.ContainsKey("jsonUsuario"))
            //{
            //    Application.Current.MainPage = new MenuShell();
            //}
            //else
            //{
            //    MainPage = new PaginaLogin();
            //}

            MainPage = new PaginaLogin();

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
