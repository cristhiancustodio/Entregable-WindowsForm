using System;
using System.Data;
using System.Drawing;
using FormColegio;
using System.Windows.Forms;

namespace FormColegio.gui
{
    public partial class main : Form
    {
        bean.Alumno alumno = new bean.Alumno();
        dao.daoColegio daoColegio = new dao.daoColegio();
        DataTable dtRegistros = new DataTable();
        public main()
        {
            
            InitializeComponent();
        }

        private void main_Load(object sender, System.EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'colegioDataSet.sp_VerAlumnos' Puede moverla o quitarla según sea necesario.
            // TODO: esta línea de código carga datos en la tabla 'colegioDataSet.sp_verCursos' Puede moverla o quitarla según sea necesario.


        }

        private void button1_Clickbtn(object sender, System.EventArgs e)
        {
            
                alumno.IdAlumno = int.Parse(txtIdAlumno.Text);
                alumno.Nombre = txtNombre.Text;
                alumno.SegNombre = txtSNombre.Text;
                alumno.Apellido = txtApellido.Text;
                alumno.SegApellido = txtSApellido.Text;
                alumno.Telefono = txtTelefono.Text;
                alumno.Celular = txtCelular.Text;
                alumno.Direccion = txtDireccion.Text;
                alumno.Email = txtEmail.Text;
                alumno.Fecha = txtFecha.Text;
                alumno.Comentario = txtComentario.Text;
           

            try
            {
                daoColegio.registrarAlumno(alumno);
                MessageBox.Show("Alumno registrado");
                ListaAlumnos();
                LimpiarCampos();
            }
            catch
            {
                MessageBox.Show("Codigo ya registrado o verifica los datos entrados");
            }
            
        }

        private void btnEliminar_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("Seguro que quieres eliminar a " + alumno.Apellido, "Eliminar",
                   MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                
                daoColegio.eliminarAlumno(alumno);
                ListaAlumnos();
                LimpiarCampos();
            }
        }
        

        private void btnListar_Click(object sender, System.EventArgs e)
        {

            ListaAlumnos();

            
        }
        public void ListaAlumnos() 
        {
            dtRegistros = daoColegio.verAlumnos();
            dgvAlumnos.DataSource = dtRegistros;
        }

        private void dgvAlumnos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            verRegistro(e.RowIndex);
            
        }

        private void verRegistro(int index)
        {
            txtIdAlumno.Text = dgvAlumnos.Rows[index].Cells[0].Value.ToString();
            txtNombre.Text = dgvAlumnos.Rows[index].Cells[1].Value.ToString();
            txtSNombre.Text = dgvAlumnos.Rows[index].Cells[2].Value.ToString();
            txtApellido.Text = dgvAlumnos.Rows[index].Cells[3].Value.ToString();
            txtSApellido.Text = dgvAlumnos.Rows[index].Cells[4].Value.ToString();
            txtTelefono.Text = dgvAlumnos.Rows[index].Cells[5].Value.ToString();
            txtCelular.Text = dgvAlumnos.Rows[index].Cells[6].Value.ToString();
            txtDireccion.Text = dgvAlumnos.Rows[index].Cells[7].Value.ToString();
            txtEmail.Text = dgvAlumnos.Rows[index].Cells[8].Value.ToString();
            txtFecha.Text = dgvAlumnos.Rows[index].Cells[9].Value.ToString();
            txtComentario.Text = dgvAlumnos.Rows[index].Cells[10].Value.ToString();

            alumno.IdAlumno= int.Parse(txtIdAlumno.Text);
            alumno.Nombre= txtNombre.Text;
            alumno.SegNombre= txtSNombre.Text;
            alumno.Apellido= txtApellido.Text;
            alumno.SegApellido= txtSApellido.Text;
            alumno.Telefono= txtTelefono.Text;
            alumno.Celular= txtCelular.Text;
            alumno.Direccion= txtDireccion.Text;
            alumno.Email= txtEmail.Text;
            alumno.Fecha= txtFecha.Text;
            alumno.Comentario= txtComentario.Text;


        }
        private void LimpiarCampos()
        {
            txtIdAlumno.Text = "";
            txtNombre.Text = "";
            txtSNombre.Text = "";
            txtApellido.Text = "";
            txtSApellido.Text = "";
            txtTelefono.Text = "";
            txtCelular.Text = "";
            txtDireccion.Text = "";
            txtEmail.Text = "";
            txtFecha.Text = "";
            txtComentario.Text = "";

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            alumno.IdAlumno = int.Parse(txtIdAlumno.Text);
            alumno.Nombre = txtNombre.Text;
            alumno.SegNombre = txtSNombre.Text;
            alumno.Apellido = txtApellido.Text;
            alumno.SegApellido = txtSApellido.Text;
            alumno.Telefono = txtTelefono.Text;
            alumno.Celular = txtCelular.Text;
            alumno.Direccion = txtDireccion.Text;
            alumno.Email = txtEmail.Text;
            alumno.Fecha = txtFecha.Text;
            alumno.Comentario = txtComentario.Text;

            daoColegio.actualizarAlumno(alumno);
            MessageBox.Show("Alumno actualizado");
            LimpiarCampos();
            ListaAlumnos();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            
        }

        private void btnProfesores_Click(object sender, EventArgs e)
        {
            profesores frmprofesores = new profesores();
            frmprofesores.ShowDialog();
        }

        private void btnClases_Click(object sender, EventArgs e)
        {
            curso frmcurso = new curso();
            frmcurso.ShowDialog();
            
        }

        public void Cerrar() 
        {
            Application.Exit();
        }


    }
}
