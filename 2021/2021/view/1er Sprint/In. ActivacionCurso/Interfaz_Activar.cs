using System;
using System.Data;
using System.Windows.Forms;
//activamos referencias que necesitamos en esta capa
using System.Data.SqlClient;

namespace _2021
{
    public partial class Interfaz_Activar : Form
    {
        conexion conexion = new conexion();
        public Interfaz_Activar()
        {
            InitializeComponent();
            Autocompletar();
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void ActualizarActivar()
        {
            string consulta2 = "exec pActulizarEstado '" + TBCodigo.Text + "', 'ACTIVADO'";      ///   ACTUALIZAR
            SqlDataAdapter adaptador2 = new SqlDataAdapter(consulta2, conexion.LeerCadena());
            DataTable DT2 = new DataTable();
            adaptador2.Fill(DT2);
            dataGridView1.DataSource = DT2;
        }
        public bool NoExiste(string pcodigo)
        {
            string sql = @"SELECT COUNT(*) FROM TCursoActivo WHERE Codigo_CursoActivo = @Codigo";
            {
                SqlCommand cmd = new SqlCommand(sql, conexion.LeerCadena());
                cmd.Parameters.AddWithValue("@Codigo", pcodigo);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                conexion.LeerCadena();
                return count == 0;
            }
        }

        private void BActivar_Click(object sender, EventArgs e)
        {
            try
            {
                if (NoExiste(TBCodigo.Text))
                {
                    if (Int32.Parse(CBHora1.Text) < Int32.Parse(CBHora2.Text))
                    {
                        //MODIFICACION
                        // Crear objeto comando y pasar por parametro el storedprocedure a ejecutar
                        // y establecer la conexion con la base de datos
                        string Horario = CBHora1.Text.ToString() + "-" + CBHora2.Text.ToString();

                        SqlCommand cmd = new SqlCommand("pInsertarCursoActivo", conexion.LeerCadena());
                        cmd.CommandType = CommandType.StoredProcedure;  // establecer el tipo de procedimiento almacenado a ejecutar
                                                                        // enviar los datos obtenidos de la capa de negocio a la base de datos
                        cmd.Parameters.AddWithValue("@Codigo_CursoActivo", TBCodigo.Text.ToString());
                        cmd.Parameters.AddWithValue("@Grupo", CBGrupo.Text.ToString());
                        cmd.Parameters.AddWithValue("@Nombre", TBNombre.Text.ToString());
                        cmd.Parameters.AddWithValue("@Tema", TBTema.Text.ToString());
                        cmd.Parameters.AddWithValue("@Tipo", TBTipo.Text.ToString());
                        cmd.Parameters.AddWithValue("@HorasxSemana", Int32.Parse(TBHorasxSemana.Text));
                        cmd.Parameters.AddWithValue("@Dias", CBDia.Text.ToString());
                        cmd.Parameters.AddWithValue("@Hora", Horario);
                        cmd.Parameters.AddWithValue("@Periodo", CBPeriodo.Text.ToString());
                        cmd.Parameters.AddWithValue("@Año", CBAnio.Text.ToString());
                        cmd.ExecuteNonQuery();

                        //Segunda consulta
                        MessageBox.Show("Curso ACTIVADO Exitosamente");
                        //Completar TextBox con datos de curso
                        ActualizarActivar();
                        if (RBCodigo.Checked == true)
                        {
                            CompletarTextBoxCodigo();
                        }
                        else
                        {
                            CompletarTextBoxNombre();
                        }
                        //Completar lista de alumnos
                        conexion.LeerCadena();
                    }
                    else
                    {
                        MessageBox.Show("Seleccione un rango de horas válido!");
                    }
                }
                else
                {
                    MessageBox.Show("El curso ya fue activado");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void CompletarTextBoxCodigo()
        {
            //conexion conexion = new conexion();
            string consulta2 = "exec pRecuperarCursoCodigo'" + TBBuscar.Text + "'";
            SqlCommand comando = new SqlCommand(consulta2, conexion.LeerCadena());
            SqlDataReader lector;
            lector = comando.ExecuteReader();

            if (lector.Read())
            {
                CompletarCampos(lector);
            }
            conexion.LeerCadena();
        }

        public void CompletarTextBoxNombre()
        {
            conexion.LeerCadena();
            string consulta2 = "exec pRecuperarCursoNombre'" + TBBuscar.Text + "'";
            SqlCommand comando = new SqlCommand(consulta2, conexion.LeerCadena());
            SqlDataReader lector;
            lector = comando.ExecuteReader();
            if (lector.Read())
            {
                CompletarCampos(lector);
            }
            conexion.LeerCadena();
        }

        public void CompletarCampos(SqlDataReader lector)
        {
            TBCodigo.Text = lector["Codigo_Curso"].ToString();
            TBNombre.Text = lector["Nombre_Curso"].ToString();
            TBTipo.Text = lector["Tipo_Curso"].ToString();
            TBEstado.Text = lector["Estado"].ToString();
            TBHorasxSemana.Text = lector["HorasxSemana"].ToString();
            TBTema.Text = lector["Temas"].ToString();
        }
        private void BDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                //Consulta en base de datos
                string consulta = "exec pActulizarEstado '" + TBCodigo.Text + "', 'DESACTIVADO'";  /// ACTUALIZAR FORNA DE ACCESO A SQL SERVER
                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion.LeerCadena());
                DataTable DT = new DataTable();
                adaptador.Fill(DT);
                dataGridView1.DataSource = DT;
                MessageBox.Show("Curso DESACTIVADO Exitosamente");

                //Completar TextBox con datos de curso
                if (RBCodigo.Checked == true)
                {
                    CompletarTextBoxCodigo();
                }
                else
                {
                    CompletarTextBoxNombre();
                }

                //Completar lista de alumnos
                DesabilitarCursoActivado(TBCodigo.Text.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        void DesabilitarCursoActivado(string pcodigo)
        {
            // Crear objeto comando y pasar por parametro el storedprocedure a ejecutar
            SqlCommand cmd = new SqlCommand("pEliminarCursoDesabilitado", conexion.LeerCadena());
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conexion.LeerCadena();                                                   // abrir conexion                                                                            
                cmd.Parameters.AddWithValue("@Codigo_CursoActivo", pcodigo);          // enviar los datos obtenidos de la capa de negocio a la base de datos
                cmd.ExecuteNonQuery();
                conexion.LeerCadena();                                                 // cerrar conexion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void BCActivados_Click(object sender, EventArgs e)
        {
            try
            {
                Limpiar_Campos();
                //Consulta en base de datos
                string consulta = "select * from TCursoActivo";  /// ACTUALIZAR A MODULO
                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion.LeerCadena());
                DataTable DT = new DataTable();
                adaptador.Fill(DT);
                dataGridView1.DataSource = DT;
                conexion.LeerCadena();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void Limpiar_Campos()
        {
            TBNombre.Clear();
            TBCodigo.Clear();
            TBTema.Clear();
            TBTipo.Clear();
            TBEstado.Clear();
            TBHorasxSemana.Clear();
            TBBuscar.Clear();
            TBBuscar.Focus();
            dataGridView1.DataSource = null;

            CBDia.SelectedIndex = 0;
            CBPeriodo.SelectedIndex = 0;
            CBAnio.SelectedIndex = 0;
            CBGrupo.SelectedIndex = 0;

        }

        private void BCDesactivados_Click(object sender, EventArgs e)
        {
            try
            {
                Limpiar_Campos();
                //Consulta en base de datos
                string consulta = "exec pListarCursos 'DESACTIVADO'";   /// ACTUALIZAR A MODULO
                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, conexion.LeerCadena());
                DataTable DT = new DataTable();
                adaptador.Fill(DT);
                dataGridView1.DataSource = DT;
                conexion.LeerCadena();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        void Autocompletar()
        {
            DataTable datos = new DataTable();
            AutoCompleteStringCollection lista = new AutoCompleteStringCollection();
            SqlDataAdapter adaptador = new SqlDataAdapter("SELECT Codigo_Curso, Nombre_Curso FROM TCurso", conexion.LeerCadena());
            adaptador.Fill(datos);
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                lista.Add(datos.Rows[i]["Codigo_Curso"].ToString());
            }
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                lista.Add(datos.Rows[i]["Nombre_Curso"].ToString());
            }
            TBBuscar.AutoCompleteCustomSource = lista;
        }

        private void BBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Operaciones operaciones = new Operaciones();
                if (TBBuscar.Text != "")
                {
                    if (RBCodigo.Checked == true)
                    {

                        //Completar TextBox con datos de curso
                        CompletarTextBoxCodigo();
                        //Completar lista de alumnos
                        
                    }
                    else
                    {
                        if (RBNombre.Checked == true)
                        {

                            //Completar TextBox con datos de curso
                            CompletarTextBoxNombre();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Complete el campo de búsqueda");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar_Campos();
        }

        private void TBNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void Interfaz_Activar_Load(object sender, EventArgs e)
        {
            CBGrupo.DropDownStyle = ComboBoxStyle.DropDownList;

            //Inicializar combobox grupo
            CBGrupo.Items.Add("A");
            CBGrupo.Items.Add("B");
            CBGrupo.Items.Add("C");
            CBGrupo.SelectedIndex = 0;

            //ComboBox periodo
            CBPeriodo.Items.Add("Enero");
            CBPeriodo.Items.Add("Febrero");
            CBPeriodo.Items.Add("Marzo");
            CBPeriodo.Items.Add("Abril");
            CBPeriodo.Items.Add("Mayo");
            CBPeriodo.Items.Add("Junio");
            CBPeriodo.Items.Add("Julio");
            CBPeriodo.Items.Add("Agosto");
            CBPeriodo.Items.Add("Setiembre");
            CBPeriodo.Items.Add("Octubre");
            CBPeriodo.Items.Add("Noviembre");
            CBPeriodo.Items.Add("Diciembre");
            CBPeriodo.SelectedIndex = 0;

            //ComboBox Año
            CBAnio.Items.Add("2022");
            CBAnio.Items.Add("2021");
            CBAnio.Items.Add("2020");
            CBAnio.Items.Add("2019");
            CBAnio.Items.Add("2018");
            CBAnio.SelectedIndex = 0;

            //ComboBox Dia
            CBDia.Items.Add("Lunes");
            CBDia.Items.Add("Martes");
            CBDia.Items.Add("Miercoles");
            CBDia.Items.Add("Jueves");
            CBDia.Items.Add("Viernes");
            CBDia.Items.Add("Sabado");
            CBDia.SelectedIndex = 0;

            //ComboBox Horarios
            CBHora1.Items.Add("07");
            CBHora1.Items.Add("08");
            CBHora1.Items.Add("09");
            CBHora1.Items.Add("10");
            CBHora1.Items.Add("11");
            CBHora1.Items.Add("12");
            CBHora1.Items.Add("13");
            CBHora1.Items.Add("14");
            CBHora1.Items.Add("15");
            CBHora1.Items.Add("16");
            CBHora1.Items.Add("17");
            CBHora1.Items.Add("18");
            CBHora1.Items.Add("19");
            CBHora1.Items.Add("20");
            CBHora1.SelectedIndex = 0;

            CBHora2.Items.Add("08");
            CBHora2.Items.Add("09");
            CBHora2.Items.Add("10");
            CBHora2.Items.Add("11");
            CBHora2.Items.Add("12");
            CBHora2.Items.Add("13");
            CBHora2.Items.Add("14");
            CBHora2.Items.Add("15");
            CBHora2.Items.Add("16");
            CBHora2.Items.Add("17");
            CBHora2.Items.Add("18");
            CBHora2.Items.Add("19");
            CBHora2.Items.Add("20");
            CBHora2.Items.Add("21");
            CBHora2.SelectedIndex = 0;

            RBCodigo.Checked = true;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
