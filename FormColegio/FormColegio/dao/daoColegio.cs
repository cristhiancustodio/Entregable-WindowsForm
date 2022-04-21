using FormColegio.bean;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using System;


            /*Cada Alumno,Curso y Profesor tienen sus metodos para que se realize el CRUD
             algunos metodos no se usan pero la gran mayoria si.
            
             Cada uno esta separado por un comentario para que sea mas legible la vista de cada 
            metodo.*/

namespace FormColegio.dao
{
    internal class daoColegio
    {
        /*Alumno alumno = new Alumno();
        Profesores profesor = new Profesores();
        Cursos curso = new Cursos();*/
        bd.clsBD clsBD = new bd.clsBD("cnColegio");


        //PARA ALUMNOS
        internal void registrarAlumno(Alumno alumno)
        {
            clsBD.Sentencia(string.Format("sp_insertarAlumno {0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}' ",
                alumno.IdAlumno,alumno.Nombre,alumno.SegNombre, alumno.Apellido ,alumno.SegApellido,alumno.Telefono,alumno.Celular,alumno.Direccion,alumno.Email
               ,alumno.Fecha,alumno.Comentario));
            clsBD.Ejecturar();
            
        }
        internal DataTable verAlumnos(){ 
            clsBD.Sentencia("sp_VerAlumnos");
            return clsBD.getDataTable();
        }
        internal void verUnicoAlumno(Alumno alumno)
        {
            //aqui instaciamos la clase Alumno y en el metodo setAlumnos le ponemos como parametro a los datos de
            //  getDataRow()    
            clsBD.Sentencia("sp_verUnicoAlumno " + alumno.IdAlumno);
            alumno.setAlumnos(clsBD.getDataRow());
        }
        internal void verCboxAlumno(ComboBox cboxAlumnos)
        {
            clsBD.Sentencia("sp_VerAlumnos");
            clsBD.getComboBox(cboxAlumnos, null, 0);
        }
        internal void eliminarAlumno(Alumno alumno)
        {
            clsBD.Sentencia("sp_EliminarAlumno " + alumno.IdAlumno);
            clsBD.Ejecturar();

        }
        internal void actualizarAlumno(Alumno alumno)
        {
            clsBD.Sentencia(string.Format("sp_ActualizarAlumno {0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}' ",
                alumno.IdAlumno, alumno.Nombre, alumno.SegNombre, alumno.Apellido, alumno.SegApellido
                , alumno.Telefono, alumno.Celular, alumno.Direccion, alumno.Email
                , alumno.Fecha, alumno.Comentario));
            clsBD.Ejecturar();
        }



        //PARA PROFESORES
        internal void registrarProfesor(Profesores profesor)
        {
            clsBD.Sentencia(string.Format("sp_InsertProfe '{0}','{1}','{2}'",profesor.idProfesor, profesor.Nombre,profesor.Apellido));
            clsBD.Ejecturar();
        }

        public DataTable verProfesoresTabla() {

            clsBD.Sentencia("sp_verTodosProfesores");
            return clsBD.getDataTable();
            //profesor.setProfesor(clsBD.getDataFilas());
        }
        public void verUnicoProfesor(Profesores profesor)
        {
            clsBD.Sentencia("sp_verProfesor "+ profesor.idProfesor);
            profesor.setProfesor(clsBD.getDataRow());
        }
        internal void verCboxProfesor(ComboBox cb)
        {
            clsBD.Sentencia("sp_verTodosProfesores");

            clsBD.getComboBox(cb,null,2);
        }
        internal DataTable verUnicoProfesorTabla(Profesores profesor) {
            clsBD.Sentencia("sp_verProfesor " + profesor.idProfesor);
            return clsBD.getDataTable();
            //profesor.setProfesor(clsBD.getDataRow());
        }
        internal void eliminarProfesor(Profesores profesor) {
            clsBD.Sentencia("sp_eliminarProfe " + profesor.idProfesor);
            clsBD.Ejecturar();
        }
        internal void actualizarProfesor(Profesores profesor)
        {
            clsBD.Sentencia(string.Format("sp_actualizarProfe '{0}','{1}','{2}'", profesor.idProfesor, profesor.Nombre, profesor.Apellido));
            clsBD.Ejecturar();
        }



        //PARA CURSOS

        /* solo se usa 1 metodo en esta seccion porque los cursos estan insertados en la misma
        base de datos, ya que no hay un FRM para el insertado de cursos y mas acciones*/
        
        internal void registrarCurso(Cursos curso){
            clsBD.Sentencia(string.Format("sp_InserCurso '{0}',{1} ", curso.CodCurso, curso.Materia));
        }

        internal void verCursos(Cursos curso){
            clsBD.Sentencia("sp_verCursos");
            curso.setCursos(clsBD.getDataRow());
        }
        internal void verCursoCbox(ComboBox combobox)
        {
            clsBD.Sentencia("sp_verCursos");
            clsBD.getComboBox(combobox,null,1);
        }
        internal void verUnicoCurso(string idCurso)
        {
            clsBD.Sentencia("sp_verUnicoCurso " + idCurso);
        }
        internal void eliminarCurso(string idCurso){
            clsBD.Sentencia("sp_eliminarCurso " + idCurso);
        }
        internal void actualizarCurso(Cursos curso){
            clsBD.Sentencia(string.Format("sp_actualizarMateria '{0}',{1}", curso.CodCurso, curso.Materia));
        }




        /*Procedimientos externos*/
        internal DataTable verClaseProfe()
        {
            clsBD.Sentencia("sp_verCursoProfe");
            return clsBD.getDataTable();

        }
        internal DataTable verClaseAlumno()
        {
            clsBD.Sentencia("sp_verClaseAlumno");
            return clsBD.getDataTable();
        }
        /*internal void registrarClase(int idAlumno,string ap_profe,string materia)
        {
            clsBD.Sentencia(string.Format("sp_RegistrarClase {0},'{1}','{2}'",idAlumno,ap_profe,materia));
            clsBD.Ejecturar();
        }*/
    }

    

        
}
