using System.Windows.Forms;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;



namespace FormColegio.bd
{
    internal class clsBD
    {
        SqlConnection cn = null;
        SqlCommand cmd = null;  
        SqlDataAdapter da = null;

        
        public clsBD(string cnBD)
        {
            //aqui me crea la conexion a la BD con SqlConnection
            cn = new SqlConnection( ConfigurationManager.ConnectionStrings[ cnBD ].ConnectionString);
        }
        /*aqui va el procedimiento de la base de datos 
         que querramos ejecutar*/
        internal void Sentencia(string sql)
        {
            
            //crea un comando SQL que se ejecuta en la BD con SqlCommand
            cmd = new SqlCommand(sql, cn);
                
            
            
        }
        //linea para insertar datos a la tabla
        internal int Ejecturar()
        { 
        if (cn.State == ConnectionState.Closed) cn.Open();
        return cmd.ExecuteNonQuery();

        }


        internal DataSet getDataSet()
        {
            DataSet ds = new DataSet();

            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            return ds;
        }

        //obtiene los valores de toda la tabla
        internal DataTable getDataTable()
        {
            DataTable dt = new DataTable();

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        //solo una fila de la tabla
        internal DataRow getDataRow()
        {
            DataTable dt = new DataTable();

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }
        
        //coloca solo una columa de la tabla en un combobox
        internal void getComboBox(ComboBox comboBox)
        {
            getComboBox(comboBox, null, 0);
        }


        internal void getComboBox(ComboBox comboBox, string item, int columna)
        {
            DataTable dt = getDataTable();

            if (item != null)
            {
                DataRow dr = dt.NewRow();
                dr[1] = item;

                dt.Rows.InsertAt(dr, 0);
            }

            comboBox.DataSource = dt;
            comboBox.DisplayMember = dt.Columns[columna].ColumnName;
            comboBox.ValueMember = dt.Columns[0].ColumnName;
        }


        internal void getListBox(ListBox listBox)
        {
            getListBox(listBox, null);
        }


        internal void getListBox(ListBox listBox, string item)
        {
            DataTable dt = getDataTable();
            if (item != null)
            {
                DataRow dr = dt.NewRow();
                dr[1] = item;

                dt.Rows.InsertAt(dr, 0);
            }

            listBox.DataSource = dt;
            listBox.DisplayMember = dt.Columns[1].ColumnName;
            listBox.ValueMember = dt.Columns[0].ColumnName;
        }
    }
}
