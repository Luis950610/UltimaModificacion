using System;
using System.Windows.Forms;
//using CapaNegocios;

namespace _2021
{
    public partial class CambioGrupo : Form
    {

        /*Atributos*/
        private string aCodCurso;
        private string aGrupo;
        private CN_CambioGrupo objetoCN_CambioGrupo = new CN_CambioGrupo();

        public CambioGrupo()
        {
            InitializeComponent();
            //Se inicializa los atributos con valores nulos


            refreshDataGridView1();
            refreshDataGridView2();
        }

        /*Modulo para refrescar los datagridviews*/
        public void refreshDataGridView1()
        {
            // Cargar al data gridview los cursos que no fueron asignados
            dataGridView1.DataSource = objetoCN_CambioGrupo.MostrarBuscarCursosxTodosLosCamposxCategorias(cbTipo1.Text, cbPeriodo1.Text, cbAño1.Text);

            // Cargar al data gridview los cursos que no fueron asignados
            dataGridView2.DataSource = objetoCN_CambioGrupo.MostrarBuscarCursosxTodosLosCamposxCategorias(cbTipo2.Text, cbPeriodo2.Text, cbAño2.Text);

        }

        /*Modulo para refrescar los datagridviews*/
        public void refreshDataGridView2()
        {
            // Cargar al data gridview los cursoS
            dataGridView2.DataSource = objetoCN_CambioGrupo.MostrarBuscarCursosxTodosLosCamposxCategorias(cbTipo2.Text, cbPeriodo2.Text, cbAño2.Text);

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        //al cambiar el valor del combobox se debe de refrescar la tabla
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(comboBox1.Text + comboBox3.Text + comboBox2.Text);
            dataGridView1.DataSource = objetoCN_CambioGrupo.MostrarBuscarCursosxTodosLosCamposxCategorias(cbTipo1.Text, cbPeriodo1.Text, cbAño1.Text);
            errorProvider1.Clear();


            //refreshDataGridView1();
        }

        //Al cambiar el valor del combobox Año se refresaca la tabla
        
        public Boolean VerificarCambio()
        {

            Boolean Valido = true;


            if (!ValidarComboBox(cbTipo1, cbTipo2, "tipo"))
                Valido = false;
            if (!ValidarComboBox(cbAño1, cbAño2, "año"))
                Valido = false;
            if (!ValidarComboBox(cbPeriodo1, cbPeriodo2, "periodo"))
                Valido = false;
            if (dataGridView1.CurrentCell == null)
            {
                //if (string.IsNullOrEmpty(cb2.Text.Trim()))
                {
                    errorProvider1.SetError(dataGridView1, "No se eligio un curso");
                    Valido = false;
                }
            }
            if (dataGridView2.CurrentCell == null)
            {
                //if (string.IsNullOrEmpty(cb2.Text.Trim()))
                {
                    errorProvider1.SetError(dataGridView2, "No se eligio un curso");
                    Valido = false;
                }
            }

            return Valido;
        }
        public Boolean ValidarComboBox(ComboBox cb1, ComboBox cb2, string Texto)
        {
            bool Valido = true;
            if (cb1.Text != cb2.Text)
            {
                //if (string.IsNullOrEmpty(cb2.Text.Trim()))
                {
                    errorProvider1.SetError(cb1, "El " + Texto + " es diferente");
                    errorProvider1.SetError(cb2, "El " + Texto + " es diferente");
                    Valido = false;
                }
            }
            else
            {
                errorProvider1.SetError(cb1, "");
            }
            return Valido;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

            //MessageBox.Show(comboBox1.Text + comboBox3.Text + comboBox2.Text);
            dataGridView2.DataSource = objetoCN_CambioGrupo.MostrarBuscarCursosxTodosLosCamposxCategorias(cbTipo2.Text, cbPeriodo2.Text, cbAño2.Text);
            errorProvider1.Clear();

            //
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Al seleccionar un celda tambien se debe de seleccionar el check
            errorProvider1.Clear();
            if (e.RowIndex >= 0)
            {
                //Al seleccionar una fila se autoselecciona el checkbutton y se deseleccionan los otros checkbuttons

                // Se inicializan las variables 


                int fila = dataGridView1.CurrentRow.Index;//.CurrentCell.RowIndex;

                aCodCurso = dataGridView1[0, fila].Value.ToString();

                //================================================================
                // Cargar al data gridview los alumnos del curso seleccionado
                dataGridView3.DataSource = objetoCN_CambioGrupo.MostrarAlumnosxCurso(cbTipo1.Text, cbPeriodo1.Text, cbAño1.Text, aCodCurso);// 
                for (int i = 0; i < dataGridView3.RowCount; i++)
                {
                    dataGridView3.Rows[i].Cells[0].Value = false;
                }
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Al seleccionar un celda tambien se debe de seleccionar el check
            errorProvider1.Clear();
            if (e.RowIndex >= 0)
            {
                //Al seleccionar una fila se autoselecciona el checkbutton y se deseleccionan los otros checkbuttons

                // Se inicializan las variables 


                int fila = dataGridView2.CurrentRow.Index;//.CurrentCell.RowIndex;

                aCodCurso = dataGridView2[0, fila].Value.ToString();

                //================================================================
                // Cargar al data gridview los alumnos del curso seleccionado
                dataGridView4.DataSource = objetoCN_CambioGrupo.MostrarAlumnosxCurso(cbTipo2.Text, cbPeriodo2.Text, cbAño2.Text, aCodCurso);// 
                for (int i = 0; i < dataGridView4.RowCount; i++)
                {
                    dataGridView4.Rows[i].Cells[0].Value = false;
                }
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Al seleccionar un celda tambien se debe de seleccionar el check

            if (e.RowIndex >= 0)
            {


                int fila = dataGridView3.CurrentCell.RowIndex;

                if (dataGridView3.Rows[fila].Cells[0].Value == null || dataGridView3.Rows[fila].Cells[0].Value.Equals(false))
                    dataGridView3.Rows[fila].Cells[0].Value = true;
                else
                    dataGridView3.Rows[fila].Cells[0].Value = false;

            }
            errorProvider1.Clear();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string aNCodCurso = "";
            if (VerificarCambio())
            {
                int fila = dataGridView1.CurrentCell.RowIndex;
                int Nfila = dataGridView2.CurrentCell.RowIndex;
                if (dataGridView1[1, fila].Value.ToString() == dataGridView2[1, Nfila].Value.ToString())
                {

                    aCodCurso = dataGridView1[0, fila].Value.ToString();
                    aNCodCurso = dataGridView2[0, Nfila].Value.ToString();
                    aGrupo = dataGridView2[2, Nfila].Value.ToString();
                    int k = 0;
                    for (int i = 0; i < dataGridView3.RowCount; i++)
                    {

                        //MessageBox.Show("bbbb" + dataGridView3[0, i].Value.ToString());
                        if ((dataGridView3[0, i].Value != null) && (dataGridView3[0, i].Value.ToString() == "True"))
                        {
                            k++;
                            dataGridView4.DataSource = objetoCN_CambioGrupo.CambioGrupo(aCodCurso, aNCodCurso, aGrupo, dataGridView3[1, i].Value.ToString());

                        }
                    }
                    if (k == 0)
                        errorProvider1.SetError(buCambioGrupo, "No se eligio ningun alumno");

                    dataGridView3.DataSource = objetoCN_CambioGrupo.MostrarAlumnosxCurso(cbTipo1.Text, cbPeriodo1.Text, cbAño1.Text, aCodCurso);
                    dataGridView4.DataSource = objetoCN_CambioGrupo.MostrarAlumnosxCurso(cbTipo1.Text, cbPeriodo1.Text, cbAño1.Text, aNCodCurso);
                    // Se inicializan las variables
                }
                else
                {
                    errorProvider1.SetError(dataGridView1, "No se eligio el mismo curso");
                    errorProvider1.SetError(dataGridView2, "No se eligio el mismo curso");
                }
            }
        }

        private void CambioGrupo_Load(object sender, EventArgs e)
        {

        }

        private void Salir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

}
