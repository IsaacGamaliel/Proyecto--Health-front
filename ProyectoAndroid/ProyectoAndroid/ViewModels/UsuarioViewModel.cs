using Newtonsoft.Json;
using Plugin.Toast;
using ProyectoAndroid.Models;
using ProyectoAndroid.Services;
using ProyectoAndroid.Views;
using ProyectoAndroid.Views.Menu;
using System;
using System.Windows.Input;
using Xamarin.Forms;


namespace ProyectoAndroid.ViewModels
{
    public class UsuarioViewModel : BaseViewModel
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



        //Registro
        public ICommand CreateComand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        var response = await apiRest.CreateUsuario(nombre, apellido, nickName, email, fechaNacimiento, genero, password);
                        if (response == null)
                        {
                            var res = await App.Current.MainPage.DisplayAlert("Error", "Algunos Campos estan vacios", "", "Ok");
                        }
                        else if (response == "{\"message\":\"This email already exist!\"}")
                        {
                            var res = await App.Current.MainPage.DisplayAlert("Error", "Correo ya existe", "", "Ok");
                        }
                        else
                        {
                            Application.Current.MainPage = new PaginaLogin();
                            //CrossToastPopUp.Current.ShowToastSuccess("Registrado");
                        }
                    }
                    catch (Exception ex)
                    {
                        var res = await App.Current.MainPage.DisplayAlert("Error", "Revisa tus campos", "", "Ok");
                        Console.WriteLine(ex);
                    }
                });


            }
        }

        //Login
        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {


                    try
                    {
                        var response = await apiRest.Login(email, password);

                        if (response == "{\"message\":\"Password does not exist\"}")
                        {
                            var res = await App.Current.MainPage.DisplayAlert("Error", "Contraseña Incorrecta", "", "Ok");
                        }
                        else if (response == "{\"message\":\"Email does not exist\"}")
                        {
                            var res = await App.Current.MainPage.DisplayAlert("Error", "Correo No existe", "", "Ok");
                        }
                        else
                        {

                            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(response);

                            Application.Current.Properties["jsonUsuario"] = JsonConvert.SerializeObject(usuario);
                            await Application.Current.SavePropertiesAsync();

                            Application.Current.MainPage = new MenuShell();
                            //CrossToastPopUp.Current.ShowToastSuccess("Inicio exitoso");
                        }

                    }
                    catch (Exception ex)
                    {
                        var res = await App.Current.MainPage.DisplayAlert("Error", "Revisa tus campos vacios", "", "Ok");
                        Console.WriteLine(ex);

                    }

                });
            }
        }

    }
}
