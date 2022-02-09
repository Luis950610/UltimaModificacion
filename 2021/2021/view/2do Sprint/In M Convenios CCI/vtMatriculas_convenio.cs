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
    public partial class vtMatriculas_convenio : Form
    {
        N_Matricula objetoCN_Matricula = new N_Matricula();
        N_Estudiante N_Estudiante = new N_Estudiante();
        E_Estudiante E_Estudiante = new E_Estudiante();
        E_Matricula E_Matricula = new E_Matricula();
        N_Boleta N_Boleta = new N_Boleta();
        E_Boleta E_Boleta = new E_Boleta();
        N_CursoActivo N_CursoAct = new N_CursoActivo();
        E_CursoActivo E_CursoAct = new E_CursoActivo();
        public vtMatriculas_convenio()
        {
            InitializeComponent();
        }
        //MODULO PARA ASIGNAR DATOS DE LOS TEXBOTONES A LA CAPA ENTIDADES
        void Mantenimiento_Matricula_Convenio(String accion)
        {
            E_Estudiante.Codigo = textCodigo.Text;
            E_Estudiante.Nombre = textNombre.Text;
            E_Estudiante.AppPaterno = textApPa.Text;
            E_Estudiante.AppMaterno = textApMa.Text;
            E_Estudiante.DNI = textDNI.Text;
            E_Estudiante.Email = textEmail.Text;
            E_Estudiante.accion = accion;
            E_Boleta.Codigo = textNroBoleta.Text;
            E_Boleta.FechaEmision = Convert.ToString(datetimeFechaEmision.Text);
            E_Boleta.NroSerie = textNroSerie.Text;
            E_Boleta.Codigo_CursoActivo = cnbCurso.Text.ToString();
            E_Boleta.TipoDscto = "DCTO1";
            E_Boleta.Costo = float.Parse(textCosto.Text);
            E_Boleta.Pago = float.Parse(textPago.Text);
            E_Boleta.Observacion = textObs.Text;
            E_Boleta.accion = accion;
            E_Boleta.CodEstudiante = textCodigo.Text;
            // Mensaje a mostrar para la confirmacion si los datos de estudiante fueron guardados
            String men = N_Estudiante.N_Manteniemiento_EstudianteMatriculado(E_Estudiante);
            MessageBox.Show(men, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Mensaje a mostrar para la confirmacion si los datos de boleta estudiante fueron guardados
            String men1 = N_Boleta.N_Mantenimiento_BoletadeMatricula(E_Boleta);
            MessageBox.Show(men, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // MODULO PARA LIMPIAR TODOS TEXBOTON 
        void Limpiar_Datos()
        {
            textCodigo.Text = "";
            textNombre.Text = "";
            textApMa.Text = "";
            textDNI.Text = "";
            textApPa.Text = "";
            textEmail.Text = "";
            textBuscar.Text = "";
            datetimeFechaEmision.Text = "";
            cnbCurso.Text = "";
            textNroSerie.Text = "";
            textNroBoleta.Text = "";
            textCosto.Text = "";
            textPago.Text = "";
            textObs.Text = "";
            //Mostrar los datos de estudiantes matriculados en el dataGridView1
            dataGridView1.DataSource = objetoCN_Matricula.N_Detalle_MatriculadoCurso();
        }
         //MODULO PARA ASIGNAR DATOS DE LOS TEXBOTONES A LA CAPA ENTIDADES MATRICULA
        void InsertarDatosMatricula(String accion)
        {
            E_Matricula.CodMatricula = textNroBoleta.Text;
            E_Matricula.Anio = "2022";
            E_Matricula.Mes = "ENERO";
            E_Matricula.Tipo_Matricula = "CONVENIO";
            E_Matricula.Cod_CurActivo = cnbCurso.Text;
            E_Matricula.CodBoleta = textNroBoleta.Text;
            E_Matricula.accion = accion;
            // Mensaje a mostrar para la confirmacion si los datos de matricula fueron guardados
            String men3 = objetoCN_Matricula.N_InseratarDatosMatricula(E_Matricula);
            MessageBox.Show(men3, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

   

        }
        //MODULO PARA EL AUTORRELLENADO DEL DATAGRIDVIEW2 A LOS TEXBOTONS
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridView2.CurrentCell.RowIndex;
            textCodigo.Text = dataGridView2[0, fila].Value.ToString();
            textNombre.Text = dataGridView2[1, fila].Value.ToString();
            textApMa.Text = dataGridView2[3, fila].Value.ToString();
            textApPa.Text = dataGridView2[2, fila].Value.ToString();
            textDNI.Text = dataGridView2[4, fila].Value.ToString();
            textEmail.Text = dataGridView2[5, fila].Value.ToString();
            textNroBoleta.Text = dataGridView2[6, fila].Value.ToString();
            textNroSerie.Text = dataGridView2[7, fila].Value.ToString();
            textCosto.Text = dataGridView2[9, fila].Value.ToString();
            textPago.Text = dataGridView2[10, fila].Value.ToString();
            textObs.Text = dataGridView2[11, fila].Value.ToString();
        }

        private void cnbCurso_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        // MODULO PARA MOSTRAR LAS TABLAS CON DATOS AL MOMENTO DE EJECUCION
        private void vtMatriculas_convenio_Load_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = objetoCN_Matricula.N_Detalle_MatriculadoCurso();
            dataGridView2.DataSource = objetoCN_Matricula.N_Detalle_Matricula_Estudiante_Pago();
            cnbCurso.DataSource = N_CursoAct.N_Mostrar_CursoActivo();
            cnbCurso.DisplayMember = "Codigo";
            cnbCurso.ValueMember = "Codigo";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        // MODULO PARA BOTON GUARDAR ,LA INFORMACION DE ESTUDIANTE Y MATRICULA 
        private void button1_Click(object sender, EventArgs e)
        {
            if (textCodigo.Text != "" && textNroBoleta.Text != "" && textApMa.Text != "" && textApPa.Text != "" && textDNI.Text != "" && textEmail.Text != "" && textNombre.Text != "" && textNroSerie.Text != "" && textPago.Text != "" && textObs.Text != "")
            {
                if (MessageBox.Show("¿Deseas modificar a " + textNombre.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    Mantenimiento_Matricula_Convenio("1");
                    InsertarDatosMatricula("1");
                    Limpiar_Datos();
                    
                }
            }
            else { MessageBox.Show("Algunos Campos no se ingresaron", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }
        // MODULO PARA EL BOTON NUEVO LIMPIAR LOS TEXBOTONS
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar_Datos();
        }

        // MODULO PARA BOTON MODIFICAR ,LA INFORMACION DE ESTUDIANTE Y BOLETA 
        private void button3_Click(object sender, EventArgs e)
        {
            if (textCodigo.Text != "" && textNroBoleta.Text != "" && textApMa.Text != "" && textApPa.Text != "" && textDNI.Text != "" && textEmail.Text != "" && textNombre.Text != "" && textNroSerie.Text != "" && textPago.Text != "" && textObs.Text != "")
            {
                if (MessageBox.Show("¿Deseas modificar a " + textNombre.Text + "?", "Mensaje",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    Mantenimiento_Matricula_Convenio("2");
                    Limpiar_Datos();
                }
            }
            else { MessageBox.Show("Algunos Campos no se ingresaron", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
        }
        // MODULO PARA VALIDAR EL TEXBOTON DE CODIGO 
        private void textCodigo_TextChanged(object sender, EventArgs e)
        {
            int DNI = Convert.ToInt32(textCodigo.TextLength);
            // EL CODIGO SOLO TIENE 6 DIGITOS
            if (DNI > 5)
            {
                MessageBox.Show("El codigo tiene 6 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
        }

        private void textNombre_TextChanged(object sender, EventArgs e)
        {

        }
        // MODULO PARA VALIDAR EL TEXBOTON DE DNI
        private void textDNI_TextChanged(object sender, EventArgs e)
        {
            int DNI = Convert.ToInt32(textDNI.TextLength);
            // EL CODIGO SOLO TIENE 8 DIGITOS
            if (DNI > 7)
            {
                MessageBox.Show("DNI tiene 8 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
        }
        // MODULO PARA VALIDAR EL TEXBOTON DE BUSCAR
        private void textBuscar_TextChanged(object sender, EventArgs e)
        {
            int DNI = Convert.ToInt32(textCodigo.TextLength);
            // EL CODIGO SOLO TIENE 6 DIGITOS
            if (DNI > 5)
            {
                MessageBox.Show("El codigo tiene 6 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
        }
        // MODULO PARA BUSCAR A ALUMNO POR CODIGO
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (textBuscar.Text != "")
            {
                E_Estudiante.Codigo = textBuscar.Text;
                DataTable DT = new DataTable();
                //LLAMAMOS AL PROCEDIMIENTO DE BUSCAR ALMUNOS
                DT = N_Estudiante.N_Buscar_EstudianteMatriculado(E_Estudiante);
                // SI EXISTE
                if (DT.Rows.Count > 0)
                {
                    // MOSTRAMOS DATOS DEL ALUMNO ENCONTRADO
                    dataGridView2.DataSource = DT;
                    int fila = dataGridView1.CurrentCell.RowIndex;
                }
                //NO
                else
                {
                    MessageBox.Show("No se registro estudiante " + textBuscar.Text);
                }
            }
            // MOSTRAMOS LOS DATOS DE TODOS LOS ALUMNOS EN GENERAL
            else
            {
                dataGridView2.DataSource = objetoCN_Matricula.N_Detalle_Matricula_Estudiante_Pago();
            }
        }
        //MODULO PATA VALIDAR EL TEXBOTON DE NROSERIE
        private void textNroSerie_TextChanged(object sender, EventArgs e)
        {
            int DNI = Convert.ToInt32(textNroSerie.TextLength);
            if (DNI > 3)
            {
                MessageBox.Show("El numero de serie tiene 4 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
        }
        //MODULO PATA VALIDAR EL TEXBOTON DE NRO DE BOLETA
        private void textNroBoleta_TextChanged(object sender, EventArgs e)
        {
            int DNI = Convert.ToInt32(textNroBoleta.TextLength);
            if (DNI > 3)
            {
                MessageBox.Show("El numero de boleta tiene 4 caracteres", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }
        }
        // MODULO PARA VALIDAR DATOS INGRESADOS EN TEXBOTON DNI 
        private void textDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            // DNI SOLO SON NUMEROS 
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo numeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        // MODULO PARA VALIDAR DATOS INGRESADOS EN TEXBOTON CODIGO
        private void textCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // CODIGO DE ESTUDIANTE  SOLO SON NUMEROS
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo numeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        // MODULO PARA TEXBOTON CODIGO ENTER VERIFICAR SI YA EXISTE CODIGO INGRESADO
        private void textCodigo_Enter(object sender, EventArgs e)
        {
            if (textCodigo.Text != "")
            {
                E_Estudiante.Codigo = textCodigo.Text;
                DataTable DT = new DataTable();
                // BUSCAMOS EL CODIGO INGRESADO
                DT = N_Estudiante.N_Buscar_EstudianteMatriculado(E_Estudiante);
                if (DT.Rows.Count > 0)
                {
                    // MOSTRAMOS MENSAJE
                    MessageBox.Show("El codigo ya fue registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                // MOSTRAMOS LOS DATOS DE TODOS LOS ALUMNOS EN GENERAL
                else
                {
                    dataGridView2.DataSource = objetoCN_Matricula.N_Detalle_Matricula_Estudiante_Pago();
                }
            }
        }
        // MODULO PARA MOSTRAR LOS ALUMNOS DE UN DETERMINADO CURSO
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int n = e.RowIndex;
            if (n != -1)
            {
                E_CursoAct.CodCurso = (String)dataGridView1.Rows[n].Cells[0].Value;
                dataGridView2.DataSource=N_CursoAct.N_Detalle_Alumnos_Matriculados(E_CursoAct);

            }

        }
    }
}
