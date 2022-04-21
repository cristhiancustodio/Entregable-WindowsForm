using System.Data;
using System.Windows.Forms;

using FormColegio.bean;
namespace FormColegio.gui
{
    public partial class profesores : Form
    {
        bean.Profesores profe = new bean.Profesores();
        dao.daoColegio daoColegio = new dao.daoColegio();
        DataTable dtRegistros = new DataTable();


        
        public profesores()
        {
            
            InitializeComponent();
        }

        private void profesores_Load(object sender, System.EventArgs e)
        {
           
           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            verRegistro(e.RowIndex);
        }

        private void btnVerLista_Click(object sender, System.EventArgs e)
        {

            getProfesores();
        }

        private void getProfesores()
        {
            dtRegistros = daoColegio.verProfesoresTabla();
            dgvProfesores.DataSource = dtRegistros;

            

            
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            
            profe.idProfesor = txtIdProfe.Text;
            profe.Nombre = txtNombre.Text;
            profe.Apellido = txtApellido.Text;
            if (txtIdProfe.Text == "" || txtNombre.Text == "" || txtApellido.Text == "")
            {
                MessageBox.Show("Rellene todos los campos");
            }
            else
            {
                daoColegio.registrarProfesor(profe);
                MessageBox.Show("Registrado con exito");
                getProfesores();
            }
            
            LimpiarCampos();
            
        }

        private void btnBuscar_Click(object sender, System.EventArgs e)
        {
            profe.idProfesor = txtBuscar.Text;
            if (txtBuscar.Text == "" )
            {
                MessageBox.Show("Rellene el campo buscar");
            }
            else
            {
                dtRegistros = daoColegio.verUnicoProfesorTabla(profe);
                dgvProfesores.DataSource = dtRegistros;
                daoColegio.verUnicoProfesor(profe);
                txtIdProfe.Text = profe.idProfesor;
                txtNombre.Text = profe.Nombre;
                txtApellido.Text = profe.Apellido;
            }
            txtBuscar.Text = "";




        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            
            profe.idProfesor = txtBuscar.Text;
            profe.Nombre = txtNombre.Text;
            profe.Apellido = txtApellido.Text;
            if (txtIdProfe.Text == "" || txtNombre.Text == "" || txtApellido.Text == "")
            {
                MessageBox.Show("Rellene todos los campos");
            }
            else
            {
                daoColegio.actualizarProfesor(profe);
            }

            LimpiarCampos();
            txtBuscar.Text = "";
            getProfesores();


        }
        private void verRegistro(int index)
        {

            
            profe.idProfesor = dgvProfesores.Rows[index].Cells[0].Value.ToString();
            profe.Nombre = dgvProfesores.Rows[index].Cells[1].Value.ToString();
            profe.Apellido = dgvProfesores.Rows[index].Cells[2].Value.ToString();

            txtIdProfe.Text = profe.idProfesor;
            txtNombre.Text = profe.Nombre;
            txtApellido.Text = profe.Apellido;

        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            
            if(MessageBox.Show("Seguro que quieres eliminar a " + profe.Apellido,"Eliminar",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                profe.idProfesor = txtIdProfe.Text;
                daoColegio.eliminarProfesor(profe);
            }
            getProfesores();
            LimpiarCampos();
        }
        private void LimpiarCampos()
        {
            txtApellido.Text = "";
            txtIdProfe.Text = "";
            txtNombre.Text = "";
        }

        private void dgvCursoProfe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnInicio_Click(object sender, System.EventArgs e)
        {
            main frmAlumno = new main();
            frmAlumno.ShowDialog();
            Application.Exit();
        }

        private void btnClases_Click(object sender, System.EventArgs e)
        {
            curso frmCurso = new curso();
            frmCurso.ShowDialog();
            Application.Exit();
        }

        private void btnProfesores_Click(object sender, System.EventArgs e)
        {

        }
    }
}
