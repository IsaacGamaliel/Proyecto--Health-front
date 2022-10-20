using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoAndroid.Models
{
    public class Usuario
    {
        public string _id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string nickName { get; set; }
        public string email { get; set; }
        public string fechaNacimiento { get; set; }
        public string genero { get; set; }
        public string password { get; set; }
    }
}
