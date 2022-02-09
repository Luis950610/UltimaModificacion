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
using System.Configuration;
//Espacios de Estado necesarios
using System.IO;

namespace _2021
{
    public partial class Form1Pao : Form
    {
        // Inicializar Interfaces 

        public Form1Pao()
        {
            InitializeComponent();
            ModuloGestionBoleta combo = new ModuloGestionBoleta();

            combo.Seleccionar(CBPorNombre);
            combo.SeleccionarCodigo(CBPorCodigo);
        }
        
        
        #region 
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        #endregion
        // objetos necesarios para la importacion de datos al sql
        SqlConnection cn = new SqlConnection();
        #region *************************** TABLA *******************
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            txtFecha.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtEstado.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtSerie.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtComprobante.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtIDComprobante.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtDescripcion.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtDoc.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtCodAlumno.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtApellidosNombres.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            txtMonto.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();

        }
        #endregion ***************************************************

        #region ******************** Botones *******************************

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtComprobante.Focus();
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtIDComprobante.Focus();
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtDescripcion.Focus();
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtCodAlumno.Focus();
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtApellidosNombres.Focus();
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtMonto.Focus();
            }
        }
        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtAnio.Focus();
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                
            }
        }
        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
               
            }
        }

        private void textBox11_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                
            }
        }

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
               
            }
        }
        #endregion

        #region ***************************** LISTAR **************************
        // La funcion que nos permite hacer clik para mostrar la ultima actualizacion de docentes.
        private void Listar_Click(object sender, EventArgs e)
        {
            ModuloGestionBoleta t = new ModuloGestionBoleta();
            dataGridView1.DataSource = t.ListarGestionBoletas();

            txtFecha.Text = "";
            txtEstado.Text = "";
            txtSerie.Text = "";
            txtComprobante.Text = "";
            txtIDComprobante.Text = "";
            txtDescripcion.Text = "";
            txtDoc.Text = "";
            txtCodAlumno.Text = "";
            txtApellidosNombres.Text = "";
            txtMonto.Text = null;
        }
        #endregion ************************************************************

        #region **************************** MODIFICAR *********************
        private void Editar_Click(object sender, EventArgs e)
        {

            GestionBoleta d = new GestionBoleta();

            
            d.Estado = txtEstado.Text;
            d.Serie = txtSerie.Text;
            d.Comprobante = txtComprobante.Text;
            d.IDComprobante = txtIDComprobante.Text;
            d.Descripcion = txtDescripcion.Text;
            d.Doc = txtDoc.Text;
            d.CodAlumno = txtCodAlumno.Text;
            d.ApellidosNombres = txtApellidosNombres.Text;
            d.Monto = Convert.ToInt32(txtMonto.Text);

            MessageBox.Show("¿ESTA SEGURO QUE DESEA EDITAR? ", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            int n = ModuloGestionBoleta.EditarGestionBoletas(d);
            if (n > 0)
            {
                MessageBox.Show("LOS DATOS HAN SIDO MODIFICADOS CORRECTAMENTE! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("ERROR NO SE PUDO MODIFICAR! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }


        #endregion *********************************************************
        
        #region **************************** BUSCAR ************************

        private void Buscar_Click(object sender, EventArgs e)
        {
            #region Campos Buscar ******************************
           

            
            if (datos.Text == "Descripcion")
            {

                //Creamos una memoria para guardar informacion
                //System.IO.MemoryStream ms = new System.IO.MemoryStream();
                GestionBoleta d = new GestionBoleta();
               
                d.Descripcion = txtBuscarComprobante.Text;
                if (txtBuscarComprobante.Text != "")
                {
                    try
                    {

                        DataTable n = ModuloGestionBoleta.BuscarDescripcion(d);
                        //CodigoNuevo.Text = validar.ToString();
                        dataGridView1.DataSource = n;

                        if(dataGridView1.Rows != null && dataGridView1.Rows.Count > 1)
                        {
                            txtFecha.Text = dataGridView1.CurrentRow.Cells["Fecha"].Value.ToString();
                            txtEstado.Text = dataGridView1.CurrentRow.Cells["Estado"].Value.ToString();
                            txtSerie.Text = dataGridView1.CurrentRow.Cells["Serie"].Value.ToString();
                            txtComprobante.Text = dataGridView1.CurrentRow.Cells["Comprobante"].Value.ToString();
                            txtIDComprobante.Text = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                            txtDescripcion.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                            txtDoc.Text = dataGridView1.CurrentRow.Cells["Doc"].Value.ToString();
                            txtCodAlumno.Text = dataGridView1.CurrentRow.Cells["CodAlumno"].Value.ToString();
                            txtApellidosNombres.Text = dataGridView1.CurrentRow.Cells["ApellidosNombres"].Value.ToString();
                            txtMonto.Text = dataGridView1.CurrentRow.Cells["Monto"].Value.ToString();


                            MessageBox.Show("DESCRIPCION ENCONTRADO! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("DESCRIPCION NO ENCONTRADO! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }


                    }
                    catch (Exception)
                    {
                        MessageBox.Show("ERROR DE BUSQUEDA DE DESCRIPCION", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                }
                else
                {
                    MessageBox.Show("DESCRIPCION EN BLANCO! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            else if (datos.Text == "Id Comprobante")

            {

                //Creamos una memoria para guardar informacion
                //System.IO.MemoryStream ms = new System.IO.MemoryStream();
                GestionBoleta d = new GestionBoleta();

                d.IDComprobante = txtBuscarComprobante.Text;
                if (txtBuscarComprobante.Text != "")
                {
                    try
                    {

                        DataTable n = ModuloGestionBoleta.BuscarIDComprobante(d);
                        //CodigoNuevo.Text = validar.ToString();
                        dataGridView1.DataSource = n;
                        if(dataGridView1.Rows != null && dataGridView1.Rows.Count > 1)
                        {
                            txtFecha.Text = dataGridView1.CurrentRow.Cells["Fecha"].Value.ToString();
                            txtEstado.Text = dataGridView1.CurrentRow.Cells["Estado"].Value.ToString();
                            txtSerie.Text = dataGridView1.CurrentRow.Cells["Serie"].Value.ToString();
                            txtComprobante.Text = dataGridView1.CurrentRow.Cells["Comprobante"].Value.ToString();
                            txtIDComprobante.Text = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                            txtDescripcion.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                            txtDoc.Text = dataGridView1.CurrentRow.Cells["Doc"].Value.ToString();
                            txtCodAlumno.Text = dataGridView1.CurrentRow.Cells["CodAlumno"].Value.ToString();
                            txtApellidosNombres.Text = dataGridView1.CurrentRow.Cells["ApellidosNombres"].Value.ToString();
                            txtMonto.Text = dataGridView1.CurrentRow.Cells["Monto"].Value.ToString();


                            MessageBox.Show("ID COMPROBANTE ENCONTRADO! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }

                        else
                        {
                            MessageBox.Show("ID COMPROBANTE NO ENCONTRADO! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("ERROR DE BUSQUEDA DE ID COMPROBANTE", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                }
                else
                {
                    MessageBox.Show("ID COMPROBANTE EN BLANCO! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            else if (datos.Text == "Estado")

            {

                //Creamos una memoria para guardar informacion
                //System.IO.MemoryStream ms = new System.IO.MemoryStream();
                GestionBoleta d = new GestionBoleta();

                d.Estado = txtBuscarComprobante.Text;
                if (txtBuscarComprobante.Text != "")
                {
                    try
                    {

                        DataTable n = ModuloGestionBoleta.BuscarEstado(d);
                        //CodigoNuevo.Text = validar.ToString();
                        dataGridView1.DataSource = n;

                        if(dataGridView1.Rows != null && dataGridView1.Rows.Count > 1)
                        {
                            txtFecha.Text = dataGridView1.CurrentRow.Cells["Fecha"].Value.ToString();
                            txtEstado.Text = dataGridView1.CurrentRow.Cells["Estado"].Value.ToString();
                            txtSerie.Text = dataGridView1.CurrentRow.Cells["Serie"].Value.ToString();
                            txtComprobante.Text = dataGridView1.CurrentRow.Cells["Comprobante"].Value.ToString();
                            txtIDComprobante.Text = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                            txtDescripcion.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                            txtDoc.Text = dataGridView1.CurrentRow.Cells["Doc"].Value.ToString();
                            txtCodAlumno.Text = dataGridView1.CurrentRow.Cells["CodAlumno"].Value.ToString();
                            txtApellidosNombres.Text = dataGridView1.CurrentRow.Cells["ApellidosNombres"].Value.ToString();
                            txtMonto.Text = dataGridView1.CurrentRow.Cells["Monto"].Value.ToString();


                            MessageBox.Show("ESTADO ENCONTRADO! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("ESTADO NO ENCONTRADO! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }


                    }
                    catch (Exception)
                    {
                        MessageBox.Show("ERROR DE BUSQUEDA DE ESTADO", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                }
                else
                {
                    MessageBox.Show("ESTADO EN BLANCO! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            else if (datos.Text == "Nro Serie")

            {

                //Creamos una memoria para guardar informacion
                //System.IO.MemoryStream ms = new System.IO.MemoryStream();
                GestionBoleta d = new GestionBoleta();

                d.Serie = txtBuscarComprobante.Text;
                if (txtBuscarComprobante.Text != "")
                {
                    try
                    {

                        DataTable n = ModuloGestionBoleta.BuscarSerie(d);
                        //CodigoNuevo.Text = validar.ToString();
                        dataGridView1.DataSource = n;

                        if(dataGridView1.Rows != null && dataGridView1.Rows.Count > 1)
                        {
                            txtFecha.Text = dataGridView1.CurrentRow.Cells["Fecha"].Value.ToString();
                            txtEstado.Text = dataGridView1.CurrentRow.Cells["Estado"].Value.ToString();
                            txtSerie.Text = dataGridView1.CurrentRow.Cells["Serie"].Value.ToString();
                            txtComprobante.Text = dataGridView1.CurrentRow.Cells["Comprobante"].Value.ToString();
                            txtIDComprobante.Text = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                            txtDescripcion.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                            txtDoc.Text = dataGridView1.CurrentRow.Cells["Doc"].Value.ToString();
                            txtCodAlumno.Text = dataGridView1.CurrentRow.Cells["CodAlumno"].Value.ToString();
                            txtApellidosNombres.Text = dataGridView1.CurrentRow.Cells["ApellidosNombres"].Value.ToString();
                            txtMonto.Text = dataGridView1.CurrentRow.Cells["Monto"].Value.ToString();


                            MessageBox.Show("NRO SERIE ENCONTRADO! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("NRO SERIE NO ENCONTRADO! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("ERROR DE BUSQUEDA DE NRO SERIE", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                }
                else
                {
                    MessageBox.Show("NRO SERI EN BLANCO! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            else if (datos.Text == "Nro Comprobante")

            {

                //Creamos una memoria para guardar informacion
                //System.IO.MemoryStream ms = new System.IO.MemoryStream();
                GestionBoleta d = new GestionBoleta();

                d.Comprobante = txtBuscarComprobante.Text;
                if (txtBuscarComprobante.Text != "")
                {
                    try
                    {

                        DataTable n = ModuloGestionBoleta.BuscarComprobante(d);
                        //CodigoNuevo.Text = validar.ToString();
                        dataGridView1.DataSource = n;

                        if(dataGridView1.Rows != null && dataGridView1.Rows.Count > 1)
                        {
                            txtFecha.Text = dataGridView1.CurrentRow.Cells["Fecha"].Value.ToString();
                            txtEstado.Text = dataGridView1.CurrentRow.Cells["Estado"].Value.ToString();
                            txtSerie.Text = dataGridView1.CurrentRow.Cells["Serie"].Value.ToString();
                            txtComprobante.Text = dataGridView1.CurrentRow.Cells["Comprobante"].Value.ToString();
                            txtIDComprobante.Text = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                            txtDescripcion.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                            txtDoc.Text = dataGridView1.CurrentRow.Cells["Doc"].Value.ToString();
                            txtCodAlumno.Text = dataGridView1.CurrentRow.Cells["CodAlumno"].Value.ToString();
                            txtApellidosNombres.Text = dataGridView1.CurrentRow.Cells["ApellidosNombres"].Value.ToString();
                            txtMonto.Text = dataGridView1.CurrentRow.Cells["Monto"].Value.ToString();


                            MessageBox.Show(" NRO COMPROBANTE ENCONTRADO! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show(" NRO COMPROBANTE NO ENCONTRADO! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("ERROR DE BUSQUEDA DE NRO COMPROBANTE", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                }
                else
                {
                    MessageBox.Show("NRO COMPROBANTE EN BLANCO! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            else if (datos.Text == "TipoDoc")

            {

                //Creamos una memoria para guardar informacion
                //System.IO.MemoryStream ms = new System.IO.MemoryStream();
                GestionBoleta d = new GestionBoleta();

                d.Doc = txtBuscarComprobante.Text;
                if (txtBuscarComprobante.Text != "")
                {
                    try
                    {

                        DataTable n = ModuloGestionBoleta.BuscarDoc(d);
                        //CodigoNuevo.Text = validar.ToString();
                        dataGridView1.DataSource = n;

                        if(dataGridView1.Rows != null && dataGridView1.Rows.Count > 1)
                        {
                            txtFecha.Text = dataGridView1.CurrentRow.Cells["Fecha"].Value.ToString();
                            txtEstado.Text = dataGridView1.CurrentRow.Cells["Estado"].Value.ToString();
                            txtSerie.Text = dataGridView1.CurrentRow.Cells["Serie"].Value.ToString();
                            txtComprobante.Text = dataGridView1.CurrentRow.Cells["Comprobante"].Value.ToString();
                            txtIDComprobante.Text = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                            txtDescripcion.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                            txtDoc.Text = dataGridView1.CurrentRow.Cells["Doc"].Value.ToString();
                            txtCodAlumno.Text = dataGridView1.CurrentRow.Cells["CodAlumno"].Value.ToString();
                            txtApellidosNombres.Text = dataGridView1.CurrentRow.Cells["ApellidosNombres"].Value.ToString();
                            txtMonto.Text = dataGridView1.CurrentRow.Cells["Monto"].Value.ToString();


                            MessageBox.Show("TIPO DOC ENCONTRADO! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }

                        else
                        {

                            MessageBox.Show("TIPO DOC NO ENCONTRADO! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("ERROR DE BUSQUEDA DE TIPO DOC", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                }
                else
                {
                    MessageBox.Show("TIPO DOC EN BLANCO! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            else if (datos.Text == "CodAlumno")

            {

                //Creamos una memoria para guardar informacion
                //System.IO.MemoryStream ms = new System.IO.MemoryStream();
                GestionBoleta d = new GestionBoleta();

                d.CodAlumno = txtBuscarComprobante.Text;
                if (txtBuscarComprobante.Text != "")
                {
                    try
                    {

                        DataTable n = ModuloGestionBoleta.BuscarCodAlumno(d);
                        //CodigoNuevo.Text = validar.ToString();
                        dataGridView1.DataSource = n;

                        if(dataGridView1.Rows != null && dataGridView1.Rows.Count > 1)
                        {
                            txtFecha.Text = dataGridView1.CurrentRow.Cells["Fecha"].Value.ToString();
                            txtEstado.Text = dataGridView1.CurrentRow.Cells["Estado"].Value.ToString();
                            txtSerie.Text = dataGridView1.CurrentRow.Cells["Serie"].Value.ToString();
                            txtComprobante.Text = dataGridView1.CurrentRow.Cells["Comprobante"].Value.ToString();
                            txtIDComprobante.Text = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                            txtDescripcion.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                            txtDoc.Text = dataGridView1.CurrentRow.Cells["Doc"].Value.ToString();
                            txtCodAlumno.Text = dataGridView1.CurrentRow.Cells["CodAlumno"].Value.ToString();
                            txtApellidosNombres.Text = dataGridView1.CurrentRow.Cells["ApellidosNombres"].Value.ToString();
                            txtMonto.Text = dataGridView1.CurrentRow.Cells["Monto"].Value.ToString();


                            MessageBox.Show("CODIGO ALUMNO ENCONTRADO! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {

                            MessageBox.Show("CODIGO ALUMNO NO ENCONTRADO! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }


                    }
                    catch (Exception)
                    {
                        MessageBox.Show("ERROR DE BUSQUEDA DE CODIGO ALUMNO", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                }
                else
                {
                    MessageBox.Show("CODIGO ALUMNO EN BLANCO! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            else if (datos.Text == "ApellidosNombres")

            {

                //Creamos una memoria para guardar informacion
                //System.IO.MemoryStream ms = new System.IO.MemoryStream();
                GestionBoleta d = new GestionBoleta();

                d.ApellidosNombres = txtBuscarComprobante.Text;
                if (txtBuscarComprobante.Text != "")
                {
                    try
                    {

                        DataTable n = ModuloGestionBoleta.BuscarApellidosNombres(d);
                        //CodigoNuevo.Text = validar.ToString();
                        dataGridView1.DataSource = n;

                        if(dataGridView1.Rows != null && dataGridView1.Rows.Count > 1)
                        {
                            txtFecha.Text = dataGridView1.CurrentRow.Cells["Fecha"].Value.ToString();
                            txtEstado.Text = dataGridView1.CurrentRow.Cells["Estado"].Value.ToString();
                            txtSerie.Text = dataGridView1.CurrentRow.Cells["Serie"].Value.ToString();
                            txtComprobante.Text = dataGridView1.CurrentRow.Cells["Comprobante"].Value.ToString();
                            txtIDComprobante.Text = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                            txtDescripcion.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                            txtDoc.Text = dataGridView1.CurrentRow.Cells["Doc"].Value.ToString();
                            txtCodAlumno.Text = dataGridView1.CurrentRow.Cells["CodAlumno"].Value.ToString();
                            txtApellidosNombres.Text = dataGridView1.CurrentRow.Cells["ApellidosNombres"].Value.ToString();
                            txtMonto.Text = dataGridView1.CurrentRow.Cells["Monto"].Value.ToString();


                            MessageBox.Show("NOMBRES ENCONTRADO! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("NOMBRES NO ENCONTRADO! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }


                    }
                    catch (Exception)
                    {
                        MessageBox.Show("ERROR DE BUSQUEDA DE NOMBRES", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                }
                else
                {
                    MessageBox.Show("NOMBRES EN BLANCO! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }

            #endregion 

            else if (txtAnio.Text != "")

            {

                //Creamos una memoria para guardar informacion
                //System.IO.MemoryStream ms = new System.IO.MemoryStream();
                GestionBoleta d = new GestionBoleta();
                DateTime f = d.Fecha;
                string date_str = f.ToString();
                if (txtAnio.Text != "")
                {
                    try
                    {

                        DataTable n = ModuloGestionBoleta.BuscarIDComprobante(d);
                        //CodigoNuevo.Text = validar.ToString();
                        dataGridView1.DataSource = n;

                        txtFecha.Text = dataGridView1.CurrentRow.Cells["Fecha"].Value.ToString();
                        txtEstado.Text = dataGridView1.CurrentRow.Cells["Estado"].Value.ToString();
                        txtSerie.Text = dataGridView1.CurrentRow.Cells["Serie"].Value.ToString();
                        txtComprobante.Text = dataGridView1.CurrentRow.Cells["Comprobante"].Value.ToString();
                        txtIDComprobante.Text = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                        txtDescripcion.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                        txtDoc.Text = dataGridView1.CurrentRow.Cells["Doc"].Value.ToString();
                        txtCodAlumno.Text = dataGridView1.CurrentRow.Cells["CodAlumno"].Value.ToString();
                        txtApellidosNombres.Text = dataGridView1.CurrentRow.Cells["ApellidosNombres"].Value.ToString();
                        txtMonto.Text = dataGridView1.CurrentRow.Cells["Monto"].Value.ToString();


                        MessageBox.Show("AÑO ENCONTRADO! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                    catch (Exception)
                    {
                        MessageBox.Show("ERROR DE BUSQUEDA DE AÑO", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                }
                else
                {
                    MessageBox.Show("AÑO EN BLANCO! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            if (txtPeriodo.Text != "")
            {
                //Creamos una memoria para guardar informacion
                //System.IO.MemoryStream ms = new System.IO.MemoryStream();
                CFecha1 d = new CFecha1();
                d.Mes = Convert.ToInt32(txtPeriodo.Text);
                //txtAnio.Text = d.Año.ToString()+"S";

                DataTable n = ModuloGestionBoleta.BuscarFechaPeriodo(d);
                //CodigoNuevo.Text = validar.ToString();
                dataGridView1.DataSource = n;

                if (dataGridView1.Rows != null && dataGridView1.Rows.Count > 1)
                {
                    MessageBox.Show("CODIGO ENCONTRADO! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtFecha.Text = dataGridView1.CurrentRow.Cells["Fecha"].Value.ToString();
                    txtEstado.Text = dataGridView1.CurrentRow.Cells["Estado"].Value.ToString();
                    txtSerie.Text = dataGridView1.CurrentRow.Cells["Serie"].Value.ToString();
                    txtComprobante.Text = dataGridView1.CurrentRow.Cells["Comprobante"].Value.ToString();
                    txtIDComprobante.Text = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                    txtDescripcion.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                    txtDoc.Text = dataGridView1.CurrentRow.Cells["Doc"].Value.ToString();
                    txtCodAlumno.Text = dataGridView1.CurrentRow.Cells["CodAlumno"].Value.ToString();
                    txtApellidosNombres.Text = dataGridView1.CurrentRow.Cells["ApellidosNombres"].Value.ToString();
                    txtMonto.Text = dataGridView1.CurrentRow.Cells["Monto"].Value.ToString();
                    MessageBox.Show("MES ENCONTRADO", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {

                    MessageBox.Show("MES VACIA", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        
            //Limpiar_Datos(groupBox2);
        }
        

        


        #endregion *********************************************************

        #region ********************************** OTROS *************************************
        public void Limpiar_Datos(GroupBox gb)
        {
            foreach (var combo in gb.Controls) {
                if (combo is TextBox) {
                    ((TextBox)combo).Clear();
                }
                else if (combo is ComboBox)
                {
                    ((ComboBox)combo).SelectedIndex = 0;
                }


            }
        }

        #endregion ***************************************************************************

        #region *****************************  GUARDAR  *******************************
        

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btTransferirBoleta_Click(object sender, EventArgs e)
        {            
            if(CBPorCodigo.SelectedIndex == 0)
            {
                MessageBox.Show("Codigo no debe estar vacio");
                return;
            }

            if (CBPorNombre.SelectedIndex == 0)
            {
                MessageBox.Show("Nombre no debe estar vacio");
                return;
            }

            if(dataGridView1.Rows != null && dataGridView1.Rows.Count > 0 && dataGridView1.SelectedRows.Count == 1 )
            {
                //string Id = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                int Id = dataGridView1.CurrentRow.Index ;
                string Codigo = CBPorCodigo.Text.ToString();
                string Nombres = CBPorNombre.Text.ToString();

                ModuloGestionBoleta mgb = new ModuloGestionBoleta();
                mgb.TransferirBoleta(Id+1, Codigo, Nombres);

                MessageBox.Show("Transferencia exitosa!");
            }

        }
        
        private void CBPorNombre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(CBPorNombre.SelectedIndex == 0)
            {
                if (CBPorCodigo.SelectedIndex != 0 && CBPorCodigo.Items.Count > 0)
                    CBPorCodigo.ResetText();
            }
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells["ApellidosNombres"].Value.ToString() == CBPorNombre.Text)
                    {
                        CBPorCodigo.SelectedItem = dataGridView1.Rows[i].Cells["CodAlumno"].Value.ToString();
                        break;
                    }
                }

            }
        }
        //*****************************************************************************
       

        private void txtBuscarDescripcion_TextChanged(object sender, EventArgs e)
        {

        }
        // Campos
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                        
        }

        private void txtAnio_KeyUp(object sender, KeyEventArgs e)
        {
            /*
            // buscsar----------------------------
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "select * from TGestionBoletas where Descripcion like ('" + Campos.Text + "%') or CodAlumno == ('" + Campos.Text + "%') or Id like ('" + Campos.Text + "%') or Estado like ('" + Campos.Text + "%') " +
            //    "or serie like ('" + Campos.Text + "%') or Comprobante like ('" + Campos.Text + "%')or Doc like ('" + Campos.Text + "%') or ApellidosNombres like ('" + Campos.Text + "%') or Monto like ('" + Campos.Text + "%')";
            cmd.CommandText = "select * from TGestionBoletas where Year(Fecha) like ('" + txtAnio.Text + "%') ";


            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            txtFecha.Text = dataGridView1.CurrentRow.Cells["Fecha"].Value.ToString();
            txtEstado.Text = dataGridView1.CurrentRow.Cells["Estado"].Value.ToString();
            txtSerie.Text = dataGridView1.CurrentRow.Cells["Serie"].Value.ToString();
            txtComprobante.Text = dataGridView1.CurrentRow.Cells["Comprobante"].Value.ToString();
            txtIDComprobante.Text = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
            txtDescripcion.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
            txtDoc.Text = dataGridView1.CurrentRow.Cells["Doc"].Value.ToString();
            txtCodAlumno.Text = dataGridView1.CurrentRow.Cells["CodAlumno"].Value.ToString();
            txtApellidosNombres.Text = dataGridView1.CurrentRow.Cells["ApellidosNombres"].Value.ToString();
            txtMonto.Text = dataGridView1.CurrentRow.Cells["Monto"].Value.ToString();
            cn.Close();

            */

        }

        private void txtAnio_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (txtAnio.Text != "")
            {
                //Creamos una memoria para guardar informacion
                //System.IO.MemoryStream ms = new System.IO.MemoryStream();
                CFecha1 d = new CFecha1();
                d.Año = Convert.ToInt32(txtAnio.Text);
                //txtAnio.Text = d.Año.ToString()+"S";

                DataTable n = ModuloGestionBoleta.BuscarFechaAño(d);
                //CodigoNuevo.Text = validar.ToString();
                dataGridView1.DataSource = n;

                if (dataGridView1.Rows != null && dataGridView1.Rows.Count > 1)
                {
                    MessageBox.Show("AÑO ENCONTRADO! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtFecha.Text = dataGridView1.CurrentRow.Cells["Fecha"].Value.ToString();
                    txtEstado.Text = dataGridView1.CurrentRow.Cells["Estado"].Value.ToString();
                    txtSerie.Text = dataGridView1.CurrentRow.Cells["Serie"].Value.ToString();
                    txtComprobante.Text = dataGridView1.CurrentRow.Cells["Comprobante"].Value.ToString();
                    txtIDComprobante.Text = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                    txtDescripcion.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                    txtDoc.Text = dataGridView1.CurrentRow.Cells["Doc"].Value.ToString();
                    txtCodAlumno.Text = dataGridView1.CurrentRow.Cells["CodAlumno"].Value.ToString();
                    txtApellidosNombres.Text = dataGridView1.CurrentRow.Cells["ApellidosNombres"].Value.ToString();
                    txtMonto.Text = dataGridView1.CurrentRow.Cells["Monto"].Value.ToString();


                }
                else
                {
                   
                    MessageBox.Show("AÑO VACIA", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }


            
        }

        private void txtPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtPeriodo.Text != "")
            {
                //Creamos una memoria para guardar informacion
                //System.IO.MemoryStream ms = new System.IO.MemoryStream();
                CFecha1 d = new CFecha1();
                d.Mes = Convert.ToInt32(txtPeriodo.Text);
                //txtAnio.Text = d.Año.ToString()+"S";

                DataTable n = ModuloGestionBoleta.BuscarFechaPeriodo(d);
                //CodigoNuevo.Text = validar.ToString();
                dataGridView1.DataSource = n;

                if (dataGridView1.Rows != null && dataGridView1.Rows.Count > 1)
                {
                    MessageBox.Show("MES ENCONTRADO! ", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtFecha.Text = dataGridView1.CurrentRow.Cells["Fecha"].Value.ToString();
                    txtEstado.Text = dataGridView1.CurrentRow.Cells["Estado"].Value.ToString();
                    txtSerie.Text = dataGridView1.CurrentRow.Cells["Serie"].Value.ToString();
                    txtComprobante.Text = dataGridView1.CurrentRow.Cells["Comprobante"].Value.ToString();
                    txtIDComprobante.Text = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                    txtDescripcion.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                    txtDoc.Text = dataGridView1.CurrentRow.Cells["Doc"].Value.ToString();
                    txtCodAlumno.Text = dataGridView1.CurrentRow.Cells["CodAlumno"].Value.ToString();
                    txtApellidosNombres.Text = dataGridView1.CurrentRow.Cells["ApellidosNombres"].Value.ToString();
                    txtMonto.Text = dataGridView1.CurrentRow.Cells["Monto"].Value.ToString();

                }
                else
                {

                    MessageBox.Show("MES VACIA", "BASE DE DATOS DEL CCI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void CBPorCodigo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(CBPorCodigo.SelectedIndex == 0)
            {
                //CBPorNombre.SelectedIndex = 0;
                if (CBPorNombre.SelectedIndex != 0 && CBPorNombre.Items.Count > 0)
                    //CBPorNombre.ResetText();
                    CBPorNombre.SelectedIndex = 0;
            }
            else
            {
                for(int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if(dataGridView1.Rows[i].Cells["CodAlumno"].Value.ToString() == CBPorCodigo.Text)
                    {
                        CBPorNombre.SelectedItem = dataGridView1.Rows[i].Cells["ApellidosNombres"].Value.ToString();
                        break;
                    }
                }
                
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        #endregion

        //*****************************************************************************

    }
}
