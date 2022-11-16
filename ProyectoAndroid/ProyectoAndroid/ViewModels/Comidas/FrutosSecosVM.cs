﻿using Newtonsoft.Json;
using ProyectoAndroid.Models;
using ProyectoAndroid.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAndroid.ViewModels.Comidas
{
    public class FrutosSecosVM : BaseViewModel
    {
        ApiRest apiRest = new ApiRest();
        public ObservableCollection<ComidaModel> Items { get; set; }
        public string categoriaAlimento { get; set; }

        public FrutosSecosVM()
        {
            try

            {
                string response = "";
                Task.Run(async () =>
                {
                    categoriaAlimento = "FRUTOSSECOS";
                    response = await apiRest.ConsultaAlimentos(categoriaAlimento);
                }).Wait();
                List<ComidaModel> consulta = JsonConvert.DeserializeObject<List<ComidaModel>>(response);
                Items = new ObservableCollection<ComidaModel>();
                foreach (ComidaModel consultas in consulta)
                {
                    Items.Add(consultas);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
