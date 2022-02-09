//Estudiante:     Jhon Waldir Guerra Bellido
//Código:           171910

using System;
using System.Data;
using System.Windows.Forms;
//activamos referencias que necesitamos en esta capa
using System.Data.SqlClient;
using System.Linq;

namespace _2021
{
    public partial class ImpresionCertificados : Form
    {
        //Atributos
        private string NroCertificado = "";
        private string NroHoras = "";
        private string FechaEmision = "";
        private string Periodo = "";
        private string CodAlumno = "";
        private string Alumno = "";
        private string Curso = "";
        private string Denominacion = "";
        private string Nota = "";
        private string Tema = "";
        private string Costo = "";
        private string Anio = "";
        private string Tipo = "";
        private bool Flag = false;

        public ImpresionCertificados()
        {
            InitializeComponent();
            Autocompletar();
        }

        private void ImpresionCertificados_Load(object sender, EventArgs e)
        {
            CBAnio.Items.Add("2019");
            CBAnio.Items.Add("2020");
            CBAnio.Items.Add("2021");
            CBAnio.Items.Add("2022");
            CBAnio.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        void Autocompletar()
        {
            DataTable datos = new DataTable();
            AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
            SqlDataAdapter adaptador  = new SqlDataAdapter("SELECT NroCertificado FROM TCertificadoEmitido", conexion.LeerCadena());
            adaptador.Fill(datos);
            for(int i = 0; i < datos.Rows.Count; i++)
            {
                lista.Add(datos.Rows[i]["NroCertificado"].ToString());
            }
            TBNroCertificado.AutoCompleteCustomSource = lista;
        }

        private void BTBuscar_Click(object sender, EventArgs e)
        {
            ActivarCB();
            try
            {
                if (TBNroCertificado.Text != "")
                {
                    string consulta = "EXEC pBuscarCertificado '" + TBNroCertificado.Text + "'";
                    SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion.LeerCadena());
                    DataTable DT = new DataTable();
                    adaptador.Fill(DT);
                    dataGridView1.DataSource = DT;
                }
                else
                {
                    MessageBox.Show("Ingrese un número de certificado válido");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BMostrarBloque_Click(object sender, EventArgs e)
        {
            ActivarCB();
            try
            {
                if (TBInferior.Text != "" && TBSuperior.Text != "")
                {
                    if (Int32.Parse(TBInferior.Text) > -1 && Int32.Parse(TBSuperior.Text) > -1) {
                        if (Int32.Parse(TBInferior.Text) < Int32.Parse(TBSuperior.Text)) {
                            string consulta = "EXEC pRangoCertificados '" + TBInferior.Text + "','" + TBSuperior.Text + "','" + CBAnio.SelectedItem.ToString() + "'";
                            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion.LeerCadena());
                            DataTable DT = new DataTable();
                            adaptador.Fill(DT);
                            dataGridView1.DataSource = DT;
                        }
                        else
                        {
                            MessageBox.Show("El límite superior debe tener un valor mayor que el límite inferior");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese un rango válido");
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese el límite Inferior y Superior de la búsqueda");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BLimpiar_Click(object sender, EventArgs e)
        {
            TBInferior.Clear();
            TBSuperior.Clear();
            TBNroCertificado.Clear();
            TBNroCertificado.Focus();
            dataGridView1.DataSource = null;
            CBAnio.SelectedIndex = 0;
        }

        public void InsertarCertificadoImpreso2()
        {
            // Crear objeto comando y pasar por parametro el storedprocedure a ejecutar
            // y establecer la conexion con la base de datos
            SqlCommand cmd = new SqlCommand("pInsertarCertificadoImpreso", conexion.LeerCadena());
            cmd.CommandType = CommandType.StoredProcedure;  // establecer el tipo de procedimiento almacenado a ejecutar
            try
            {
                conexion.LeerCadena();                     // abrir conexion                                                                            
                                                           // enviar los datos obtenidos de la capa de negocio a la base de datos
                cmd.Parameters.AddWithValue("@NroCertificado", NroCertificado);
                cmd.Parameters.AddWithValue("@Alumno", Alumno);
                cmd.Parameters.AddWithValue("@Denominacion", Denominacion);
                //cmd.Parameters.AddWithValue("@FechaEmision", FechaEmision);
                cmd.Parameters.Add("@FechaEmision", SqlDbType.Date).Value = FechaEmision;
                cmd.Parameters.AddWithValue("@NroHoras", Int32.Parse(NroHoras));
                cmd.ExecuteNonQuery();
                conexion.LeerCadena();                      // cerrar conexion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void InsertarDetalleImpreso()
        {
            // Crear objeto comando y pasar por parametro el storedprocedure a ejecutar
            // y establecer la conexion con la base de datos
            SqlCommand cmd = new SqlCommand("pInsertarDetalleImpreso", conexion.LeerCadena());
            cmd.CommandType = CommandType.StoredProcedure;                          // establecer el tipo de procedimiento almacenado a ejecutar
            try
            {
                conexion.LeerCadena();         // abrir conexion                                                                            
                                                                 // enviar los datos obtenidos de la capa de negocio a la base de datos
                cmd.Parameters.AddWithValue("@NroCertificado", NroCertificado);
                cmd.Parameters.AddWithValue("@Curso", Curso);
                cmd.Parameters.AddWithValue("@Tema", Tema);
                cmd.Parameters.AddWithValue("@Periodo", Periodo);
                cmd.Parameters.AddWithValue("@Nota", Int32.Parse(Nota));
                cmd.ExecuteNonQuery();
                conexion.LeerCadena();           // cerrar conexion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Flag)
                {

                    VisualizarImpresion Imp = new VisualizarImpresion();

                    //Insertar datos en la tabla TCertificadoImpreso
                    InsertarCertificadoImpreso2();

                    //Insertar datos en la tabla TDetalleImpreso
                    InsertarDetalleImpreso();

                    //Cargar los datos al formulario Visualizar Impresion

                    //Generar la lista de Cursos
                    string filas = string.Empty;
                    int TotalHoras = 0;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (NroCertificado == row.Cells["NroCertificado"].Value.ToString()) { 
                            filas += "<tr>";
                            filas += "<td>" + row.Cells["Curso"].Value.ToString() + "</td>";
                            filas += "<td>" + row.Cells["Tema"].Value.ToString() + "</td>";
                            filas += "<td>" + row.Cells["Nota"].Value.ToString() + "</td>";
                            filas += "<td>" + row.Cells["FechaEmision"].Value.ToString().Substring(0,10) + "</td>";
                            filas += "</tr>";
                            TotalHoras += Int32.Parse(row.Cells["NroHoras"].Value.ToString());
                        }
                    }

                    Imp.CargarDatos(NroCertificado, TotalHoras.ToString(), FechaEmision, Alumno, Curso, Denominacion, Nota, Tema, Tipo, filas);
                    Imp.Show();
                }
                else
                {
                    MessageBox.Show("Seleccione un certificado");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //Al seleccionar un celda tambien se debe de seleccionar el check
                if (e.RowIndex >= 0)
                {
                    //Al seleccionar una fila se autoselecciona el checkbutton y se deseleccionan los otros checkbuttons
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        dataGridView1.Rows[i].Cells[0].Value = false;
                    }
                    // Se inicializan las variables
                    //dataGridView1.Rows[e.RowIndex].Cells[0].Value = true;
                    NroCertificado = dataGridView1.Rows[e.RowIndex].Cells["NroCertificado"].FormattedValue.ToString();
                    NroHoras = dataGridView1.Rows[e.RowIndex].Cells["NroHoras"].FormattedValue.ToString();
                    FechaEmision = dataGridView1.Rows[e.RowIndex].Cells["FechaEmision"].FormattedValue.ToString();
                    Costo = dataGridView1.Rows[e.RowIndex].Cells["Costo"].FormattedValue.ToString();
                    CodAlumno = dataGridView1.Rows[e.RowIndex].Cells["CodAlumno"].FormattedValue.ToString();
                    Alumno = dataGridView1.Rows[e.RowIndex].Cells["Alumno"].FormattedValue.ToString();
                    Periodo = dataGridView1.Rows[e.RowIndex].Cells["Periodo"].FormattedValue.ToString();
                    Anio = dataGridView1.Rows[e.RowIndex].Cells["Año"].FormattedValue.ToString();
                    Curso = dataGridView1.Rows[e.RowIndex].Cells["Curso"].FormattedValue.ToString();
                    Denominacion = dataGridView1.Rows[e.RowIndex].Cells["Denominacion"].FormattedValue.ToString();
                    Nota = dataGridView1.Rows[e.RowIndex].Cells["Nota"].FormattedValue.ToString();
                    Tema = dataGridView1.Rows[e.RowIndex].Cells["Tema"].FormattedValue.ToString();
                    Tipo = dataGridView1.Rows[e.RowIndex].Cells["Tipo"].FormattedValue.ToString();
                    Flag = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        void DesactivarCB()
        {
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                row.Cells[0].ReadOnly = true;
                row.Cells[1].ReadOnly = true;
                row.Cells[2].ReadOnly = true;
                row.Cells[3].ReadOnly = true;
                row.Cells[4].ReadOnly = true;
            }
            this.dataGridView1.Columns[0].Visible = false;
        }

        void ActivarCB()
        {
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                row.Cells[0].ReadOnly = false;
            }
            this.dataGridView1.Columns[0].Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DesactivarCB();
                //this.dataGridView1.Columns[0].Visible = false;
                string consulta = "pListarCertificadoImpreso";
                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion.LeerCadena());
                DataTable DT = new DataTable();
                adaptador.Fill(DT);
                dataGridView1.DataSource = DT;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BDetalleImpreso_Click(object sender, EventArgs e)
        {
            try
            {
                DesactivarCB();
                string consulta = "pListarDetalleImpreso";
                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion.LeerCadena());
                DataTable DT = new DataTable();
                adaptador.Fill(DT);
                dataGridView1.DataSource = DT;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (TBInferior.Text != "" && TBSuperior.Text != "")
                {
                    string consulta = "EXEC pRangoCertificadosFecha '" + TBInferior.Text + "','" + TBSuperior.Text + "','" + CBAnio.SelectedItem.ToString() + "','" + this.dateTimePicker1.Text + "'";
                    SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion.LeerCadena());
                    DataTable DT = new DataTable();
                    adaptador.Fill(DT);
                    dataGridView1.DataSource = DT;
                }
                else
                {
                    MessageBox.Show("Ingrese el límite Inferior y Superior de la búsqueda");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TBCodigo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
