using Newtonsoft.Json;
using ProyectoAndroid.Models;
using ProyectoAndroid.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAndroid.ViewModels.Ejercicios
{
    public class EjercicioViewModel : BaseViewModel
    {
        ApiRest apiRest = new ApiRest();
        public string _id { get; set; }
        public string nombreEjercisio { get; set; }
        public string descripcion { get; set; }
        public string urlVideo { get; set; }
        public string urlImg { get; set; }

        public ObservableCollection<EjercicioModel> Items { get; }
        public EjercicioViewModel()
        {
            string response = "";
            try
            {
                Task.Run(async () =>
                {
                    
                    response = await apiRest.ConsultaEjercicios();
                }).Wait();

                List<EjercicioModel> consulta = JsonConvert.DeserializeObject<List<EjercicioModel>>(response);
                Items = new ObservableCollection<EjercicioModel>();
                foreach (EjercicioModel consultas in consulta)
                {
                    Items.Add(consultas);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
