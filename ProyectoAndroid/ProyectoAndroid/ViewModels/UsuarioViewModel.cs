using ProyectoAndroid.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Plugin.Toast;
using ProyectoAndroid.Views;

using ProyectoAndroid.Models;
using Newtonsoft.Json;
using ProyectoAndroid.Views.Menu;

namespace ProyectoAndroid.ViewModels
{
    public class UsuarioViewModel : BaseViewModel
    {
        ApiRest apiRest = new ApiRest();

        public string idcliente { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string nickName { get; set; }
        public string email { get; set; }
        public string fechaNacimiento { get; set; }
        public string genero { get; set; }
        public string password { get; set; }


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
                            if (response == "")
                            {
                                CrossToastPopUp.Current.ShowToastError("Algo salio Mal vuelva a intentarlo");
                            }
                            else
                            {
                                Application.Current.MainPage = new PaginaLogin();
                                CrossToastPopUp.Current.ShowToastSuccess("Registrado");
                            }
                    }
                    catch (Exception ex)
                    {
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

                        //var response = await apiRest.Login(email, password);
                        //if (response == "{\"message\":\"Todos los campos son requeridos\"}" )
                        //{
                        //    CrossToastPopUp.Current.ShowToastSuccess("Correo o contraseña incorrecta");

                        //}
                        //else
                        //{
                        //    //Usuario usuario = JsonConvert.DeserializeObject<Usuario>(response);
                        //    //UsuarioViewModel usuario = JsonConvert.DeserializeObject<UsuarioViewModel>(response);
                        //    //Application.Current.Properties["jsonUsuario"] = JsonConvert.SerializeObject(usuario);
                        //    //await Application.Current.SavePropertiesAsync();
                        //    //await Application.Current.MainPage.Navigation.PushModalAsync(new Principal());
                        Application.Current.MainPage = new MenuShell();
                        //CrossToastPopUp.Current.ShowToastSuccess("Inicio exitoso");

                        //}

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }

                });
            }
        }
    }
}
