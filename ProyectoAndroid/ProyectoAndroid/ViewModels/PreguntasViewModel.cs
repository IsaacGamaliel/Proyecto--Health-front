using Newtonsoft.Json;
using ProyectoAndroid.Models;
using ProyectoAndroid.Services;
using ProyectoAndroid.Views.Menu;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProyectoAndroid.ViewModels
{
    public class PreguntasViewModel : BaseViewModel
    {
        ApiRest apiRest = new ApiRest();
        public string _id { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public string idUsuario { get; set; }
        public string respuesta { get; set; }
        public ObservableCollection<PreguntasModel> Items { get; }

        public PreguntasViewModel()
        {
            string response = "";
            try
            {
                Task.Run(async () =>
                {
                    Usuario usuario = JsonConvert.DeserializeObject<Usuario>(Application.Current.Properties["jsonUsuario"].ToString());
                    idUsuario = $"{usuario._id}";
                    response = await apiRest.ConsultaPreguntas(idUsuario);
                }).Wait();

                List<PreguntasModel> consulta = JsonConvert.DeserializeObject<List<PreguntasModel>>(response);
                Items = new ObservableCollection<PreguntasModel>();
                foreach (PreguntasModel consultas in consulta )
                {
                    Items.Add(consultas);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        //Login
        public ICommand CrearPregCommand
        {
            get
            {
                return new Command(async () =>
                {


                    try
                    {
                        Usuario usuario = JsonConvert.DeserializeObject<Usuario>(Application.Current.Properties["jsonUsuario"].ToString());
                        idUsuario = $"{usuario._id}";
                        var response = await apiRest.GenerarPregunta(titulo , descripcion, idUsuario);

                        if (response == "")
                        {
                            var res = await App.Current.MainPage.DisplayAlert("Error", "Error de id", "", "Ok");
                        }
                        else
                        {
                            var res = await App.Current.MainPage.DisplayAlert("Exito", "Pregunta Creada correctamente", "", "Ok");
                            Application.Current.MainPage = new MenuShell();
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
