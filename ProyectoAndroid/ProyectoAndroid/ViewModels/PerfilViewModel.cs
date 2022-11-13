using Newtonsoft.Json;
using Plugin.Toast;
using ProyectoAndroid.Models;
using ProyectoAndroid.Services;
using ProyectoAndroid.Views.Menu;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProyectoAndroid.ViewModels
{
    public class PerfilViewModel : BaseViewModel
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

        //public PerfilViewModel()
        //{
        //    UsuarioId();
        //    //usuarios();
        //}



        //private async void UsuarioId()
        //{
        //    try
        //    {
        //        Usuario usuario = JsonConvert.DeserializeObject<Usuario>(Application.Current.Properties["jsonUsuario"].ToString());
        //        idUsuario = $"{usuario._id}";
        //        var response = await apiRest.ConsultaUsuario(idUsuario);
        //        Usuario consulta = JsonConvert.DeserializeObject<Usuario>(response);
        //        this.idUsuario = consulta._id.ToString();
        //        this.nombre = consulta.nombre.ToString();
        //        this.apellido = consulta.apellido.ToString();
        //        this.fechaNacimiento = consulta.fechaNacimiento.ToString();
        //        //this.Correo = consulta.Correo;
        //        //this.Phone = consulta.Phone;
        //        //this.Url = consulta.Url;
        //    }
        //    catch (Exception ex)
        //    {

        //        Console.WriteLine(ex);
        //    }

        //}
        //Actualizar usuario
        public ICommand ActualizarComand
        {
            get
            {
                return new Command(async () =>
                {
                    try
                    {
                        Usuario usuario = JsonConvert.DeserializeObject<Usuario>(Application.Current.Properties["jsonUsuario"].ToString());
                        idUsuario = $"{usuario._id}";
                        var response = await apiRest.EditarUsuario(nombre, apellido, nickName, email, fechaNacimiento, genero, idUsuario);
                        if (response == "{\"message\":\"Sorry, all fields are required\"}")
                        {
                            var res = await App.Current.MainPage.DisplayAlert("Error", "Revisar campos vacios", "", "Ok");
                        }
                        else if(response == "{\"message\":\"User does not exist\"}")
                        {
                            var res = await App.Current.MainPage.DisplayAlert("Error", "Usuario no existe", "", "Ok");
                        
                        }
                        else if(response == "{\"message\":\"error updating user.\"}")
                        {
                            var res = await App.Current.MainPage.DisplayAlert("Error", "Error al editar el usuario", "", "Ok");
                        }
                        else if(response == "{\"message\":\"error finding new user.\"}")
                        {
                            var res = await App.Current.MainPage.DisplayAlert("Error", "Error al encontrar el usuario", "", "Ok");
                        }
                        else if (response == "{\"message\":\"There is an error with server\"}")
                        {
                            var res = await App.Current.MainPage.DisplayAlert("Error", "Error del servidor", "", "Ok");
                        }
                        else if (response == "")
                        {
                            var res = await App.Current.MainPage.DisplayAlert("Error", "Error", "", "Ok");
                        }
                        else
                        {
                            
                            Application.Current.MainPage = new MenuShell();
                            var res = await App.Current.MainPage.DisplayAlert("Exito", "Actualizado Correctamente", "", "Ok");

                        }

                    }
                    catch (Exception ex)
                    {
                        var res = await App.Current.MainPage.DisplayAlert("Error", ex.Message, "", "Ok");
                        Console.WriteLine(ex);
                    }

                });


            }
        }
    }
}
