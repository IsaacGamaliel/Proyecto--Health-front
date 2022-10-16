using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAndroid.Services
{
    public class ApiRest
    {
        //Url donde se consume la api creada
        private string URL = "http://192.168.1.66:4000/";

        public async Task<string> CreateUsuario(string nombre, string apellido, string nickName, string email, string fechaNacimiento, string genero,  string password)
        {
            string resultado = "";
            //Decodifica los valos obtenidos
            MultipartFormDataContent from = new MultipartFormDataContent();
            //Se decalara la variable contenido donde se añanden en forma de estring
            var contenido = new StringContent(nombre);
            from.Add(contenido, "nombre");
            contenido = new StringContent(apellido);
            from.Add(contenido, "apellido");
            contenido = new StringContent(nickName);
            from.Add(contenido, "nickName");
            contenido = new StringContent(email);
            from.Add(contenido, "email");
            contenido = new StringContent(fechaNacimiento);
            from.Add(contenido, "fechaNacimiento");
            contenido = new StringContent(genero);
            from.Add(contenido, "genero");
            contenido = new StringContent(password);
            from.Add(contenido, "password");
            //Peticion Http
            HttpClient client = new HttpClient();
            //Catch para detectar errores
            try
            {


                //Envio de datos a apirest para poder ser insertados en la base de datos
                var response = new HttpResponseMessage();
                response = await client.PostAsync(string.Concat(URL, "Login"), from);
                resultado = await response.Content.ReadAsStringAsync();

            }
            catch (Exception ex)
            {
                resultado = "";
                Debug.WriteLine(ex.Message);
            }

            return resultado;
        }


        

    }
}
