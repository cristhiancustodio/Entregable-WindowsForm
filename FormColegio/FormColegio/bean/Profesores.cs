using System.Data;
using System;
using System.Collections.Generic;

namespace FormColegio.bean
{
    internal class Profesores
    {
        public string idProfesor { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    
        public Profesores() { }
        public Profesores(string id_profesor, string nombre, string apellido)
            {
                idProfesor = id_profesor;
                Nombre = nombre;
                Apellido = apellido;

            }
        internal void setProfesor(DataRow dataRow)
        {

            idProfesor = dataRow["idProfesor"].ToString();
            Nombre = dataRow["nombre"].ToString();
            Apellido = dataRow["apellido"].ToString();
            
        }
        

    }

}
