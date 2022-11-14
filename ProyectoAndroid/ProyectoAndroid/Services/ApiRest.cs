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
        private string URL = "http://192.168.129.91:4000/";

        //Se consume metodo de Crear Usuario
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
                response = await client.PostAsync(string.Concat(URL, "Login/Register"), from);
                resultado = await response.Content.ReadAsStringAsync();

            }
            catch (Exception ex)
            {
                resultado = "";
                Debug.WriteLine(ex.Message);
            }

            return resultado;
        }
        //Se consume metodo de login
        public async Task<string> Login(string email, string password)
        {
            string resultado = "";
            MultipartFormDataContent from = new MultipartFormDataContent();
            var contenido = new StringContent(email);
            from.Add(contenido, "email");
            contenido = new StringContent(password);
            from.Add(contenido, "password");
            HttpClient client = new HttpClient();
            try
            {
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

        //Se consume metodo de editar usuario
        public async Task<string> EditarUsuario(string nombre, string apellido, string nickName, string email, string fechaNacimiento, string genero, string idUsuario)
        {
            string resultado = "";
            MultipartFormDataContent from = new MultipartFormDataContent();
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
            contenido = new StringContent(idUsuario);
            from.Add(contenido, "idUsuario");
            HttpClient client = new HttpClient();
            try
            {
                var response = new HttpResponseMessage();
                response = await client.PostAsync(string.Concat(URL, "user/Edit"), from);
                resultado = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                resultado = "";
                Debug.WriteLine(ex.Message);
            }
            return resultado;
        }

        //Metodo para consultar usuario
        public async Task<string> ConsultaUsuario(string idUsuario)
        {
            string resultado = "";

            MultipartFormDataContent from = new MultipartFormDataContent();
            var contenido = new StringContent(idUsuario);
            from.Add(contenido, "idUsuario");
            HttpClient client = new HttpClient();
            try
            {
                var response = new HttpResponseMessage();
                response = await client.GetAsync(string.Concat(URL, "user/Information/" + idUsuario));
                resultado = await response.Content.ReadAsStringAsync();
                //claveQ = JsonConvert.DeserializeObject<String>(resultado);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return resultado;
        }

        //Consulta usuario post
        public async Task<string> ConsultaUsu(string idUsuario)
        {
            string resultado = "";

            MultipartFormDataContent from = new MultipartFormDataContent();
            var contenido = new StringContent(idUsuario);
            from.Add(contenido, "idUsuario");
            HttpClient client = new HttpClient();
            try
            {
                var response = new HttpResponseMessage();
                
                response = await client.PostAsync(string.Concat(URL, "user/informationPost/"), from);
                resultado = await response.Content.ReadAsStringAsync();
                //claveQ = JsonConvert.DeserializeObject<String>(resultado);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return resultado;
        }

        //Metodo de generar pregunta
        public async Task<string> GenerarPregunta(string titulo, string descripcion, string idUsuario)
        {
            string resultado = "";
            MultipartFormDataContent from = new MultipartFormDataContent();
            var contenido = new StringContent(titulo);
            from.Add(contenido, "titulo");
            contenido = new StringContent(descripcion);
            from.Add(contenido, "descripcion");
            contenido = new StringContent(idUsuario);
            from.Add(contenido, "idUsuario");
            HttpClient client = new HttpClient();
            try
            {
                var response = new HttpResponseMessage();
                response = await client.PostAsync(string.Concat(URL, "comments/CreateComments"), from);
                resultado = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                resultado = "";
                Debug.WriteLine(ex.Message);
            }
            return resultado;
        }
        //COnsulta para traer las preguntas del usuario
        public async Task<string> ConsultaPreguntas(string idUsuario)
        {
            string resultado = "";
            MultipartFormDataContent from = new MultipartFormDataContent();
            var contenido = new StringContent(idUsuario);
            from.Add(contenido, "idUsuario");
            HttpClient client = new HttpClient();
            try
            {
                var response = new HttpResponseMessage();
                response = await client.PostAsync(string.Concat(URL, "comments/ShowComments"), from);
                resultado = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                resultado = "";
                Debug.WriteLine(ex.Message);
            }
            return resultado;
        }

        //Consulta para traer los alimentos de la api

        public async Task<string> ConsultaAlimentos(string categoriaAlimento)
        {
            string resultado = "";
            try
            {

                MultipartFormDataContent from = new MultipartFormDataContent();
                var contenido = new StringContent(categoriaAlimento);
                from.Add(contenido, "categoria");
                HttpClient client = new HttpClient();


                var response = new HttpResponseMessage();
                response = await client.PostAsync(string.Concat(URL, "foods/ShowFoods"), from);
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
