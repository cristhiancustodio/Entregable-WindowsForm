using System.Data;
namespace FormColegio.bean
{
    internal class Cursos
    {
        public string CodCurso { get; set; }
        public string Materia { get; set; }
        public string Apellido { get; set; }

        public Cursos() { }

        public Cursos(string cod_curso,string materia,string a_profe)
        {
            CodCurso = cod_curso;
            Materia = materia;
            Apellido = a_profe;
        }

        internal void setCursos(DataRow dataRow)
        {
            
            CodCurso = dataRow["Codigo"].ToString();
            Materia = dataRow["materia"].ToString();
            Apellido =  dataRow["Apellido"].ToString();
        }
    }
}
