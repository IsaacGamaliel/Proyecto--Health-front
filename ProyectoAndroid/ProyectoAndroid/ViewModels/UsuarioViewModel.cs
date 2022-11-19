using Newtonsoft.Json;
using Plugin.Toast;
using ProyectoAndroid.Models;
using ProyectoAndroid.Services;
using ProyectoAndroid.Views;
using ProyectoAndroid.Views.Menu;
using ProyectoAndroid.Views.UsuariosM;
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

        public string token { get; set; }
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

                    IsBusy = true;
                    try
                    {
                        var response = await apiRest.Login(email, password);
                        
                        if (response == "{\"message\":\"Password does not exist\"}")
                        {
                            var res = await App.Current.MainPage.DisplayAlert("Error", "Contraseña Incorrecta", "", "Ok");
                            IsBusy = false;
                        }
                        else if (response == "{\"message\":\"Email does not exist\"}")
                        {
                            var res = await App.Current.MainPage.DisplayAlert("Error", "Correo No existe", "", "Ok");
                            IsBusy = false;
                        }
                        else
                        {
                            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(response);

                            Application.Current.Properties["jsonUsuario"] = JsonConvert.SerializeObject(usuario);
                            await Application.Current.SavePropertiesAsync();

                            Application.Current.MainPage = new MenuShell();
                            IsBusy = false;
                            //CrossToastPopUp.Current.ShowToastSuccess("Inicio exitoso");
                        }

                    }
                    catch (Exception ex)
                    { 
                        var res = await App.Current.MainPage.DisplayAlert("Error", "Revisa tus campos vacios", "", "Ok");
                        IsBusy = false;
                        Console.WriteLine(ex);

                    }

                });
            }
        }

        public ICommand VerificarComand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        var response = await apiRest.VerificacionCorreo(email);
                        if (response == "\"Email es requerido\"")
                        {

                            var res = await App.Current.MainPage.DisplayAlert("Error", "Email Requerido", "", "Ok");
                            //await Application.Current.MainPage.Navigation.PushModalAsync(new NuevaContra());
                        }
                        else if(response == "{\"message\":\"Cannot read properties of undefined (reading 'nombre')\"}")
                        {
                            var res = await App.Current.MainPage.DisplayAlert("Error", "Email no registrado", "", "Ok");
                        }
                        else
                        {
                            var res = await App.Current.MainPage.DisplayAlert("Exito", "Email Correcto", "", "Ok");
                            await Application.Current.MainPage.Navigation.PushModalAsync(new NuevaContra());
                        }

                    }
                    catch (Exception ex)
                    {
                        var res = await App.Current.MainPage.DisplayAlert("Error", "Email Requerido", "", "Ok");
                        Console.WriteLine(ex);
                    }

                });


            }
        }

        public ICommand cambiarContra
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        var response = await apiRest.cambiarcontra(password, token);
                        if (response == "{\"message\":\"todos los campos son requeridos\",\"code\":1}")
                        {

                            var res = await App.Current.MainPage.DisplayAlert("Error", "Campos vacios verifica", "", "Ok");
                            //await Application.Current.MainPage.Navigation.PushModalAsync(new NuevaContra());
                        }
                        else if (response == "{\"message\":\"No se puede recuperar la contraseña, verifique el enlace enviado a su correo electrónico\"}")
                        {
                            var res = await App.Current.MainPage.DisplayAlert("Error", "Enlace incompleto o erroneo", "", "Ok");
                        }
                        else if(response == "{\"message\":\"La contraseña se ha cambiado con éxito\"}")
                        {
                            var res = await App.Current.MainPage.DisplayAlert("Exito", "Contraseña actualizada", "", "Ok");
                            Application.Current.MainPage = new PaginaLogin();

                        }

                    }
                    catch (Exception ex)
                    {
                        var res = await App.Current.MainPage.DisplayAlert("Error","Error", "", "Ok");
                        Console.WriteLine(ex);
                    }

                });


            }
        }

    }
}
