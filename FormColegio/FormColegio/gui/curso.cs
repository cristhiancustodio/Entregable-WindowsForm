using FormColegio.bd;
using System;
using System.Data;
using System.Windows.Forms;

namespace FormColegio.gui
{
    public partial class curso : Form
    {
        bean.Alumno alumno = new bean.Alumno();
        bean.Profesores profe = new bean.Profesores();
        bean.Cursos cursos = new bean.Cursos();
        dao.daoColegio daoColegio = new dao.daoColegio();
        DataTable dtRegistros = new DataTable();
        
        public curso()
        {
            InitializeComponent();
        }
        
            
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void curso_Load(object sender, EventArgs e)
        {
            //dtRegistros = daoColegio.verClaseAlumno();
            //dataGridView1.DataSource = dtRegistros;
            

            dtRegistros = daoColegio.verAlumnos();
            dgvAlumnos.DataSource = dtRegistros;

            
            getCurso_Profe();

        }

        private void btnListarClases_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            getClaseAlumno();
        }

        private void dgvCursoProfe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            seleccionarFila(e.RowIndex);
            

        }
        private void getClaseAlumno()
        {
            dtRegistros = daoColegio.verClaseAlumno();
            dataGridView1.DataSource = dtRegistros;
        }

        private void getCurso_Profe()
        {
            dtRegistros = daoColegio.verClaseProfe();
            dgvCursoProfe.DataSource = dtRegistros;
        }
        private void seleccionarFila(int index)
        {
            cursos.CodCurso = dgvCursoProfe.Rows[index].Cells[0].Value.ToString();
            cursos.Apellido = dgvCursoProfe.Rows[index].Cells[1].Value.ToString();
            cursos.Materia = dgvCursoProfe.Rows[index].Cells[2].Value.ToString();

            
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void cboxAlumnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            removerFilas();
        }

        private void dgvAlumnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            seleccionarFilaAlumno(e.RowIndex);
            
        }

        private void seleccionarFilaAlumno(int rowIndex)
        {
            
            alumno.IdAlumno = (int)dgvAlumnos.Rows[rowIndex].Cells[0].Value;

            
           
        }
        public int contarFilas()
        {
            int numero = dataGridView1.Rows.Count;
            return numero-1;
        }

        public void agregarFilas()
        {
            dataGridView1.Rows.Add(alumno.IdAlumno,cursos.Apellido,cursos.Materia);
        }

        public void removerFilas()
        {
            dataGridView1.Columns[0].Visible = true;
            dataGridView1.Columns[1].Visible = true;
            dataGridView1.Columns[2].Visible = true;
            dataGridView1.Rows.Clear();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            agregarFilas();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            // trae la ventana donde se registra al alumno
            main frmMain = new main();
            frmMain.ShowDialog();
        }

        private void btnProfesores_Click(object sender, EventArgs e)
        {
            //linea que trae la ventana donde se registra los profesores
            profesores frmprofesores = new profesores();
            frmprofesores.ShowDialog();
        }

        private void btnRegistrarClase_Click(object sender, EventArgs e)
        {
            /*alumno.IdAlumno = (int)dataGridView1.Rows[0].Cells[0].Value;
            profe.Apellido = dataGridView1.Rows[1].Cells[0].Value.ToString();
            cursos.Materia = dataGridView1.Rows[2].Cells[0].Value.ToString();

            daoColegio.registrarClase(alumno.IdAlumno,profe.Apellido,cursos.Materia);

            dataGridView1.Rows.Clear();*/
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //se quiere limpiar la tabla despues de listar la clases traidas de la misma base de datos
            // pero sale un error
            dataGridView1.Rows.Clear();
        }
    }
}
