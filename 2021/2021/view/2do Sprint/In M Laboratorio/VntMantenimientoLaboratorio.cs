using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace _2021
{
    public partial class VntMantenimientoLaboratorio : Form
    {

        CN_MantLabo objetoCN_MntLab = new CN_MantLabo();
        CN_MantLabo N_MntLab = new CN_MantLabo();
        CE_MantLabo E_MntLab = new CE_MantLabo();

        public VntMantenimientoLaboratorio()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        void Limpiar_Datos()
        {

            textCodLab.Text = "";
            textNombre.Text = "";
            textCapac.Text = "";
            textUbic.Text = "";      
            textBuscxCod.Text = "";
            cmbModalidad.Text = "";
            textSala.Text = "";
            textBuscxNomb.Text = "";
            dataGridView1.DataSource = objetoCN_MntLab.N_Listar_Laboratorios();
        } 
        void Mantenimiento_Laboratorio(String accion)
        {

            E_MntLab.CodLaboratorio = textCodLab.Text;
            E_MntLab.Nombre = textNombre.Text;
            E_MntLab.Capacidad = int.Parse(textCapac.Text);
            E_MntLab.Ubicacion = textUbic.Text;
            E_MntLab.Modalidad = cmbModalidad.Text;
            E_MntLab.Sala = textSala.Text;
            E_MntLab.Accion = accion;

            String men = N_MntLab.N_Mantenimiento_Laboratorio(E_MntLab);
            MessageBox.Show(men, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_2(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int fila = dataGridView1.CurrentCell.RowIndex;

            textCodLab.Text = dataGridView1[0, fila].Value.ToString();
            textNombre.Text = dataGridView1[1, fila].Value.ToString();
            textCapac.Text = dataGridView1[2, fila].Value.ToString();
            textUbic.Text = dataGridView1[3, fila].Value.ToString();
            cmbModalidad.Text = dataGridView1[4, fila].Value.ToString();
            textSala.Text = dataGridView1[5, fila].Value.ToString();
            //textBuscxCod.Text = dataGridView1[4, fila].Value.ToString();

        }

        private void DateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar_Datos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (textCodLab.Text != "" && textNombre.Text != ""
                && textCapac.Text != "" && textUbic.Text != ""
                && cmbModalidad.Text != "" && textSala.Text != ""
                )
            {
                if (MessageBox.Show("¿Deseas modificar a " + textNombre.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    Mantenimiento_Laboratorio("2");
                    Limpiar_Datos();
                }
            }
            else { MessageBox.Show("Todos los campos deben completarse", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

        }

        private void textNombre_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textCapac_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Por favor, solo ingrese numeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }


        private void textNombre_TextChanged(object sender, EventArgs e)
        {

        }
            
        private void VntMantenimientoLaboratorio_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'db_BDmantenimientolaboDataSet.SP_Listar_Laboratorios' Puede moverla o quitarla según sea necesario.
            //this.sP_Listar_LaboratoriosTableAdapter.Fill(this.db_BDmantenimientolaboDataSet.SP_Listar_Laboratorios);
            dataGridView1.DataSource = objetoCN_MntLab.N_Listar_Laboratorios();
            cmbModalidad.Items.Add("VIRTUAL");
            cmbModalidad.Items.Add("PRESENCIAL");
            cmbModalidad.Items.Add("SEMIPRESENCIAL");
        }

        private void BntEliminar_Click(object sender, EventArgs e)
        {
            if (textCodLab.Text != "" && textNombre.Text != ""
                && textCapac.Text != "" && textUbic.Text != ""
                && cmbModalidad.Text != "" && textSala.Text != ""
               )
            {
                if (MessageBox.Show("¿Esta seguro de eliminar a " + textNombre.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    Mantenimiento_Laboratorio("3");
                    Limpiar_Datos();
                }
            }
            else { MessageBox.Show("Todos los campos deben completarse", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void TextBuscxCod_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextCapac_TextChanged(object sender, EventArgs e)
        {

        }

        private void BntGuardar_Click(object sender, EventArgs e)
        {
            if (textCodLab.Text != "" && textNombre.Text != "" 
                && textCapac.Text != "" && textUbic.Text != ""
                && cmbModalidad.Text != "" && textSala.Text != ""
               )
            {
                if (MessageBox.Show("¿Deseas agregar a " + textNombre.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    Mantenimiento_Laboratorio("1");
                    Limpiar_Datos();
                }
            }
            else { MessageBox.Show("Todos los campos deben completarse", "Error", 
                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }

        private void BtnBuscarxCod_Click(object sender, EventArgs e)
        {
            if (textBuscxCod.Text != "")
            {
                E_MntLab.CodLaboratorio = textBuscxCod.Text;
                DataTable DT = new DataTable();
                DT = N_MntLab.N_Buscar_LaboratorioxCod(E_MntLab);
                if (DT.Rows.Count > 0)
                {
                    dataGridView1.DataSource = DT;
                    int fila = dataGridView1.CurrentCell.RowIndex;

                    textCodLab.Text = dataGridView1[0, fila].Value.ToString();
                    textNombre.Text = dataGridView1[1, fila].Value.ToString();
                    textCapac.Text = dataGridView1[2, fila].Value.ToString();
                    textUbic.Text = dataGridView1[3, fila].Value.ToString();
                    cmbModalidad.Text = dataGridView1[4, fila].Value.ToString();
                    textSala.Text = dataGridView1[5, fila].Value.ToString();
                }
                else
                {
                    MessageBox.Show("El laboratorio " + textBuscxCod.Text + " no ha sido registrado", "Error",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                dataGridView1.DataSource = objetoCN_MntLab.N_Listar_Laboratorios();
            }
        }

        private void TextCodLab_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void TextCodLab_Enter(object sender, EventArgs e)
        {
           
        }

        private void TextCodLab_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void TextCodLab_CursorChanged(object sender, EventArgs e)
        {

        }

        private void TextCodLab_Leave(object sender, EventArgs e)
        {
            if (textCodLab.Text != "")
            {
                E_MntLab.CodLaboratorio = textCodLab.Text;
                DataTable DT = new DataTable();
                DT = N_MntLab.N_Buscar_LaboratorioxCod(E_MntLab);
                if (DT.Rows.Count > 0)
                {

                    MessageBox.Show("El codigo " + textCodLab.Text + " ya fue registrado", "Alerta",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textCodLab.Text = "";
                }
                else
                {                   
                    dataGridView1.DataSource = objetoCN_MntLab.N_Listar_Laboratorios();
                }
            }
        }

        private void TextNombre_Leave(object sender, EventArgs e)
        {
            if (textNombre.Text != "")
            {
                E_MntLab.Nombre = textNombre.Text;
                DataTable DT = new DataTable();
                DT = N_MntLab.N_Buscar_LaboratorioxNomb(E_MntLab);
                if (DT.Rows.Count > 0)
                {
                    MessageBox.Show("El laboratorio " + textNombre.Text + " ya fue registrado", "Alerta",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textNombre.Text = "";
                }
                else
                {
                    dataGridView1.DataSource = objetoCN_MntLab.N_Listar_Laboratorios();
                }
            }
        }

        private void TextUbic_Leave(object sender, EventArgs e)
        {
            if (cmbModalidad.Text != "")
            {
                if (cmbModalidad.Text == "VIRTUAL")
                {
                    MessageBox.Show("La modalidad ha sido seleccionado como Virtual", "Alerta",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textUbic.Text = "--";
                }
                else
                {
                    dataGridView1.DataSource = objetoCN_MntLab.N_Listar_Laboratorios();
                }
            }
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnBuscarxNomb_Click(object sender, EventArgs e)
        {
            if (textBuscxNomb.Text != "")
            {
                E_MntLab.Nombre = textBuscxNomb.Text;
                DataTable DT = new DataTable();
                DT = N_MntLab.N_Buscar_LaboratorioxNomb(E_MntLab);
                if (DT.Rows.Count > 0)
                {
                    dataGridView1.DataSource = DT;
                    int fila = dataGridView1.CurrentCell.RowIndex;

                    textCodLab.Text = dataGridView1[0, fila].Value.ToString();
                    textNombre.Text = dataGridView1[1, fila].Value.ToString();
                    textCapac.Text = dataGridView1[2, fila].Value.ToString();
                    textUbic.Text = dataGridView1[3, fila].Value.ToString();
                    cmbModalidad.Text = dataGridView1[4, fila].Value.ToString();
                    textSala.Text = dataGridView1[5, fila].Value.ToString();
                }
                else
                {
                    MessageBox.Show("El laboratorio con nombre " + textBuscxNomb.Text + " no ha sido registrado", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                dataGridView1.DataSource = objetoCN_MntLab.N_Listar_Laboratorios();
            }
        }

        private void textModalidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void textSala_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label3_Click_1(object sender, EventArgs e)
        {

        }

        private void CmbModalidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void CmbModalidad_Leave(object sender, EventArgs e)
        {
            if (cmbModalidad.Text != "")
            {
                if (cmbModalidad.Text != "VIRTUAL" && cmbModalidad.Text != "PRESENCIAL"
                   && cmbModalidad.Text != "SEMIPRESENCIAL")
                {
                    MessageBox.Show("Modalidad entre la opciones", "Alerta",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cmbModalidad.Text = "";
                }
                else
                {
                    dataGridView1.DataSource = objetoCN_MntLab.N_Listar_Laboratorios();
                }
            }
        }

        private void TextSala_Click(object sender, EventArgs e)
        {
            
        }

        private void TextSala_Leave(object sender, EventArgs e)
        {
            if (cmbModalidad.Text != "")
            {
                if (cmbModalidad.Text == "PRESENCIAL")
                {
                    MessageBox.Show("La modalidad ha sido seleccionado como Presencial", "Alerta",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textSala.Text = "--";
                }
                else
                {
                    dataGridView1.DataSource = objetoCN_MntLab.N_Listar_Laboratorios();
                }
            }
        }

        private void TextUbic_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

