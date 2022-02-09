using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Windows.Forms;


namespace _2021
{
    public partial class FormMantenimientoPaquete : Form
    {
        // ==================================================================================================
        // Variables globales
        // ==================================================================================================
        NPaquete objPaquete_N = new NPaquete();
        NCurso objCurso_N = new NCurso();
        EPaquete objPaquete_E;
        bool Modificar = false;

        public FormMantenimientoPaquete()
        {
            InitializeComponent();
        }
        private void FormMantenimientoPaquete_Load(object sender, EventArgs e)
        {
            btnGuardarCambios.Visible = false;
            Listar_Cursos();
            Listar_Paquetes();
        }
        // ==================================================================================================
        // ================================== MOSTRAR REGISTROS =============================================
        // ==================================================================================================
        public void Listar_Cursos()
        {
            DataTable dt = new DataTable();
            dt = objCurso_N.N_listar_mCurso();
            dataGridViewCursos.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridViewCursos.Rows.Add();
                dataGridViewCursos.Rows[n].Cells[0].Value = false;
                dataGridViewCursos.Rows[n].Cells[1].Value = item["Codigo_Curso"].ToString();
                dataGridViewCursos.Rows[n].Cells[2].Value = item["Nombre_Curso"].ToString();
                dataGridViewCursos.Rows[n].Cells[3].Value = item["Tipo_Curso"].ToString();
                dataGridViewCursos.Rows[n].Cells[4].Value = item["Temas"].ToString();
                //dataGridViewCursos.Rows[n].Cells[5].Value = item["Grupo"].ToString();
                dataGridViewCursos.Rows[n].Cells[5].Value = item["HorasxSemana"].ToString();
                //dataGridViewCursos.Rows[n].Cells[6].Value = item["Estado"].ToString();
                //dataGridViewCursos.Rows[n].Cells[8].Value = item["Horario"].ToString();
            }
        }
        public void Listar_Paquetes()
        {
            btnGuardarCambios.Visible = false;
            dataGridViewPaquete.DataSource = objPaquete_N.Mostrar_Paquetes();
            dataGridViewPaquete.Columns[0].Visible = false;
        }
        public void Listar_Detalle_Paquete()
        {
            if (Modificar == true)
                btnGuardarCambios.Visible = true;
            else
                btnGuardarCambios.Visible = false;
            if (dataGridViewPaquete.SelectedRows.Count > 0)
                dataGridViewDetalle.DataSource = objPaquete_N.Mostrar_Detalle_Paquete(dataGridViewPaquete.CurrentRow.Cells["Codigo_Paquete"].Value.ToString());
            else
                MessageBox.Show("seleccione una fila de la lista de paquetes", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
           
        }
        // ==================================================================================================
        // ================================== PROGRAMACION DE BOTONES =======================================
        // ==================================================================================================
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Modificar = false;
            
            //btnGuardarCambios.Visible = false;            
            objPaquete_E = new EPaquete();
            int nro_cursos_seleccionados = 0;
            int k = 0;
            string[] Cod_Cursos = new string[100];
            if (Modificar == false)
            {
                dataGridViewDetalle.DataSource = null;
                try
                {
                    foreach (DataGridViewRow item in dataGridViewCursos.Rows)
                    {
                        if ((bool)item.Cells[0].Value == true)
                        {
                            //extraer los codigos de cada fila
                            if (nro_cursos_seleccionados == 0)
                            {
                                Cod_Cursos[k] = item.Cells[1].Value.ToString();
                            }
                            else
                            {
                                Cod_Cursos[k] = item.Cells[1].Value.ToString();
                            }
                            nro_cursos_seleccionados++;
                            k++;
                        }
                    }
                    // mostrar nro de cursos seleccionados
                    txtCursosSeleccionados.Text = nro_cursos_seleccionados.ToString();

                    if (txtNombrePaquete.Text != "")
                    {
                        if (txtNroMinCursos.Text != "")
                        {
                            if (txtNroMinCursos.Text != "0")
                            {
                                if (nro_cursos_seleccionados != 0)
                                {
                                    if (nro_cursos_seleccionados == int.Parse(txtNroMinCursos.Text))
                                    {
                                        objPaquete_E.CODIGO = "";
                                        objPaquete_E.DENOMINACION = txtNombrePaquete.Text;
                                        objPaquete_E.NRO_REQUISITOS = txtNroMinCursos.Text;
                                        objPaquete_N.Agregar_Paquete(objPaquete_E, Cod_Cursos, k);

                                        MessageBox.Show("Los datos se registraron exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        Listar_Paquetes();
                                        Listar_Cursos();
                                        Limpiar();
                                    }
                                    else
                                        MessageBox.Show("Seleccione la cantidad de cursos indicada!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                else
                                    MessageBox.Show("Seleccione los cursos para el paquete!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                                MessageBox.Show("El paquete debe contener como mínimo un curso!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                            MessageBox.Show("Ingrese el número de cursos para el paquete!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                        MessageBox.Show("Ingrese nombre del paquete!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                if (Modificar)
                {
                    if(MessageBox.Show("Si acepta, el paquete actual no se modificará!", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Limpiar();
                    }
                }
            }

        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            Modificar = false;
            if (dataGridViewPaquete.SelectedRows.Count > 0)
            {                
                //habilitar boton guardarcambios
                btnGuardarCambios.Visible = true;
                Modificar = true;
                // mostrar los datos en los textbox
                txtNombrePaquete.Text = dataGridViewPaquete.CurrentRow.Cells["Denominacion"].Value.ToString();
                txtNroMinCursos.Text = dataGridViewPaquete.CurrentRow.Cells["Nro_Requisitos"].Value.ToString();
                Listar_Detalle_Paquete();
                Listar_Cursos();
            }
            else
                MessageBox.Show("Seleccione una fila de la lista de paquetes", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (Modificar == true)
            {
                try
                {
                    string[] Cod_Cursos = new string[100];
                    objPaquete_E = new EPaquete();
                    int nro_cursos_seleccionados = 0;
                    //recorrer dgvCursos y buscar las filas marcadas
                    foreach (DataGridViewRow item in dataGridViewCursos.Rows)
                    {
                        if ((bool)item.Cells[0].Value == true)
                        {
                            //extraer los codigos de cada fila
                            if (nro_cursos_seleccionados == 0)
                                Cod_Cursos[nro_cursos_seleccionados] = item.Cells[1].Value.ToString();
                            else
                                Cod_Cursos[nro_cursos_seleccionados] = item.Cells[1].Value.ToString();
                            nro_cursos_seleccionados++;
                        }
                    }
                    // cargar los codigos de los cursos registrados en un paquete sino se ha seleccionado ningun curso
                    if (nro_cursos_seleccionados == 0)
                    {
                        foreach (DataGridViewRow item in dataGridViewDetalle.Rows)
                        {
                            Cod_Cursos[nro_cursos_seleccionados] = item.Cells["Codigo_Curso"].Value.ToString();
                            nro_cursos_seleccionados++;
                        }
                    }
                    // mostrar nro de cursos seleccionados
                    txtCursosSeleccionados.Text = nro_cursos_seleccionados.ToString();

                    if (txtNombrePaquete.Text != "")
                    {
                        if (txtNroMinCursos.Text != "")
                        {
                            if (txtNroMinCursos.Text != "0")
                            {

                                if (nro_cursos_seleccionados != 0)
                                {
                                    if (nro_cursos_seleccionados == int.Parse(txtNroMinCursos.Text))
                                    {
                                        objPaquete_E.CODIGO = dataGridViewPaquete.CurrentRow.Cells["Codigo_Paquete"].Value.ToString();
                                        objPaquete_E.DENOMINACION = txtNombrePaquete.Text;
                                        objPaquete_E.NRO_REQUISITOS = txtNroMinCursos.Text;
                                        if (MessageBox.Show("¿Desea modificar el paquete actual?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                                        {
                                            objPaquete_N.Modificar_Paquete(objPaquete_E, Cod_Cursos, nro_cursos_seleccionados);
                                            MessageBox.Show("El paquete se modificó correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            Modificar = false;
                                            btnGuardarCambios.Visible = false;
                                            Limpiar();
                                        }
                                        Listar_Paquetes();
                                    }
                                    else
                                        MessageBox.Show("Seleccione la cantidad de cursos indicada!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                else
                                    MessageBox.Show("Vuelva a seleccionar los cursos para el paquete!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                                MessageBox.Show("El paquete debe contener como mínimo un curso!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                            MessageBox.Show("Ingrese el número de cursos para el paquete!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                        MessageBox.Show("Ingrese nombre del paquete!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo modificar los datos"+ex.Message, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
        }
        private void btnDetalle_Click(object sender, EventArgs e)
        {
            Limpiar();
            Listar_Detalle_Paquete();
        }
        private void cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void txtDenominacion_TextChanged(object sender, EventArgs e)
        {
            // buscar paquete por denominacion
            objPaquete_E = new EPaquete();
            if (txtDenominacion.Text != "")
            {
                objPaquete_E.DENOMINACION = txtDenominacion.Text;
                DataTable dt = new DataTable();
                dt = objPaquete_N.Buscar_Paquete(objPaquete_E);
                dataGridViewPaquete.DataSource = dt;
            }
            else
            {
                dataGridViewPaquete.DataSource = objPaquete_N.Mostrar_Paquetes();
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            objPaquete_E = new EPaquete();
            btnGuardarCambios.Visible = false;
            if (dataGridViewPaquete.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Desea eliminar el paquete?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    objPaquete_E.CODIGO = dataGridViewPaquete.CurrentRow.Cells["Codigo_Paquete"].Value.ToString();
                    objPaquete_N.Eliminar_Paquete(objPaquete_E);
                    MessageBox.Show("El paquete se ha eliminado!");
                    Limpiar();
                    Listar_Paquetes();
                    Listar_Cursos();
                }
            }
            else
                MessageBox.Show("Seleccione una fila de la lista de paquetes", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        
        // ==================================================================================================
        // ================================ VALIDACIONES DE DATOS DE ENTRADA ================================
        // ==================================================================================================
        private void txtNroMinCursos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255) || (e.KeyChar >= 160 && e.KeyChar <= 165))
            {
                MessageBox.Show("Ingrese solo Números", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        private void txtNombrePaquete_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarCampos(sender, e);
        }
        private void txtDenominacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidarCampos(sender, e);
        }
        // ==================================================================================================
        // ================================== Configuracion de Datagridview =================================
        // ==================================================================================================
        private void dataGridViewCursos_MouseClick(object sender, MouseEventArgs e)
        {
            if ((bool)dataGridViewCursos.SelectedRows[0].Cells[0].Value == false)
                dataGridViewCursos.SelectedRows[0].Cells[0].Value = true;
            else
                dataGridViewCursos.SelectedRows[0].Cells[0].Value = false;
        }
        private void dataGridViewPaquete_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        // ==================================================================================================
        // ================================== otras funciones ===============================================
        // ==================================================================================================
        public void Limpiar()
        {            
            txtDenominacion.Clear();
            txtNombrePaquete.Clear();
            txtNroMinCursos.Clear();
            txtCursosSeleccionados.Clear();
            Listar_Cursos();
            Modificar = false;
            dataGridViewDetalle.DataSource = null;            
            btnGuardarCambios.Visible = false;
        }
        public void ValidarCampos(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == 45)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        
    }
}
