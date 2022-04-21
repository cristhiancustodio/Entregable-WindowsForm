using System;
using System.Data;


namespace FormColegio.bean
{
    internal class Alumno
    {
        /*Creamos nuestros getters and setters */
        public int IdAlumno { get; set; }
        public string Nombre { get; set; }
        public string SegNombre { get; set; }
        public string Apellido { get; set; }
        public string SegApellido { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Fecha { get; set; }
        public string Comentario { get; set; }

        public bool Valido { get; set; }
        public Alumno() { }

        /* este es nuestro constructor*/
        public Alumno(int id_alumno,string nombre, string seg_nombre,string apellido, string seg_apellido, string telefono,string cel,string direccion,string email,string fecha,string coment)
        {
            IdAlumno = id_alumno;
            Nombre = nombre;
            SegNombre = seg_nombre;
            Apellido = apellido;
            SegApellido = seg_apellido;
            Telefono = telefono;
            Celular = cel;
            Direccion = direccion;
            Email = email;
            Fecha = fecha;
            Comentario = coment;
        }
        /*aqui iran nuestros metodos que querramos hacer con nuestras variables*/

        internal void setAlumnos(DataRow dataRow)//con DataRow podremos traer los valores de las tablas
        {
            Valido = false;
            if (dataRow == null) return;

            Valido = true;
            IdAlumno = (int)dataRow["idAlumno"];
            Nombre = dataRow["primer_nombre"].ToString().Trim();
            SegNombre = dataRow["segundo_nombre"].ToString();
            Apellido = dataRow["primer_apellido"].ToString();
            SegApellido = dataRow["segundo_apellido"].ToString();
            Telefono = dataRow["telefono"].ToString();
            Celular = dataRow["celular"].ToString();
            Direccion = dataRow["direccion"].ToString();
            Email = dataRow["email"].ToString();
            Fecha = dataRow["fecha_nacimiento"].ToString();
            Comentario = dataRow["observacion"].ToString();

        }
        // ya no es necesario el get, automaticamente llamando a nuestra varible y se retorna el valor
        
}
}
