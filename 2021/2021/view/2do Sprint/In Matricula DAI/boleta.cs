using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace _2021
{
    public partial class btnBoleta : Form
    {
        CE_Estudiante2sprint oEnt = new CE_Estudiante2sprint();
        CN_Estudiante2sprint oNeg = new CN_Estudiante2sprint();
        CE_Boleta2sprint oEntB = new CE_Boleta2sprint();
        CN_Boleta2sprint oNegB = new CN_Boleta2sprint();

        public btnBoleta()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void boleta_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            RelacionCurso RelacionCurso = new RelacionCurso();
            RelacionCurso.Show();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GuardarB();
        }
        void mantenimientoB(String accion)
        {
            oEntB.NroBoleta = txtNroBoleta.Text;
            oEntB.NroSerie = txtNroSerie.Text;
            oEntB.Costo=txtCosto.Text;
            oEntB.Pago =cmbPago.Text;
            oEntB.CodCursoActivo = txtCodigoCursoBoleta.Text;
            oEntB.CodEstudiante = txtCodigo.Text;
            oEntB.Observacion = cmbObservacion.Text;

            oEntB.accion = accion;
            String men = oNegB.N_Mantenimiento_BoletadeMatricula(oEntB);
            MessageBox.Show(men, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        void mantenimiento(String accion)
        {
            oEnt.CodEstudiante = txtCodigo.Text;
            oEnt.Nombre = txtNombre.Text;
            oEnt.ApPaterno =txtAP.Text;
            oEnt.ApMaterno = txtAM.Text;
            oEnt.TipoDocumento = txtDocumento.Text;
            oEnt.Email = txtEmail.Text;
            oEnt.Sexo = cmbSexo.Text;
            oEnt.accion = accion;
            String men = oNeg.N_Insertar_EstudianteMatriculado(oEnt);
            MessageBox.Show(men, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        void limpiarB()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtAP.Text = "";
            txtAM.Text = "";
            txtDocumento.Text = "";
            txtEmail.Text = "";
            cmbSexo.Text = "";

            txtNroBoleta.Text = "";
            txtNroSerie.Text="";
            txtCosto.Text = "";
            cmbPago.Text = "";
            txtCodigoCursoBoleta.Text = "";
            cmbObservacion.Text = "";

            dgvAlumno.DataSource = oNegB.N_Listar_Boleta();
        }
        void limpiar()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtAP.Text = "";
            txtAM.Text = "";
            txtDocumento.Text = "";
            txtEmail.Text = "";
            cmbSexo.Text = "";
            dgvAlumno.DataSource = oNeg.N_listar_Alumnos();
        }
        public void GuardarB()
        {
            if (txtNroBoleta.Text == "")
            {
                if (MessageBox.Show("¿Deseas Registrar " + txtNroBoleta.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimientoB("1");
                    limpiarB();
                }
            }

        }
        public void Guardar()
        {
            if (txtCodigo.Text == "")
            {
                if (MessageBox.Show("¿Deseas Registrar " + txtCodigo.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("1");
                    limpiar();
                }
            }

        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dgvAlumno.CurrentCell.RowIndex;

            txtCodigo.Text = dgvAlumno[0, fila].Value.ToString();
            txtNombre.Text = dgvAlumno[1, fila].Value.ToString();
            txtAP.Text = dgvAlumno[2, fila].Value.ToString();
            txtAM.Text = dgvAlumno[3, fila].Value.ToString();
            txtDocumento.Text = dgvAlumno[4, fila].Value.ToString();
            txtEmail.Text = dgvAlumno[5, fila].Value.ToString();
            cmbSexo.Text = dgvAlumno[6, fila].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

            if (txtCodigo.Text != "")
            {
                oEnt.CodEstudiante = txtCodigo.Text;
                DataTable DT = new DataTable();
                DT = oNeg.N_Buscar_EstudianteMatriculadoC(oEnt);
                dgvAlumno.DataSource = DT;
            }
            else
            {
                dgvAlumno.DataSource = oNeg.N_listar_Alumnos();
            }
        }

        private void txtAP_TextChanged(object sender, EventArgs e)
        {
            if (txtAP.Text != "")
            {
                oEnt.ApPaterno = txtAP.Text;
                DataTable DT = new DataTable();
                DT = oNeg.N_Buscar_EstudianteMatriculadoAP(oEnt);
                dgvAlumno.DataSource = DT;
            }
            else
            {
                dgvAlumno.DataSource = oNeg.N_listar_Alumnos();
            }
        }

        private void txtAM_TextChanged(object sender, EventArgs e)
        {
            if (txtAM.Text != "")
            {
                oEnt.ApMaterno = txtAM.Text;
                DataTable DT = new DataTable();
                DT = oNeg.N_Buscar_EstudianteMatriculadoAM(oEnt);
                dgvAlumno.DataSource = DT;
            }
            else
            {
                dgvAlumno.DataSource = oNeg.N_listar_Alumnos();
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text != "")
            {
                oEnt.Nombre = txtNombre.Text;
                DataTable DT = new DataTable();
                DT = oNeg.N_Buscar_EstudianteMatriculadoN(oEnt);
                dgvAlumno.DataSource = DT;
            }
            else
            {
                dgvAlumno.DataSource = oNeg.N_listar_Alumnos();
            }

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            dgvAlumno.DataSource = oNeg.N_listar_Alumnos();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            limpiarB();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
            dgvBoleta.DataSource = oNegB.N_Listar_Boleta();
        }
    }
}
